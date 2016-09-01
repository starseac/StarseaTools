using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace egovtools.forms.bsfmtools
{
    public partial class ExcelSytleEmpty : Form
    {
        public ExcelSytleEmpty()
        {
            InitializeComponent();                      
        }

   

        private void styleClean_Click(object sender, EventArgs e)
        {
          

        }

        private void toText_Click(object sender, EventArgs e)
        {
            this.tableText.Text = this.richText.Text;
        }

      /*  private void cleanStyle() {
            String value = text1.Text;
            String[] str = value.Split('"');
            String ans = "";
            for (int i = 0; i < str.Length; i += 2)
            {
                ans += str[i];
            }

            text2.Text = ans;
            text2.Text = text2.Text.Replace("style=", " ");
            String textValue = text2.Text;

            text3.Text = text3.Text + "清除了style,";
        
        }

        private void cleanCol() {
            String textValue = text2.Text;
            int col_start = textValue.IndexOf("<COLGROUP");
            int col_end = textValue.IndexOf("<TBODY");
           // Console.WriteLine(col_start);
           // Console.WriteLine(col_end);
            text2.Text = textValue.Substring(0, col_start) + textValue.Substring(col_end + 1);

            text3.Text = text3.Text + "清除了col,";
        }

        private void cleanFont() {
            text2.Text = text2.Text.Replace("</FONT>", " ");

            int font_start= text2.Text.IndexOf("<FONT");
            int font_end = text2.Text.IndexOf("face=宋体>");
           // Console.WriteLine(font_start);
           // Console.WriteLine(font_end);
           // text2.Text = text2.Text.Substring(0, font_start) + text2.Text.Substring(font_end + 11);


            text3.Text = text3.Text + '\n' + "清空font标记";
        
        }


        private void button2_Click(object sender, EventArgs e)
        {
            cleanStyle();
            cleanCol();
            cleanFont();      
          
           
            

        }

        private void clean_Click(object sender, EventArgs e)
        {
            text1.Text = "";
            text2.Text = "";
            text3.Text = "";

        }

        private void delSpace_Click(object sender, EventArgs e)
        {
            text2.Text = text2.Text.Replace("  ", " ");
            text2.Text = text2.Text.Replace(" <", "<");
            //text2.Text = text2.Text.Replace('\n',' ');

            //text2.Text = text2.Text.Replace("  </FONT>", "</FONT>");
        }    */　

    } 
  
}
