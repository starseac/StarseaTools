using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SCANNER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.button1.Text != "停止")
            {
                axDoccameraOcx1.bStopPlay();
                //axDoccameraOcx1.vSetSkewFlag(true);
                //axDoccameraOcx1.vSetDelHBFlag(true);
                axDoccameraOcx1.bStartPlay();
                this.button1.Text = "停止";
            }
            else
            {
                axDoccameraOcx1.bStopPlay();
                this.button1.Text = "启动";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.button2.Text != "继续拍摄")
            {
                axDoccameraOcx1.bSavePDFStart(@"c:\", "test");

                this.button2.Text = "继续拍摄";
            }
            else
            {
                axDoccameraOcx1.bSavePDFColorPage();

            }
        }

       
        private void button4_Click(object sender, EventArgs e)
        {
             axDoccameraOcx1.bSavePDFColorPage();
            axDoccameraOcx1.bSavePDFEnd();
            if (this.button2.Text == "继续拍摄")
            {
                this.button2.Text = "拍摄";
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

       

        private void button5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
