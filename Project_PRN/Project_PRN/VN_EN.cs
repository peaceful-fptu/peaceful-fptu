using Microsoft.EntityFrameworkCore;
using Project_PRN.Models;
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
    public partial class VN_EN : Form
    {
        public VN_EN()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DictionaryContext contextVNEN = new DictionaryContext();

        #region 0
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
        private void VN_EN_Load(object sender, EventArgs e)
        {
            loadDataVNEN();
        }
        private void loadDataVNEN()
        {
            var dataVNEN = contextVNEN.DictionaryVnens.Select(item => new
            {
                wordID = item.WordId,
                word = item.Word,
                meaning = item.Meaning,
                type = item.TypeNavigation.WordType
            }).ToList();
            var data2VNEN = contextVNEN.DictionaryVnens.ToList();
            dgvVNEN.DataSource = dataVNEN;

            // binding
            txtWordVNEN.DataBindings.Clear();
            txtWordVNEN.DataBindings.Add("Text", dataVNEN, "word");
            txtTypeVNEN.DataBindings.Clear();
            txtTypeVNEN.DataBindings.Add("Text", dataVNEN, "type");
            txtMeaningVNEN.DataBindings.Clear();
            txtMeaningVNEN.DataBindings.Add("Text", dataVNEN, "meaning");
        }

        private void btnTranslateVNEN_Click(object sender, EventArgs e)
        {
            DictionaryVnen d = contextVNEN.DictionaryVnens.Include("TypeNavigation").FirstOrDefault(x => x.Word.Equals(txtWordVNEN.Text));
            List<DictionaryVnen> dList = new List<DictionaryVnen>();
            dList.Add(d);
            dgvVNEN.DataSource = dList;
            if (d == null)
            {
                MessageBox.Show("Not found!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to go to EN - VN Dictionary?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                EN_VN en = new EN_VN();
                en.Show();
                this.Hide();
            }
        }

        private void dgvVNEN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtWordVNEN.Text = dgvVNEN.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
            txtMeaningVNEN.Text = dgvVNEN.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
            txtTypeVNEN.Text = dgvVNEN.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
        }
    }
}
