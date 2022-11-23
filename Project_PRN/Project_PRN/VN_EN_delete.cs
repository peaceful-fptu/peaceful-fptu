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
    public partial class VN_EN_delete : Form
    {
        public VN_EN_delete()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DictionaryContext context = new DictionaryContext();
        private void VNENDelete_Load(object sender, EventArgs e)
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
            dgvVNENDelete.DataSource = data;
            var data2 = context.WorkTypeVnens.ToList();
            cboTypeVNENDelete.DataSource = data2;
            cboTypeVNENDelete.DisplayMember = "wordType";
            cboTypeVNENDelete.ValueMember = "ID";

            // binding
            txtWordVNENDelete.DataBindings.Clear();
            txtWordVNENDelete.DataBindings.Add("Text", data, "word");
            txtMeaningVNENDelete.DataBindings.Clear();
            txtMeaningVNENDelete.DataBindings.Add("Text", data, "meaning");
        }

        private void btnDeleteVNEN_Click(object sender, EventArgs e)
        {
            try
            {
                DictionaryVnen d = context.DictionaryVnens.FirstOrDefault(item => item.Word.Equals(txtWordVNENDelete.Text));
                if (d != null)
                {
                    context.DictionaryVnens.Remove(d);
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
