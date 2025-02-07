using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;

namespace YektamakDesktop.Formlar
{
    /// <summary>
    /// Projedeki bütün formlarda olmasını istediğimiz özellik ve metodları tanımlar.
    /// </summary>
    public interface IForm
    {        
        /// <summary>
        /// GlobalData.ActiveFormStack listesindeki en son form ya da açılan en son form bu değilse (headerPanel vb sürekli aktif kalmasını istediğimiz kontroller dışındaki) 
        /// disable olmasını istediğimiz kontrolleri bu listeye ekleriz.
        /// </summary>
        public List<Control> controlsToDisable { get; set; }
        /// <summary>
        /// GlobalData.ActiveFormStack listesine en son eklenen form bu form ise true döner.
        /// </summary>
        public bool activeForm { get; set; }
        //public bool Yetki();
    }
}
