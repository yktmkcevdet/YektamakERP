using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;
using YektamakDesktop.Common;
using YektamakDesktop.Settings;

namespace YektamakDesktop
{
    public static class FormFactory
    {
        public static Form CreateFormByType(Type formType)
        {
            Form form = (Form)DIContainer.serviceProvider.GetService(formType);
            SetupFormDefaults(form);
            return form;
        }

        public static Form CreateFormByName(string formTypeName)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var asm in assemblies)
            {
                var type = asm.GetTypes().FirstOrDefault(t =>
                    t.Name.Equals(formTypeName, StringComparison.OrdinalIgnoreCase) &&
                    typeof(Form).IsAssignableFrom(t));

                if (type != null)
                    return CreateFormByType(type);
            }

            throw new InvalidOperationException($"Form tipi bulunamadı: {formTypeName}");
        }

        public static T CreateForm<T>() where T : Form
        {
            var form = DIContainer.GetService<T>();
            SetupFormDefaults(form);
            return form;
        }
        private static void SetupFormDefaults(Form form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;

            // Ekran modunu ayarla (normal / maximized)
            form.WindowState = FormDisplaySettings.WindowMode == FormDisplaySettings.WindowModes.Maximized
                ? FormWindowState.Maximized
                : FormWindowState.Normal;

            // Form kapatıldığında dispose edilsin
            form.FormClosed += (s, e) =>
            {
                if (s is IDisposable disposable)
                    disposable.Dispose();
            };

            // Resize olayı üzerinden ayar güncellemesi
            form.Resize += (s, e) =>
            {
                if (form.WindowState == FormWindowState.Maximized)
                    FormDisplaySettings.WindowMode = FormDisplaySettings.WindowModes.Maximized;
                else if (form.WindowState == FormWindowState.Normal)
                    FormDisplaySettings.WindowMode = FormDisplaySettings.WindowModes.Normal;
            };
        }
    }

}
