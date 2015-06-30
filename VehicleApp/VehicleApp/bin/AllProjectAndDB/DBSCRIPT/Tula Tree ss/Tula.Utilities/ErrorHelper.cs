using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tula.Utilities
{
  
   public class ErrorHelper
   {
       public string ErrorMessege { get; set; }
       public string StackTrace { get; set; }

       private ErrorHelper(string errorMessege, string stackTrace)
       {
           this.ErrorMessege = errorMessege;
           this.StackTrace = stackTrace;
       }

       public static ErrorHelper GetInstance(string errorMessege, string stackTrace)
       {
           return new ErrorHelper(errorMessege, stackTrace);
       }
       public static ErrorHelper GetInstanceAndWriteToLogFile(string errorMessege, string stackTrace, string pageLogPath)
       {
           LogFileHelper.LogFileWritten(errorMessege, stackTrace, pageLogPath);
           return new ErrorHelper(errorMessege, stackTrace);
       }
   }
}
