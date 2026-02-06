using Dapper;
using Models;
using MySql.Data.MySqlClient;
using System.Data;


namespace Api.Business
{
    public class StokService : IStokService
    {
        public async Task<string> SaveStokKartDosya(StokKartDosya stokKartDosya)
        {
            const string sql = @"
        UPDATE t01_stokkartdosya
        SET kontrolEdenKullaniciId = @kontrolEdenKullaniciId,
            kontrolTarihi = @kontrolTarihi,
            kontrolSonucu = @kontrolSonucu
        WHERE Id = @Id";

            try
            {
                using var connection = new MySqlConnection(
                    "Server=172.16.9.160;Database=YektamakDb;User ID=YektamakAdmin;Password=Yektamak@dmin;"
                );

                var affectedRows = await connection.ExecuteAsync(
                    sql,
                    new
                    {
                        stokKartDosya.kontrolEdenKullaniciId,
                        stokKartDosya.kontrolTarihi,
                        stokKartDosya.kontrolSonucu,
                        stokKartDosya.Id
                    },
                    commandTimeout: 300
                );

                return affectedRows > 0 ? "Başarılı" : "Kayıt bulunamadı";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
