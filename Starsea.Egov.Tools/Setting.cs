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
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();

            txtUSERNAME.Text = System.Configuration.ConfigurationSettings.AppSettings["username"].ToString();
            txtPASSWORD.Text = System.Configuration.ConfigurationSettings.AppSettings["password"].ToString();
            txtDATASOURCE.Text = System.Configuration.ConfigurationSettings.AppSettings["datasource"].ToString();

            txtConnectionStringEncrypt.Text = System.Configuration.ConfigurationManager.ConnectionStrings["dn0pdaWh13ErOsc3pzeiQw=="].ConnectionString;


        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            string username = txtUSERNAME.Text;
            string password = txtPASSWORD.Text;
            string datasource = txtDATASOURCE.Text;

            txtConnectionString.Text = "Password=" + password + ";User ID=" + username + ";Data Source=" + datasource + ";Persist Security Info=True";
            string connStr = txtConnectionString.Text;
            string connStrEncrtype = BSI.EnterpriseLibrary.Utility.Encoder.ECBEncoder.Encrypt(connStr);

            txtConnectionStringEncrypt.Text = connStrEncrtype;
        }


        private void btn_set_Click(object sender, EventArgs e)
        {
            string username = txtUSERNAME.Text;
            string password = txtPASSWORD.Text;
            string datasource = txtDATASOURCE.Text;

          
            txtConnectionString.Text = "Password="+password+";User ID="+username+";Data Source="+datasource+";Persist Security Info=True";
            string connStr = txtConnectionString.Text;
            string connStrEncrtype = BSI.EnterpriseLibrary.Utility.Encoder.ECBEncoder.Encrypt(connStr);

            txtConnectionStringEncrypt.Text = connStrEncrtype;

        
            SetValue("appSettings","key","username","value" ,username);
            SetValue("appSettings", "key", "password", "value" ,password);
            SetValue("appSettings", "key", "datasource","value" , datasource);

            SetValue("connectionStrings", "name", "dn0pdaWh13ErOsc3pzeiQw==", "connectionString", connStrEncrtype);
          
        }


        public static void SetValue(string nodename, string selectKey, string selectKeyValue,string setKeyName, string setKeyValue)
        {
            System.Xml.XmlDocument xDoc = new System.Xml.XmlDocument();
            xDoc.Load(System.Windows.Forms.Application.ExecutablePath + ".config");

            System.Xml.XmlNode xNode;
            System.Xml.XmlElement xElem1;
           // System.Xml.XmlElement xElem2;
            xNode = xDoc.SelectSingleNode("//"+nodename+"");

            xElem1 = (System.Xml.XmlElement)xNode.SelectSingleNode("//add[@" + selectKey + "='" + selectKeyValue + "']");
            if (xElem1 != null) xElem1.SetAttribute(setKeyName, setKeyValue);
            //else
            //{
            //    xElem2 = xDoc.CreateElement("add");
            //    xElem2.SetAttribute("key", AppKey);
            //    xElem2.SetAttribute("value", AppValue);
            //    xNode.AppendChild(xElem2);
            //}
            xDoc.Save(System.Windows.Forms.Application.ExecutablePath + ".config");
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

       
    }
}
