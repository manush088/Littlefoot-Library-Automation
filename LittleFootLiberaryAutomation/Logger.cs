using log4net;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleFootLiberaryAutomation
{
      public static class Logger
      {


              private static log4net.ILog Log { get; set; }

              static Logger()
              {
                  Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
                  hierarchy.Root.RemoveAllAppenders(); 

                  FileAppender fileAppender = new FileAppender();
                  fileAppender.AppendToFile = true;
                  fileAppender.LockingModel = new FileAppender.MinimalLock();
                  fileAppender.File = Common.Default.LogFileLocation +"_"+DateTime.Now.ToString("ddMMMyyyy_HHmmss") +".txt";
                  PatternLayout pl = new PatternLayout();
                  pl.ConversionPattern = "%d [%2%t] %-5p [%-10c]   %m%n%n";
                  pl.ActivateOptions();
                  fileAppender.Layout = pl;
                  fileAppender.ActivateOptions();

                  log4net.Config.BasicConfigurator.Configure(fileAppender);
           
                 Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


                 
              }

              public static void Error(object msg)
              {
                  Log.Error(msg);
              }

              public static void Error(object msg, Exception ex)
              {
                  Log.Error(msg, ex);
              }

              public static void Error(Exception ex)
              {
                  Log.Error(ex.Message, ex);
              }

              public static void Info(object msg)
              {
                  Log.Info(msg);
              }
          }
      }

  
