using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dic.Add("安徽", "合肥，安庆，芜湖");
            dic.Add("浙江", "杭州，湖州，宁波");
            //for (int i = 0; i < dic.Keys.Count; i++)
            //{
            //    cmbTest.SelectedItem = dic.Keys.ke
            //}
            foreach (var item in dic)
            {
                cmbTest.Items.Add(item.Key);
            }
            cmbTest.SelectedIndex = 0;
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            cmbTest.SelectedItem="江苏";
            var sltTxt = cmbTest.SelectedText;
            var sltIndex = cmbTest.SelectedIndex;
        }
        private void cmbTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb2.Items.Clear();
            string aa = cmbTest.SelectedItem.ToString();
            var cities = dic[aa].Split('，');
            //for (int i = 0; i < cities.Length; i++)
            //{
            //    cmb2.Items.Add(cities[i]);
            //    //cmb2.SelectedItem = cities[i];
            //}
            foreach (var item in cities)
            {
                // cmbTest.Items.Add(item.);
                cmb2.Items.Add(item);
            }
            cmb2.SelectedIndex = 0;

        }
    }
}
