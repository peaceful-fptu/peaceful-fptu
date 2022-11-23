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
    public partial class EN_VN_update : Form
    {
        public EN_VN_update()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DictionaryContext context = new DictionaryContext();
        private void ENVNUpdate_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            var data = context.DictionaryEnvns.Select(item => new
            {
                wordID = item.WordId,
                word = item.Word,
                meaning = item.Meaning,
                type = item.TypeNavigation.WordType
            }).ToList();
            dgvENVNUpdate.DataSource = data;
            var data2 = context.WorkTypeEnvns.ToList();
            cboTypeENVNUpdate.DataSource = data2;
            cboTypeENVNUpdate.DisplayMember = "wordType";
            cboTypeENVNUpdate.ValueMember = "ID";

            // binding
            txtWordENVNUpdate.DataBindings.Clear();
            txtWordENVNUpdate.DataBindings.Add("Text", data, "word");
            txtMeaningENVNUpdate.DataBindings.Clear();
            txtMeaningENVNUpdate.DataBindings.Add("Text", data, "meaning");
        }

        private void btnUpdateENVN_Click(object sender, EventArgs e)
        {
            try
            {
                string w = txtWordENVNUpdate.Text;
                string m = txtMeaningENVNUpdate.Text;
                if (string.IsNullOrEmpty(w) || string.IsNullOrEmpty(m))
                {
                    MessageBox.Show("Cannot be blank!");
                }
                else
                {
                    int id = (int)dgvENVNUpdate.CurrentRow.Cells["WordID"].Value;
                    DictionaryEnvn d = context.DictionaryEnvns.FirstOrDefault(item => item.WordId == id);
                    if (d != null)
                    {
                        d.Word = w;
                        d.Meaning = m;
                        d.Type = (int)cboTypeENVNUpdate.SelectedValue;
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
