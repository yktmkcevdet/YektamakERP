using ApiService.Interfaces;
using Models;
using Models.DTO;

namespace ApiService.Implementations
{
    public class DosyalamaService:IDosyalamaService
    {
        private readonly IFileService _fileService;
        private readonly ICache _cache;

        public DosyalamaService(IFileService fileService, ICache cache)
        {
            _fileService = fileService;
            _cache = cache;
        }

        public async Task CreateOrderFile(List<ProjeStokKart> projeStokKartList,string filePath)
        {
            if(string.IsNullOrEmpty(filePath))
                filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            foreach (var row in projeStokKartList)
            {
                foreach (var skd in row.stokKart.dosyaList)
                {
                    foreach (var dosyalamaYapisi in await _cache.dosyalamaYapisiList)
                    {
                        bool bukum1 = dosyalamaYapisi.isBukum;
                        bool bukum2 = row.stokKart.isBukum ?? false;

                        if (row.stokKart.malzemeGrup.Id == dosyalamaYapisi.malzemeGrupId
                            && (dosyalamaYapisi.malzemeAltGrupId is null || dosyalamaYapisi.malzemeAltGrupId == row.stokKart.malzemeAltGrup.Id)
                            && (dosyalamaYapisi.boyutId is null || dosyalamaYapisi.boyutId == row.stokKart.boyutTanim.Id)
                            && bukum1 == bukum2
                            )
                        {
                            await SaveMaterialFile(skd, Path.Combine(filePath,dosyalamaYapisi.path));
                        }
                    }
                }
            }

        }
        private async Task SaveMaterialFile(StokKartDosya skd,string filePath)
        {
            //string directoryPath = Path.GetDirectoryName(filePath);
            // Dizin yoksa oluştur
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            File.WriteAllBytes(Path.Combine(filePath,skd.dosyaAd), await _fileService.GetFile(skd.dosyaFullPath));
        }
    }
}
