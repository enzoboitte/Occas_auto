using applicationOccasAuto.src.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace applicationOccasAuto.src.view
{
    using tValue = Dictionary<string, object>;
    using tData = List<Dictionary<string, object>>;

    public partial class frmResearch : Form
    {
        private frmMain G_fFrmMain;

        private List<string> G_lListCrit;

        public frmResearch(frmMain l_fMain)
        {
            InitializeComponent();
            this.G_fFrmMain = l_fMain;

            this.G_lListCrit = new List<string>();
            this.G_lListCrit.Add("`ville`");
            this.G_lListCrit.Add("`nom`");
            this.G_lListCrit.Add("`codePostal`");

            cbCrit.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCrit.SelectedIndex = 0;



            lvTable.View = View.Details;
            lvTable.FullRowSelect = true;

            lvTable.Columns.Add("Id", 50, HorizontalAlignment.Left);
            lvTable.Columns.Add("Nom", 100, HorizontalAlignment.Left);
            lvTable.Columns.Add("Prénom", 100, HorizontalAlignment.Left);
            lvTable.Columns.Add("Adresse", 200, HorizontalAlignment.Left);
            lvTable.Columns.Add("Code postal", 100, HorizontalAlignment.Left);
            lvTable.Columns.Add("Ville", 150, HorizontalAlignment.Left);

            this.F_vLoadList();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.F_vLoadList();
        }

        private void MouseDoubleClick_ListView(object sender, MouseEventArgs e)
        {
            if (lvTable.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lvTable.SelectedItems[0];

                string l_sId = selectedItem.SubItems[0].Text;
                string l_sNom = selectedItem.SubItems[1].Text;
                string l_sPrenom = selectedItem.SubItems[2].Text;
                string l_sAdresse = selectedItem.SubItems[3].Text;
                string l_sCodePostal = selectedItem.SubItems[4].Text;
                string l_sVille = selectedItem.SubItems[5].Text;

                this.G_fFrmMain.F_vChangeView(3, l_sId, l_sNom, l_sPrenom, l_sAdresse, l_sCodePostal, l_sVille);
            }
        }

        private void F_vLoadList()
        {
            CDBManager l_cManager = new CDBManager("localhost", "dboccasauto");

            string selectQuery = $"SELECT `idConces`, `nom`, `prenom`, `adresse`, `codePostal`, `ville` FROM `concessionnaire` WHERE {this.G_lListCrit[cbCrit.SelectedIndex]} LIKE '%{tbSearch.Text}%' ORDER BY `idConces`;";
            tData usersTable = l_cManager.F_lExecuteQuery(selectQuery);

            lvTable.Items.Clear();
            foreach (tValue user in usersTable)
            {
                string[] row = { (string)user["nom"], (string)user["prenom"], (string)user["adresse"], (string)user["codePostal"], (string)user["ville"] };
                ListViewItem listViewItem = new ListViewItem(((int)user["idConces"]).ToString());

                foreach (string item in row)
                {
                    listViewItem.SubItems.Add(item);
                }

                lvTable.Items.Add(listViewItem);
            }
        }
    }
}
