using applicationOccasAuto.src.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace applicationOccasAuto.src.page
{
    public partial class frmMyAccount : Form
    {
        private frmMain G_fMain;

        public frmMyAccount(frmMain l_fMain)
        {
            InitializeComponent();
            this.G_fMain = l_fMain;
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            if (tbPass.Text.Length == 0
                || tbPassConfirm.Text.Length == 0)
            {
                MessageBox.Show("Veuillez remplir tous les champs !");

                tbPass.BackColor = tbPass.Text.Length == 0 ? Color.Red : Color.White;
                tbPassConfirm.BackColor = tbPassConfirm.Text.Length == 0 ? Color.Red : Color.White;
                return;
            }

            if(tbPass.Text != tbPassConfirm.Text)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas !");
                return;
            }

            CDBManager l_cManger = new CDBManager("localhost", "dboccasauto");

            

            string selectQuery = $"UPDATE `account` SET `passwd`='{tbPass.Text}' WHERE `idConces` = '{this.G_fMain.Account.IdConces}' AND `id` = '{this.G_fMain.Account.Id}';";
            l_cManger.F_iExecuteNonQuery(selectQuery);

            this.G_fMain.F_vChangeView(0);
        }
    }
}
