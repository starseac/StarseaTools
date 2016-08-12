using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starsea.Egov
{
   public class console
    {
       public string getMessage(List<string> array) {
           string mes = "";         
           foreach(string aa in array){
               mes += aa + "\r\n";           
           }

           return mes;
       }

    }
}
