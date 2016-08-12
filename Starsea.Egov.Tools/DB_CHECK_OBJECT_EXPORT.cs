using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Starsea.Egov.Tools
{
    public partial class DB_CHECK_OBJECT_EXPORT : Form
    {
        public DB_CHECK_OBJECT_EXPORT()
        {
            InitializeComponent();
            setAll_list();

            
        }
        private void setAll_list() {
            db.dbdata dbdate = new db.dbdata();
            string username = System.Configuration.ConfigurationSettings.AppSettings["username"].ToString();

            TreeNode node = new TreeNode("数据库");

            TreeNode node_table = new TreeNode("表");
          
            DataTable dt = dbdate.getAllTable(username);
            if(dt.Rows.Count>0){
            for (int i = 0; i < dt.Rows.Count;i++ )
            {
                string tableName = dt.Rows[i]["table_name"].ToString();
                TreeNode node_tmp = new TreeNode(tableName);
                node_table.Nodes.Add(node_tmp);
            }
            node_table.Expand();
            node.Nodes.Add(node_table);
            node.Expand();
            this.treeView1.Nodes.Add(node);
            this.treeView1.CheckBoxes = true;
            
            }
              
        
        }
             

        private void btn_add_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> tables = new List<string>();
            int choose_num = 0;

            TreeNode tabeleTree = this.treeView1.Nodes[0].Nodes[0];
            foreach (TreeNode node in tabeleTree.Nodes)
            {
               
                string table_name = node.Text;
                if(node.Checked==true){
                    tables.Add(table_name);
                    
                }

                choose_num++;
            }
            if (choose_num == 0)
            {
                MessageBox.Show("请选择要导出的表!");
            }
            
            string filename = "table_infos_" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond + ".xml";
            string url = AppDomain.CurrentDomain.BaseDirectory + @"TempFile/" + filename + "";

            XmlTextWriter xw = new XmlTextWriter(url, Encoding.UTF8);

            db.dbdata export = new db.dbdata();

            string username = System.Configuration.ConfigurationSettings.AppSettings["username"].ToString();
            export.exportXML(xw, username, tables);

            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "xml配置文件(*.xml)|*.xml";
            saveFile.Title = "导出数据库配置文件";
            saveFile.FileName = filename;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                //将用户选择的文件路径 显示 在文本框中
                // MessageBox.Show(saveFile.FileName);
                File.Copy(url, saveFile.FileName);
                MessageBox.Show("导出完成!");
            }



        }

        private void treeView1_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node = e.Node;
            bool check = node.Checked == true ? false : true;

            // setParentNode(node);
            setChildrenNode(node, check);
        }

        private void setChildrenNode(TreeNode node,bool check)
        {
            
                foreach (TreeNode cnode in node.Nodes)
                {
                    cnode.Checked = check;
                    if(cnode.Nodes.Count>0){
                        setChildrenNode(cnode,check);
                    }
                }
           
        }

        private void setParentNode(TreeNode node)
        {
           
        }

        private void btnExportChoose_Click(object sender, EventArgs e)
        {

        }

        private void btnExportView_Click(object sender, EventArgs e)
        {

        }

       
    }
}
