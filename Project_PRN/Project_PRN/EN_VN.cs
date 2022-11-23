using Microsoft.EntityFrameworkCore;
using Project_PRN;
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
using System.Xml.Linq;

namespace Dictionary
{
    public partial class EN_VN : Form
    {
        bool isLoading1 = true;
        SpeakText English;
        public EN_VN()
        {
            InitializeComponent();
            ChangeLoading();
            WebBrowser wben = new WebBrowser();
            wben.Width = 0;
            wben.Height = 0;
            wben.Visible = false;
            wben.ScriptErrorsSuppressed = true;
            wben.Navigate(ConnectVoice.EngLishLink);
            wben.DocumentCompleted += Wben_DocumentCompleted;
            this.Controls.Add(wben);
            English = new SpeakText(wben);


        }

        private void Wben_DocumentCompleted(object? sender, WebBrowserDocumentCompletedEventArgs e)
        {
            isLoading1 = false;
            ChangeLoading();
        }

        private void ChangeLoading()
        {
            this.Enabled = isLoading1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DictionaryContext context = new DictionaryContext();
        private void EN_VN_Load(object sender, EventArgs e)
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
            var data3 = context.DictionaryEnvns.Select(item => new
            {
                word = item.Word,
                meaning = item.Meaning,
                type = item.TypeNavigation.WordType
            }).ToList();
            listENVN.DataSource = data3.ToList();
            listENVN.DisplayMember = "Word";
            listENVN.ValueMember = "Word";

            // binding
            txtWordENVN.DataBindings.Clear();
            txtWordENVN.DataBindings.Add("Text", data, "word");
            txtTypeENVN.DataBindings.Clear();
            txtTypeENVN.DataBindings.Add("Text", data, "type");
            txtMeaningENVN.DataBindings.Clear();
            txtMeaningENVN.DataBindings.Add("Text", data, "meaning");
        }

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

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            listENVN.SelectedItems.Clear();
            List<DictionaryEnvn> data = context.DictionaryEnvns.Where(x => x.Word.Contains(txtWordENVN.Text)).ToList();
            listENVN.DataSource = data;
            listENVN.DisplayMember = "Word";
            listENVN.ValueMember = "Word";
            txtWordENVN.DataBindings.Clear();
            txtWordENVN.DataBindings.Add("Text", data, "word");
            txtTypeENVN.DataBindings.Clear();
            txtTypeENVN.DataBindings.Add("Text", data, "type");
            txtMeaningENVN.DataBindings.Clear();
            txtMeaningENVN.DataBindings.Add("Text", data, "meaning");
        }

        private void gotoVNEN_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to go to VN - EN Dictionary?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                VN_EN vn = new VN_EN();
                vn.Show();
                this.Hide();
            }
        }

        private void btnSpeakENVN_Click(object sender, EventArgs e)
        {
            English.Spreak(txtWordENVN.Text);
        }

        private void dgvENVN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void listENVN_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
