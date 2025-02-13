using ApiService;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Implementations;
using Utilities.Interfaces;
using YektamakDesktop.Common;
using YektamakDesktop.CustomControls;
using YektamakDesktop.Formlar;

namespace YektamakDesktop
{
    public partial class GlobalData
    {
        private static ICache _cache;
        private static IJsonConvertHelper _converter;
        public GlobalData(ICache cache,IJsonConvertHelper jsonConverter)
        {
            _cache = cache;
            _converter = jsonConverter;
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
            activeFormStack.Pop();            
            if (activeFormStack.Count>0)
            {
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
        
        public static string HashPassword(string password, string salt)
        {
            using var sha256 = SHA256.Create();
            var saltedPassword = password + salt;
            var bytes = Encoding.UTF8.GetBytes(saltedPassword);
            var hash = sha256.ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
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
            DataSet dataSet = _converter.JsonStringToDataSet(WebMethods.GetKullaniciYetki(_cache.kullanici));
            if (dataSet.Tables[1].Select("Id is not null and FormAdi='" + form.Name + "'").Count() > 0)
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
        /// <summary>
        /// web isteklerinden dönen json değerlerini dataset nesnesine dönüştürür
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
       
        public static T GetModelFromDatabase<T>(Func<T,string> func,T model,int rowIndex=0) where T : IEntity, new()
        {
            string result = func(model);
            DataSet dataSet= _converter.JsonStringToDataSet(result);
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                DataRow dataRow = dataSet.Tables[0].Rows[rowIndex];
                return Common.ConvertHelper.DataRowToModel<T>(dataRow);
            }
            else
            {
                return model;
            }
            
        }
        public static async Task<T> GetModelFromDatabase<T>(Func<T, Task<string>> func, T model, int rowIndex = 0) where T : IEntity, new()
        {
            string result = await func(model);
            DataSet dataSet = _converter.JsonStringToDataSet(result);
            DataRow dataRow = dataSet.Tables[0].Rows[rowIndex];
            return Common.ConvertHelper.DataRowToModel<T>(dataRow);
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
        public static bool CheckField<T>(string mesaj, T form, CustomTextBox customTextBox) where T : Form
        {
            bool result = true;

            object value = customTextBox.TextCustom;

            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                form.Controls.Add(WarningLabel(mesaj, customTextBox));
                result = false;
            }
            return result;
        }
        public static bool CheckField<T>(string mesaj, T form, CustomComboListBox customComboListBox) where T : Form
        {
            bool result = true;

            object value = customComboListBox.selectedDataRowId;

            if (value == null || value.ToString()=="-1" || string.IsNullOrWhiteSpace(value.ToString()))
            {
                form.Controls.Add(WarningLabel(mesaj, customComboListBox));
                result = false;
            }
            return result;
        }
        public static bool CheckField<T>(string mesaj, T form, TextBox textBox) where T : Form
        {
            bool result = true;

            object value = textBox.Text;

            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                form.Controls.Add(WarningLabel(mesaj, textBox));
                result = false;
            }
            return result;
        }
        public static bool CheckField<T>(string mesaj, T form, CustomTextBoxTarih customTextBoxTarih) where T : Form
        {
            bool result = true;

            object value = customTextBoxTarih.TextCustom;

            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                form.Controls.Add(WarningLabel(mesaj, customTextBoxTarih));
                result = false;
            }
            return result;
        }
        public static bool CheckField<T>(string mesaj, T form, CustomTextBoxSayisal customTextBoxSayisal) where T : Form
        {
            bool result = true;

            float value = float.TryParse(customTextBoxSayisal.TextCustom.ToString(), out float sayi)?sayi:0;

            if (value == 0)
            {
                Label label = WarningLabel(mesaj, customTextBoxSayisal);
                form.Controls.Add(label);
                label.BringToFront();
                result = false;
            }
            return result;
        }
        public static bool CheckField<T>(string mesaj, T form, CustomCheckedComboBox customCheckedComboBox) where T : Form
        {
            bool result = true;

            if (customCheckedComboBox.checkedCount==0)
            {
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
        public static void CloseForm<T>(ref T form) where T : Form,IForm
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
