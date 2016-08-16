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
    public partial class TOOLS_AdobePdfPrint : Form
    {
        public TOOLS_AdobePdfPrint()
        {
            InitializeComponent();
            this.txt_docpath.Text = "C:\\temp.docx";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdobePdfPrint.printpdf print = new AdobePdfPrint.printpdf(this.txt_docpath.Text);
        }
    }
}
