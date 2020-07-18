using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace 自定义控件
{
    public partial class DoctorData : UserControl
    {
        public delegate void TextChangedEventHandler(object sender, TextChangeEventArgs e);
        public new event TextChangedEventHandler OnTextChanged;
        public event EventHandler OnSelectedValueChanged;

        private DoctorDataView_Product _selectedProduct;
        private List<DoctorDataView_Product> _currentProducts;


        public DoctorData()
        {
            InitializeComponent();
        }

        private void dgvDoctorData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectedProduct = null;
            if (e.RowIndex > -1)
            {
                _selectedProduct = _currentProducts[e.RowIndex];
            }
            RaiseSelectedValueChangeEvent();
        }
        private void RaiseSelectedValueChangeEvent()
        {
            EventHandler eventHandler = OnSelectedValueChanged;
            if (eventHandler != null)
                OnSelectedValueChanged(this, EventArgs.Empty);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RaiseTextChangeEvent();
            FiltrateProduct();
        }

        private void FiltrateProduct()
        {
            _selectedProduct = null;
            _currentProducts = DoctorDataView.OriginalProducts.ToList();
            if (!string.IsNullOrEmpty(txtSearchContent.Text.Trim()))
            {
                string content = txtSearchContent.Text.Trim().ToLower();
                if (DoctorDataView.SearchOnlyByCode)
                {
                    _currentProducts = _currentProducts.Where(x => x.Code.ToLower().Contains(content)).OrderBy(x => x.Code).ToList();
                }
                else
                {
                    _currentProducts = _currentProducts.Where(x => x.Name.ToLower().Equals(content) ||  x.Code.ToLower().Equals(content)).Union(_currentProducts.Where(x => x.Name.ToLower().Contains(content) || x.Code.ToLower().Contains(content)).OrderBy(x => x.Name).ThenBy(x => x.Code)).ToList();
                }
            }
            else
            {
                _currentProducts = _currentProducts.OrderBy(x => x.Name).ThenBy(x => x.Code).ToList();
            }
            this.clnName.HeaderText = "医院";//这里更改
            dgvDoctorData.DataSource = _currentProducts;
        }

        private void RaiseTextChangeEvent()
        {
            TextChangedEventHandler eventHandler = OnTextChanged;
            if (eventHandler != null)
                OnTextChanged(this.txtSearchContent, new TextChangeEventArgs(txtSearchContent.Text));
        }

        public class TextChangeEventArgs : EventArgs
        {
            public TextChangeEventArgs(string text)
            {
                Text = text;
            }
            public string Text { get; protected set; }
        }
        public string GetSelectedProduct()
        {
            return _selectedProduct == null ? txtSearchContent.Text : _selectedProduct.Name;
        }

        public void AssignSearchContent(string content)
        {
            this.txtSearchContent.Text = content;
            this.txtSearchContent.SelectionStart = this.txtSearchContent.Text.Length;
            this.ActiveControl = txtSearchContent;
            FiltrateProduct();
        }



        private void txtSearchContent_KeyDown(object sender, KeyEventArgs e)
        {
            bool handled = true;
            switch (e.KeyData & Keys.KeyCode)
            {
                case Keys.Down:
                    if (dgvDoctorData.Rows.Count > 0)
                    {
                        dgvDoctorData.Focus();
                        int nextIndex = dgvDoctorData.CurrentRow.Index + 1;
                        if (nextIndex > -1 && dgvDoctorData.Rows.Count > nextIndex)
                        {
                            dgvDoctorData.ClearSelection();
                            this.dgvDoctorData.Rows[nextIndex].Selected = true;
                            this.dgvDoctorData.CurrentCell = this.dgvDoctorData.Rows[nextIndex].Cells[0];
                        }
                    }
                    break;
                case Keys.Up:
                    if (dgvDoctorData.Rows.Count > 0)
                    {
                        int nextIndex = dgvDoctorData.CurrentRow.Index - 1;
                        if (nextIndex > -1 && dgvDoctorData.Rows.Count > nextIndex)
                        {
                            dgvDoctorData.Focus();
                            dgvDoctorData.ClearSelection();
                            this.dgvDoctorData.Rows[nextIndex].Selected = true;
                            this.dgvDoctorData.CurrentCell = this.dgvDoctorData.Rows[nextIndex].Cells[0];
                        }
                        else
                        {
                            //this.ActiveControl = cboFirstKind;
                        }
                    }
                    else
                    {
                        //this.ActiveControl = cboFirstKind;
                    }
                    break;
                case Keys.Enter:
                    _selectedProduct = null;
                    if (dgvDoctorData.CurrentRow != null && dgvDoctorData.CurrentRow.Index > -1)
                    {
                        _selectedProduct = _currentProducts[dgvDoctorData.CurrentRow.Index];
                        e.Handled = true;
                    }
                    RaiseSelectedValueChangeEvent();
                    break;
                default:
                    handled = false;
                    break;
            }
            e.Handled = handled;
        }

        private void dgvDoctorData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar))
            {
                txtSearchContent.Focus();
                e.Handled = true;
                Console.Write(e.KeyChar.ToString());
                this.txtSearchContent.Text += e.KeyChar.ToString();
                this.txtSearchContent.SelectionStart = this.txtSearchContent.Text.Length;
                e.Handled = true;
            }
        }

        private void dgvDoctorData_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    _selectedProduct = null;
                    if (dgvDoctorData.CurrentRow != null && dgvDoctorData.CurrentRow.Index > -1)
                    {
                        _selectedProduct = _currentProducts[dgvDoctorData.CurrentRow.Index];
                        e.Handled = true;
                    }
                    RaiseSelectedValueChangeEvent();
                    break;
                case Keys.Up:
                    int nextIndex = dgvDoctorData.CurrentRow.Index;
                    if (nextIndex == 0)
                    {
                        txtSearchContent.Focus();
                        txtSearchContent.SelectionLength = 0;
                        txtSearchContent.SelectionStart = txtSearchContent.Text.Length;
                        e.Handled = true;
                    }
                    break;
                case Keys.Back:
                    txtSearchContent.Focus();
                    if (txtSearchContent.Text.Length > 0)
                    {
                        txtSearchContent.Text = txtSearchContent.Text.Remove(txtSearchContent.Text.Length - 1);
                        txtSearchContent.SelectionStart = txtSearchContent.Text.Length;
                    }
                    e.Handled = true;
                    break;
            }
        }
    }
    public class DoctorDataView_Product
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }



    public class DoctorDataView
    {

        public static void InitializeOriginalProducts(List<DoctorDataView_Product> originalProducts)
        {
            OriginalProducts = originalProducts == null ? new List<DoctorDataView_Product>() : originalProducts;

            //OriginalProducts = OriginalProducts.Select(x=>new DoctorDataView_Product { });
            //OriginalKinds = (from q in DoctorDataView.OriginalProducts

            //                 select q
            //                 ).Distinct().ToList();
        }
        public static int HospitalId { get; set; }
        public static List<DoctorDataView_Product> OriginalProducts = new List<DoctorDataView_Product>();
        //public static List<ProductSelectorView_Kind> OriginalKinds = new List<ProductSelectorView_Kind>();
        public static bool SearchOnlyByCode { get; set; }
    }
}
