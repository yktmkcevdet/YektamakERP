using ApiService.Implementations;
using ApiService.Interfaces;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YektamakDesktop.Formlar
{
    public partial class UpdateVersion : Form
    {
        private readonly string setupUrl = "http://172.16.9.160:8080/Download/YektamakERP_Setup.exe"; // Güncelleme dosyasının URL'si
        public UpdateVersion()
        {
            InitializeComponent();
            Load += async(s,e)=>  await UpdateVersion_Load(s,e);
        }
        async Task StartUpdateWithProgressAsync(string setupUrl)
        {
            var tempPath = Path.Combine(
                Path.GetTempPath(),
                "YektamakERP_Setup.exe");

            progressBar1.Value = 0;
            progressBar1.Visible = true;
            lblStatus.Visible = true;
            lblStatus.Text = "Güncelleme indiriliyor...";

            var progress = new Progress<int>(percent =>
            {
                progressBar1.Value = percent;
                lblStatus.Text = $"İndiriliyor... %{percent}";
            });
            try
            {
                await DownloadWithProgressAsync(setupUrl, tempPath, progress);

                lblStatus.Text = "Kurulum başlatılıyor...";

                Process.Start(new ProcessStartInfo
                {
                    FileName = tempPath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Güncelleme indirilemedi.\n\n" + ex.Message,
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Application.Exit();
            }
        }
        async Task DownloadWithProgressAsync(string downloadUrl, string destinationPath, IProgress<int> progress)
        {
            using var http = new HttpClient();
            using var response = await http.GetAsync(
                downloadUrl,
                HttpCompletionOption.ResponseHeadersRead);

            response.EnsureSuccessStatusCode();
            var totalBytes = response.Content.Headers.ContentLength ?? -1L;
            var canReportProgress = totalBytes != -1;

            await using var contentStream =
                await response.Content.ReadAsStreamAsync();

            await using var fileStream =
                new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None);

            var buffer = new byte[81920];
            long totalRead = 0;
            int read;

            while ((read = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
            {
                await fileStream.WriteAsync(buffer, 0, read);
                totalRead += read;

                if (canReportProgress)
                {
                    int percent = (int)((totalRead * 100L) / totalBytes);
                    progress.Report(percent);
                }
            }
        }

        private async Task UpdateVersion_Load(object sender, EventArgs e)
        {
            await StartUpdateWithProgressAsync(setupUrl);
        }
    }
}
