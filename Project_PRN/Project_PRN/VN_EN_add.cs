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
    public partial class VN_EN_add : Form
    {
        public VN_EN_add()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DictionaryContext context = new DictionaryContext();
        private void VNENAdd_Load(object sender, EventArgs e)
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
            dgvVNENAdd.DataSource = data;
            var data2 = context.WorkTypeVnens.ToList();
            cboTypeVNENAdd.DataSource = data2;
            cboTypeVNENAdd.DisplayMember = "wordType";
            cboTypeVNENAdd.ValueMember = "ID";

            // binding
            txtWordVNENAdd.DataBindings.Clear();
            txtWordVNENAdd.DataBindings.Add("Text", data, "word");
            txtMeaningVNENAdd.DataBindings.Clear();
            txtMeaningVNENAdd.DataBindings.Add("Text", data, "meaning");
        }

        private void btnAddVNEN_Click(object sender, EventArgs e)
        {
            try
            {
                string w = txtWordVNENAdd.Text;
                string m = txtMeaningVNENAdd.Text;
                if (string.IsNullOrEmpty(w) || string.IsNullOrEmpty(m))
                {
                    MessageBox.Show("Cannot be blank!");
                }
                else
                {
                    DictionaryVnen d = new DictionaryVnen()
                    {
                        Word = w,
                        Meaning = m,
                        Type = (int)cboTypeVNENAdd.SelectedValue
                    };
                    context.DictionaryVnens.Add(d);
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
