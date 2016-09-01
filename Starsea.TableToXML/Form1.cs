using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using TableToXML.DATA;
using System.Data.OracleClient;



namespace TableToXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.CasenoText.Text==""){
                MessageBox.Show("案卷编号不能为空!");
            }else {
                this.xmlText.Text = createXMLstring(this.CasenoText.Text, this.lczt.SelectedItem.ToString());
                // this.label2.Text = "字段个数：" + this.filedsArrayModel(this.CasenoText.Text).GetLength(0);
                string[][][] point = this.xyPoints(this.CasenoText.Text);
                string str = "";
                //for(int i=0;i<point.GetLength(0);i++){
                //    str+=point[i].GetLength(0)+"\n\r";
                //}
                this.label4.Text = "坐标点个数：" + str;
            
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetDataObject(this.xmlText.Text, false);
            }
            catch (Exception exce)
            {
                MessageBox.Show("复制失败");
            }
            MessageBox.Show("已复制到粘贴板");

        }

        private void address_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (address.SelectedItem.ToString() == "黄石")
            {
                this.wsURL.Text = "http://10.10.10.5:8060/CommonService.svc";
            }
            else if (address.SelectedItem.ToString() == "大冶")
            {
                this.wsURL.Text = "http://10.10.8.205:8060/CommonService.svc";
            }
        }

        private void Done_Click(object sender, EventArgs e)
        {
            if (this.addFuction.Checked == true)
            {

            }
            else if (this.updateFuction.Checked == true)
            {

            }
            else if (this.deleteFuction.Checked == true)
            {

            }
        }
             

        //获取数据表
        public DataTable getDataTable(String caseno)
        {
            //-------
            string TableName = GetTableName(caseno);
            string sql = "select * from " + TableName + " where " + this.GetKYQStyle(caseno) + " = '" + caseno + "'";
            Database db = new Database();
            OracleConnection conn = db.getConnection();
            try
            {
                conn.Open();
                OracleDataAdapter da = new OracleDataAdapter(sql, conn);
                // DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                da.Fill(dt);
                // this.textBox2.Text = ds.Tables[0].Rows[0][0].ToString();
                //DateTable dt = ds.Tables[0];
                return dt;

            }
            catch (Exception eg)
            {
                throw eg;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        //转换申请序号
        public string ChangeCaseno(string caseno)
        {
            return caseno.Replace("CKQXL", "CKXL").Replace("CKQBG", "CKBG").Replace("CKQZX", "CKZX").Replace("CKQHK", "CKHK").Replace("CKQYX", "CKYX");
        }

        //生成xml格式的数据   
        public string createXMLstring(string caseno, string lczt)
        {
            StringWriter sw = new StringWriter();

            XmlTextWriter xw = new XmlTextWriter(sw);
            try
            {
                xw.Formatting = Formatting.Indented;

                xw.WriteStartDocument();

                xw.WriteStartElement("Process");
                //--获取process的属性值
                xw.WriteAttributeString("id", caseno);
                string[] nat = getProcessNameAndType(caseno);
                xw.WriteAttributeString("name", nat[0]);
                xw.WriteAttributeString("type", nat[1]);

                //--坐标
                xw.WriteStartElement("Polygons");

                xw.WriteStartElement("Polygon");
                xw.WriteAttributeString("Coordinate", "XiAn_80");

                //----添加多环解析 
                //--获取坐标点数组，并添加坐标点到xml中
                string[][][] points = xyPoints(caseno);
                //坐标字符为非空的时候才添加
                if (points != null)
                {
                    for (int i = 0; i < points.GetLength(0); i++)
                    {
                        for (int j = 0; j < points[i].GetLength(0); j++)
                        {
                            if (j == 0)
                            {
                                xw.WriteStartElement("Ring");
                                xw.WriteAttributeString("type", points[i][j][0]);
                            }
                            else
                            {
                                xw.WriteStartElement("Point");
                                xw.WriteAttributeString("x", points[i][j][0]);
                                xw.WriteAttributeString("y", points[i][j][1]);
                                xw.WriteAttributeString("h", "0");
                                xw.WriteEndElement();
                            }

                        }
                        xw.WriteEndElement();
                        //-----
                    }

                }

                xw.WriteEndElement();
                xw.WriteEndElement();

                //-----数据
                xw.WriteStartElement("Fields");

                //--for
                string[,] fileds = Getfileds(caseno, lczt);
                if (fileds != null)
                {
                    for (int i = 0; i < fileds.GetLength(0); i++)
                    {
                        xw.WriteStartElement("Field");
                        xw.WriteAttributeString("name", fileds[i, 0]);
                        xw.WriteAttributeString("type", fileds[i, 1]);
                        xw.WriteAttributeString("length", fileds[i, 2]);
                        xw.WriteString(fileds[i, 3]);
                        xw.WriteEndElement();
                    }
                }


                //--end for 
                xw.WriteEndElement();

                xw.WriteEndElement();

                xw.WriteEndDocument();

                xw.Flush();
                xw.Close();

            }
            catch (Exception EG)
            {

                Console.Write(EG);

            }

            string xml = sw.ToString();
            return xml;
        }
        //是探矿还是采矿,然后返回主键字段名称
        private string GetKYQStyle(string caseno)
        {
            string key = "";
            if (caseno.Substring(0, 2) == "CK")
            {
                key = "unused1";
            }
            else if (caseno.Substring(0, 2) == "TK")
            {
                key = "caseno";
            }
            return key;

        }
        // 获取数据表名
        private string GetTableName(string caseno)
        {
            if (caseno != "" && caseno.Length > 6)
            {
                caseno = ChangeCaseno(caseno);
                switch (caseno.Substring(0, 6))
                {
                    case "CKHK20":
                    case "CKQHK2":
                        return "划定矿区范围";
                    case "CKXL20":
                    case "CKYS20":
                    case "CKBG20":
                    case "CKYX20":
                    case "CKZX20":
                    case "CKQXL2":
                    case "CKQBG2":
                    case "CKQYX2":
                    case "CKQZX2":
                        return "采矿申请登记";
                    case "CKZR20":
                    case "CKQZR2":
                        return "采矿转让登记";
                    case "TKKCFW":
                        return "BJ_50_08_KCQDKCFW";
                    case "TKXL20":
                        return "BJ_50_01_KCXLSQ";
                    case "TKHKBG":
                    case "TKHK20":
                        return "BJ_50_10_KCQBGKCFW";
                    case "TKBG20":
                        return "bj_50_03_kcbgsq";
                    case "TKYX20":
                        return "bj_50_02_kcyxsq";
                    case "TKZR20":
                        return "bj_50_07_kczrsq";
                    case "TKBL20":
                        return "bj_50_04_kcblsq";
                    case "TKZX20":
                        return "bj_50_05_kcbzxq";
                }
            }
            return "";
        }
        //获取 process 的name 和type值 flowsn

        private string[] getProcessNameAndType(string caseno)
        {
            string[] pat = new string[3];
            if (caseno != "" && caseno.Length > 6)
            {
                caseno = ChangeCaseno(caseno);
                if (caseno.Substring(0, 6) == "CKHK20" || caseno.Substring(0, 6) == "CKQHK2")
                {
                    pat[0] = "采矿权划定矿区范围"; pat[1] = "KC01"; pat[2] = "11064";
                }
                else if (caseno.Substring(0, 6) == "CKXL20" || caseno.Substring(0, 6) == "CKQXL2")
                {
                    pat[0] = "采矿权新立"; pat[1] = "KC03"; pat[2] = "11023";
                }
                else if (caseno.Substring(0, 6) == "CKYS20")
                {
                    pat[0] = "采矿权变更划定矿区范围"; pat[1] = "KC02"; pat[2] = "11098";
                }
                else if (caseno.Substring(0, 6) == "CKBG20" || caseno.Substring(0, 6) == "CKQBG2")
                {
                    pat[0] = "采矿权变更"; pat[1] = "KC04"; pat[2] = "11065";
                }
                else if (caseno.Substring(0, 6) == "CKYX20" || caseno.Substring(0, 6) == "CKQYX2")
                {
                    pat[0] = "采矿权延续"; pat[1] = "KC05"; pat[2] = "11067";
                }
                else if (caseno.Substring(0, 6) == "CKZR20" || caseno.Substring(0, 6) == "CKQZR2")
                {
                    pat[0] = "采矿权转让"; pat[1] = "KC06"; pat[2] = "11024";
                }
                else if (caseno.Substring(0, 6) == "CKZX20" || caseno.Substring(0, 6) == "CKQZX2")
                {
                    pat[0] = "采矿权注销"; pat[1] = "KC07"; pat[2] = "11068";
                }
                else if (caseno.Substring(0, 6) == "TKKCFW")
                {
                    pat[0] = "探矿权划定勘查区范围"; pat[1] = "KT01"; pat[2] = "11125";
                }
                else if (caseno.Substring(0, 6) == "TKXL20")
                {
                    pat[0] = "探矿权新立"; pat[1] = "KT02"; pat[2] = "11126";
                }
                else if (caseno.Substring(0, 6) == "TKHKBG" || caseno.Substring(0, 6) == "TKHK20")
                {
                    pat[0] = "探矿权变更预核准"; pat[1] = "KT03"; pat[2] = "11225";
                }
                else if (caseno.Substring(0, 6) == "TKBG20")
                {
                    pat[0] = "探矿权变更"; pat[1] = "KT04"; pat[2] = "11170";
                }
                else if (caseno.Substring(0, 6) == "TKYX20")
                {
                    pat[0] = "探矿权延续"; pat[1] = "KT05"; pat[2] = "11171";
                }              
                else if (caseno.Substring(0, 6) == "TKBL20")
                {
                    pat[0] = "探矿权保留"; pat[1] = "KT06"; pat[2] = "11172";
                }
                else if (caseno.Substring(0, 6) == "TKZR20")
                {
                    pat[0] = "探矿权转让"; pat[1] = "KT07"; pat[2] = "11127";
                }
                else if (caseno.Substring(0, 6) == "TKZX20")
                {
                    pat[0] = "探矿权注销"; pat[1] = "KT08"; pat[2] = "11173";
                }

            }
            return pat;
        }

        public string GetFlowID(string caseno)
        {
            if (caseno != "" && caseno.Length > 6)
            {
                return getProcessNameAndType(caseno)[2];
            }
            return "";
        }


        //取得坐标的x y值数组
        private string[][][] xyPoints(string caseno)
        {
            //string[,] filedsArray = this.filedsArrayModel(caseno);
            DataTable dt = this.getDataTable(caseno);
            //接收坐标数组
            string[][][] xyPoints = null;
            //判断是采矿 还是探矿
            string str = "";
            //如果是探矿权的

            if (this.GetKYQStyle(caseno) == "caseno")
            {
                if (caseno.Substring(0, 4) == "TKZX")
                {
                    //若果是探矿 注销的的，在 数据表里没有这个 “区域范围”的字段，则会报错
                    str = "";
                }
                else if (caseno.Substring(0, 4) == "TKZR")
                {
                    str = dt.Rows[0]["区域坐标"].ToString();
                }
                else
                {
                    str = dt.Rows[0]["区域范围"].ToString();
                }
                if (str != "")
                {

                    string[] pointsStr = str.Split(',');

                    //坐标环数
                    int ringNum = Convert.ToInt32(pointsStr[0]);
                    //如果是单环坐标
                    if (ringNum == 1)
                    {
                        //坐标点个数                   
                        int len = Convert.ToInt32(pointsStr[1]);

                        xyPoints = new string[1][][];
                        xyPoints[0] = new string[len + 1][];

                        for (int j = 0; j < xyPoints[0].GetLength(0); j++)
                        {
                            xyPoints[0][j] = new string[2];
                            if (j == 0)
                            {
                                //内 外环 标识
                                xyPoints[0][j][0] = "1";
                                //
                                xyPoints[0][j][1] = "0";
                            }
                            else
                            {
                                //x坐标
                                xyPoints[0][j][0] = pointsStr[2 + 2 * (j - 1)];
                                //y坐标
                                xyPoints[0][j][1] = pointsStr[2 + 2 * (j - 1) + 1];

                            }

                        }

                    }
                    //如果是多环坐标
                    else if (ringNum > 1)
                    {
                        //每个环的坐标个数值的下标值的数组 和环的类型的下标值
                        int[] singRingNum = new int[ringNum];
                        int[] singRingType = new int[ringNum];
                        //获取所有环的 坐标点个数值和环类型参数 在 pointsStr数组中的下标值
                        for (int i = 0; i < ringNum; i++)
                        {
                            if (i == 0)
                            {
                                singRingNum[i] = 1;
                                singRingType[i] = 1 + Convert.ToInt32(pointsStr[singRingNum[i]]) * 2 + 4;
                            }
                            else if (i > 0)
                            {
                                singRingNum[i] = singRingNum[i - 1] + Convert.ToInt32(pointsStr[singRingNum[i - 1]]) * 2 + 3 + 1;
                                singRingType[i] = singRingNum[i] + Convert.ToInt32(pointsStr[singRingNum[i]]) * 2 + 2;
                            }

                        }
                        //输出坐标数组
                        xyPoints = new string[ringNum][][];
                        for (int i = 0; i < ringNum; i++)
                        {
                            xyPoints[i] = new string[Convert.ToInt32(pointsStr[singRingNum[i]]) + 1][];

                            for (int j = 0; j < xyPoints[i].GetLength(0); j++)
                            {
                                xyPoints[i][j] = new string[2];
                                //数组第一行设置 环类型
                                if (j == 0)
                                {
                                    //环类型 如果 环坐标字符窜最后一行中间的一个字符是0，则为外环赋值1，不是0 ，就是外环，赋值-1，
                                    if (pointsStr[singRingType[i]] == "0")
                                    {
                                        xyPoints[i][j][0] = "1";
                                    }
                                    else
                                    {
                                        xyPoints[i][j][0] = "-1";
                                    }
                                    //冗余值
                                    xyPoints[i][j][1] = "0";
                                }
                                else
                                {
                                    //x坐标
                                    xyPoints[i][j][0] = pointsStr[singRingNum[i] + (j - 1) * 2 + 1];
                                    //y坐标
                                    xyPoints[i][j][1] = pointsStr[singRingNum[i] + (j - 1) * 2 + 2];
                                }
                            }

                        }

                    }


                }
                else
                {
                    xyPoints = new string[0][][];
                }
            }
            //若果是采矿权的
            else if (this.GetKYQStyle(caseno) == "unused1")
            {
                str = dt.Rows[0]["区域坐标"].ToString();
                if (str != "")
                {
                    string[] pointsStr = str.Split(',');
                    //获取环数
                    int ringNum = Convert.ToInt32(pointsStr[0]);

                    //如果环数为1 ---------???或者是环数虽大于1 但是 格式不对的话 ，当作单环处理
                    if (ringNum == 1)
                    {
                        int len = Convert.ToInt32(pointsStr[1]);
                        xyPoints = new string[1][][];
                        xyPoints[0] = new string[len + 1][];

                        for (int i = 0; i < len + 1; i++)
                        {
                            xyPoints[0][i] = new string[2];
                            if (i == 0)
                            {
                                //环类型
                                xyPoints[0][i][0] = "1";
                                //冗余值
                                xyPoints[0][i][1] = "0";
                            }
                            else
                            {
                                //x坐标
                                xyPoints[0][i][0] = pointsStr[1 + 3 * (i - 1) + 3];
                                //y坐标
                                xyPoints[0][i][1] = pointsStr[1 + 3 * (i - 1) + 2];
                            }
                        }
                    }
                    //多环
                    else if (ringNum > 1)
                    {
                        //每个环的坐标个数值的下标值的数组 和环的类型的下标值
                        int[] singRingNum = new int[ringNum];
                        int[] singRingType = new int[ringNum];
                        //获取所有环的 坐标点个数值和环类型参数 在 pointsStr数组中的下标值
                        for (int i = 0; i < ringNum; i++)
                        {
                            if (i == 0)
                            {
                                singRingNum[i] = 1;
                                singRingType[i] = 1 + Convert.ToInt32(pointsStr[singRingNum[i]]) * 3 + 4;
                            }
                            else if (i > 0)
                            {
                                singRingNum[i] = singRingNum[i - 1] + Convert.ToInt32(pointsStr[singRingNum[i - 1]]) * 3 + 4 + 1;
                                singRingType[i] = singRingNum[i] + Convert.ToInt32(pointsStr[singRingNum[i]]) * 3 + 4;
                            }

                        }

                        xyPoints = new string[ringNum][][];
                        for (int i = 0; i < ringNum; i++)
                        {
                            xyPoints[i] = new string[Convert.ToInt32(pointsStr[singRingNum[i]]) + 1][];

                            for (int j = 0; j < xyPoints[i].GetLength(0); j++)
                            {
                                xyPoints[i][j] = new string[2];
                                if (j == 0)
                                {
                                    //环类型 如果 环坐标字符窜最后一个字符不是1 ，则赋值-1
                                    if (pointsStr[singRingType[i]] == "1")
                                    {
                                        xyPoints[i][j][0] = pointsStr[singRingType[i]];
                                    }
                                    else
                                    {
                                        xyPoints[i][j][0] = "-1";
                                    }
                                    //冗余值
                                    xyPoints[i][j][1] = "0";
                                }
                                else
                                {
                                    //x坐标
                                    xyPoints[i][j][0] = pointsStr[singRingNum[i] + (j - 1) * 3 + 3];
                                    //y坐标
                                    xyPoints[i][j][1] = pointsStr[singRingNum[i] + (j - 1) * 3 + 2];
                                }
                            }


                        }

                    }


                }
                else
                {
                    xyPoints = new string[0][][];
                }
            }

            return xyPoints;
        }


        //接口xml模板数组
        private string[,] filedsArrayModel(string caseno)
        {
            string[,] array = null;

            //--采矿权划定矿区范围
            string[,] array_hdkqfw = new string[49, 4]{
                {"BSM","Int","4",""},  //--标识码
                {"YSDM","String","10",""}, //--要素代码
                {"SQXH","String","30","unused1"},//--申请序号  ----必填
                {"XMMC","String","200","矿区名称"},//--项目名称 ----必填
                {"KQMC","String","100","矿区名称"},//--矿区名称
                {"SQR","String","100","申请人"},//--申请人
                {"XMLX","Int","4","项目类型"},//--项目类型
                {"XMLXMC","String","40",""},//--项目类型名称
                {"JJLX","Int","4","经济类型"},//--经济类型
                {"JJLXMC","String","20",""},//--经济类型名称
                {"FDDBR","String","100","法定代表人"},//--法定代表人
                {"LXR","String","20",""},//--联系人
                {"DZ","String","255","地址"},//--地址
                {"YB","String","6","邮编"},//--邮编
                {"DH","String","20","电话"},//--电话
                {"KCZKZ","Int","4","开采主矿种"},//--开采主矿种
                {"KCZKZMC","String","20",""},//--开采主矿种名称
                {"QTZKZ","String","60","其它主矿种"},//--其他主矿种
                {"SZXZQ","Int","4","所在行政区"},//--所在行政区
                {"SZXZQMC","String","20","所在行政区名称"},//--所在行政去名称
                {"DLWZ","String","100",""},//--地理位置
                {"YXQQ","Date","36","有效期起"},//--有效期 起
                {"YXQZ","Date","36","有效期止"},//--有效期 止
                {"SJGM","Double","8","规划规模"},//--设计规模
                {"GMDW","String","10","规模单位"},//--规模单位
                {"KCFS","String","20",""},//--开采方式
                {"QDFSDM","Int","4","取得方式代码"},//--取得方式代码
                {"CKQQDFS","String","20","采矿权取得方式"},//--采矿权取得方式
                {"QYZB","String","255","区域坐标"},//--区域坐标
                {"DJQ","Double","8","东经起"},//--东经起
                {"DJZ","Double","8","东经止"},//--东经止
                {"BWQ","Double","8","北纬起"},//--北纬起
                {"BWZ","Double","8","北纬止"},//--北纬止
                {"BGLX","String","10",""},//--变更类型
                {"BGNR","String","255",""},//--变更类容
                {"KTID","String","10",""},//--矿体标识
                {"LCZT","String","6","$LCZT"},//--流程状态   ----必填
                {"FLOWSN","String","20","$FLOWSN"},//--业务标识 ----必填
                {"CSSX","Double","8","采深上限"},//--采深上限
                {"CSXX","Double","8","采深下限"},//--采深下限
                {"GBSLX","Int","4","共伴生类型"},//--共半生类型
                {"XZ","Int","4",""},//--性质
                {"ZBXT","Int","4",""},//--坐标系统
                {"BZ","String","255","备注"},//--备注
                {"YYSJ","String","50",""},//--引用资料时间
                {"DZCL","String","255",""},//--地质储量
                {"KCCL","String","255",""},//--可采储量
                {"GHSCNL","String","255",""},//--规划生产能力
                {"SCYJ","String","255","审查意见"}//--审查意见
            };

            //--变更矿区范围
            string[,] array_bghdkqfw = new string[49, 4]{
                {"BSM","Int","4",""},  //--标识码
                {"YSDM","String","10",""}, //--要素代码
                {"SQXH","String","30","unused1"},//--申请序号  ----必填
                {"XMMC","String","200","矿山名称"},//--项目名称 ----必填
                {"KQMC","String","100","矿山名称"},//--矿区名称
                {"SQR","String","100","申请人"},//--申请人
                {"XMLX","Int","4","项目类型"},//--项目类型
                {"XMLXMC","String","40",""},//--项目类型名称
                {"JJLX","Int","4","经济类型"},//--经济类型
                {"JJLXMC","String","20",""},//--经济类型名称
                {"FDDBR","String","100","法定代表人"},//--法定代表人
                {"LXR","String","20",""},//--联系人
                {"DZ","String","255","地址"},//--地址
                {"YB","String","6","邮编"},//--邮编
                {"DH","String","20","电话"},//--电话
                {"KCZKZ","Int","4","开采主矿种"},//--开采主矿种
                {"KCZKZMC","String","20",""},//--开采主矿种名称
                {"QTZKZ","String","60","其它主矿种"},//--其他主矿种
                {"SZXZQ","Int","4","所在行政区"},//--所在行政区
                {"SZXZQMC","String","20","所在行政区名称"},//--所在行政去名称
                {"DLWZ","String","100",""},//--地理位置
                {"YXQQ","Date","36","有效期起"},//--有效期 起
                {"YXQZ","Date","36","有效期止"},//--有效期 止
                {"SJGM","Double","8","设计规模"},//--设计规模
                {"GMDW","String","10","规模单位"},//--规模单位
                {"KCFS","String","20","开采方式"},//--开采方式
                {"QDFSDM","Int","4","取得方式代码"},//--取得方式代码
                {"CKQQDFS","String","20","采矿权取得方式"},//--采矿权取得方式
                {"QYZB","String","255","区域坐标"},//--区域坐标
                {"DJQ","Double","8","东经起"},//--东经起
                {"DJZ","Double","8","东经止"},//--东经止
                {"BWQ","Double","8","北纬起"},//--北纬起
                {"BWZ","Double","8","北纬止"},//--北纬止
                {"BGLX","String","10","变更类型"},//--变更类型
                {"BGNR","String","255","变更内容"},//--变更类容
                {"KTID","String","10",""},//--矿体标识
                {"LCZT","String","6","$LCZT"},//--流程状态   ----必填
                {"FLOWSN","String","20","$FLOWSN"},//--业务标识 ----必填
                {"CSSX","Double","8","采深上限"},//--采深上限
                {"CSXX","Double","8","采深下限"},//--采深下限
                {"GBSLX","Int","4","共伴生类型"},//--共半生类型
                {"XZ","Int","4",""},//--性质
                {"ZBXT","Int","4",""},//--坐标系统
                {"BZ","String","255","备注"},//--备注
                {"YYSJ","String","50",""},//--引用资料时间
                {"DZCL","String","255",""},//--地质储量
                {"KCCL","String","255",""},//--可采储量
                {"GHSCNL","String","255",""},//--规划生产能力
                {"SCYJ","String","255","审查人意见"}//--审查意见
            };

            //--采矿权新立模板 、变更模板、延续模板、注销模板
            string[,] array_sqb = new string[56, 4]{
                {"BSM","Int","4",""},  //--标识码
                {"YSDM","String","10",""}, //--要素代码
                {"SQXH","String","30","unused1"},//--申请序号  ----必填
                {"XKZH","String","25","许可证号"},//--许可证号
                {"XMDAH","String","30","unused1"},//--项目档案号  --把项目档案号替换为案卷编号
                {"FZJGBM","String","10","发证机关编码"},//--发证机关编码
                {"FZJGMC","String","40","发证机关名称"},//--发证机关名称
                {"QFSJ","Date","8","签发时间"},//--签发时间
                {"XMMC","String","100","矿山名称"},//--项目名称 ----必填               
                {"SQR","String","100","申请人"},//--申请人
                {"XMLX","Int","4","项目类型"},//--项目类型
                {"XMLXMC","String","40",""},//--项目类型名称
                {"JJLX","Int","4","经济类型"},//--经济类型
                {"JJLXMC","String","20",""},//--经济类型名称
                {"FDDBR","String","100","法定代表人"},//--法定代表人
                {"LXR","String","20",""},//--联系人
                {"DZ","String","255","地址"},//--地址
                {"YB","String","6","邮编"},//--邮编
                {"DH","String","20","电话"},//--电话
                {"KSMC","String","100","矿山名称"},//--矿区名称
                {"KCZKZ","Int","4","开采主矿种"},//--开采主矿种
                {"KCZKZMC","String","20",""},//--开采主矿种名称
                {"QTZKZ","String","60","其它主矿种"},//--其他主矿种
                {"SZXZQ","Int","4","所在行政区"},//--所在行政区
                {"SZXZQMC","String","20","所在行政区名称"},//--所在行政去名称
                {"DLWZ","String","100",""},//--地理位置
                {"YXQQ","Date","36","有效期起"},//--有效期 起
                {"YXQZ","Date","36","有效期止"},//--有效期 止
                {"SJGM","Double","8","设计规模"},//--设计规模
                {"GMDW","String","10","规模单位"},//--规模单位
                {"KCFS","String","20","开采方式"},//--开采方式
                {"QDFSDM","Int","4","取得方式代码"},//--取得方式代码
                {"CKQQDFS","String","20","采矿权取得方式"},//--采矿权取得方式
                {"QYZB","String","255","区域坐标"},//--区域坐标
                {"DJQ","Double","8","东经起"},//--东经起
                {"DJZ","Double","8","东经止"},//--东经止
                {"BWQ","Double","8","北纬起"},//--北纬起
                {"BWZ","Double","8","北纬止"},//--北纬止
                {"BGLX","String","10","变更类型"},//--变更类型
                {"BGNR","String","255","变更内容"},//--变更类容
                {"KTID","String","10",""},//--矿体标识
                {"LCZT","String","6","$LCZT"},//--流程状态   ----必填
                {"FLOWSN","String","20","$FLOWSN"},//--业务标识 ----必填
                {"CSSX","Double","8","采深上限"},//--采深上限
                {"CSXX","Double","8","采深下限"},//--采深下限
                {"YXKZH","String","25","原许可证号"},//--原许可证号
                {"YQFSJ","Date","8","原签发时间"},//--原签发时间
                {"YSQXH","String","28",""},//--原申请序号
                {"GBSLX","Int","4","共伴生类型"},//--共半生类型
                {"XZ","Int","4",""},//--性质
                {"ZBXT","Int","4",""},//--坐标系统
                {"SQYY","String","255",""},//--申请原因
                {"BZ","String","255","备注"},//--备注
                {"YYSJ","String","50",""},//--引用资料时间
                {"STYLE","String","10",""},//--图形类型
                {"TBRQ","Date","8",""}//--备注日期
            };
            //--采矿权转让模板  没有提供
            string[,] array_zr = new string[0, 0];

            //-----探矿权----------------

            //---探矿权划定勘查区范围   bj_50_08_kcqdkcfw 
            string[,] array_tkq_hdkcqfw = new string[27, 4]{
                {"BSM","Int","4",""},  //--标识码
                {"YSDM","String","10",""}, //--要素代码
                {"SQXH","String","30","caseno"},//--申请序号  ----必填               
                {"XMMC","String","100","项目名称"},//--项目名称 ----必填  
                {"TBRQ","Date","36","填表日期"},//--填表日期             
                {"SQR","String","100","申请人"},//--申请人
                {"ZKZ","Int","4","主矿种"},//--主矿种
                {"ZKZMC","String","15",""},//--主矿种名称
                {"DWFZR","String","30","单位负责人"},//--单位负责人  
                {"DH","String","50","电话号码"},//--电话
                {"DZ","String","50","地址"},//--地址
                {"YB","String","15","邮政编码"},//--邮编                
                {"GDZB","String","255","区域范围"},//--区域范围
                {"DTKCGK","String","255","地质矿产概况"},//--地址矿产概况
                {"TBR","String","15","填表人"},//--填表人
                {"XYJ","String","255","县意见"},//--县意见
                {"SYJ","String","255","省意见"},//--省意见
                {"XFZR","String","15","县负责人"},//--县负责人
                {"XYJSJ","Date","36","县意见时间"},//--县意见时间
                {"SJFZR","String","15","市负责人"},//--市负责人
                {"SJYJSJ","Date","36","市意见时间"},//--市意见时间
                {"SHJFZR","String","50","省负责人"},//--省负责人
                {"SHJYJSJ","Date","36","省意见时间"},//--省意见时间               
                {"QKMJ","String","25","区块面积"},//--区块面积
                {"ZBXT","Int","4",""},//--坐标系统              
                {"LCZT","String","6","$LCZT"},//--流程状态     ---必填
                {"FLOWSN","String","20","$FLOWSN"}//--业务标识     ---必填
            };

            //--探矿权新立

            string[,] array_tkqxl = new string[65, 4]{
                {"BSM","Int","4",""},//--标识码
                {"YSDM","String","10",""},//--要素代码
                {"SQXH","String","50","caseno"},//--申请序号    ---必填
                {"XKZH","String","25",""},//--许可证号
                {"XMDAH","String","25","caseno"},//--项目档案号    ---必填   --延续\变更\保留、数据表没有这个字段
                {"FZRQ","String","36",""},//--发证日期
                {"XMMC","String","200","项目名称"},//--项目名称     ---必填
                {"SQR","String","100","申请人名称"},//--申请人
                {"KCDW","String","100","勘查单位名称"},//--勘查单位
                {"ZGZH","String","20","资格证号"},//--资格证号
                {"KCDWDZ","String","255","勘查单位地址"},//--勘查单位地址
                {"KCKZ","Int","4","勘查矿种"},//--勘查矿种
                {"KCKZMC","String","50",""},//--勘查矿种名称
                {"ZMJ","Doublie","8","总面积"},//--总面积
                {"DLWZ","String","100","地理位置"},//--地理位置
                {"SZXZQ","String","60",""},//--所在行政区
                {"SZXZQMC","String","60",""},//--所在行政区名称
                {"SQRFRDB","String","100","法人代表"},//--申请人法人代表
                {"SQRLLY","String","20","联络员"},//--申请人联络员
                {"SQRDZ","String","255","地址"},//--申请人地址
                {"SQRYB","String","10","邮编"},//--申请人邮编
                {"SQRDH","String","20","电话"},//--申请人电话
                {"XMLX","String","10",""},//--项目类型
                {"XMLXMC","String","40",""},//--项目类型名称
                {"JJLX","Int","4","经济类型"},//--经济类型
                {"JJLXMC","String","20",""},//--经济类型名称
                {"KCJD","Int","4","勘查阶段"},//--勘查阶段
                {"KCJDMC","String","50",""},//--勘查阶段名称
                {"SCSLSJ","Date","8",""},//--首次设立时间
                {"SLRQ","Date","8",""},//--受理日期
                {"YXQQ","Date","8","申请有效期起"},//--有效期起
                {"YXQZ","Date","8","申请有效期止"},//--有效期止
                {"TKQQDFS","Int","4","探矿权取得方式"},//--探矿权取得方式
                {"TKQQDFSMC","String","50",""},//--探矿权取得方式名称
                {"KCTR","Double","8",""},//--勘查投入
                {"GJTZ","Double","8","国家投资"},//--中央投资
                {"DFTZ","Double","8","地方投资"},//--地方投资
                {"QYTZ","Double","8","企业投资"},//--企业投资
                {"WSTZ","Double","8","外商投资"},//--外商投资
                {"GRTZ","Double","8","个人投资"},//--个人投资
                {"QTTZ","Double","8","其他投资"},//--其他投资
                {"DYKCND","Double","8","第一勘查年度"},//--第一勘查年度
                {"DEKCND","Double","8","第二勘查年度"},//--第二勘查年度
                {"DSKCND","Double","8","第三勘查年度"},//--第三勘查年度
                {"QYZB","String","255","区域范围"},//--区域坐标
                {"DJQ","String","8",""},//--东经起
                {"DJZ","String","8",""},//--东经止
                {"BWQ","String","8",""},//--北纬起
                {"BWZ","String","8",""},//--北纬止
                {"XMXZ","Int","4","项目性质"},//--项目性质
                {"FZJGBH","String","10",""},//--发证机关编号
                {"FZJGMC","String","40",""},//--发证机关名称
                {"YSQXH","String","50",""},//--原申请序号
                {"YXKZH","String","25",""},//--原许可证号
                {"YXMMC","String","100",""},//--原项目名称
                {"YXMDAH","String","20",""},//--原项目档案号
                {"KTID","String","10",""},//--矿体标识
                {"LCZT","String","6","$LCZT"},//--流程状态      ---必填
                {"FLOWSN","String","20","$FLOWSN"},//--业务标识     ---必填
                {"BGLX","Int","4",""},//--变更类型
                {"BGYY","String","255",""},//--变更原因
                {"SQZXLY","String","255",""},//--申请注销理由
                {"BZ","String","255",""},//--备注
                {"ZBXT","Int","4",""},//--坐标系统
                {"TBRQ","Date","36",""}//--备注日期            
            };

            //---探矿权变更预核准  bj_50_10_kcqbgkcfw 

            string[,] arry_tkqbgyhz = new string[42, 4]{
                {"BSM","Int","4",""},  //--标识码
                {"YSDM","String","10",""}, //--要素代码
                {"SQXH","String","30","caseno"},//--申请序号  ----必填               
                {"XMMC","String","100","项目名称"},//--项目名称 ----必填  
                {"TBRQ","Date","36","填表日期"},//--填表日期             
                {"SQR","String","100","申请人"},//--申请人
                {"ZKZ","Int","4","主矿种"},//--主矿种
                {"ZKZMC","String","15",""},//--主矿种名称
                {"DWFZR","String","30","单位负责人"},//--单位负责人  
                {"DH","String","50","电话号码"},//--电话
                {"DZ","String","50","地址"},//--地址
                {"YB","String","15","邮政编码"},//--邮编                
                {"GDZB","String","255","区域范围"},//--区域范围
                {"DTKCGK","String","255","地质矿产概况"},//--地质矿产概况
                {"TBR","String","15","填表人"},//--填表人
                {"XYJ","String","255","县意见"},//--县意见
                {"SYJ","String","255","省意见"},//--省意见
                {"XFZR","String","15","县负责人"},//--县负责人
                {"XYJSJ","Date","36","县意见时间"},//--县意见时间
                {"SJFZR","String","15","市负责人"},//--市负责人
                {"SJYJSJ","Date","36","市意见时间"},//--市意见时间
                {"SHJFZR","String","50","省负责人"},//--省负责人
                {"SHJYJSJ","Date","36","省意见时间"},//--省意见时间
                {"SHYJ","String","255","市意见"},//--市意见
                {"YXKZHYXQQ","Date","36","原探矿权许可证有效期起"},//--原探矿权许可证有效期起
                {"YXKZHYXQZ","Date","36","原探矿权许可证有效期止"},//--原探矿权许可证有效期止
                {"KCGZQK","String","255","勘查工作情况"},//--勘查工作情况
                {"BGLY","String","255","变更理由"},//--变更理由
                {"KCKZQ","String","50","勘查矿种前"},//--勘查矿种前
                {"KCKZH","String","50","勘查矿种后"},//--勘查矿种后
                {"KQFWZBQ","String","255","矿区范围坐标前"},//--矿区范围坐标前
                {"KQFWZBH","String","255","矿区范围坐标后"},//--矿区范围坐标后
                {"KCZYQMJQ","String","50","勘查作业区面积前"},//--勘查作业区面积前
                {"KCZYQMJH","String","50","勘查作业区面积后"},//--勘查作业区面积后
                {"KCFSQ","String","30","勘查方式前"},//--勘查方式前
                {"KCFSH","String","30","勘查方式后"},//--勘查方式后
                {"ZYSWGZLQ","String","20","主要实物工作量前"},//--主要实物工作量前
                {"ZYSWGTLH","String","20","主要实物工作量后"},//--主要实物工作量后
                {"CRFSJCLFS","String","50","出让方式及处置方式"},//--出让方式及处置方式
                {"YTKQXKEH","String","30","原探矿许可证证号"},//--原许可证证号
                {"LCZT","String","6","$LCZT"},//--流程状态     ------必填
                {"FLOWSN","String","20","$FLOWSN"}//--业务标识     -------必填
            };

            //--探矿权变更 、 延续 、保留

            string[,] array_tkqbg = new string[65, 4]{
                {"BSM","Int","4",""},//--标识码
                {"YSDM","String","10",""},//--要素代码
                {"SQXH","String","50","caseno"},//--申请序号    ---必填
                {"XKZH","String","25",""},//--许可证号
                {"XMDAH","String","25","caseno"},//--项目档案号    ---必填   --延续\变更\保留、数据表没有这个字段
                {"FZRQ","String","36",""},//--发证日期
                {"XMMC","String","200","项目名称"},//--项目名称     ---必填
                {"SQR","String","100","申请人名称"},//--申请人
                {"KCDW","String","100","勘查单位名称"},//--勘查单位
                {"ZGZH","String","20","资格证号"},//--资格证号
                {"KCDWDZ","String","255","勘查单位地址"},//--勘查单位地址
                {"KCKZ","Int","4","勘查矿种"},//--勘查矿种
                {"KCKZMC","String","50",""},//--勘查矿种名称
                {"ZMJ","Doublie","8","总面积"},//--总面积
                {"DLWZ","String","100","地理位置"},//--地理位置
                {"SZXZQ","String","60",""},//--所在行政区
                {"SZXZQMC","String","60",""},//--所在行政区名称
                {"SQRFRDB","String","100","法人代表"},//--申请人法人代表
                {"SQRLLY","String","20","联络员"},//--申请人联络员
                {"SQRDZ","String","255","地址"},//--申请人地址
                {"SQRYB","String","10","邮编"},//--申请人邮编
                {"SQRDH","String","20","电话"},//--申请人电话
                {"XMLX","String","10","申请类型"},//--项目类型
                {"XMLXMC","String","40",""},//--项目类型名称
                {"JJLX","Int","4","经济类型"},//--经济类型
                {"JJLXMC","String","20",""},//--经济类型名称
                {"KCJD","Int","4","勘查阶段"},//--勘查阶段
                {"KCJDMC","String","50",""},//--勘查阶段名称
                {"SCSLSJ","Date","8","首次设立时间"},//--首次设立时间
                {"SLRQ","Date","8",""},//--受理日期
                {"YXQQ","Date","8","申请有效期起"},//--有效期起
                {"YXQZ","Date","8","申请有效期止"},//--有效期止
                {"TKQQDFS","Int","4","探矿权取得方式"},//--探矿权取得方式
                {"TKQQDFSMC","String","50",""},//--探矿权取得方式名称
                {"KCTR","Double","8",""},//--勘查投入
                {"GJTZ","Double","8","国家投资"},//--中央投资
                {"DFTZ","Double","8","地方投资"},//--地方投资
                {"QYTZ","Double","8","企业投资"},//--企业投资
                {"WSTZ","Double","8","外商投资"},//--外商投资
                {"GRTZ","Double","8","个人投资"},//--个人投资
                {"QTTZ","Double","8","其他投资"},//--其他投资
                {"DYKCND","Double","8","第一勘查年度"},//--第一勘查年度
                {"DEKCND","Double","8","第二勘查年度"},//--第二勘查年度
                {"DSKCND","Double","8","第三勘查年度"},//--第三勘查年度
                {"QYZB","String","255","区域范围"},//--区域坐标
                {"DJQ","String","8",""},//--东经起
                {"DJZ","String","8",""},//--东经止
                {"BWQ","String","8",""},//--北纬起
                {"BWZ","String","8",""},//--北纬止
                {"XMXZ","Int","4","项目性质"},//--项目性质
                {"FZJGBH","String","10",""},//--发证机关编号
                {"FZJGMC","String","40",""},//--发证机关名称
                {"YSQXH","String","50",""},//--原申请序号
                {"YXKZH","String","25","原许可证号"},//--原许可证号
                {"YXMMC","String","100","原项目名称"},//--原项目名称
                {"YXMDAH","String","20",""},//--原项目档案号
                {"KTID","String","10",""},//--矿体标识
                {"LCZT","String","6","$LCZT"},//--流程状态      ---必填
                {"FLOWSN","String","20","$FLOWSN"},//--业务标识     ---必填
                {"BGLX","Int","4",""},//--变更类型
                {"BGYY","String","255","变更内容"},//--变更原因
                {"SQZXLY","String","255",""},//--申请注销理由
                {"BZ","String","255",""},//--备注
                {"ZBXT","Int","4",""},//--坐标系统
                {"TBRQ","Date","36",""}//--备注日期            
            };
             //--探矿权转让  没有模板，没有提供接口
            string[,] array_tkqzr = new string[0, 0];

            //--探矿权注销  xml模板与变更一样 但数据库表字段没有那么多
            string[,] array_tkqzx = new string[65, 4]{
                {"BSM","Int","4",""},//--标识码
                {"YSDM","String","10",""},//--要素代码
                {"SQXH","String","50","caseno"},//--申请序号    ---必填
                {"XKZH","String","25",""},//--许可证号
                {"XMDAH","String","25","caseno"},//--项目档案号    ---必填
                {"FZRQ","String","36",""},//--发证日期
                {"XMMC","String","200","项目名称"},//--项目名称     ---必填
                {"SQR","String","100","申请人名称"},//--申请人
                {"KCDW","String","100","勘查单位名称"},//--勘查单位
                {"ZGZH","String","20","资格证号"},//--资格证号
                {"KCDWDZ","String","255",""},//--勘查单位地址
                {"KCKZ","Int","4","勘查矿种"},//--勘查矿种
                {"KCKZMC","String","50",""},//--勘查矿种名称
                {"ZMJ","Doublie","8",""},//--总面积
                {"DLWZ","String","100",""},//--地理位置
                {"SZXZQ","String","60",""},//--所在行政区
                {"SZXZQMC","String","60",""},//--所在行政区名称
                {"SQRFRDB","String","100",""},//--申请人法人代表
                {"SQRLLY","String","20",""},//--申请人联络员
                {"SQRDZ","String","255",""},//--申请人地址
                {"SQRYB","String","10",""},//--申请人邮编
                {"SQRDH","String","20",""},//--申请人电话
                {"XMLX","String","10","注销类型"},//--项目类型
                {"XMLXMC","String","40",""},//--项目类型名称
                {"JJLX","Int","4",""},//--经济类型
                {"JJLXMC","String","20",""},//--经济类型名称
                {"KCJD","Int","4","勘查阶段"},//--勘查阶段
                {"KCJDMC","String","50",""},//--勘查阶段名称
                {"SCSLSJ","Date","8",""},//--首次设立时间
                {"SLRQ","Date","8",""},//--受理日期
                {"YXQQ","Date","8","有效期起"},//--有效期起
                {"YXQZ","Date","8","有效期止"},//--有效期止
                {"TKQQDFS","Int","4",""},//--探矿权取得方式
                {"TKQQDFSMC","String","50",""},//--探矿权取得方式名称
                {"KCTR","Double","8",""},//--勘查投入
                {"GJTZ","Double","8",""},//--中央投资
                {"DFTZ","Double","8",""},//--地方投资
                {"QYTZ","Double","8",""},//--企业投资
                {"WSTZ","Double","8",""},//--外商投资
                {"GRTZ","Double","8",""},//--个人投资
                {"QTTZ","Double","8",""},//--其他投资
                {"DYKCND","Double","8",""},//--第一勘查年度
                {"DEKCND","Double","8",""},//--第二勘查年度
                {"DSKCND","Double","8",""},//--第三勘查年度
                {"QYZB","String","255",""},//--区域坐标
                {"DJQ","String","8",""},//--东经起
                {"DJZ","String","8",""},//--东经止
                {"BWQ","String","8",""},//--北纬起
                {"BWZ","String","8",""},//--北纬止
                {"XMXZ","Int","4",""},//--项目性质
                {"FZJGBH","String","10",""},//--发证机关编号
                {"FZJGMC","String","40",""},//--发证机关名称
                {"YSQXH","String","50",""},//--原申请序号
                {"YXKZH","String","25",""},//--原许可证号
                {"YXMMC","String","100",""},//--原项目名称
                {"YXMDAH","String","20",""},//--原项目档案号
                {"KTID","String","10",""},//--矿体标识
                {"LCZT","String","6","$LCZT"},//--流程状态      ---必填
                {"FLOWSN","String","20","$FLOWSN"},//--业务标识     ---必填
                {"BGLX","Int","4",""},//--变更类型
                {"BGYY","String","255",""},//--变更原因
                {"SQZXLY","String","255","注销原因"},//--申请注销理由
                {"BZ","String","255","备注"},//--备注
                {"ZBXT","Int","4",""},//--坐标系统
                {"TBRQ","Date","36",""}//--备注日期            
            };



            //返回模板数组
            if (caseno != "" && caseno.Length > 6)
            {
                caseno = ChangeCaseno(caseno);
                if (caseno.Substring(0, 6) == "CKHK20" || caseno.Substring(0, 6) == "CKQHK2")
                {
                    array = array_hdkqfw;
                }
                else if (caseno.Substring(0, 6) == "CKYS20" )
                {
                    array = array_bghdkqfw;
                }
                else if (caseno.Substring(0, 6) == "CKXL20" || caseno.Substring(0, 6) == "CKQXL2" || caseno.Substring(0, 6) == "CKBG20" || caseno.Substring(0, 6) == "CKQBG2" || caseno.Substring(0, 6) == "CKYX20" || caseno.Substring(0, 6) == "CKQYX2" || caseno.Substring(0, 6) == "CKZX20" || caseno.Substring(0, 6) == "CKQZX2")
                {
                    array = array_sqb;
                }
                else if (caseno.Substring(0, 6) == "CKZR20" || caseno.Substring(0, 6) == "CKQZR2")
                {
                    array =array_zr;
                }
                else if (caseno.Substring(0, 6) == "TKKCFW")
                {
                    array = array_tkq_hdkcqfw;
                }
                  else if (caseno.Substring(0, 6) == "TKXL20")
                {
                    array = array_tkqxl;
                }
                    
                else if (caseno.Substring(0, 6) == "TKHK20" || caseno.Substring(0, 6) == "TKHKBG")
                {
                    array = arry_tkqbgyhz;
                }
                else if (caseno.Substring(0, 6) == "TKBG20" || caseno.Substring(0, 6) == "TKYX20" || caseno.Substring(0, 6) == "TKBL20")
                {
                    array = array_tkqbg;
                }
                else if (caseno.Substring(0, 6) == "TKZR20")
                {
                    array =array_tkqzr;
                }
                else if (caseno.Substring(0, 6) == "TKZX20")
                {
                    array = array_tkqzx;
                }
             
            }

            return array;

        }

        //--取得字段 名称 和 值的数组
        private string[,] Getfileds(string caseno, string lczt)
        {
            string[,] filedsArray = this.filedsArrayModel(caseno);
            if (filedsArray != null)
            {
                DataTable dt = this.getDataTable(caseno);
                for (int i = 0; i < filedsArray.GetLength(0); i++)
                {
                    if (filedsArray[i, 3] != "")
                    {
                        try
                        {
                            if (filedsArray[i, 3] == "$LCZT" && lczt == "create")
                            {
                                filedsArray[i, 3] = "";
                            }
                            else if (filedsArray[i, 3] == "$LCZT" && lczt == "update1")
                            {
                                filedsArray[i, 3] = "1";
                            }
                            else if (filedsArray[i, 3] == "$LCZT" && lczt == "update2")
                            {
                                filedsArray[i, 3] = "2";
                            }
                            else if (filedsArray[i, 3] == "$LCZT" && lczt == "failure")
                            {
                                filedsArray[i, 3] = "";
                            }
                            else if (filedsArray[i, 3] == "$FLOWSN")
                            {
                                filedsArray[i, 3] = this.getProcessNameAndType(caseno)[2];
                            }
                            else
                            {
                                filedsArray[i, 3] = dt.Rows[0][filedsArray[i, 3]].ToString();
                            }
                        }
                        catch (Exception eg)
                        {
                            throw eg;
                        }

                    }
                }
            }
            else
            {
                filedsArray = new string[0, 0];
            }
            return filedsArray;
        }      

    }

}
