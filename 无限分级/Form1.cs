using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 无限分级
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.tvUnlimited.Nodes.Clear();
            AddTree("00", (TreeNode)null);
        }





        #region 创建树形菜单
        /// <summary>
        /// 描述：创建树形菜单
        /// </summary>
        public void AddTree(string ParentID, TreeNode pNode)
        {
            DataTable dt= SqlHelper.ExcuteDataTable("SELECT * FROM dbo.ProductClassificationTree");
            //DataTable dt = typeManager.GetAllList().Tables[0];
            DataView dvTree = new DataView(dt);

            //过滤ParentID,得到当前的所有子节点 
            dvTree.RowFilter = "ProType_ParentID = '" + ParentID+"'";

            foreach (DataRowView Row in dvTree)
            {
                TreeNode Node = new TreeNode();
                if (pNode == null)
                { //添加根节点 
                    Node.Text = Row["ProductTypeName"].ToString();
                    Node.Name = Row["ProductTypeName"].ToString();
                    Node.Tag = Row["ID"].ToString();
                    this.tvUnlimited.Nodes.Add(Node);
                    //Node.Expanded = true; 

                    AddTree(Row["ProductTypeName"].ToString(), Node); //再次递归 
                }
                else
                { //添加当前节点的子节点 
                    Node.Text = Row["ProductTypeName"].ToString();
                    Node.Name = Row["ProductTypeName"].ToString();
                    Node.Tag = Row["ID"].ToString();
                    pNode.Nodes.Add(Node);
                    //Node.Expanded = true; 
                    AddTree(Row["ProductTypeName"].ToString(), Node); //再次递归 
                }
            }
        }
        #endregion

        #region treeview操作
        /// <summary>
        /// 新增同级
        /// </summary>
        /// <param name = "sender" ></ param >
        /// < param name="e"></param>
        private void 新增同级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPeerType aptForm = new AddPeerType();
            DialogResult d = aptForm.ShowDialog();
            if (d == DialogResult.OK)
            {
                //Emp.tagComType = "1";
                //Emp.parentTagComType = "0";
                this.tvUnlimited.Nodes.Clear();
                AddTree("00", (TreeNode)null);
            }
        }
        /// <summary>
        /// 新增下一级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 新增下一级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLowerType altForm = new AddLowerType();
            DialogResult d = altForm.ShowDialog();
            if (d == DialogResult.OK)
            {
                //Emp.tagComType = "1";
                //Emp.parentTagComType = "0";
                this.tvUnlimited.Nodes.Clear();
                AddTree("00", (TreeNode)null);
            }
        }

        /// <summary>
        /// 单击树上一个节点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvType_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text != "所有商品")
            {
            //    删除类别ToolStripMenuItem.Enabled = true;
            //    新增同级ToolStripMenuItem.Enabled = true;
            //    修改类别ToolStripMenuItem.Enabled = true;
            //    if (this.tvType.SelectedNode != null)
            //    {
            //        util.Emp.tagComType = this.tvType.SelectedNode.Tag.ToString();
            //        if (this.tvType.SelectedNode.Parent != null)
            //        {
            //            util.Emp.parentTagComType = this.tvType.SelectedNode.Parent.Tag.ToString();
            //        }
            //    }
            //}
            //else
            //{
            //    Emp.tagComType = "1";
            //    Emp.parentTagComType = "0";
            //    删除类别ToolStripMenuItem.Enabled = false;
            //    新增同级ToolStripMenuItem.Enabled = false;
            //    修改类别ToolStripMenuItem.Enabled = false;
            }
        }
        #endregion






    }
}
