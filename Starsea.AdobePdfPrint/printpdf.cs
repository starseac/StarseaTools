using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starsea.AdobePdfPrint
{
    public class printpdf
    {
        public printpdf(string docpath)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            //不现实调用程序窗口,但是对于某些应用无效
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            //采用操作系统自动识别的模式
            p.StartInfo.UseShellExecute = true;           

            //要打印的文件路径，可以是WORD,EXCEL,PDF,TXT等等
            p.StartInfo.FileName = docpath;

            //指定执行的动作，是打印，即print，打开是 open
            p.StartInfo.Verb = "print";

            //开始
            p.Start();

        }
    }
}
