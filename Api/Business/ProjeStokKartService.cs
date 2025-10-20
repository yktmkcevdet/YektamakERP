using Api.DatabaseJobs;
using Api.Interfaces;
using Dapper;
using Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace Api.Business
{
    public class ProjeStokKartService: IProjeStokKartService
    {
        private readonly ILogger<ProjeStokKartService> _logger;
        public ProjeStokKartService(IConfiguration configuration, ILogger<ProjeStokKartService> logger)
        {
        }

        public async Task<string> SaveProjeStokKartAsync(ProjeStokKart model)
        {
            using var conn = DataBaseJobsGeneral.MySqlConnectionYerel();
            //await conn.OpenAsync();

            using var tran = await conn.BeginTransactionAsync();

            try
            {
                // 1. Boyut işlemleri
                int? boyutId = GetOrInsertBoyutAsync(conn, tran, model.stokKart.boyut);

                // 2. Stok kart işlemleri
                int stokKartId = GetOrInsertOrUpdateStokKartAsync(conn, tran, model, boyutId);

                // 3. Dosya işlemleri
                await SaveDosyalarAsync(conn, tran, stokKartId, model.stokKart.dosyaList);

                // 4. Proje stok kart işlemleri
                await SaveProjeStokKartRelationAsync(conn, tran, stokKartId, model);

                // Commit
                await tran.CommitAsync();
                return JsonConvert.SerializeObject(model);
            }
            catch (MySqlException ex)
            {
                await tran.RollbackAsync();

                if (ex.Number == 1213) // Deadlock
                    throw new Exception("Deadlock detected in SaveProjeStokKartAsync: " + ex.Message, ex);

                throw new Exception($"MySQL Error in SaveProjeStokKartAsync: {ex.Number} - {ex.Message}", ex);
            }
        }

        private int? GetOrInsertBoyutAsync(MySqlConnection conn, MySqlTransaction tran, string boyutAd)
        {
            if (string.IsNullOrWhiteSpace(boyutAd))
                return null;

            var boyutId = conn.ExecuteScalar<int?>(
                "SELECT Id FROM t01_boyut WHERE ad=@ad",
                new { ad = boyutAd }, tran
            );

            if (boyutId == null)
            {
                conn.Execute("INSERT INTO t01_boyut(ad) VALUES(@ad)", new { ad = boyutAd }, tran);
                boyutId = conn.ExecuteScalar<int>("SELECT LAST_INSERT_ID()", transaction: tran);
            }

            return boyutId;
        }

        private int GetOrInsertOrUpdateStokKartAsync(MySqlConnection conn, MySqlTransaction tran, ProjeStokKart model, int? boyutId)
        {
            var stokKartId = conn.ExecuteScalar<int?>(
                "SELECT Id FROM t01_stokkart WHERE kod=@kod",
                new { kod = model.stokKart.kod }, tran
            );

            if (stokKartId == null)
            {
                // INSERT
                string insertSql = @"INSERT INTO t01_stokkart(kod, parcaKod, ad, stokTipId, stokGrupId, malzemeGrupId, malzemeAltGrupId, malzemeAltGrup2Id,parcaAdi, boyut, uzunluk, malzeme, aciklama, agirlik, olcuBirimId, boy, en, yukseklik, cap,etKalinligi, malzemeStandartId, isTalasli, isFromExcel, boyutId, tedarikciKod)
VALUES(@StokKartKod, @StokKartParcaKod, @StokKartAd, @StokKartStokTipId, @StokKartStokGrupId,@StokKartMalzemeGrupId, @StokKartMalzemeAltGrupId,
@StokKartMalzemeAltGrup2Id,@StokKartParcaAdi, @StokKartBoyut, @StokKartUzunluk, @StokKartMalzeme, @StokKartAciklama,
@StokKartAgirlik, @StokKartOlcuBirimId, @StokKartBoy, @StokKartEn, @StokKartYukseklik,
@StokKartCap, @StokKartEtKalinligi, @StokKartMalzemeStandartId, @StokKartIsTalasli,
@StokKartIsFromExcel, @BoyutId, @StokKartTedarikciKod);
SELECT LAST_INSERT_ID();";

                stokKartId =  conn.ExecuteScalar<int?>(insertSql, new
                {
                    StokKartKod=model.stokKart.kod,
                    StokKartParcaKod=model.stokKart.parcaKod,
                    StokKartAd=model.stokKart.ad,
                    StokKartStokTipId=model.stokKart.stokTip.Id,
                    StokKartStokGrupId=model.stokKart.stokGrup.Id,
                    StokKartMalzemeGrupId=model.stokKart.malzemeGrup.Id,
                    StokKartMalzemeAltGrupId=model.stokKart.malzemeAltGrup.Id,
                    StokKartMalzemeAltGrup2Id = model.stokKart.malzemeAltGrup2.Id,
                    StokKartParcaAdi = model.stokKart.parcaAdi,
                    StokKartBoyut=model.stokKart.boyut,
                    StokKartUzunluk=model.stokKart.uzunluk,
                    StokKartMalzeme=model.stokKart.malzeme,
                    StokKartAciklama=model.stokKart.aciklama,
                    StokKartAgirlik=model.stokKart.agirlik,
                    StokKartOlcuBirimId=model.stokKart.olcuBirim.Id,
                    StokKartBoy=model.stokKart.boy,
                    StokKartEn=model.stokKart.en,
                    StokKartYukseklik=model.stokKart.yukseklik,
                    StokKartCap=model.stokKart.cap,
                    StokKartEtKalinligi=model.stokKart.etKalinligi,
                    StokKartMalzemeStandartId=model.stokKart.malzemeStandart.Id,
                    StokKartIsTalasli=model.stokKart.isTalasli,
                    StokKartIsFromExcel=model.stokKart.isFromExcel,
                    BoyutId = boyutId,
                    StokKartTedarikciKod=model.stokKart.tedarikciKod
                }, tran);
            }
            else
            {
                // UPDATE
                string updateSql = @"
                UPDATE t01_stokkart SET
                    parcaKod=@StokKartParcaKod,
                    ad=@StokKartAd,
                    stokTipId=@StokKartStokTipId,
                    stokGrupId=@StokKartStokGrupId,
                    malzemeGrupId=@StokKartMalzemeGrupId,
                    malzemeAltGrupId=@StokKartMalzemeAltGrupId,
                    malzemeAltGrup2Id=@StokKartMalzemeAltGrup2Id,
                    parcaAdi=@StokKartParcaAdi,
                    boyut=@StokKartBoyut,
                    uzunluk=@StokKartUzunluk,
                    malzeme=@StokKartMalzeme,
                    aciklama=@StokKartAciklama,
                    agirlik=@StokKartAgirlik,
                    olcuBirimId=@StokKartOlcuBirimId,
                    boy=@StokKartBoy,
                    en=@StokKartEn,
                    yukseklik=@StokKartYukseklik,
                    cap=@StokKartCap,
                    etKalinligi=@StokKartEtKalinligi,
                    malzemeStandartId=@StokKartMalzemeStandartId,
                    isTalasli=@StokKartIsTalasli,
                    isFromExcel=@StokKartIsFromExcel,
                    tedarikciKod=@StokKartTedarikciKod,
                    boyutId=@BoyutId
                WHERE Id=@StokKartId";

                conn.Execute(updateSql, new
                {
                    StokKartParcaKod = model.stokKart.parcaKod,
                    StokKartAd=model.stokKart.ad,
                    StokKartStokTipId=model.stokKart.stokTip.Id,
                    StokKartStokGrupId=model.stokKart.stokGrup.Id,
                    StokKartMalzemeGrupId=model.stokKart.malzemeGrup.Id,
                    StokKartMalzemeAltGrupId=model.stokKart.malzemeAltGrup.Id,
                    StokKartMalzemeAltGrup2Id=model.stokKart.malzemeAltGrup2.Id,
                    StokKartParcaAdi=model.stokKart.parcaAdi,
                    StokKartBoyut=model.stokKart.boyut,
                    StokKartUzunluk=model.stokKart.uzunluk,
                    StokKartMalzeme=model.stokKart.malzeme,
                    StokKartAciklama=model.stokKart.aciklama,
                    StokKartAgirlik=model.stokKart.agirlik,
                    StokKartOlcuBirimId=model.stokKart.olcuBirim.Id,
                    StokKartBoy=model.stokKart.boy,
                    StokKartEn=model.stokKart.en,
                    StokKartYukseklik=model.stokKart.yukseklik,
                    StokKartCap=model.stokKart.cap,
                    StokKartEtKalinligi=model.stokKart.etKalinligi,
                    StokKartMalzemeStandartId=model.stokKart.malzemeStandart.Id,
                    StokKartIsTalasli = model.stokKart.isTalasli,
                    StokKartIsFromExcel = model.stokKart.isFromExcel,
                    BoyutId = boyutId,
                    StokKartTedarikciKod = model.stokKart.tedarikciKod,
                    StokKartId = stokKartId
                }, tran);
            }

            return stokKartId.Value;
        }

        private async Task SaveDosyalarAsync(MySqlConnection conn, MySqlTransaction tran, int stokKartId, List<StokKartDosya> dosyaList)
        {
            if (dosyaList == null || dosyaList.Count == 0)
                return;

            foreach (var dosya in dosyaList)
            {
                if (dosya.Id == 0)
                {
                    string insert = @"INSERT INTO t01_stokkartdosya(stokKartId,dosyaTipId,dosyaAd,dosyaUzanti,dosya)
                                  VALUES(@stokKartId,@dosyaTipId,@dosyaAd,@dosyaUzanti,@dosya)";
                    await conn.ExecuteAsync(insert, new
                    {
                        stokKartId,
                        DosyaTipId=dosya.dosyaTip.Id,
                        DosyaAd=dosya.dosyaAd,
                        DosyaUzanti=dosya.dosyaUzanti,
                        Dosya=dosya.dosya
                    }, tran);
                }
                else
                {
                    // isActive=0 yapma veya güncelleme mantığı buraya eklenebilir
                }
            }
        }

        private async Task SaveProjeStokKartRelationAsync(MySqlConnection conn, MySqlTransaction tran, int stokKartId, ProjeStokKart model)
        {
            var exists = await conn.ExecuteScalarAsync<int>(
                "SELECT COUNT(*) FROM t02_projestokkart WHERE projeId=@projeId AND stokKartId=@stokKartId",
                new { projeId = model.proje.Id, stokKartId }, tran
            );

            if (exists == 0)
            {
                await conn.ExecuteAsync(
                    "INSERT INTO t02_projestokkart(projeId,stokKartId,miktar,adet) VALUES(@projeId,@stokKartId,@miktar,@adet)",
                    new { projeId = model.proje.Id, stokKartId, model.miktar, model.adet }, tran
                );
            }
            else
            {
                await conn.ExecuteAsync(
                    "UPDATE t02_projestokkart SET adet=@adet, miktar=@miktar WHERE projeId=@projeId AND stokKartId=@stokKartId",
                    new { projeId = model.proje.Id, stokKartId, model.miktar, model.adet }, tran
                );
            }
        }
    }
}
