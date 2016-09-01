using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZD.MAP
{
   public class mapanaly
    {
        public string Analy_ExecuteAnalyForWeb(string caseid, string wfid)
        {
           

            string Analy = System.Configuration.ConfigurationSettings.AppSettings["WebServiceAnaly"].ToString();
       

            string oldDQBH = "";
            //string oldCaseID = "";
            string oldDKID = "";

            //用来存储坐标
            string zbs = "";
            

            // string strDotString = zbs;
            string strDotString = "38397335.35,3364232.98 38397417.61,3364244.89 38397431.04,3364127.37 38397400.38,3364122.93 38397345.89,3364120.61 38397335.35,3364232.98";
            string CoveredSubjectList = "DC,GH,NT,JS,QS", CoverDataYearList = "2013,2010,2010,2012,2008", CoverScaleList = "G,G,G,G,K";
            //   string strDotString = GetXmlInfo(caseno, out  CoveredSubjectList, out  CoverDataYearList, out  CoverScaleList);

            object oValue = WebServiceLoader.InvokeWebService(Analy, "ExecuteAnalyForWeb",

                 new object[24] 
                { 
                    caseid, caseid, "", "", "", "", "", strDotString,CoveredSubjectList, CoverDataYearList, CoverScaleList, "", 1, true, 
                    "", 0, 0, 1, "", "", "", "", "",""
                });

            return (string)oValue;
        }

        public string Analy_ExecuteAnalyForWeb2(string caseid, string wfid)
        {


            //string Analy = System.Configuration.ConfigurationSettings.AppSettings["WebServiceAnaly"].ToString();


            //string oldDQBH = "";
            ////string oldCaseID = "";
            //string oldDKID = "";

            ////用来存储坐标
            //string zbs = "";


            //// string strDotString = zbs;
         //   string strDotString = "38397335.35,3364232.98 38397417.61,3364244.89 38397431.04,3364127.37 38397400.38,3364122.93 38397345.89,3364120.61 38397335.35,3364232.98";

            string strDotString = "37495349.764,3604531.927 37495403.763,3604538.797 37495431.725,3604548.716 37495471.399,3604573.102 37495505.143,3604603.430 37495515.805,3604614.429 37495525.067,3604623.984 37495560.663,3604667.753 37495587.857,3604691.862 37495589.645,3604691.926 37495605.129,3604680.387 37495620.572,3604665.934 37495635.676,3604629.070 37495626.940,3604608.809 37495627.265,3604604.530 37495634.731,3604586.280 37495635.186,3604577.452 37495635.941,3604562.778 37495630.234,3604522.471 37495637.088,3604484.477 37495662.518,3604471.830 37495683.251,3604436.205 37495678.922,3604416.850 37495691.650,3604397.777 37495692.322,3604396.770 37495707.486,3604392.392 37495708.248,3604392.172 37495714.351,3604380.369 37495717.449,3604374.378 37495712.485,3604373.391 37495686.038,3604381.178 37495683.312,3604367.585 37495428.404,3604316.857 37495386.241,3604308.466 37495288.297,3604436.473 37495284.672,3604441.211 37495309.764,3604464.036 37495327.679,3604483.237 37495349.764,3604531.927";
            string CoveredSubjectList = "DC,GH,NT,JS,QS", CoverDataYearList = "2013,2010,2010,2012,2008", CoverScaleList = "G,G,G,G,K";
            ////   string strDotString = GetXmlInfo(caseno, out  CoveredSubjectList, out  CoverDataYearList, out  CoverScaleList);

            //object oValue = WebServiceLoader.InvokeWebService(Analy, "ExecuteAnalyForWeb",

            //     new object[24] 
            //    { 
            //        caseid, caseid, "", "", "", "", "", strDotString,CoveredSubjectList, CoverDataYearList, CoverScaleList, "", 1, true, 
            //        "", 0, 0, 1, "", "", "", "", "",""
            //    });

            //return (string)oValue;


            ZDMAP_Analy.Analy analy = new ZDMAP_Analy.Analy();
           string res=analy.ExecuteAnalyForWeb(caseid, caseid, "", "", "", "", "", strDotString, CoveredSubjectList, CoverDataYearList, CoverScaleList, "", 1, true,
                    "", 0, 0, 1, "", "", "", "", "", "");

           return res;
        }


    }
}
