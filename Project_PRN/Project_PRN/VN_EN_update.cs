using Project_PRN.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class VN_EN_update : Form
    {
        public VN_EN_update()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DictionaryContext context = new DictionaryContext();
        private void VNENUpdate_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            var data = context.DictionaryVnens.Select(item => new
            {
                wordID = item.WordId,
                word = item.Word,
                meaning = item.Meaning,
                type = item.TypeNavigation.WordType
            }).ToList();
            dgvVNENUpdate.DataSource = data;
            var data2 = context.WorkTypeVnens.ToList();
            cboTypeVNENUpdate.DataSource = data2;
            cboTypeVNENUpdate.DisplayMember = "wordType";
            cboTypeVNENUpdate.ValueMember = "ID";

            // binding
            txtWordVNENUpdate.DataBindings.Clear();
            txtWordVNENUpdate.DataBindings.Add("Text", data, "word");
            txtMeaningVNENUpdate.DataBindings.Clear();
            txtMeaningVNENUpdate.DataBindings.Add("Text", data, "meaning");
        }

        private void btnUpdateVNEN_Click(object sender, EventArgs e)
        {
            try
            {
                string w = txtWordVNENUpdate.Text;
                string m = txtMeaningVNENUpdate.Text;
                if (string.IsNullOrEmpty(w) || string.IsNullOrEmpty(m))
                {
                    MessageBox.Show("Cannot be blank!");
                }
                else
                {
                    int id = (int)dgvVNENUpdate.CurrentRow.Cells["WordID"].Value;
                    DictionaryVnen d = context.DictionaryVnens.FirstOrDefault(item => item.WordId == id);
                    if (d != null)
                    {
                        d.Word = w;
                        d.Meaning = m;
                        d.Type = (int)cboTypeVNENUpdate.SelectedValue;
                        if (context.SaveChanges() > 0)
                        {
                            MessageBox.Show("Update successful!");
                            loadData();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
            }
        }
    }
}
