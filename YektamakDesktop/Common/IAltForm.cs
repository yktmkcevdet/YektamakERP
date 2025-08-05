using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YektamakDesktop.Formlar;
using YektamakDesktop.Formlar.Satinalma;

namespace YektamakDesktop.Common
{
    public interface IAltForm
    {
        public void UstFormuBagla(IUstForm ustForm);
    }
}
