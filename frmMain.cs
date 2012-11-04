/*
 * NsfwHandler - A Windows URI handler for NSFW web links
 * Copyright 2012 Michael Farrell <http://micolous.id.au/>.
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        private void frmMain_Load(object sender, EventArgs e)
        {
            switch (this.u.Scheme.ToLowerInvariant())
            {
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

                    MessageBox.Show("Unknown URI scheme passed!", "NsfwHandler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    break;

            }
            txtUrlField.Text = this.u.ToString();
        }
    }
}
