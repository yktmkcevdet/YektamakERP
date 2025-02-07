using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class DovizKurlari : Form
    {
        public DovizKurlari()
        {
            InitializeComponent();
        }

        private async void roundedButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // TCMB Döviz Kurları API URL'si
                string apiUrl = "https://www.tcmb.gov.tr/kurlar/today.xml";

                // Web isteği oluştur
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Clear();
                // TCMB'den verileri al
                var response = await client.GetAsync(apiUrl);
                var strResponse = await response.Content.ReadAsStringAsync();
                
                // XML verisini işle
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(strResponse);

                // Döviz kurlarını çek
                XmlNodeList currencyNodes = xmlDoc.SelectNodes("//Currency");
                foreach (XmlNode currencyNode in currencyNodes)
                {
                    //string currencyCode = currencyNode.SelectSingleNode("CuurencyName").InnerText;
                    string currencyName = currencyNode.SelectSingleNode("Isim").InnerText;
                    string buyingRate = currencyNode.SelectSingleNode("BanknoteBuying").InnerText;
                    string sellingRate = currencyNode.SelectSingleNode("BanknoteSelling").InnerText;

                    //Console.WriteLine($"Döviz Kodu: {currencyCode}");
                    //Console.WriteLine($"Döviz Adı: {currencyName}");
                    //Console.WriteLine($"Alış Kuru: {buyingRate}");
                    //Console.WriteLine($"Satış Kuru: {sellingRate}");
                    //Console.WriteLine("-----------------------------");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }
    }
}
