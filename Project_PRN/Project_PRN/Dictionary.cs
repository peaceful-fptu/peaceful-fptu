using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dictionary

{
    public partial class Dictionary : Form
    {
        public Dictionary()
        {
            InitializeComponent();
            hideSubMenu();
        }

        private void hideSubMenu()
        {
            pnDictionary.Visible = false;
            pnCrudENVN.Visible = false;
            pnCrudVNEN.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        #region Dictionary
        private void btnDictionary_Click(object sender, EventArgs e)
        {
            showSubMenu(pnDictionary);
        }

        private void btnDictionaryENVN_Click(object sender, EventArgs e)
        {
            openChildForm(new EN_VN());

            hideSubMenu();
        }

        private void btnDictionaryVNEN_Click(object sender, EventArgs e)
        {
            openChildForm(new VN_EN());

            hideSubMenu();
        }
        #endregion
        #region function_envn
        private void btnFunctionENVN_Click(object sender, EventArgs e)
        {
            showSubMenu(pnCrudENVN);
        }
        private void btnAddENVN_Click(object sender, EventArgs e)
        {
            openChildForm(new EN_VN_add());
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnUpdateENVN_Click(object sender, EventArgs e)
        {
            openChildForm(new EN_VN_update());
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnDeleteENVN_Click(object sender, EventArgs e)
        {
            openChildForm(new EN_VN_delete());
            //..
            //your codes
            //..
            hideSubMenu();
        }
        #endregion
        #region function_vnen
        private void btnFunctionVNEN_Click(object sender, EventArgs e)
        {
            showSubMenu(pnCrudVNEN);
        }
        private void btnAddVNEN_Click(object sender, EventArgs e)
        {
            openChildForm(new VN_EN_add());
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnUpdateVNEN_Click(object sender, EventArgs e)
        {
            openChildForm(new VN_EN_update());
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void btnDeleteVNEN_Click(object sender, EventArgs e)
        {
            openChildForm(new VN_EN_delete());
            //..
            //your codes
            //..
            hideSubMenu();
        }
        #endregion
        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to quit?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}