using System.Data;
using System.Windows.Forms;
using System.Linq;
using static 自定义控件.DoctorData;
using System.Collections.Generic;
using System;

namespace 自定义控件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            DoctorData doctorData = new DoctorData();
            doctorData.OnTextChanged += DoctorData_OnTextChanged;
            doctorData.OnSelectedValueChanged += DoctorData_OnSelectedValueChanged;
            productComboBox.DropDownControl = doctorData;

            productComboBox.DropDownSizeMode = ProductComboBox.SizeMode.UseControlSize;

            //string sql = "select distinct Doctor.Name 医生,isnull(DoctorCode,'') 编码 from Doctor join  Hospital  on Hospital.id= Doctor.HID where  Isnull(Hospital.IsExist,0) =0  order by Doctor.Name";
            //DataTable dt =  SqlHelper.ExcuteDataTable(sql);
            //doctorData.setDgvDoctorData(dt);

            DoctorDataView.InitializeOriginalProducts(GetProductSelectorDataSource());
            DoctorDataView.SearchOnlyByCode = false;

            productComboBox.DropDown += ProductComboBox_DropDown;
            productComboBox.DropDownClosed += ProductComboBox_DropDownClosed;
        }
        public List<DoctorDataView_Product> GetProductSelectorDataSource() {
            string sql = string.Format(@"select distinct Doctor.Name,isnull(DoctorCode,'') code from Doctor join  Hospital  on Hospital.id= Doctor.HID where  Isnull(Hospital.IsExist,0) =0  order by Doctor.Name");
            DataTable dt = SqlHelper.ExcuteDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                return (from DataRow dr in dt.Rows
                        select new DoctorDataView_Product()
                        {
                            Name = ReadString(dr["Name"]),
                            Code = ReadString(dr["code"]),
                        }).ToList();
            }
            else
            {
                return new List<DoctorDataView_Product>();
            }
        }
        private string ReadString(object obj)
        {
            return obj == DBNull.Value || obj == null ? "" : obj.ToString();
        }

        private void ProductComboBox_DropDown(object sender, System.EventArgs e)
        {
            var DoctorData = productComboBox.DropDownControl as DoctorData;
            if (DoctorData != null)
            {
                DoctorData.AssignSearchContent(this.productComboBox.Text);
            }
        }

        private void ProductComboBox_DropDownClosed(object sender, System.EventArgs e)
        {
            var DoctorData = productComboBox.DropDownControl as DoctorData;
            if (DoctorData != null)
            {
                productComboBox.Text = DoctorData.GetSelectedProduct();
                productComboBox.SelectAll();
            }
        }

        private void DoctorData_OnSelectedValueChanged(object sender, System.EventArgs e)
        {
            productComboBox.HideDropDown();
        }

        private void DoctorData_OnTextChanged(object sender, TextChangeEventArgs e)
        {
            productComboBox.Text = e.Text;
        }
    }
}
