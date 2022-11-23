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
    public partial class EN_VN_add : Form
    {
        public EN_VN_add()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DictionaryContext context = new DictionaryContext();
        private void ENVNAdd_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            var data = context.DictionaryEnvns.Select(item => new
            {
                word = item.Word,
                meaning = item.Meaning,
                type = item.TypeNavigation.WordType
            }).ToList();
            dgvENVNAdd.DataSource = data;
            var data2 = context.WorkTypeEnvns.ToList();
            cboTypeENVNAdd.DataSource = data2;
            cboTypeENVNAdd.DisplayMember = "wordType";
            cboTypeENVNAdd.ValueMember = "ID";

            // binding
            txtWordENVNAdd.DataBindings.Clear();
            txtWordENVNAdd.DataBindings.Add("Text", data, "word");
            txtMeaningENVNAdd.DataBindings.Clear();
            txtMeaningENVNAdd.DataBindings.Add("Text", data, "meaning");
        }

        private void btnAddENVN_Click(object sender, EventArgs e)
        {
            try
            {
                string w = txtWordENVNAdd.Text;
                string m = txtMeaningENVNAdd.Text;
                if (string.IsNullOrEmpty(w) || string.IsNullOrEmpty(m))
                {
                    MessageBox.Show("Cannot be blank!");
                }
                else
                {
                    DictionaryEnvn d = new DictionaryEnvn()
                    {
                        Word = w,
                        Meaning = m,
                        Type = (int)cboTypeENVNAdd.SelectedValue
                    };
                    context.DictionaryEnvns.Add(d);
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Add successful!");
                        loadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add Error: " + ex.Message);
            }
        }
    }
}
