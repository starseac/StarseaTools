using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZDMAP_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
           
            ZDMapGisInput.ZDMapGisInput mg = new ZDMapGisInput.ZDMapGisInput();

            var dics = new Dictionary<string, string>();
            dics.Add("案卷编号", this.txt_caseno.Text);
            dics.Add("项目名称", this.txt_ajmc.Text);

            dics.Add("土地位置", this.txt_tdwz.Text);
            dics.Add("土地用途", this.txt_tdyt.Text);
            dics.Add("土地面积", this.txt_tdmj.Text);
            dics.Add("农用地", this.txt_nyd.Text);
            dics.Add("建设用地", this.txt_jsyd.Text);
            dics.Add("未利用地", this.txt_wlyd.Text);
            dics.Add("耕地", this.txt_gd.Text);
            dics.Add("批准文号", this.txt_pzwh.Text);
            dics.Add("批准时间", this.txt_pzsj.Text);
            dics.Add("审批状态", this.txt_spzt.SelectedItem.ToString());

            if (mg.InputMapGis(this.txt_caseno.Text, this.txt_wfid.Text, dics))
            {
                MessageBox.Show("入库成功!");

            }
            else
            {
                MessageBox.Show("入库失败!");
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            ZDMapGisInput.ZDMapGisInput mg = new ZDMapGisInput.ZDMapGisInput();

            var dics = new Dictionary<string, string>();
            dics.Add("案卷编号", this.txt_caseno.Text);
            dics.Add("项目名称", this.txt_ajmc.Text);

            dics.Add("土地位置", this.txt_tdwz.Text);
            dics.Add("土地用途", this.txt_tdyt.Text);
            dics.Add("土地面积", this.txt_tdmj.Text);
            dics.Add("农用地", this.txt_nyd.Text);
            dics.Add("建设用地", this.txt_jsyd.Text);
            dics.Add("未利用地", this.txt_wlyd.Text);
            dics.Add("耕地", this.txt_gd.Text);
            dics.Add("批准文号", this.txt_pzwh.Text);
            dics.Add("批准时间", this.txt_pzsj.Text);
            dics.Add("审批状态", this.txt_spzt.SelectedItem.ToString());


            if (mg.DelMapGis(this.txt_caseno.Text, this.txt_wfid.Text))
            {
              
                //MessageBox.Show("删除成功!");
                if (mg.InputMapGis(this.txt_caseno.Text, this.txt_wfid.Text, dics))
                {
                    MessageBox.Show("更新成功!");


                }
                else
                {
                    MessageBox.Show("更新失败!");
                }

            }
            else
            {
                MessageBox.Show("删除旧记录失败!");
            }

           
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            ZDMapGisInput.ZDMapGisInput mg = new ZDMapGisInput.ZDMapGisInput();

           

           if (mg.DelMapGis(this.txt_caseno.Text, this.txt_wfid.Text))
            {
                MessageBox.Show("删除成功!");

            }
            else
            {
                MessageBox.Show("删除失败!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.txt_caseno.Text = "FPC2012000001";
            this.txt_wfid.Text= "17";
            this.txt_ajmc.Text = "潜江市2012年度第10批次农民个人建房用地（农地转用）";

            this.txt_tdwz.Text = "潜江市周矶管理区、西大院管理区、总口管理区、后湖管理区、高场办事处、浩口镇";
            this.txt_tdyt.Text = "住宅用地";
            this.txt_tdmj.Text = "13.411200000000001";
            this.txt_nyd.Text = "13.3459";
            this.txt_jsyd.Text = "12.5253";
            this.txt_wlyd.Text = "0.6489";
            this.txt_gd.Text = "0.0653";
            this.txt_pzwh.Text = "鄂土资函〔2012〕2579号";
            this.txt_pzsj.Text = "2012-10-11";
            this.txt_spzt.SelectedIndex = 0;
        }

        private void btn_check_Click(object sender, EventArgs e)
        {

        }
    }
}
