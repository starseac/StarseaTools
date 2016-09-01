using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starsea.NPOI.word
{
    public class model
    {

      private  string id;
      private string title;
      private string content;
      private string addTime;


      public string Id
        {
            get { return id; }
            set { id = value; }
        }

      public string Title
        {
            get { return title; }
            set { title = value; }
        }

      public string Content
        {
            get { return content; }
            set { content = value; }
        }

      public string AddTime
        {
            get { return addTime; }
            set { addTime = value; }
        }  


    }
}
