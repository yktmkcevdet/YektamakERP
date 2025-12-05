using ApiService.Implementations;
using ApiService.Interfaces;
using Models;
using Models.DTO;
using Models.Models.Stok;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Formlar.Satinalma;

namespace YektamakDesktop.Common
{
    public class SatinalmaTalepHelper : ISatinalmaTalepHelper
    {
        private readonly IConvertHelper _convertHelper;
        private readonly IProjeService _projeService;
        private readonly ICache _cache;

        public SatinalmaTalepHelper(IConvertHelper convertHelper, IProjeService projeService, ICache cache)
        {
            _convertHelper = convertHelper;
            _projeService = projeService;
            _cache = cache;
        }

        public async void CreateSatinalmaTalep(List<ProjeStokKartDTO> talepList, Proje proje, MalzemeGrup malzemeGrup)
        {
            if (ValidateForm(talepList))
            {
                List<SatinalmaTalepDetay> satinalmaTalepDetayList = new List<SatinalmaTalepDetay>();
                foreach (var item in talepList)
                {
                    SatinalmaTalepDetay satinalmaTalepdetay = new SatinalmaTalepDetay { proje = proje };
                    SatinalmaTalepSatirDetayDTO satinalmaTalepSatirDetay = new SatinalmaTalepSatirDetayDTO();
                    satinalmaTalepdetay.projeStokKart = _convertHelper.ToEntity<ProjeStokKart>(item);
                    // Eğer stok kartının hammaddeId'si varsa, ve lazer grubuna ait parça değilse satınalma talep detay listesine hammadde olarak ekle
                    if (item.stokKarthammaddeId != null && item.stokKartmalzemeGrupId != 28)
                    {
                        //Hammadde ise ve listeye daha önce eklenmiş mi kontrol et, eklenmişse miktarını güncelle
                        if (satinalmaTalepDetayList.Any(x => x.projeStokKart.stokKart.Id == item.stokKarthammaddeId))
                        {
                            satinalmaTalepdetay = satinalmaTalepDetayList.FirstOrDefault(x => x.projeStokKart.stokKart.Id == item.stokKarthammaddeId);
                            if (item.stokKarthammaddeolcuBirimId == 2)
                            {
                                satinalmaTalepdetay.miktar += item.miktar * item.stokKartagirlik;
                            }
                            else
                            {
                                satinalmaTalepdetay.miktar += item.miktar;
                            }
                            satinalmaTalepdetay.agirlik += item.miktar * item.stokKartagirlik;

                            satinalmaTalepdetay.satinalmaTalepSatirDetays.Add(
                                new SatinalmaTalepSatirDetay { projeStokKart = _convertHelper.ToEntity<ProjeStokKart>(item) });
                        }
                        // Eğer hammadde olarak eklenmemişse, yeni bir hammadde olarak ekle
                        else
                        {
                            if (satinalmaTalepdetay.projeStokKart.stokKart.hammadde.olcuBirim.Id == 2)
                            {
                                satinalmaTalepdetay.miktar = item.miktar * item.stokKartagirlik;
                                satinalmaTalepdetay.onaylananMiktar = item.miktar * item.stokKartagirlik;
                            }
                            else
                            {
                                satinalmaTalepdetay.miktar = item.miktar;
                                satinalmaTalepdetay.onaylananMiktar = item.miktar;
                            }
                            satinalmaTalepdetay.projeStokKart = new ProjeStokKart
                            {
                                stokKart = new StokKart { Id = item.stokKarthammaddeId }
                            };
                            satinalmaTalepdetay.agirlik = item.miktar * item.stokKartagirlik;
                            satinalmaTalepdetay.satinalmaTalepSatirDetays.Add(new SatinalmaTalepSatirDetay { projeStokKart = _convertHelper.ToEntity<ProjeStokKart>(item) });
                            satinalmaTalepdetay.projeStokKart = (await _projeService.GetProjeStokKart(new ProjeStokKart
                            {
                                //proje = { Id = Convert.ToInt32(fcbProjeKod.SelectedValue) },
                                stokKart = new StokKart { Id = item.stokKarthammaddeId }
                            })).FirstOrDefault();
                            satinalmaTalepDetayList.Add(satinalmaTalepdetay);
                        }
                    }
                    // Eğer stok kartının hammaddeId'si yoksa, satınalma talep detay listesine normal stok kartı olarak ekle
                    else
                    {
                        satinalmaTalepdetay = new SatinalmaTalepDetay { projeStokKart = _convertHelper.ToEntity<ProjeStokKart>(item) };
                        satinalmaTalepdetay.miktar = item.miktar;
                        satinalmaTalepdetay.onaylananMiktar = item.miktar;
                        satinalmaTalepdetay.agirlik = item.miktar * item.stokKartagirlik;
                        satinalmaTalepDetayList.Add(satinalmaTalepdetay);
                    }
                }
                if (malzemeGrup.Id == 29)
                {
                    var profilGroups = talepList.GroupBy(t => new { t.stokKarthammaddeId }).Select(group => group.First()).ToList();
                    foreach (var profilGroup in profilGroups)
                    {
                        var profilList = talepList.Where(t => t.stokKarthammaddeId == profilGroup.stokKarthammaddeId).ToList();
                        var sonuc = OptimizedCutting(profilList, Convert.ToDouble(profilGroup.stokKarthammaddeuzunluk), 2);
                        satinalmaTalepDetayList.Where(s => s.projeStokKart.stokKart.Id == profilGroup.stokKarthammaddeId).FirstOrDefault().miktar = sonuc.Bins.Count;
                        foreach (var b in sonuc.Bins)
                        {
                            var fire = profilGroup.stokKarthammaddeuzunluk - b.Sum(x => x.projeStokKart.stokKart.uzunluk);
                        }
                    }
                }
                SatinalmaTalep satinalmaTalep = new SatinalmaTalep
                {
                    proje = proje,
                    //malzemeGrup = new MalzemeGrup { Id = int.TryParse(clbMalzemeGrup.SelectedValue.ToString(), out int malzemegrupId) ? malzemegrupId : null },
                    talepNeden = new TalepNeden { Id = 1 }, //Varsayılan olarak 1 atanıyor
                    talepTarihi = DateTime.Today,
                    teslimTarihi = null,
                    aciklama = "Otomatik oluşturulan satınalma talebi",
                    talepEdenKullanici = _cache.kullanici,
                    satinalmaTalepDetays = satinalmaTalepDetayList
                };
                SatinalmaTalepKayitFormu satinalmaTalepKayitFormu = FormFactory.CreateForm<SatinalmaTalepKayitFormu>();
                satinalmaTalepKayitFormu.UpdateMode(satinalmaTalep);
                satinalmaTalepKayitFormu.ShowDialog();
            }
        }
        public async void CreateSatinalmaTalep(List<SatinalmaTalepDetay> talepList, Proje proje, MalzemeGrup malzemeGrup)
        {
            if (ValidateForm(talepList))
            {
                List<SatinalmaTalepDetay> satinalmaTalepDetayList = new List<SatinalmaTalepDetay>();
                foreach (var item in talepList)
                {
                    SatinalmaTalepDetay satinalmaTalepdetay = new SatinalmaTalepDetay { proje = proje };
                    SatinalmaTalepSatirDetayDTO satinalmaTalepSatirDetay = new SatinalmaTalepSatirDetayDTO();
                    // Eğer stok kartının hammaddeId'si varsa, ve lazer grubuna ait parça değilse satınalma talep detay listesine hammadde olarak ekle
                    if (item.projeStokKart.stokKart.hammadde.Id != null && item.projeStokKart.stokKart.malzemeGrup.Id != 28)
                    {
                        //Hammadde ise ve listeye daha önce eklenmiş mi kontrol et, eklenmişse miktarını güncelle
                        if (satinalmaTalepDetayList.Any(x => x.projeStokKart.stokKart.Id == item.projeStokKart.stokKart.hammadde.Id))
                        {
                            satinalmaTalepdetay = satinalmaTalepDetayList.FirstOrDefault(x => x.projeStokKart.stokKart.Id == item.projeStokKart.stokKart.hammadde.Id);
                            if (item.projeStokKart.stokKart.hammadde.olcuBirim.Id == 2)
                            {
                                satinalmaTalepdetay.miktar += item.miktar * item.projeStokKart.stokKart.agirlik;
                            }
                            else
                            {
                                satinalmaTalepdetay.miktar += item.miktar;
                            }
                            satinalmaTalepdetay.agirlik += item.miktar * item.projeStokKart.stokKart.agirlik;

                            satinalmaTalepdetay.satinalmaTalepSatirDetays.Add(
                                new SatinalmaTalepSatirDetay { projeStokKart = item.projeStokKart });
                        }
                        // Eğer hammadde olarak eklenmemişse, yeni bir hammadde olarak ekle
                        else
                        {
                            if (satinalmaTalepdetay.projeStokKart.stokKart.hammadde.olcuBirim.Id == 2)
                            {
                                satinalmaTalepdetay.miktar = item.miktar * item.projeStokKart.stokKart.agirlik;
                                satinalmaTalepdetay.onaylananMiktar = item.miktar * item.projeStokKart.stokKart.agirlik;
                            }
                            else
                            {
                                satinalmaTalepdetay.miktar = item.miktar;
                                satinalmaTalepdetay.onaylananMiktar = item.miktar;
                            }
                            satinalmaTalepdetay.projeStokKart = new ProjeStokKart
                            {
                                stokKart = new StokKart { Id = item.projeStokKart.stokKart.hammadde.Id }
                            };
                            
                            satinalmaTalepdetay.satinalmaTalepSatirDetays.Add(new SatinalmaTalepSatirDetay { projeStokKart = _convertHelper.ToEntity<ProjeStokKart>(item) });
                            satinalmaTalepdetay.projeStokKart = (await _projeService.GetProjeStokKart(new ProjeStokKart
                            {
                                //proje = { Id = Convert.ToInt32(fcbProjeKod.SelectedValue) },
                                stokKart = new StokKart { Id = item.projeStokKart.stokKart.hammadde.Id }
                            })).FirstOrDefault();
                            satinalmaTalepDetayList.Add(satinalmaTalepdetay);
                        }
                    }
                    // Eğer stok kartının hammaddeId'si yoksa, satınalma talep detay listesine normal stok kartı olarak ekle
                    else
                    {
                        satinalmaTalepdetay = new SatinalmaTalepDetay { projeStokKart = _convertHelper.ToEntity<ProjeStokKart>(item) };
                        satinalmaTalepdetay.miktar = item.miktar;
                        satinalmaTalepdetay.onaylananMiktar = item.miktar;
                        satinalmaTalepDetayList.Add(satinalmaTalepdetay);
                    }
                    
                    satinalmaTalepdetay.aciklama = item.aciklama;
                    satinalmaTalepdetay.agirlik = item.miktar * item.projeStokKart.stokKart.agirlik;
                }
                if (malzemeGrup.Id == 29)
                {
                    var profilGroups = talepList.GroupBy(t => new { t.projeStokKart.stokKart.hammadde.Id }).Select(group => group.First()).ToList();
                    foreach (var profilGroup in profilGroups)
                    {
                        var profilList = talepList.Where(t => t.projeStokKart.stokKart.hammadde.Id == profilGroup.projeStokKart.stokKart.hammadde.Id).ToList();
                        var sonuc = OptimizedCutting(profilList, Convert.ToDouble(profilGroup.projeStokKart.stokKart.hammadde.uzunluk), 2);
                        satinalmaTalepDetayList.Where(s => s.projeStokKart.stokKart.Id == profilGroup.projeStokKart.stokKart.hammadde.Id).FirstOrDefault().miktar = sonuc.Bins.Count;
                        foreach (var b in sonuc.Bins)
                        {
                            var fire = profilGroup.projeStokKart.stokKart.hammadde.uzunluk - b.Sum(x => x.projeStokKart.stokKart.uzunluk);
                        }
                    }
                }
                SatinalmaTalep satinalmaTalep = new SatinalmaTalep
                {
                    proje = proje,
                    //malzemeGrup = new MalzemeGrup { Id = int.TryParse(clbMalzemeGrup.SelectedValue.ToString(), out int malzemegrupId) ? malzemegrupId : null },
                    talepNeden = new TalepNeden { Id = 1 }, //Varsayılan olarak 1 atanıyor
                    talepTarihi = DateTime.Today,
                    teslimTarihi = null,
                    aciklama = "Otomatik oluşturulan satınalma talebi",
                    talepEdenKullanici = _cache.kullanici,
                    satinalmaTalepDetays = satinalmaTalepDetayList
                };
                SatinalmaTalepKayitFormu satinalmaTalepKayitFormu = FormFactory.CreateForm<SatinalmaTalepKayitFormu>();
                satinalmaTalepKayitFormu.UpdateMode(satinalmaTalep);
                satinalmaTalepKayitFormu.ShowDialog();
            }
        }
        private bool ValidateForm(List<ProjeStokKartDTO> stokKarts)
        {
            foreach(var item in stokKarts)
            {
                if(item.stokKartmalzemeAltGrupId == null)
                {
                    if(_cache.malzemeAltGrups.Where(m=>m.malzemeGrup.Id== item.stokKartmalzemeGrupId).Any())
                    {
                        MessageBox.Show($"{item.stokKartkod} kodlu parçanın Malzeme Grup tanımı yapılmalıdır.");
                        return false;
                    }
                }
                if (item.stokKartmalzemeAltGrup2Id == null)
                {
                    if (_cache.malzemeAltGrup2List.Where(m => m.malzemeAltGrup.Id == item.stokKartmalzemeAltGrupId).Any())
                    {
                        MessageBox.Show($"{item.stokKartkod} kodlu parçanın Malzeme Alt Grup-2 tanımı yapılmalıdır.");
                        return false;
                    }
                }

            }
            // Formdaki gerekli alanların dolu olup olmadığını kontrol et
            if (!stokKarts.Any())
            {
                MessageBox.Show("Satınalma talebi oluşturulacak satırlar seçilmelidir.");
                return false;
            }
            if (stokKarts.Any(x => x.stokKartisPdf == false))
            {
                MessageBox.Show("PDF dosyası olmayan kayıtlar seçilemez.");
                return false;
            }
            if (stokKarts.Any(x => x.stokKartisDxf == false))
            {
                MessageBox.Show("DXF dosyası olmayan kayıtlar seçilemez.");
                return false;
            }
            if (stokKarts.Any(x => x.stokKartisStep == false))
            {
                DialogResult dialogResult = MessageBox.Show("STEP dosyası olmayan kayıtlar var devam edilsin mi?", "STEP Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No)
                {
                    return false;
                }
            }
            if (stokKarts.Any(x => x.stokKartisSatinalma == true))
            {
                DialogResult dialogResult = MessageBox.Show("Satınalma talebi açılmış kayıtlar seçildi. Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }
        private bool ValidateForm(List<SatinalmaTalepDetay> stokKarts)
        {
            // Formdaki gerekli alanların dolu olup olmadığını kontrol et
            if (!stokKarts.Any())
            {
                MessageBox.Show("Satınalma talebi oluşturulacak satırlar seçilmelidir.");
                return false;
            }
            if (stokKarts.Any(x => x.projeStokKart.stokKart.isPdf == false))
            {
                MessageBox.Show("PDF dosyası olmayan kayıtlar seçilemez.");
                return false;
            }
            if (stokKarts.Any(x => x.projeStokKart.stokKart.isDxf == false))
            {
                MessageBox.Show("DXF dosyası olmayan kayıtlar seçilemez.");
                return false;
            }
            if (stokKarts.Any(x => x.projeStokKart.stokKart.isStep == false))
            {
                DialogResult dialogResult = MessageBox.Show("STEP dosyası olmayan kayıtlar var devam edilsin mi?", "STEP Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No)
                {
                    return false;
                }
            }
            if (stokKarts.Any(x => x.projeStokKart.stokKart.isSatinalma == true))
            {
                DialogResult dialogResult = MessageBox.Show("Satınalma talebi açılmış kayıtlar seçildi. Devam etmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }
        public CuttingOptimizationResult OptimizedCutting(
            List<ProjeStokKartDTO> items,
            double stockLength,
            int kerf,
            double usableWasteMinLength = 0) // Minimum kullanılabilir fire uzunluğu
        {
            // 1) Tüm parçaları adetlerine göre aç
            var allPieces = new List<SatinalmaTalepDetay>();
            foreach (var item in items)
            {
                for (int i = 0; i < item.miktar; i++)
                {
                    allPieces.Add(new SatinalmaTalepDetay { miktar = item.miktar, projeStokKart = _convertHelper.ToEntity<ProjeStokKart>(item) });
                }
            }

            // 2) Parçaları boydan küçüğe sırala
            var sorted = allPieces.OrderByDescending(x => x.projeStokKart.stokKart.uzunluk).ToList();

            // Bin sınıfı - her stoğun durumunu takip eder
            var bins = new List<BinInfo>();

            // 3) Best Fit Decreasing ile yerleştirme
            foreach (var piece in sorted)
            {
                BinInfo bestBin = null;
                double bestRemainingSpace = double.MaxValue;

                // Mevcut stoklarda en uygun yeri bul
                foreach (var bin in bins)
                {
                    double requiredSpace = piece.projeStokKart.stokKart.uzunluk.Value + (bin.Pieces.Count > 0 ? kerf : 0);
                    double remainingSpace = bin.RemainingSpace - requiredSpace;

                    // Parça sığıyor mu?
                    if (remainingSpace >= 0)
                    {
                        // En az fire bırakacak stoğu seç
                        if (remainingSpace < bestRemainingSpace)
                        {
                            bestRemainingSpace = remainingSpace;
                            bestBin = bin;
                        }
                    }
                }

                // Uygun stok bulunduysa yerleştir
                if (bestBin != null)
                {
                    bestBin.AddPiece(piece, kerf);
                }
                else
                {
                    // Yeni stok aç
                    var newBin = new BinInfo(stockLength);
                    newBin.AddPiece(piece, kerf);
                    bins.Add(newBin);
                }
            }

            // 4) İkinci geçiş: Küçük parçaları fire alanlarına yerleştirmeye çalış
            if (usableWasteMinLength > 0)
            {
                OptimizeWithWasteReuse(bins, sorted, kerf, usableWasteMinLength);
            }

            // 5) Sonuçları hesapla
            var result = new CuttingOptimizationResult
            {
                Bins = bins.Select(b => b.Pieces).ToList(),
                TotalStocksUsed = bins.Count,
                TotalWaste = bins.Sum(b => b.RemainingSpace),
                UsableWaste = bins.Count(b => b.RemainingSpace >= usableWasteMinLength) * usableWasteMinLength,
                WastePercentage = (bins.Sum(b => b.RemainingSpace) / (bins.Count * stockLength)) * 100
            };

            return result;
        }
        public CuttingOptimizationResult OptimizedCutting(
            List<SatinalmaTalepDetay> items,
            double stockLength,
            int kerf,
            double usableWasteMinLength = 0) // Minimum kullanılabilir fire uzunluğu
        {
            // 1) Tüm parçaları adetlerine göre aç
            var allPieces = new List<SatinalmaTalepDetay>();
            foreach (var item in items)
            {
                for (int i = 0; i < item.miktar; i++)
                {
                    allPieces.Add(new SatinalmaTalepDetay { miktar = item.miktar, projeStokKart = item.projeStokKart });
                }
            }

            // 2) Parçaları boydan küçüğe sırala
            var sorted = allPieces.OrderByDescending(x => x.projeStokKart.stokKart.uzunluk).ToList();

            // Bin sınıfı - her stoğun durumunu takip eder
            var bins = new List<BinInfo>();

            // 3) Best Fit Decreasing ile yerleştirme
            foreach (var piece in sorted)
            {
                BinInfo bestBin = null;
                double bestRemainingSpace = double.MaxValue;

                // Mevcut stoklarda en uygun yeri bul
                foreach (var bin in bins)
                {
                    double requiredSpace = piece.projeStokKart.stokKart.uzunluk.Value + (bin.Pieces.Count > 0 ? kerf : 0);
                    double remainingSpace = bin.RemainingSpace - requiredSpace;

                    // Parça sığıyor mu?
                    if (remainingSpace >= 0)
                    {
                        // En az fire bırakacak stoğu seç
                        if (remainingSpace < bestRemainingSpace)
                        {
                            bestRemainingSpace = remainingSpace;
                            bestBin = bin;
                        }
                    }
                }

                // Uygun stok bulunduysa yerleştir
                if (bestBin != null)
                {
                    bestBin.AddPiece(piece, kerf);
                }
                else
                {
                    // Yeni stok aç
                    var newBin = new BinInfo(stockLength);
                    newBin.AddPiece(piece, kerf);
                    bins.Add(newBin);
                }
            }

            // 4) İkinci geçiş: Küçük parçaları fire alanlarına yerleştirmeye çalış
            if (usableWasteMinLength > 0)
            {
                OptimizeWithWasteReuse(bins, sorted, kerf, usableWasteMinLength);
            }

            // 5) Sonuçları hesapla
            var result = new CuttingOptimizationResult
            {
                Bins = bins.Select(b => b.Pieces).ToList(),
                TotalStocksUsed = bins.Count,
                TotalWaste = bins.Sum(b => b.RemainingSpace),
                UsableWaste = bins.Count(b => b.RemainingSpace >= usableWasteMinLength) * usableWasteMinLength,
                WastePercentage = (bins.Sum(b => b.RemainingSpace) / (bins.Count * stockLength)) * 100
            };

            return result;
        }
        private void OptimizeWithWasteReuse(
            List<BinInfo> bins,
            List<SatinalmaTalepDetay> allPieces,
            int kerf,
            double usableWasteMinLength)
        {
            // Fire alanlarını büyükten küçüğe sırala
            var binsWithUsableWaste = bins
                .Where(b => b.RemainingSpace >= usableWasteMinLength)
                .OrderByDescending(b => b.RemainingSpace)
                .ToList();

            // Kullanılmayan küçük parçaları bul
            var unusedSmallPieces = allPieces
                .Where(p => p.projeStokKart.stokKart.uzunluk <= usableWasteMinLength)
                .OrderByDescending(p => p.projeStokKart.stokKart.uzunluk)
                .ToList();

            foreach (var wasteBin in binsWithUsableWaste)
            {
                foreach (var smallPiece in unusedSmallPieces.ToList())
                {
                    double requiredSpace = smallPiece.projeStokKart.stokKart.uzunluk.Value + kerf;
                    if (wasteBin.RemainingSpace >= requiredSpace)
                    {
                        // Not: Gerçek uygulamada bu parçanın başka bir bin'den çıkarılması gerekebilir
                        // Bu basitleştirilmiş versiyon sadece konsepti gösteriyor
                    }
                }
            }
        }
    }
}
