using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starsea.Egov.Tools
{
    public partial class UpdateLogInfo : Form
    {
        public UpdateLogInfo()
        {
            InitializeComponent();

            setLogInfo();

        }

        protected void setLogInfo(){
            string url = AppDomain.CurrentDomain.BaseDirectory + @"\UpdateLog.txt";
          FileStream fs = new FileStream(url, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str = sr.ReadToEnd();
            this.txt_loginfo.Text = str;
            sr.Close();
            fs.Close();        
        }
    }
}
