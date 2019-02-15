using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cir.Clie.Modal
{
    public partial class ModalFatRigMod : Form
    {
        private ClsDataBase clsDB = ClsDataBase.Instance;
        private Cir.Classi.ClsDbGet dbGet = new Cir.Classi.ClsDbGet();

        public ModalFatRigMod(string fatId)
        {
            InitializeComponent();

            Cir.Fatt.SubFatt subFat = new Cir.Fatt.SubFatt(this);
            subFat.TopLevel = false;
            this.panelFat.Controls.Add(subFat);
            subFat.Top = (panelFat.Height - subFat.Height) / 2;
            subFat.Left = (panelFat.Width - subFat.Width) / 2;
            subFat.Open (fatId);
            subFat.Show();
        }
    }
}
