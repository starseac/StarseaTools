using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StrToDate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date1 = this.textBox1.Text;

            DateTime dt = DateTime.Parse(date1);

            this.textBox2.Text = dt.Date.ToString();

            int year = dt.Year;
            string yearStr = year+"";
            int month = dt.Month;
            string monthStr = "";
            int day = dt.Day;
            string dayStr = "";

            if(month<10){
                monthStr = "0" + month;
            }else{
                monthStr=month+"";
            }
            if (day < 10)
            {
                dayStr = "0" + day;
            }else{
                dayStr = day + "";            
            }

            this.textBox3.Text = yearStr + monthStr + dayStr;

        }
    }
}
