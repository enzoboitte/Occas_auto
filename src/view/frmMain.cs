using applicationOccasAuto.src.model;
using applicationOccasAuto.src.page;
using applicationOccasAuto.src.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace applicationOccasAuto
{
    public partial class frmMain : Form
    {
        private Form G_fFrm;
        private int  G_iCurrPage;

        public CAccount Account { get; set; }

        public frmMain()
        {
            InitializeComponent();
            this.G_fFrm         = null;
            this.G_iCurrPage    = -1;

            this.F_vChangeView(0);
        }

        public void F_vChangeView(int l_iPage, params string[] l_lParam)
        {
            if(l_iPage == this.G_iCurrPage)
                return;

            foreach (Form f in this.MdiChildren)
            { f.Close(); }

            Form l_fFrm;

            this.G_iCurrPage = l_iPage;
            switch (l_iPage)
            {
                // Page de modification du compte actuel
                case 4:
                    mstAction.Visible = true;
                    l_fFrm = new frmMyAccount(this);
                    break;

                // Page de modification
                case 3:
                    if (l_lParam.Length != 6)
                        throw new Exception("Execpt 6 parameters from F_vChangeView function");

                    mstAction.Visible = true;
                    l_fFrm = new frmModif(this, l_lParam[0], l_lParam[1], l_lParam[2], l_lParam[3], l_lParam[4], l_lParam[5]);
                    break;

                // Page d'ajout
                case 2:
                    mstAction.Visible = true;
                    l_fFrm = new frmModif(this);
                    break;

                // Page de recherche
                case 1:
                    mstAction.Visible = true;
                    l_fFrm = new frmResearch(this);
                    break;

                // Page de login
                default:
                case 0:
                    mstAction.Visible = false;
                    l_fFrm = new frmLogin(this);

                    this.G_iCurrPage = 0;
                    break;
            }

            l_fFrm.MdiParent = this;
            l_fFrm.Show();
            l_fFrm.Location = new Point(0, 0);

            this.G_fFrm = l_fFrm;

            F_vAdjust();
        }

        public void F_vAdjust()
        {
            if (this.G_fFrm == null)
                return;
            int l_iWidth    = this.ClientSize.Width - 4;
            int l_iHeight   = this.ClientSize.Height - 4 - (mstAction.Visible ? mstAction.Height : 0);

            this.G_fFrm.Size = new Size(l_iWidth, l_iHeight);
        }

        private void Resize_Page(object sender, EventArgs e)
        {
            this.F_vAdjust();
        }

        private void affichageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.F_vChangeView(1);
        }

        private void modificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.F_vChangeView(2);
        }

        private void compteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.F_vChangeView(4);
        }
    }
}
