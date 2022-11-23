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
    public partial class EN_VN_delete : Form
    {
        public EN_VN_delete()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DictionaryContext context = new DictionaryContext();
        private void ENVNDelete_Load(object sender, EventArgs e)
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
            dgvENVNDelete.DataSource = data;
            var data2 = context.WorkTypeEnvns.ToList();
            cboTypeENVNDelete.DataSource = data2;
            cboTypeENVNDelete.DisplayMember = "wordType";
            cboTypeENVNDelete.ValueMember = "ID";

            // binding
            txtWordENVNDelete.DataBindings.Clear();
            txtWordENVNDelete.DataBindings.Add("Text", data, "word");
            txtMeaningENVNDelete.DataBindings.Clear();
            txtMeaningENVNDelete.DataBindings.Add("Text", data, "meaning");
        }

        private void btnDeleteENVN_Click(object sender, EventArgs e)
        {
            try
            {
                DictionaryEnvn d = context.DictionaryEnvns.FirstOrDefault(item => item.Word.Equals(txtWordENVNDelete.Text));
                if (d != null)
                {
                    context.DictionaryEnvns.Remove(d);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Delete successful!");
                        loadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Error: " + ex.Message);
            }
        }
    }
}
