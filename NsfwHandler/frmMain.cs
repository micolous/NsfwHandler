using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NsfwHandler
{
    public partial class frmMain : Form
    {

        private UriBuilder u;

        public frmMain(Uri u)
        {
            this.u = new UriBuilder(u);
            InitializeComponent();

            switch (this.u.Scheme.ToLowerInvariant()) {
                case "nsfw":
                case "http":
                    this.u.Scheme = "http";
                    break;
            
                case "nsfws":
                case "https":
                    this.u.Scheme = "https";
                    break;

                default:
                    // unknown handler
                    // die

                    MessageBox.Show("Unknown URI scheme passed!");
                    Application.Exit();
                    break;

            }
            txtUrlField.Text = this.u.ToString();
        }

        private void chkUnlockConfirm_CheckedChanged(object sender, EventArgs e)
        {
            btnOpen.Enabled = chkUnlockConfirm.Checked;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (chkUnlockConfirm.Checked)
            {
                // open the URL with the default browser
                System.Diagnostics.Process.Start(this.u.ToString());
                Close();
            }
        }
    }
}
