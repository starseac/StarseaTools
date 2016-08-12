using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Starsea.Egov.filespackage;

namespace Starsea.Egov.Tools
{
    public partial class EGOV_FJ_FILES : Form
    {
        public EGOV_FJ_FILES()
        {
            InitializeComponent();
        }

        private void btn_files_Click(object sender, EventArgs e)
        {
            string tvnodetypeid = this.txt_tvnodetypeid.Text;

            string path = "d:\\";
            

            createpkg pkg = new createpkg();
            pkg.createFiles(tvnodetypeid, path);

            

          
        }
    }
}
