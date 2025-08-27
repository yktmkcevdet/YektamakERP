using ApiService.Interfaces;
using Models;
using Models.DTO;
using System;
using System.Linq;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.Formlar.Stok;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class StokGrupTanimlari : Form
    {
        private readonly ICache _cache;
        private readonly IStokService _stokService;
        public StokGrupTanimlari(ICache cache, IStokService stokService)
        {
            _stokService = stokService;
            _cache = cache;
            InitializeComponent();
        }
       
        private void StokGrupTanimlari_Load(object sender, EventArgs e)
        {
            foreach (var stokGrup in _cache.stokGrups)
            {
                TreeNode stokNode = new TreeNode(stokGrup.ad);
                stokNode.Name = stokGrup.Id.ToString();
                foreach (var malzemeGrup in _cache.malzemeGrups.Where(m => m.stokGrup.Id == stokGrup.Id))
                {
                    TreeNode malzemeNode = new TreeNode(malzemeGrup.ad);
                    malzemeNode.Name = malzemeGrup.Id.ToString();
                    stokNode.Nodes.Add(malzemeNode);
                    foreach (var malzemeAltGrup in _cache.malzemeAltGrups.Where(m => m.malzemeGrup.Id == malzemeGrup.Id))
                    {
                        TreeNode malzemeAltGrupNode = new TreeNode(malzemeAltGrup.ad);
                        malzemeAltGrupNode.Name = malzemeAltGrup.Id.ToString();
                        malzemeNode.Nodes.Add(malzemeAltGrupNode);
                        foreach (var malzemeAltGrup2 in _cache.malzemeAltGrup2List.Where(m => m.malzemeAltGrup.Id == malzemeAltGrup.Id))
                        {
                            TreeNode malzemeAltGrup2Node = new TreeNode(malzemeAltGrup2.ad);
                            malzemeAltGrup2Node.Name = malzemeAltGrup2.Id.ToString();
                            malzemeAltGrupNode.Nodes.Add(malzemeAltGrup2Node);
                        }
                    }
                }
                treeView1.Nodes.Add(stokNode);
            }
        }
        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            treeView1.SelectedNode = treeView1.HitTest(e.X, e.Y).Node;
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(treeView1, e.X, e.Y);
            }
            if (e.Button == MouseButtons.Left)
            {
                var node = treeView1.SelectedNode;
                switch (node.Level)
                {
                    case 0:
                        {
                            StokGrup stokGrup = _cache.stokGrups.FirstOrDefault(s=>s.Id==int.Parse(node.Name));
                            var stokGrupTanimFormu = FormFactory.CreateForm<StokGrupTanimFormu>();
                            stokGrupTanimFormu.UpdateMode(stokGrup);
                            stokGrupTanimFormu.TopLevel = false;
                            stokGrupTanimFormu.Dock = DockStyle.Fill;
                            stokGrupTanimFormu.AfterSave += StokGrupTanimFormu_AfterSave;
                            panel1.Controls.Clear();
                            panel1.Controls.Add(stokGrupTanimFormu);
                            stokGrupTanimFormu.Show();
                            var excelGrupParametreForm = FormFactory.CreateForm<ExcelGrupParametreForm>();
                            ExcelGrupParametre excelGrupParametre = new ExcelGrupParametre { stokGrupId = int.Parse(node.Name) };
                            excelGrupParametreForm.TopLevel = false;
                            excelGrupParametreForm.Dock = DockStyle.Fill;
                            panel2.Controls.Clear();
                            panel2.Controls.Add(excelGrupParametreForm);
                            excelGrupParametreForm.Show();
                            excelGrupParametreForm.Filter(excelGrupParametre);
                            break;
                        }
                    case 1:
                        {
                            MalzemeGrupDTO malzemeGrup = _cache.malzemeGrups.CastToDTO<MalzemeGrupDTO>().ToList().FirstOrDefault(m=>m.Id==int.Parse(node.Name));
                            var malzemeGrupTanimFormu = FormFactory.CreateForm<MalzemeGrupTanimFormu>();
                            malzemeGrupTanimFormu.UpdateMode(malzemeGrup);
                            malzemeGrupTanimFormu.TopLevel = false;
                            malzemeGrupTanimFormu.Dock = DockStyle.Fill;
                            malzemeGrupTanimFormu.AfterSave += MalzemeGrupTanimFormu_AfterSave;
                            panel1.Controls.Clear();
                            panel1.Controls.Add(malzemeGrupTanimFormu);
                            malzemeGrupTanimFormu.Show();
                            var excelGrupParametreForm=FormFactory.CreateForm<ExcelGrupParametreForm>();
                            ExcelGrupParametre excelGrupParametre = new ExcelGrupParametre { malzemeGrupId = int.Parse(node.Name) };
                            excelGrupParametreForm.TopLevel=false;
                            excelGrupParametreForm.Dock = DockStyle.Fill;
                            panel2.Controls.Clear();
                            panel2.Controls.Add(excelGrupParametreForm);
                            excelGrupParametreForm.Show();
                            excelGrupParametreForm.Filter(excelGrupParametre);
                            break;
                        }
                    case 2:
                        {
                            MalzemeAltGrup malzemeAltGrup = _cache.malzemeAltGrups.FirstOrDefault(m => m.Id == int.Parse(node.Name));
                            var malzemeAltGrupTanimFormu = FormFactory.CreateForm<MalzemeAltGrupTanimFormu>();
                            malzemeAltGrupTanimFormu.UpdateMode(ConvertHelper.ToDTO<MalzemeAltGrupDTO>(malzemeAltGrup));
                            malzemeAltGrupTanimFormu.TopLevel = false;
                            malzemeAltGrupTanimFormu.Dock = DockStyle.Fill;
                            panel1.Controls.Clear();
                            panel1.Controls.Add(malzemeAltGrupTanimFormu);
                            malzemeAltGrupTanimFormu.Show();
                            var excelGrupParametreForm = FormFactory.CreateForm<ExcelGrupParametreForm>();
                            ExcelGrupParametre excelGrupParametre = new ExcelGrupParametre { malzemeAltGrupId = int.Parse(node.Name) };
                            excelGrupParametreForm.TopLevel = false;
                            excelGrupParametreForm.Dock = DockStyle.Fill;
                            panel2.Controls.Clear();
                            panel2.Controls.Add(excelGrupParametreForm);
                            excelGrupParametreForm.Show();
                            excelGrupParametreForm.Filter(excelGrupParametre);
                            break;
                        }
                    case 3:
                        {
                            MalzemeAltGrup2 malzemeAltGrup2 = _cache.malzemeAltGrup2List.FirstOrDefault(m => m.Id == int.Parse(node.Name));
                            var malzemeAltGrup2TanimFormu = FormFactory.CreateForm<MalzemeAltGrup2TanimFormu>();
                            malzemeAltGrup2TanimFormu.UpdateMode(malzemeAltGrup2);
                            malzemeAltGrup2TanimFormu.TopLevel = false;
                            malzemeAltGrup2TanimFormu.Dock = DockStyle.Fill;
                            panel1.Controls.Clear();
                            panel1.Controls.Add(malzemeAltGrup2TanimFormu);
                            malzemeAltGrup2TanimFormu.Show();
                            var excelGrupParametreForm = FormFactory.CreateForm<ExcelGrupParametreForm>();
                            ExcelGrupParametre excelGrupParametre = new ExcelGrupParametre { malzemeAltGrup2Id = int.Parse(node.Name) };
                            excelGrupParametreForm.TopLevel = false;
                            excelGrupParametreForm.Dock = DockStyle.Fill;
                            panel2.Controls.Clear();
                            panel2.Controls.Add(excelGrupParametreForm);
                            excelGrupParametreForm.Show();
                            excelGrupParametreForm.Filter(excelGrupParametre);
                            break;
                        }
                }
            }
        }

        

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var node = treeView1.SelectedNode;
            DialogResult dialogResult = MessageBox.Show($"{node.Text} grubunu silmek istediğinizden emin misiniz?","Silme Onayı",MessageBoxButtons.OKCancel);
            if (node != null && dialogResult == DialogResult.OK)
            {
                switch (node.Level)
                {
                    case 0:
                        {
                            StokGrup stokGrup = new StokGrup { Id = int.Parse(node.Name) };
                            _stokService.DeleteStokGrup(stokGrup);
                            _cache.stokGrups.Remove(_cache.stokGrups.FirstOrDefault(s => s.Id == stokGrup.Id));
                            treeView1.Nodes.Remove(node);
                            break;
                        }
                    case 1:
                        {
                            MalzemeGrup malzemeGrup = new MalzemeGrup { Id = int.Parse(node.Name) };
                            _stokService.DeleteMalzemeGrup(malzemeGrup);
                            _cache.malzemeGrups.Remove(_cache.malzemeGrups.FirstOrDefault(s => s.Id == malzemeGrup.Id));
                            treeView1.Nodes.Remove(node);
                            break;
                        }
                    case 2:
                        {
                            MalzemeAltGrup malzemeAltGrup = new MalzemeAltGrup { Id = int.Parse(node.Name) };
                            _stokService.DeleteMalzemeAltGrup(malzemeAltGrup);
                            _cache.malzemeAltGrups.Remove(_cache.malzemeAltGrups.FirstOrDefault(s => s.Id == malzemeAltGrup.Id));
                            treeView1.Nodes.Remove(node);
                            break;
                        }
                    case 3:
                        {
                            MalzemeAltGrup2 malzemeAltGrup2 = new MalzemeAltGrup2 { Id = int.Parse(node.Name) };
                            _stokService.DeleteMalzemeAltGrup2(malzemeAltGrup2);
                            _cache.malzemeAltGrup2List.Remove(_cache.malzemeAltGrup2List.FirstOrDefault(s => s.Id == malzemeAltGrup2.Id));
                            treeView1.Nodes.Remove(node);
                            break;
                        }
                }
            }

        }

        private void altınaGrupEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = treeView1.SelectedNode;
            if (node != null)
            {
                switch (node.Level)
                {
                    case 0:
                        {
                            MalzemeGrupDTO malzemeGrup = new MalzemeGrupDTO { stokGrupId = int.Parse(node.Name)  };
                            var malzemeGrupTanimFormu= FormFactory.CreateForm<MalzemeGrupTanimFormu>();
                            malzemeGrupTanimFormu.UpdateMode(malzemeGrup);
                            malzemeGrupTanimFormu.TopLevel = false;
                            malzemeGrupTanimFormu.Dock = DockStyle.Fill;
                            malzemeGrupTanimFormu.AfterSave += MalzemeGrupTanimFormu_AfterSave;
                            panel1.Controls.Clear();
                            panel1.Controls.Add(malzemeGrupTanimFormu);
                            malzemeGrupTanimFormu.Show();
                            break;
                        }
                    case 1:
                        {
                            MalzemeAltGrup malzemeAltGrup = new MalzemeAltGrup { malzemeGrup = { Id = int.Parse(node.Name), stokGrup = { Id=int.Parse(node.Parent.Name) } } };
                            var malzemeAltGrupTanimFormu = FormFactory.CreateForm<MalzemeAltGrupTanimFormu>();
                            malzemeAltGrupTanimFormu.UpdateMode(ConvertHelper.ToDTO<MalzemeAltGrupDTO>(malzemeAltGrup));
                            malzemeAltGrupTanimFormu.TopLevel = false;
                            malzemeAltGrupTanimFormu.Dock = DockStyle.Fill;
                            malzemeAltGrupTanimFormu.AfterSave += MalzemeAltGrupTanimFormu_AfterSave;
                            panel1.Controls.Clear();
                            panel1.Controls.Add(malzemeAltGrupTanimFormu);
                            malzemeAltGrupTanimFormu.Show();
                            break;
                        }
                    case 2:
                        {
                            MalzemeAltGrup2 malzemeAltGrup2 = new MalzemeAltGrup2 { malzemeAltGrup = { Id = int.Parse(node.Name), malzemeGrup = { Id = int.Parse(node.Parent.Name), stokGrup = { Id = int.Parse(node.Parent.Parent.Name) } } } };
                            var malzemeAltGrup2TanimFormu = FormFactory.CreateForm<MalzemeAltGrup2TanimFormu>();
                            malzemeAltGrup2TanimFormu.UpdateMode(malzemeAltGrup2);
                            malzemeAltGrup2TanimFormu.TopLevel = false;
                            malzemeAltGrup2TanimFormu.Dock = DockStyle.Fill;
                            malzemeAltGrup2TanimFormu.AfterSave += MalzemeAltGrup2TanimFormu_AfterSave;
                            panel1.Controls.Clear();
                            panel1.Controls.Add(malzemeAltGrup2TanimFormu);
                            malzemeAltGrup2TanimFormu.Show();
                            break;
                        }
                }
            }
        }
        private void MalzemeGrupTanimFormu_AfterSave(object sender, object e)
        {
            var malzemeGrup = (MalzemeGrupDTO)e;
            foreach(var existNode in treeView1.Nodes.Find(malzemeGrup.Id.ToString(), true))
            {
                if (existNode.Level == 1)
                {
                    existNode.Text=malzemeGrup.ad;
                    return;
                }
            }
            TreeNode node = new TreeNode(malzemeGrup.ad);
            node.Name = malzemeGrup.Id.ToString();
            treeView1.SelectedNode.Nodes.Add(node);
        }
        private void StokGrupTanimFormu_AfterSave(object sender, object e)
        {
            var stokGrup = (StokGrup)e;
            foreach (var existNode in treeView1.Nodes.Find(stokGrup.Id.ToString(), true))
            {
                if (existNode.Level == 0)
                {
                    existNode.Text = stokGrup.ad;
                    return;
                }
            }
            TreeNode node = new TreeNode(stokGrup.ad);
            node.Name = stokGrup.Id.ToString();
            treeView1.SelectedNode.Nodes.Add(node);
        }
        private void MalzemeAltGrupTanimFormu_AfterSave(object sender, object e)
        {
            var malzemeAltGrup = (MalzemeAltGrup)e;
            foreach (var existNode in treeView1.Nodes.Find(malzemeAltGrup.Id.ToString(), true))
            {
                if (existNode.Level == 1)
                {
                    existNode.Text = malzemeAltGrup.ad;
                    return;
                }
            }
            TreeNode node = new TreeNode(malzemeAltGrup.ad);
            node.Name = malzemeAltGrup.Id.ToString();
            treeView1.SelectedNode.Nodes.Add(node);
        }
        private void MalzemeAltGrup2TanimFormu_AfterSave(object sender, object e)
        {
            var malzemeAltGrup2 = (MalzemeAltGrup2)e;
            foreach (var existNode in treeView1.Nodes.Find(malzemeAltGrup2.Id.ToString(), true))
            {
                if (existNode.Level == 1)
                {
                    existNode.Text = malzemeAltGrup2.ad;
                    return;
                }
            }
            TreeNode node = new TreeNode(malzemeAltGrup2.ad);
            node.Name = malzemeAltGrup2.Id.ToString();
            treeView1.SelectedNode.Nodes.Add(node);
        }
    }
}
