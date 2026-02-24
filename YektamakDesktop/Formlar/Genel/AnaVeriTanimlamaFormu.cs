using ApiService.Interfaces;
using Models.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Utilities.Interfaces;

namespace YektamakDesktop.Formlar.Genel
{
    public partial class AnaVeriTanimlamaFormu<T> : Form where T : class,IBaseEntity, new()
    {
        private T _entity;
        DataGridView dataGridView;
        private readonly ICache _cache;
        private readonly IAnaVeriService _anaVeriService;
        public AnaVeriTanimlamaFormu(ICache cache, IAnaVeriService anaVeriService)
        {
            _cache = cache;
            _anaVeriService = anaVeriService;
            InitializeComponent();
            CreateDynamicControls();
        }

        

        public AnaVeriTanimlamaFormu()
        {
            InitializeComponent();
            CreateDynamicControls();
        }

        private void buttomMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void rButtonKaydet_Click(object sender, EventArgs e)
        {
            _entity = new T();
            var properties = typeof(T).GetProperties();
            foreach (var prop in properties)
            {
                var txtBox = this.Controls.OfType<TextBox>().FirstOrDefault(t => t.Name == "txt" + prop.Name);
                if (txtBox != null)
                {
                    var value = Convert.ChangeType(txtBox.Text, prop.PropertyType);
                    prop.SetValue(_entity, value);
                }
            }
            if (typeof(T) == _entity.GetType())
            {
                string methodName = "Save"+typeof(T).Name;
                MethodInfo methodInfo=_anaVeriService.GetType().GetMethod(methodName);
                object[] objects = { _entity };
                if (methodInfo != null)
                {
                    methodInfo.Invoke(_anaVeriService,objects);
                }
                string listName = typeof(T).Name + "List";
                object[] param = { listName[0].ToString().ToLower() + listName.Substring(1, listName.Length-1) };
                PropertyInfo propertyInfo = _cache.GetType().GetProperty(param[0].ToString());
                MethodInfo method = propertyInfo.PropertyType.GetMethod("Add");
                object[] objects1 = { _entity };
                object list = propertyInfo.GetValue(_cache);
                method.Invoke(list, objects1);
                dataGridView.DataSource = null;
                dataGridView.DataSource = propertyInfo.GetValue(_cache);
            }
            MessageBox.Show($"{typeof(T).Name} başarıyla kaydedildi!");

        }
        private void CreateDynamicControls()
        {
            int yPosition = 50; // İlk kontrolün başlangıç noktası
            var properties = typeof(T).GetProperties();

            foreach (var prop in properties)
            {
                Label lbl = new Label
                {
                    Text = prop.Name,
                    Location = new Point(60, yPosition),
                    Width = 100
                };
                this.Controls.Add(lbl);

                TextBox txt = new TextBox
                {
                    Name = "txt" + prop.Name,
                    Location = new Point(170, yPosition),
                    Width = 200
                };
                this.Controls.Add(txt);

                yPosition += 30; // Bir sonraki kontrolün konumu
            }
            Button button = new Button
            {
                Name = "rButtonKaydet",
                Location = new Point(200, yPosition),
                Width = 70,
                Text="Kaydet"
            };
            button.Click += rButtonKaydet_Click;
            this.Controls.Add(button);

            yPosition += 30;
            labelHeader.Text=typeof(T).Name+" Ekle";

            dataGridView = new DataGridView
            {
                Location = new Point(30, yPosition),
                Size= new Size(400, 300)
            };
            string listName = typeof(T).Name+"List";
            object[] param ={ listName[0].ToString().ToLower() + listName.Substring(1, listName.Length-1)};
            PropertyInfo propertyInfo = _cache.GetType().GetProperty(param[0].ToString());
            dataGridView.DataSource = propertyInfo.GetValue(_cache, null);
            this.Controls.Add(dataGridView);
        }
    }
    
}
