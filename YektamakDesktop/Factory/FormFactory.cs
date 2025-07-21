using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Windows.Forms;
using YektamakDesktop.Common;

namespace YektamakDesktop
{
    public static class FormFactory
    {
        public static Form CreateFormByType(Type formType)
        {
            Form form = (Form)DIContainer.serviceProvider.GetService(formType);
            form.StartPosition = FormStartPosition.CenterScreen;
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
            form.StartPosition= FormStartPosition.CenterScreen;
            form.FormClosed += (s, e) =>
            {
                if (s is IDisposable disposable)
                    disposable.Dispose();
            };
            return form;
        }
    }
}
