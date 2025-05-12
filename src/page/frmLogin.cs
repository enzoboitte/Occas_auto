using applicationOccasAuto.src.model;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace applicationOccasAuto
{
    using tValue = Dictionary<string, object>;
    using tData = List<Dictionary<string, object>>;

    public partial class frmLogin : Form
    {
        private frmMain G_fFrmMain;

        public frmLogin(frmMain l_fMain)
        {
            InitializeComponent();

            this.G_fFrmMain = l_fMain;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbUser.Text.Length == 0
                || tbPasswd.Text.Length == 0)
            {
                MessageBox.Show("Veuillez remplir tous les champs !");

                tbUser.BackColor = tbUser.Text.Length == 0 ? Color.Red : Color.White;
                tbPasswd.BackColor = tbPasswd.Text.Length == 0 ? Color.Red : Color.White;
                return;
            }

            string[] l_lInfo = tbUser.Text.Split('.');
            if(l_lInfo.Length != 2)
            {
                MessageBox.Show("Veuillez saisir un identifiant valide (nom.prenom).");
                return;
            }

            Tuple<string, bool> l_Result = CAccount.F_bIsConsesExist(l_lInfo[0], l_lInfo[1]);
            if (!l_Result.Item2)
            {
                if (l_Result.Item1.Length != 0)
                {
                    MessageBox.Show(l_Result.Item1);
                    return;
                }

                MessageBox.Show("Aucun compte concessionnaire existe à ce nom/prenom.");
                return;
            }

            l_Result = CAccount.F_bIsConsesExist(l_lInfo[0], l_lInfo[1]);
            if (!l_Result.Item2)
            {
                if (l_Result.Item1.Length != 0)
                {
                    MessageBox.Show(l_Result.Item1);
                    return;
                }

                DialogResult l_cResult = MessageBox.Show("Vous n'avez pas de compte, voulez-vous en créé un ?", "", MessageBoxButtons.YesNo);

                if (l_cResult == DialogResult.Yes)
                {
                    string l_sCode = this.F_sGenerateRand();
                    MessageBox.Show($"Votre mot de passe temporaire est {l_sCode} (pensez bien à le modifier).");
                    CAccount.F_vCreateAccount(l_lInfo[0], l_lInfo[1], l_sCode);
                }
            } else
            {
                CDBManager l_cManager = new CDBManager("localhost", "dboccasauto");
                string selectQuery = $"SELECT A.`id`, C.`idConces`, A.`level` FROM `concessionnaire` C INNER JOIN `account` A ON A.`idConces` = C.`idConces`  WHERE C.`nom` = '{l_lInfo[0]}' AND C.`prenom` = '{l_lInfo[1]}' AND A.`passwd` = '{tbPasswd.Text}';";
                tData usersTable = l_cManager.F_lExecuteQuery(selectQuery);

                if (usersTable.Count == 1)
                {
                    this.G_fFrmMain.Account = new CAccount((int)usersTable[0]["id"], (int)usersTable[0]["idConces"], (int)usersTable[0]["level"]);
                    this.G_fFrmMain.F_vChangeView(1);
                }
                else
                {
                    MessageBox.Show("Votre identifiant et mot de passe sont incorrects.");
                }
            }
        }

        private void llReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (tbUser.Text.Length == 0)
            {
                MessageBox.Show("Veuillez remplir le champ identifiant pour réinitialisé le mot de passe !");

                tbUser.BackColor = tbUser.Text.Length == 0 ? Color.Red : Color.White;
                return;
            }

            string[] l_lInfo = tbUser.Text.Split('.');
            if (l_lInfo.Length != 2)
            {
                MessageBox.Show("Veuillez saisir un identifiant valide (nom.prenom).");
                return;
            }

            Tuple<string, bool> l_Result = CAccount.F_bIsConsesExist(l_lInfo[0], l_lInfo[1]);
            if (!l_Result.Item2)
            {
                if (l_Result.Item1.Length != 0)
                {
                    MessageBox.Show(l_Result.Item1);
                    return;
                }

                MessageBox.Show("Aucun compte concessionnaire existe à ce nom/prenom.");
                return;
            }

            string l_sCode = this.F_sGenerateRand();
            MessageBox.Show($"Votre mot de passe temporaire est {l_sCode} (pensez bien à le modifier).");

            CDBManager  l_cManger = new CDBManager("localhost", "dboccasauto");
            string      l_sQuery  = $"UPDATE `account` SET `passwd`='{l_sCode}' WHERE `idConces` = (SELECT `idConces` FROM `concessionnaire` WHERE `nom` = '{l_lInfo[0]}' AND `prenom` = '{l_lInfo[1]}');";
            
            if (l_cManger.F_iExecuteNonQuery(l_sQuery) == -1)
                MessageBox.Show("Erreur de connexion à la base de donnée.");
        }

        private string F_sGenerateRand(int l_iSize = 8)
        {
            string l_sKey = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789&#$*!:/;.,?<>-_@";
            string l_sCode = "";

            Random l_cRand = new Random();
            for (int l_iId = 0; l_iId < l_iSize; l_iId++)
            {
                int l_iPos = l_cRand.Next(l_sKey.Length);
                l_sCode += l_sKey[l_iPos];
            }
            
            return l_sCode;
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            tbPasswd.PasswordChar = tbPasswd.PasswordChar == '\0' ? '*' : '\0';
        }
    }
}
