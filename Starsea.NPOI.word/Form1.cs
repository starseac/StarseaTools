using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NPOI.XWPF.UserModel;

namespace Starsea.NPOI.word
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          

            model m1= new model();
            m1.Id = "1";
            m1.Title = "标题1";
            m1.Content = "内容1";
            m1.AddTime = "2016-1";

            model m2 = new model();
            m2.Id = "2";
            m2.Title = "标题2";
            m2.Content = "内容2";
            m2.AddTime = "2016-2";


            model m3 = new model();
            m3.Id = "3";
            m3.Title = "标题3";
            m3.Content = "内容3";
            m3.AddTime = "2016-3";


            model m4 = new model();
            m4.Id = "4";
            m4.Title = "标题4";
            m4.Content = "内容4";
            m4.AddTime = "2016-4";

            List<model> list = new List<model>();
            list.Add(m1);
            list.Add(m2);
            list.Add(m3);
            list.Add(m4);



            //创建document对象

            XWPFDocument doc = new XWPFDocument();

            //创建段落对象

            XWPFParagraph p1 = doc.CreateParagraph();

            //创建run对象

            //本节提到的所有样式都是基于XWPFRun的，

            //你可以把XWPFRun理解成一小段文字的描述对象，

            //这也是Word文档的特征，即文本描述性文档。

            //来自Tony Qu http://tonyqus.sinaapp.com/archives/609

            XWPFRun r1 = p1.CreateRun();
         

            r1.SetText("数据导出demo");

           
            r1.SetText("The quick brown fox");
        
           
            r1.SetUnderline(UnderlinePatterns.DotDotDash);
            r1.SetTextPosition(100);

            r1.SetFontFamily("Arial",FontCharRange.None);//设置雅黑字体

            //创建表格对象列数写死了，可根据自己需要改进或者自己想想解决方案

            XWPFTable table = doc.CreateTable(list.Count(), 4);

            for (int i = 0; i < list.Count(); i++)
            {

                table.GetRow(i).GetCell(0).SetText(list[i].Id.ToString());

                table.GetRow(i).GetCell(1).SetText(list[i].Title);

                table.GetRow(i).GetCell(2).SetText(list[i].Content);

                table.GetRow(i).GetCell(3).SetText(list[i].AddTime);

            }

            //保存文件到磁盘

            FileStream out1 = new FileStream("simpleTable.docx", FileMode.Create);

            doc.Write(out1);

            out1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            XWPFDocument doc = new XWPFDocument();

            XWPFParagraph p1 = doc.CreateParagraph();
            p1.Alignment=ParagraphAlignment.CENTER;
            p1.BorderBottom=Borders.Double;
            p1.BorderTop=Borders.Double;

            p1.BorderRight=Borders.Double;
            p1.BorderLeft=Borders.Double;
            p1.BorderBetween=Borders.Double;

            p1.VerticalAlignment=TextAlignment.TOP;

            XWPFRun r1 = p1.CreateRun();
            r1.IsBold=true;
            r1.SetText("The quick brown fox");
            r1.IsBold = true;
         
            r1.SetFontFamily("Courier",FontCharRange.None);
            r1.SetUnderline(UnderlinePatterns.DotDotDash);
            r1.SetTextPosition(100);

            XWPFParagraph p2 = doc.CreateParagraph();
            p2.Alignment=ParagraphAlignment.RIGHT;

            //BORDERS
            p2.BorderBottom=Borders.Double;
            p2.BorderTop = Borders.Double;
            p2.BorderRight = Borders.Double;
            p2.BorderLeft = Borders.Double;
            p2.BorderBetween = Borders.Double;

            XWPFRun r2 = p2.CreateRun();
            r2.SetText("jumped over the lazy dog");
            r2.IsStrike=true;
            r2.FontSize=20;

            XWPFRun r3 = p2.CreateRun();
            r3.SetText("and went away");
            r3.IsStrike=true;
            r3.FontSize=20;
            r3.Subscript=VerticalAlign.SUPERSCRIPT;


            XWPFParagraph p3 = doc.CreateParagraph();
            p3.IsWordWrap=true;
            p3.IsPageBreak=true;

            //p3.SetAlignment(ParagraphAlignment.DISTRIBUTE);
            p3.Alignment=ParagraphAlignment.BOTH;
            p3.SpacingLineRule=LineSpacingRule.EXACT;

            p3.IndentationFirstLine=600;


            XWPFRun r4 = p3.CreateRun();
            r4.SetTextPosition(20);
            r4.SetText("To be, or not to be: that is the question: "
                    + "Whether 'tis nobler in the mind to suffer "
                    + "The slings and arrows of outrageous fortune, "
                    + "Or to take arms against a sea of troubles, "
                    + "And by opposing end them? To die: to sleep; ");
            r4.AddBreak(BreakType.PAGE);
            r4.SetText("No more; and by a sleep to say we end "
                    + "The heart-ache and the thousand natural shocks "
                    + "That flesh is heir to, 'tis a consummation "
                    + "Devoutly to be wish'd. To die, to sleep; "
                    + "To sleep: perchance to dream: ay, there's the rub; "
                    + ".......");
            r4.IsItalic=true;
            //This would imply that this break shall be treated as a simple line break, and break the line after that word:

            XWPFRun r5 = p3.CreateRun();
            r5.SetTextPosition(-10);
            r5.SetText("For in that sleep of death what dreams may come");
            r5.AddCarriageReturn();
            r5.SetText("When we have shuffled off this mortal coil,"
                    + "Must give us pause: there's the respect"
                    + "That makes calamity of so long life;");
            r5.AddBreak();
            r5.SetText("For who would bear the whips and scorns of time,"
                    + "The oppressor's wrong, the proud man's contumely,");

            r5.AddBreak(BreakClear.ALL);
            r5.SetText("The pangs of despised love, the law's delay,"
                    + "The insolence of office and the spurns" + ".......");

            FileStream out1 = new FileStream("simple.docx", FileMode.Create);
            doc.Write(out1);
            out1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XWPFDocument doc = new XWPFDocument();
            doc.CreateParagraph();
            FileStream sw = File.OpenWrite("blank.docx");
            doc.Write(sw);
            sw.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XWPFDocument doc = new XWPFDocument();
            //simple bullet
            XWPFNumbering numbering = doc.CreateNumbering();

            string abstractNumId = numbering.AddAbstractNum();
            string numId = numbering.AddNum(abstractNumId);

            XWPFParagraph p0 = doc.CreateParagraph();
            XWPFRun r0 = p0.CreateRun();
            r0.SetText("simple bullet");
            r0.IsBold=true;
            r0.SetFontFamily("Courier",FontCharRange.None);
            r0.FontSize=12;

            XWPFParagraph p1 = doc.CreateParagraph();
            XWPFRun r1 = p1.CreateRun();
            r1.SetText("first, create paragraph and run, set text");
            p1.SetNumID(numId);

            XWPFParagraph p2 = doc.CreateParagraph();
            XWPFRun r2 = p2.CreateRun();
            r2.SetText("second, call XWPFDocument.CreateNumbering() to create numbering");
            p2.SetNumID(numId);

            XWPFParagraph p3 = doc.CreateParagraph();
            XWPFRun r3 = p3.CreateRun();
            r3.SetText("third, add AbstractNum[numbering.AddAbstractNum()] and Num(numbering.AddNum(abstractNumId))");
            p3.SetNumID(numId);

            XWPFParagraph p4 = doc.CreateParagraph();
            XWPFRun r4 = p4.CreateRun();
            r4.SetText("next, call XWPFParagraph.SetNumID(numId) to set paragraph property, CT_P.pPr.numPr");
            p4.SetNumID(numId);

            //multi level
            abstractNumId = numbering.AddAbstractNum();
            numId = numbering.AddNum(abstractNumId);
            doc.CreateParagraph();
            doc.CreateParagraph();

            p1 = doc.CreateParagraph();
            r1 = p1.CreateRun();
            r1.SetText("multi level bullet");
            r1.IsBold=true;
            r1.SetFontFamily("Courier",FontCharRange.None);
            r1.FontSize=12;

            p1 = doc.CreateParagraph();
            r1 = p1.CreateRun();
            r1.SetText("first");
            p1.SetNumID(numId, "0");
            p1 = doc.CreateParagraph();
            r1 = p1.CreateRun();
            r1.SetText("first-first");
            p1.SetNumID(numId, "1");
            p1 = doc.CreateParagraph();
            r1 = p1.CreateRun();
            r1.SetText("first-second");
            p1.SetNumID(numId, "1");
            p1 = doc.CreateParagraph();
            r1 = p1.CreateRun();
            r1.SetText("first-third");
            p1.SetNumID(numId, "1");
            p1 = doc.CreateParagraph();
            r1 = p1.CreateRun();
            r1.SetText("second");
            p1.SetNumID(numId, "0");
            p1 = doc.CreateParagraph();
            r1 = p1.CreateRun();
            r1.SetText("second-first");
            p1.SetNumID(numId, "1");
            p1 = doc.CreateParagraph();
            r1 = p1.CreateRun();
            r1.SetText("second-second");
            p1.SetNumID(numId, "1");
            p1 = doc.CreateParagraph();
            r1 = p1.CreateRun();
            r1.SetText("second-third");
            p1.SetNumID(numId, "1");
            p1 = doc.CreateParagraph();
            r1 = p1.CreateRun();
            r1.SetText("second-third-first");
            p1.SetNumID(numId, "2");
            p1 = doc.CreateParagraph();
            r1 = p1.CreateRun();
            r1.SetText("second-third-second");
            p1.SetNumID(numId, "2");
            p1 = doc.CreateParagraph();
            r1 = p1.CreateRun();
            r1.SetText("third");
            p1.SetNumID(numId, "0");

            FileStream sw = new FileStream("bullet-sample.docx", FileMode.Create);
            doc.Write(sw);
            sw.Close();
        }
    }
}
