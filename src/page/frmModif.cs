using applicationOccasAuto.src.model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace applicationOccasAuto.src.view
{
    public partial class frmModif : Form
    {
        private frmMain G_fFrmMain;
        private bool    G_bIsModification;

        private int     G_iIdSelect;

        public frmModif(frmMain l_fMain)
        {
            InitializeComponent();

            this.G_fFrmMain         = l_fMain;
            this.G_bIsModification  = false;
            this.G_iIdSelect        = 0;

            btnAdd.Enabled          = true;
            btnRemove.Enabled       = false;
            btnModif.Enabled        = false;
        }

        public frmModif(frmMain l_fMain, string l_sId, string l_sNom, string l_sPrenom, string l_sAdresse, string l_sCodePostal, string l_sVille)
        {
            InitializeComponent();

            this.G_fFrmMain         = l_fMain;
            this.G_bIsModification  = true;
            this.G_iIdSelect        = int.Parse(l_sId);

            tbNom.Text              = l_sNom;
            tbPrenom.Text           = l_sPrenom;
            tbAdresse.Text          = l_sAdresse;
            tbCp.Text               = l_sCodePostal;
            tbVille.Text            = l_sVille;

            btnAdd.Enabled          = false;
            btnRemove.Enabled       = true;
            btnModif.Enabled        = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult l_cResult = MessageBox.Show("Etes-vous sur de vouloir supprimer l'element selectionné ?", "", MessageBoxButtons.YesNo);

            if(l_cResult == DialogResult.Yes)
            {
                CDBManager l_cManger = new CDBManager("localhost", "dboccasauto");

                string l_sQuery = $"DELETE FROM `concessionnaire` WHERE `idConces` = '{this.G_iIdSelect}';";
                if (l_cManger.F_iExecuteNonQuery(l_sQuery) == -1)
                {
                    MessageBox.Show("Erreur de connexion à la base de donnée.");
                    return;
                }

                this.G_fFrmMain.F_vChangeView(1);
            }
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            CDBManager l_cManger = new CDBManager("localhost", "dboccasauto");

            string l_sQuery = $"UPDATE `concessionnaire` SET `nom`='{tbNom.Text}',`prenom`='{tbPrenom.Text}',`adresse`='{tbAdresse.Text}',`codePostal`='{tbCp.Text}',`ville`='{tbVille.Text}' WHERE `idConces` = '{this.G_iIdSelect}';";
            if (l_cManger.F_iExecuteNonQuery(l_sQuery) == -1)
            {
                MessageBox.Show("Erreur de connexion à la base de donnée.");
                return;
            }

            this.G_fFrmMain.F_vChangeView(1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(tbPrenom.Text.Length == 0 
                || tbNom.Text.Length == 0
                || tbAdresse.Text.Length == 0
                || tbCp.Text.Length == 0
                || tbVille.Text.Length == 0) 
            {
                MessageBox.Show("Veuillez remplir tous les champs !");

                tbPrenom.BackColor = tbPrenom.Text.Length == 0 ? Color.Red : Color.White; 
                tbNom.BackColor = tbNom.Text.Length == 0 ? Color.Red : Color.White;
                tbAdresse.BackColor = tbAdresse.Text.Length == 0 ? Color.Red : Color.White; 
                tbCp.BackColor = tbCp.Text.Length == 0 ? Color.Red : Color.White; 
                tbVille.BackColor = tbVille.Text.Length == 0 ? Color.Red : Color.White;
                return;
            }
            CDBManager l_cManger = new CDBManager("localhost", "dboccasauto");

            string l_sQuery = $"INSERT INTO `concessionnaire`(`nom`, `prenom`, `adresse`, `codePostal`, `ville`) VALUES ('{tbNom.Text}', '{tbPrenom.Text}', '{tbAdresse.Text}', '{tbCp.Text}', '{tbVille.Text}');";
            if (l_cManger.F_iExecuteNonQuery(l_sQuery) == -1)
            {
                MessageBox.Show("Erreur de connexion à la base de donnée.");
                return;
            }

            this.G_fFrmMain.F_vChangeView(1);
        }
    }
}
