using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace egovtools.forms.sqlCreate
{
    public partial class workflowDataClean : Form
    {
        public workflowDataClean()
        {
            InitializeComponent();
        }

        private void SqlCreate_Click(object sender, EventArgs e)
        {
            if (flowList.SelectedItem ==null)
            {
                MessageBox.Show("请选着流程");
            }
            else
            {

                String flowName = flowList.SelectedItem.ToString();
                String gwfw_delete = "--公文发文\n" +
                                    "--流程表 在办箱\r\n" +
                                    "delete from t_wf_wfproject where caseid like '%GWFW%';\r\n" +
                                    "delete from t_wf_caseinwf where caseid like '%GWFW%';\r\n" +
                                    "delete from t_wf_rules_nodemerge where caseid like '%GWFW%' ;\r\n" +
                                    "--意见表  --移交窗口意见\r\n" +
                                    "delete from t_PJ_OPINION where caseid like '%GWFW%' ;\r\n" +
                                    "--意见生成表  --移交窗口意见\r\n" +
                                    "delete from  t_PJ_OPINIONdex where caseid like '%GWFW%' ;\r\n" +
                                    "--数据表\r\n" +
                                    "delete from gw_newfw ;\r\n" +
                                    "--正文表\r\n" +
                                    "delete from T_LST_CASECONTENT  where caseid like '%GWFW%' ;\r\n" +
                                    "delete from T_LST_CASECONTENT  where caseid like '%GWFW%' ;\r\n" +
                                    "--上传材料表;\r\n" +
                                    "delete from t_pj_accessory where caseid like '%GWFW%' ;\r\n" +
                                    "--归档表\r\n" +
                                    "delete from T_LJGD where caseno like '%GWFW%'  ;\r\n";

                String gwsw_delete = " --公文收文\r\n" +
                                   "--流程表 在办箱\r\n" +
                                   "delete from t_wf_wfproject where caseid like '%GWSW%' ;\r\n" +
                                   "delete from t_wf_caseinwf where caseid like '%GWSW%' ;\r\n" +
                                   "delete from t_wf_rules_nodemerge where caseid like '%GWSW%' ;\r\n" +
                                   "--意见表\r\n" +
                                   "delete from t_PJ_OPINION where caseid like '%GWSW%' ;\r\n" +
                                   "--意见生成表\r\n" +
                                   "delete from  t_PJ_OPINIONdex where caseid like '%GWSW%' ;\r\n" +
                                   "--数据表\r\n" +
                                   "delete from gw_newsw ;\r\n" +
                                   "--上传材料表\r\n" +
                                   "delete from t_pj_accessory where caseid like '%GWSW%' ;\r\n" +
                                   "--归档表\r\n" +
                                   "delete from T_LJGD where caseno like '%GWSW%'  ;\r\n" +
                                   "\r\n";

                if (flowName == "发文")
                {
                    sqlText.Text = gwsw_delete;
                }


            }
        }

        private void sqlCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(sqlText.Text, false);
            }
            catch (Exception exce)
            {
                MessageBox.Show("复制失败");
            }
            MessageBox.Show("已复制到粘贴板");
        }

    }
}
