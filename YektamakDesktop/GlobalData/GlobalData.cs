using ApiService.Interfaces;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Utilities.Interfaces;
using YektamakDesktop.Abstracts;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar;

namespace YektamakDesktop
{
    public partial class GlobalData
    {
        private static ICache _cache;
        private static IJsonConverter _converter;
        private static IDataTableMapper _dataTableHelper;
        private static IKullaniciYetkiService _kullaniciYetkiService;
        private static IConvertHelper _convertHelper;
        public GlobalData(ICache cache,IJsonConverter jsonConverter,IDataTableMapper dataTableHelper, IKullaniciYetkiService kullaniciYetkiService,
                            IConvertHelper convertHelper)
        {
            _cache = cache;
            _converter = jsonConverter;
            _dataTableHelper = dataTableHelper;
            _kullaniciYetkiService = kullaniciYetkiService;
            _convertHelper = convertHelper;
        }
        public static List<string> ibanErrorList;
        
        /// <summary>
        /// Kendi firmamızın id'si
        /// </summary>
        public static int kendiFirmaId;
        /// <summary>
        /// Geride kalan formun disable edilmesi için kullanılacak.
        /// Bir form başka bir formu çağırdığında kendini disable edip bu listeye ekleyecek
        /// Kendini çağıran forma veri göndermek için de kullanılabilir.
        /// Bir form kapanırken kendinden önceki formu aktif edip stack'ten çıkaracak
        /// Liste AnaSayfa tarafından başlatılacak
        /// </summary>
        public static Stack<Form> activeFormStack;
        public static void Start()
        {
            activeFormStack= new Stack<Form>();
        }
        /// <summary>
        /// Son eklenen form enabled olur. Ondan önce eklenen formlar disabled olur
        /// </summary>
        /// <param name="form"></param>
        public static void AddNewForm(Form form)
        {
            foreach (Form _form in activeFormStack)
            {
                if (_form is IForm iForm)
                {
                    foreach (Control control in iForm.controlsToDisable)
                    {
                        control.Enabled = false;
                    }
                    iForm.activeForm = false;
                }
                else
                {
                    _form.Enabled = false;
                }
            }
            if (form is IForm iForm2)
            {                
                foreach (Control control in form.Controls)
                {
                    control.Enabled = true;
                }
                iForm2.activeForm = true;
            }
            else
            {
                form.Enabled = true;
            }
            activeFormStack.Push(form);
            form.BringToFront();
        }
        /// <summary>
        /// Son eklenen formu stack'ten çıkarır. Varsa ondan bir önceki formu aktif eder ve öne getirir.
        /// </summary>
        public static void RemoveLastForm()
        {
            if (activeFormStack!=null && activeFormStack.Count>1)
            {
            activeFormStack.Pop();           
                Form tempForm = activeFormStack.Peek();
                if (tempForm is IForm iForm)
                {
                    foreach (Control control in iForm.controlsToDisable)
                    {
                        control.Enabled = true;
                    }
                    iForm.activeForm = true;
                }
                else
                {
                    activeFormStack.Peek().Enabled = true;
                }
                tempForm.BringToFront();
            }
        }
        
        public static void HandleException(Action action) 
        {
            try
            {
                action.Invoke();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }
        /// <summary>
        /// Kullanıcının form için yetkisinin olup olmadığı kontrolünü yapar. Ywtkisi varsa formu activeFormStack listesine ekler.
        /// Yetkisi yoksa formun değişken değerini null yapar ve form açılmaz.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="form"></param>
        /// <returns></returns>
        public static bool Yetki<T>(ref T form) where T : Form
        {
            bool yetki = false;
            DataSet dataSet = _converter.DeserializeToDataSet(_kullaniciYetkiService.GetKullaniciYetki(_cache.kullanici));
            if (dataSet.Tables[1].Select("Id is not null and FormAd='" + form.Name + "'").Count() > 0)
            {
                yetki = true;
                GlobalData.AddNewForm(form);
            }
            else
            {
                form = null;
                MessageBox.Show("Bu işlem için yetkiniz yok");
            }
            return yetki;
        }
        
        private static Label WarningLabel(string mesaj,Control control)
        {
            Label warningLabel = new Label();
            warningLabel.Text = mesaj;
            warningLabel.Font = new Font("Segoe UI Semibold", 9, FontStyle.Bold);
            warningLabel.ForeColor = Color.Red;
            warningLabel.Left = control.Left + control.Width + 2;
            warningLabel.Top = control.Top;
            warningLabel.Tag = "warningLabel";
            warningLabel.AutoSize = true;
            warningLabel.Visible = true;
            warningLabel.BringToFront();
            return warningLabel;
        }
        public static bool CheckField(string mesaj, CustomTextBox customTextBox)
        {
            bool result = true;

            object value = customTextBox.TextCustom;

            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                customTextBox.textBox.ForeColor = Color.Red;
                customTextBox.textBox.BackColor = Color.LightPink;
                customTextBox.PlaceholderText = mesaj;
                result = false;
            }
            return result;
        }
        
        public static bool CheckField(string mesaj, CustomComboListBox customComboListBox) 
        {
            bool result = true;

            object value = customComboListBox.selectedDataRowId;

            if (customComboListBox.listBoxDataRows.Count>0 && (value == null || value.ToString()=="-1" || string.IsNullOrWhiteSpace(value.ToString())))
            {
                customComboListBox.textBox.textBox.ForeColor = Color.LightPink;
                customComboListBox.textBox.PlaceholderText = mesaj;
                result = false;
            }
            return result;
        }
        public static bool CheckField(string mesaj,  FilterableComboBox filterableComboBox)
        {
            bool result = true;
            int kayitSayisi = (filterableComboBox.DataSource as IList)?.Count ?? 0;
            if (kayitSayisi == 0) return result;
            object value = filterableComboBox.SelectedValue;

            if (value == null || JsonConvert.SerializeObject(value) == "-1" || string.IsNullOrWhiteSpace(value.ToString()))
            {
                filterableComboBox.ComboBox.BackColor = Color.LightPink;
                filterableComboBox.PlaceholderText = mesaj;
                result = false;
            }
            return result;
        }
        
        public static bool CheckField(string mesaj,  TextBox textBox)
        {
            bool result = true;

            object value = textBox.Text;

            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                textBox.BackColor = Color.LightPink;
                textBox.PlaceholderText = mesaj;
                result = false;
            }
            return result;
        }
        public static bool CheckField(string mesaj, CustomTextBoxTarih customTextBoxTarih)
        {
            bool result = true;

            object value = customTextBoxTarih.TextCustom;

            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                customTextBoxTarih.textBox.BackColor = Color.LightPink;
                customTextBoxTarih.textBox.PlaceholderText = mesaj;
                result = false;
            }
            return result;
        }
        public static bool CheckField<T>(string mesaj, CustomDataGrid<T> customDataGrid) where T : DataControl,new()
        {
            bool result = true;

            int value = customDataGrid.dataSource.Where(x => x.newRec == false).Count();

            if (value == 0)
            {
               MessageBox.Show(mesaj, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }
            return result;
        }
        public static bool CheckField(string mesaj, CustomTextBoxSayisal customTextBoxSayisal) 
        {
            bool result = true;

            float value = float.TryParse(customTextBoxSayisal.TextCustom.ToString(), out float sayi)?sayi:0;

            if (value == 0)
            {
                customTextBoxSayisal.textBox.BackColor = Color.LightPink;
                customTextBoxSayisal.textBox.PlaceholderText = mesaj;
                result = false;
            }
            return result;
        }
        public static bool CheckField<T>(string mesaj, T form, CustomCheckedComboBox customCheckedComboBox) where T : Form
        {
            bool result = true;

            if (customCheckedComboBox.checkedCount==0)
            {
                customCheckedComboBox.BackColor = Color.LightPink;
                form.Controls.Add(WarningLabel(mesaj, customCheckedComboBox));
                result = false;
            }
            return result;
        }
        public static void ClearWarningLabels<T>(T form) where T : Control
        {
            var controlsToRemove = new List<Control>();
            foreach (Control ctrl in form.Controls)
            {
                if (ctrl.Tag != null && ctrl.Tag.ToString() == "warningLabel")
                    controlsToRemove.Add(ctrl);
            }

            foreach (Control ctrl in controlsToRemove)
            {
                form.Controls.Remove(ctrl);
                ctrl.Dispose();
            }
        }
        
        /// <summary>
        /// IForm tipindeki formlar kapatılırken yapılacak işlemleri yapar.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="form"></param>
        public static void CloseForm<T>(ref T form) where T : Form
        {
            form.Close();
            form.Dispose();
            form = null;
            GlobalData.RemoveLastForm();
        }
        public static bool CompareClass<T>(T class1,T class2) 
        {
            bool result;
            string a = JsonConvert.SerializeObject(class1);
            string b = JsonConvert.SerializeObject(class2);
            if (a == b) 
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;

        }
    }

    public static class ListBoxStringFormat
    {
        //public string text;
        //public int totalSpace;
        //public HorizontalAlignment alignment;

        /// <summary>
        /// totalSpace kadar bir alana text'i sığdırır
        /// diğer alanları boşluk karakteri ile doldurur</summary>
        /// <param name="input"></param>
        /// <param name="totalSpace"></param>
        /// <param name="alignment"></param>
        /// <returns></returns>
        public static string FormatString(string input, int totalSpace, HorizontalAlignment alignment)
        {
            string result = "";
            if (input == null) return result;
            int stringLength = input.Length;
            
            if (stringLength > totalSpace)
                return input;

            int difference = totalSpace - stringLength;
            switch (alignment)
            {
                case HorizontalAlignment.Left:
                    result = $"{input}{new string(' ', difference)}";
                    break;
                case HorizontalAlignment.Right:
                    result = $"{new String(' ', difference)}{input}";
                    break;
                case HorizontalAlignment.Center:
                    int halfDiff = (int)Math.Floor(difference / 2.0);
                    result = $"{new String(' ', halfDiff)}{input}{new String(' ', (halfDiff + difference % 2))}";
                    break;
                default:
                    break;
            }
            return result;
        }
    }
	
	public enum IbanPrefix
    {
        TR=0
    }
}
