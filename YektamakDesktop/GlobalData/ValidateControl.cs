using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YektamakDesktop.CustomControls;

namespace YektamakDesktop
{
    public static class Validation
    {
        public interface IValidatableControl
        {
            void SetValidationError(string message);
            void ClearValidationError();
        }

        // Generic validation method
        public static bool ValidateControl<T>(string message, T form, IValidatableControl control, Func<bool> validationFunc)
            where T : Form
        {
            bool isValid = validationFunc();

            if (isValid)
            {
                control.ClearValidationError();
            }
            else
            {
                control.SetValidationError(message);
            }

            return isValid;
        }

        // CustomTextBox için özelleştirilmiş validation
        public static bool CheckField<T>(string mesaj, T form, CustomTextBox customTextBox) where T : Form
        {
            if (customTextBox == null)
                throw new ArgumentNullException(nameof(customTextBox));

            bool isValid = !string.IsNullOrWhiteSpace(customTextBox.TextCustom);

            if (isValid)
            {
                customTextBox.textBox.BackColor = SystemColors.Window;
                customTextBox.textBox.PlaceholderText = string.Empty; // Original placeholder'ı restore etmek isteyebiliriz
            }
            else
            {
                customTextBox.textBox.BackColor = Color.FromArgb(255, 200, 200); // Daha soft kırmızı
                customTextBox.PlaceholderText = mesaj;
            }

            return isValid;
        }

        // CustomComboListBox için iyileştirilmiş validation
        public static bool CheckField<T>(string mesaj, T form, CustomComboListBox customComboListBox) where T : Form
        {
            if (customComboListBox == null)
                throw new ArgumentNullException(nameof(customComboListBox));

            bool isValid = customComboListBox.listBoxDataRows.Count > 0 &&
                          customComboListBox.selectedDataRowId != null &&
                          customComboListBox.selectedDataRowId != -1;

            if (isValid)
            {
                customComboListBox.textBox.textBox.BackColor = SystemColors.Window;
            }
            else
            {
                customComboListBox.textBox.textBox.BackColor = Color.FromArgb(255, 200, 200);
                customComboListBox.textBox.PlaceholderText = mesaj;
            }

            return isValid;
        }

        // TextBox için validation
        public static bool CheckField<T>(string mesaj, T form, TextBox textBox) where T : Form
        {
            if (textBox == null)
                throw new ArgumentNullException(nameof(textBox));

            bool isValid = !string.IsNullOrWhiteSpace(textBox.Text);

            if (isValid)
            {
                textBox.BackColor = SystemColors.Window;
            }
            else
            {
                textBox.BackColor = Color.FromArgb(255, 200, 200);
                // Standard TextBox'ta PlaceholderText property'si yoktur
                // Bu durumda tooltip veya başka bir yöntem kullanılabilir
            }

            return isValid;
        }

        // CustomTextBoxTarih için validation
        public static bool CheckField<T>(string mesaj, T form, CustomTextBoxTarih customTextBoxTarih) where T : Form
        {
            if (customTextBoxTarih == null)
                throw new ArgumentNullException(nameof(customTextBoxTarih));

            bool isValid = customTextBoxTarih.TextCustom==null;

            if (isValid)
            {
                customTextBoxTarih.textBox.BackColor = SystemColors.Window;
            }
            else
            {
                customTextBoxTarih.textBox.BackColor = Color.FromArgb(255, 200, 200);
                customTextBoxTarih.textBox.PlaceholderText = mesaj;
            }

            return isValid;
        }

        // CustomTextBoxSayisal için iyileştirilmiş validation
        public static bool CheckField<T>(string mesaj, T form, CustomTextBoxSayisal customTextBoxSayisal) where T : Form
        {
            if (customTextBoxSayisal == null)
                throw new ArgumentNullException(nameof(customTextBoxSayisal));

            bool isValid = !string.IsNullOrWhiteSpace(customTextBoxSayisal.TextCustom) &&
                          float.TryParse(customTextBoxSayisal.TextCustom, out float value) &&
                          value > 0; // 0'dan büyük olması gerekiyorsa

            if (isValid)
            {
                customTextBoxSayisal.textBox.BackColor = SystemColors.Window;
            }
            else
            {
                customTextBoxSayisal.textBox.BackColor = Color.FromArgb(255, 200, 200);
                customTextBoxSayisal.textBox.PlaceholderText = mesaj;
            }

            return isValid;
        }

        // CustomCheckedComboBox için validation
        public static bool CheckField<T>(string mesaj, T form, CustomCheckedComboBox customCheckedComboBox) where T : Form
        {
            if (customCheckedComboBox == null)
                throw new ArgumentNullException(nameof(customCheckedComboBox));

            bool isValid = customCheckedComboBox.checkedCount > 0;

            if (!isValid)
            {
                // Mevcut warning label'ları temizle
                RemoveExistingWarningLabels(form, customCheckedComboBox);
                form.Controls.Add(WarningLabel(mesaj, customCheckedComboBox));
            }
            else
            {
                // Validation başarılı olduğunda warning label'ları kaldır
                RemoveExistingWarningLabels(form, customCheckedComboBox);
            }

            return isValid;
        }

        // Warning label oluşturma metodu
        public static Label WarningLabel(string mesaj, Control targetControl)
        {
            var label = new Label
            {
                Text = mesaj,
                ForeColor = Color.Red,
                BackColor = Color.Transparent,
                AutoSize = true,
                Location = new Point(targetControl.Location.X, targetControl.Location.Y + targetControl.Height + 2),
                Name = $"warning_{targetControl.Name}",
                Font = new Font(targetControl.Font.FontFamily, targetControl.Font.Size - 1, FontStyle.Italic)
            };

            return label;
        }

        // Mevcut warning label'ları temizleme
        private static void RemoveExistingWarningLabels<T>(T form, Control targetControl) where T : Form
        {
            var warningLabels = form.Controls
                .OfType<Label>()
                .Where(l => l.Name == $"warning_{targetControl.Name}")
                .ToList();

            foreach (var label in warningLabels)
            {
                form.Controls.Remove(label);
                label.Dispose();
            }
        }

        // Tüm validation renklerini sıfırlama utility metodu
        public static void ResetAllValidationColors<T>(T form) where T : Form
        {
            foreach (Control control in form.Controls)
            {
                ResetControlValidationColor(control);
            }
        }

        private static void ResetControlValidationColor(Control control)
        {
            switch (control)
            {
                case TextBox textBox:
                    textBox.BackColor = SystemColors.Window;
                    break;
                case CustomTextBox customTextBox when customTextBox.textBox != null:
                    customTextBox.textBox.BackColor = SystemColors.Window;
                    break;
                case CustomComboListBox customCombo when customCombo.textBox?.textBox != null:
                    customCombo.textBox.textBox.BackColor = SystemColors.Window;
                    break;
                    // Diğer custom control'lar için case'ler eklenebilir
            }

            // Recursive olarak child control'ları da kontrol et
            foreach (Control childControl in control.Controls)
            {
                ResetControlValidationColor(childControl);
            }
        }
    }

    // Validation sonuçlarını toplu olarak yönetmek için helper class
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();

        public void AddError(string message)
        {
            ErrorMessages.Add(message);
            IsValid = false;
        }

        public string GetErrorSummary()
        {
            return string.Join(Environment.NewLine, ErrorMessages);
        }
    }

    // Advanced validation için builder pattern
    public class ValidationBuilder<T> where T : Form
    {
        private readonly T _form;
        private readonly ValidationResult _result = new ValidationResult { IsValid = true };

        public ValidationBuilder(T form)
        {
            _form = form;
        }

        public ValidationBuilder<T> Validate(string message, Func<bool> validationFunc)
        {
            if (!validationFunc())
            {
                _result.AddError(message);
            }
            return this;
        }

        public ValidationBuilder<T> ValidateControl<TControl>(string message, TControl control, Func<TControl, bool> validationFunc)
        {
            if (!validationFunc(control))
            {
                _result.AddError(message);
            }
            return this;
        }

        public ValidationResult Build()
        {
            return _result;
        }
    }
}
