using Api.Factory;
using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System.Data;


namespace Api.Business
{
    public class StokKartRepository : IStokService
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public StokKartRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<string> SaveStokKartDosya(StokKartDosya stokKartDosya,IDbConnection dbConnection,IDbTransaction dbTransaction)
        {
            const string sql = @"
                                INSERT t01_stokkartdosya
                                    (stokKartId,dosyaTipId,dosyaAd,dosyaUzanti,dosyaFullPath,kontrolEdenKullaniciId,kontrolTarihi,kontrolSonucu,kontrolRedSebepAciklama)
                                VALUES
                                    (@stokKartId,@dosyaTipId,@dosyaAd,@dosyaUzanti,@dosyaFullPath,@kontrolEdenKullaniciId,@kontrolTarihi,@kontrolSonucu,@kontrolRedSebepAciklama)
                                ON DUPLICATE KEY UPDATE
                                    stokKartId = VALUES(stokKartId),
                                    dosyaTipId = VALUES(dosyaTipId),
                                    dosyaAd = VALUES(dosyaAd),
                                    dosyaUzanti = VALUES(dosyaUzanti),
                                    dosyaFullPath = VALUES(dosyaFullPath),
                                    kontrolEdenKullaniciId = VALUES(kontrolEdenKullaniciId),
                                    kontrolTarihi = VALUES(kontrolTarihi),
                                    kontrolSonucu = VALUES(kontrolSonucu),
                                    kontrolRedSebepAciklama = VALUES(kontrolRedSebepAciklama),
                                Id = LAST_INSERT_ID(Id);
                                SELECT *
                                FROM t01_stokkartdosya WHERE Id = LAST_INSERT_ID()";


            var savedStokKartDosya = await dbConnection.QuerySingleAsync<StokKartDosya>(
                sql,
                new { 
                    stokKartDosya.stokKartId,
                    dosyaTipId = stokKartDosya.dosyaTip.Id,
                    stokKartDosya.dosyaAd,
                    stokKartDosya.dosyaUzanti,
                    stokKartDosya.dosyaFullPath,
                    stokKartDosya.kontrolEdenKullaniciId,
                    stokKartDosya.kontrolTarihi,
                    stokKartDosya.kontrolSonucu,
                    stokKartDosya.kontrolRedSebepAciklama
                },
                dbTransaction
            );

            return JsonConvert.SerializeObject(savedStokKartDosya);
        }
        public async Task<string> SaveProjeStokKart(ProjeStokKart projeStokKart,IDbConnection dbConnection,IDbTransaction dbTransaction)
        {
            var stokKart = await SaveStokKart(projeStokKart.stokKart,dbConnection,dbTransaction);
            projeStokKart.stokKart = stokKart;
            const string sql = @"
                                INSERT INTO t02_projestokkart
                                    (projeId,stokKartId,miktar,adet,hamVeri)
                                VALUES
                                    (@projeId,@stokKartId,@miktar,@adet,@hamVeri)
                                ON DUPLICATE KEY UPDATE
                                    projeId = VALUES(projeId),
                                    stokKartId = VALUES(stokKartId),
                                    miktar = VALUES(miktar),
                                    adet = VALUES(adet),
                                    hamVeri = VALUES(hamVeri),
                                    Id = LAST_INSERT_ID(Id);
                                SELECT *
                                FROM t02_projestokkart
                                WHERE Id = LAST_INSERT_ID();";
            
            
            var savedProjeStokKart = await dbConnection.QuerySingleAsync<ProjeStokKart>(
                sql,
                new {
                    projeId = projeStokKart.proje.Id,
                    stokKartId = projeStokKart.stokKart.Id,
                    projeStokKart.miktar,
                    projeStokKart.adet,
                    projeStokKart.hamVeri
                },
                dbTransaction
            );

            return JsonConvert.SerializeObject(savedProjeStokKart);
        }
        public async Task<StokKart> SaveStokKart(StokKart stokKart,IDbConnection dbConnection, IDbTransaction dbTransaction)
        {

            try
            {
                // 1️⃣ Boyut
                var boyut = new Boyut { ad = stokKart.boyut };
                boyut = await SaveBoyut(boyut, dbConnection, dbTransaction);
                stokKart.boyutTanim.Id = boyut.Id;
                
                // 2️⃣ StokKart
                const string sql = @"
            INSERT INTO t01_stokkart
            (kod, parcaKod, ad, hammaddeId,stokTipId, stokGrupId,
             malzemeGrupId, malzemeAltGrupId, malzemeAltGrup2Id,
             parcaAdi, boyut, uzunluk, malzeme, aciklama,
             agirlik, olcuBirimId, boy, en, yukseklik,
             cap, etKalinligi, malzemeStandartId,
             isTalasli, isBukum, isFromExcel, boyutId, tedarikciKod)
            VALUES
            (@kod, @parcaKod, @ad, @hammaddeId ,@stokTipId, @stokGrupId,
             @malzemeGrupId, @malzemeAltGrupId, @malzemeAltGrup2Id,
             @parcaAdi, @boyut, @uzunluk, @malzeme, @aciklama,
             @agirlik, @olcuBirimId, @boy, @en, @yukseklik,
             @cap, @etKalinligi, @malzemeStandartId,
             @isTalasli, @isBukum, @isFromExcel, @boyutId, @tedarikciKod)
            ON DUPLICATE KEY UPDATE
             ad = VALUES(ad),
             parcaAdi = VALUES(parcaAdi),
             boyutId = VALUES(boyutId),
             Id = LAST_INSERT_ID(Id);

            SELECT * FROM t01_stokkart WHERE Id = LAST_INSERT_ID();
        ";
                if (stokKart.malzemeGrup.Id == 29)
                {
                    const string indSql = "SELECT MAX(S.kod) FROM t01_stokkart S INNER JOIN t01_stoktip ST ON ST.Id=S.stoktipId WHERE S.stokGrupId=@stokGrupId AND S.malzemeGrupId=@malzemeGrupId AND IFNULL(@malzemeAltGrupId,0)=IFNULL(S.malzemeAltGrupId,0) AND IFNULL(@malzemeAltGrup2Id,0)=IFNULL(S.malzemeAltGrup2Id,0);";
                    var ind = await dbConnection.QuerySingleAsync<string>(indSql, 
                        new { 
                            stokGrupId=stokKart.stokGrup.Id,
                            malzemeGrupId = stokKart.malzemeGrup.Id,
                            malzemeAltGrupId = stokKart.malzemeAltGrup.Id,
                            malzemeAltGrup2Id = stokKart.malzemeAltGrup2.Id
                        },
                        dbTransaction);

                    var mag = string.IsNullOrEmpty(stokKart.malzemeAltGrup.kod) ? "0" : stokKart.malzemeAltGrup.kod;
                    var savedHammadde = await dbConnection.QuerySingleAsync<StokKart>(
                        sql,
                        new
                        {
                        
                            kod = $"{stokKart.stokGrup.kod}_{stokKart.malzemeGrup.kod}_{mag.PadLeft(4,'0')}_{ind.Substring(14,3).PadLeft(3,'0')}",
                            stokKart.parcaKod,
                            stokKart.ad,
                            hammaddeId = stokKart.hammadde.Id,
                            stokTipId = stokKart.stokTip.Id,
                            stokGrupId = stokKart.stokGrup.Id,
                            malzemeGrupId = stokKart.malzemeGrup.Id,
                            malzemeAltGrupId = stokKart.malzemeAltGrup.Id,
                            malzemeAltGrup2Id = stokKart.malzemeAltGrup2.Id,
                            stokKart.parcaAdi,
                            stokKart.boyut,
                            stokKart.uzunluk,
                            stokKart.malzeme,
                            stokKart.aciklama,
                            stokKart.agirlik,
                            olcuBirimId = stokKart.olcuBirim.Id,
                            stokKart.boy,
                            stokKart.en,
                            stokKart.yukseklik,
                            stokKart.cap,
                            stokKart.etKalinligi,
                            malzemeStandartId = stokKart.malzemeStandart.Id,
                            stokKart.isTalasli,
                            stokKart.isBukum,
                            stokKart.isFromExcel,
                            boyutId = stokKart.boyutTanim.Id,
                            stokKart.tedarikciKod
                        },
                        dbTransaction
                    );
                    stokKart.hammadde.Id = savedHammadde.Id;
                }
                var savedStokKart = await dbConnection.QuerySingleAsync<StokKart>(
                    sql,
                    new
                    {
                        stokKart.kod,
                        stokKart.parcaKod,
                        stokKart.ad,
                        hammaddeId = stokKart.hammadde.Id,
                        stokTipId = stokKart.stokTip.Id,
                        stokGrupId = stokKart.stokGrup.Id,
                        malzemeGrupId = stokKart.malzemeGrup.Id,
                        malzemeAltGrupId = stokKart.malzemeAltGrup.Id,
                        malzemeAltGrup2Id = stokKart.malzemeAltGrup2.Id,
                        stokKart.parcaAdi,
                        stokKart.boyut,
                        stokKart.uzunluk,
                        stokKart.malzeme,
                        stokKart.aciklama,
                        stokKart.agirlik,
                        olcuBirimId = stokKart.olcuBirim.Id,
                        stokKart.boy,
                        stokKart.en,
                        stokKart.yukseklik,
                        stokKart.cap,
                        stokKart.etKalinligi,
                        malzemeStandartId = stokKart.malzemeStandart.Id,
                        stokKart.isTalasli,
                        stokKart.isBukum,
                        stokKart.isFromExcel,
                        boyutId=stokKart.boyutTanim.Id,
                        stokKart.tedarikciKod
                    },
                    dbTransaction
                );

                // 3️⃣ Dosyalar
                savedStokKart.dosyaList = new List<StokKartDosya>();

                foreach (var dosya in stokKart.dosyaList)
                {
                    dosya.stokKartId = savedStokKart.Id;
                    var savedDosya = await SaveStokKartDosya(dosya, dbConnection, dbTransaction);
                    savedStokKart.dosyaList.Add(JsonConvert.DeserializeObject<StokKartDosya>(savedDosya));
                }

                return savedStokKart;
            }
            catch
            {
                dbTransaction.Rollback();
                throw;
            }
        }
        public async Task<Boyut> SaveBoyut(Boyut boyut, IDbConnection dbConnection, IDbTransaction dbTransaction)
        {
            const string sql = @"
                                INSERT INTO t01_boyut
                                    (kod, ad, malzemeGrupId, malzemeAltGrupId, malzemeAltGrup2Id)
                                VALUES
                                    (@kod, @ad, @malzemeGrupId, @malzemeAltGrupId, @malzemeAltGrup2Id)
                                ON DUPLICATE KEY UPDATE
                                    kod = VALUES(kod),
                                    malzemeGrupId = VALUES(malzemeGrupId),
                                    malzemeAltGrupId = VALUES(malzemeAltGrupId),
                                    malzemeAltGrup2Id = VALUES(malzemeAltGrup2Id),
                                    Id = LAST_INSERT_ID(Id);

                                SELECT *
                                FROM t01_boyut
                                WHERE Id = LAST_INSERT_ID();
                            ";


            var savedBoyut = await dbConnection.QuerySingleAsync<Boyut>(
                sql,
                boyut,
                dbTransaction
            );

            return savedBoyut;
        }
    }
}
