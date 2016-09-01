using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BSI.EnterpriseLibrary.Utility.Encoder;

namespace decode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //暴力破解算法
        private string pojie(String str){
            string[]  code = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            for (int i = 1; i < 2;i++ )
            {
                string sumcode = "";
                for (int j = 0; i < code.Length;j++ )
                {
                    for (int k = 0; k < i + 1;k++ )
                    {
                        sumcode+=code[k];

                    }

                }
               

            }
            return "hello";
        }
        
        private void cleanBtn_Click(object sender, EventArgs e)
        {
            inText.Text = "";
            outText.Text = "";
        }

        private void decryptBtn_Click(object sender, EventArgs e)
        {
            string inString=inText.Text;
            if (inString == "")
            {
                MessageBox.Show("请输入字符！");
            }
            if(inString!="" && type1.Checked==true) {
                try {
                    outText.Text = ECBEncoder.Decrypt(inString);
                
                }catch(Exception ex){
                  MessageBox.Show("发生错误");
                } 
            
            }
            if (inString != "" && type2.Checked == true)
            {
                 try { 
                      outText.Text = "对不起，无法破解！";
                
                }catch(Exception ex){
                MessageBox.Show("发生错误");
                }

            }
        }

        private void encryptBtn_Click(object sender, EventArgs e)
        {
            string inString = inText.Text;
            if (inString == "")
            {
                MessageBox.Show("请输入字符！");
            }
            if (inString != "" && type1.Checked == true)
            {
                 try { 
                     outText.Text = ECBEncoder.Encrypt(inString);
                
                }catch(Exception ex){
                MessageBox.Show("发生错误");
                } 

            }
            if (inString != "" && type2.Checked == true)
            {
                try { 
                    outText.Text = MD5Encoder.Encrypt(inString);
                
                }catch(Exception ex){
                    MessageBox.Show("发生错误");
                }  

            }
        }

       
    }
}
