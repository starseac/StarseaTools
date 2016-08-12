using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starsea.Egov.Tools
{
    public partial class Starsea : Form
    {
        public Starsea()
        {
            InitializeComponent();
        }

        private void btn_check_fjs_Click(object sender, EventArgs e)
        {
         EGOV_CHECK_FJS fjs= new EGOV_CHECK_FJS();
         fjs.Show();
            
        }

        private void btn_check_del_Click(object sender, EventArgs e)
        {
          EGOV_CHECK_DEL del =new EGOV_CHECK_DEL();
          del.Show();
        }

        private void btn_check_sjjh_Click(object sender, EventArgs e)
        {
            EGOV_CHECK_SJJH sjjh=new EGOV_CHECK_SJJH();
            sjjh.Show();
        }

        private void btn_check_mdb_Click(object sender, EventArgs e)
        {
            DB_CHECK_MDB mdb=new DB_CHECK_MDB();
            mdb.Show();

        }

        private void btn_check_oracle_Click(object sender, EventArgs e)
        {
            DB_CHECK_ORACLE oracle = new DB_CHECK_ORACLE();
            oracle.Show();

            //DB_CHECK_OBJECT_EXPORT dbexp = new DB_CHECK_OBJECT_EXPORT();
            //dbexp.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EGOV_FJ_FILES file = new EGOV_FJ_FILES();
            file.Show();
        }

        private void btn_set_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting();
            setting.Show();
        }

        private void btn_check_sjjc_Click(object sender, EventArgs e)
        {
            EGOV_CHECK_SJJC sjjc = new EGOV_CHECK_SJJC();
            sjjc.Show();
        }

        private void btn_updatelog_Click(object sender, EventArgs e)
        {
            UpdateLogInfo info = new UpdateLogInfo();
            info.Show();
            

        }
    }
}
