using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Threading;
using log4net;
using log4net.Config;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace LittleFootLiberaryAutomation
{
    [TestClass]
    public class LiberaryData : BaseTest
    {


        public static string filepath = Common.Default.CSVFilePath;
        [Timeout(TestTimeout.Infinite)]
        [TestMethod]
        public void LibraryDataTest()
        {
            LoginWithBrowser();

            ReportData data = new ReportData();

            DataTable libraryData = GetDataTableFromCsv(filepath);
            Logger.Info("Total Records in CSV : " + libraryData.Rows.Count);
            foreach (DataRow dr in libraryData.Rows)
            {
                string name = dr["Name"].ToString();
                string isTownResident = dr["IsTownResident"].ToString();
                string bookTitle = dr["BookTitle"].ToString();
                string bookAuthor = dr["BookAuthor"].ToString();
                string numberOfPages = dr["NumberOfPages"].ToString();
                string ddc = dr["DDC"].ToString();
                string bookRead = dr["BookRead"].ToString();
                string timeTaken = dr["TimeTaken"].ToString();
                string rating = dr["Rating"].ToString();

                IWebElement CusName = driver.FindElement(By.Id("name"));
                CusName.SendKeys(name);
              

                Logger.Info("Customer Name : " + name);

                IWebElement ResYes = driver.FindElement(By.Id("res_yes"));

                if (isTownResident.ToLower() == "no")
                {
                    IWebElement ResNo = driver.FindElement(By.Id("res_no"));
                    ResNo.Click();

                }
                Logger.Info("Town Resident Selection : " + isTownResident);

                IWebElement Title = driver.FindElement(By.Id("title"));
                Title.SendKeys(bookTitle);

                Logger.Info("Book Title : " + bookTitle);

                IWebElement Author = driver.FindElement(By.Name("author"));
                Author.SendKeys(bookAuthor);

                Logger.Info("Book Author Name : " + bookAuthor);

                IWebElement NoOfPages = driver.FindElement(By.Name("pages"));
                NoOfPages.SendKeys(numberOfPages);

                Logger.Info("Total Book Pages : " + numberOfPages);

                IWebElement DeweyKey = driver.FindElement(By.Name("dewey_decimal"));
                DeweyKey.SendKeys(ddc);

                Logger.Info("Dewey Decimal Number : " + ddc);

                SelectElement BookReaded = new SelectElement(driver.FindElement(By.Id("HowmuchBookRead")));
                BookReaded.SelectByValue(bookRead.Trim().ToLower());

                Logger.Info("Book Read Option : " + bookRead);

                SelectElement ReadTime = new SelectElement(driver.FindElement(By.Id("TimeTakenBookRead")));
                ReadTime.SelectByText(timeTaken.Trim());

                Logger.Info("Reading Time : " + timeTaken);

                SelectElement Rating = new SelectElement(driver.FindElement(By.Name("Rating")));
                Rating.SelectByValue(rating);

                Logger.Info("Rating : " + rating);

                int pagesRead = 0;
                if (bookRead.ToLower().Trim() == "fully")
                {
                    pagesRead = Convert.ToInt32(numberOfPages);
                }
                else if (bookRead.ToLower().Trim() == "partially")
                {
                    pagesRead = (Convert.ToInt32(numberOfPages) / 2);
                }

                Logger.Info("Pages Read By User : " + pagesRead);

                data.TotalPagesRead = data.TotalPagesRead + pagesRead;

                if (pagesRead > 0)
                {
                    if (ddc.StartsWith("0"))
                    {
                        Logger.Info("Book Category : Computer Science, Information &General Works");
                        data.CIGPagesRead = data.CIGPagesRead + pagesRead;
                    }
                    else if (ddc.StartsWith("1"))
                    {
                        Logger.Info("Book Category : Philosophy & Psychology ");

                        data.PPPagesRead = data.PPPagesRead + pagesRead;
                    }
                    else if (ddc.StartsWith("2"))
                    {
                        Logger.Info("Book Category : Religion");
                        data.RPagesRead = data.RPagesRead + pagesRead;
                    }
                    else if (ddc.StartsWith("3"))
                    {
                        Logger.Info("Book Category : Social Sciences");
                        data.SSPagesRead = data.SSPagesRead + pagesRead;
                    }
                    else if (ddc.StartsWith("4"))
                    {
                        Logger.Info("Book Category : Language");
                        data.LPagesRead = data.LPagesRead + pagesRead;
                    }
                    else if (ddc.StartsWith("5"))
                    {
                        Logger.Info("Book Category : Pure Science");
                        data.PSPagesRead = data.PSPagesRead + pagesRead;
                    }
                    else if (ddc.StartsWith("6"))
                    {
                        Logger.Info("Book Category : Applied Science");
                        data.ASPagesRead = data.ASPagesRead + pagesRead;
                    }
                    else if (ddc.StartsWith("7"))
                    {
                        Logger.Info("Book Category : Arts & Recreation");
                        data.ARPagesRead = data.ARPagesRead + pagesRead;
                    }
                    else if (ddc.StartsWith("8"))
                    {
                        Logger.Info("Book Category : Literature");
                        data.LitPagesRead = data.LitPagesRead + pagesRead;
                    }
                    else if (ddc.StartsWith("9"))
                    {
                        Logger.Info("Book Category : History & Geography");
                        data.HGPagesRead = data.HGPagesRead + pagesRead;
                    }
                    else
                    {
                        Logger.Info("Book Category : Other");
                        data.OtherPagesRead = data.OtherPagesRead + pagesRead;
                    }
                }

                // wait until the page shows the result
                Thread.Sleep(2000);

                CusName.Clear();
                ResYes.Click();
                Title.Clear();
                Author.Clear();
                NoOfPages.Clear();
                DeweyKey.Clear();
                BookReaded.SelectByText("Read");
                ReadTime.SelectByText("Less then 1 week");
                Rating.SelectByValue("5");

                // wait until the page shows the result
                Thread.Sleep(2000);
            }

            Logger.Info("Total Pages Read : " + data.TotalPagesRead);
            Logger.Info("By Category");
            if (data.CIGPagesRead > 0)
            {
                Logger.Info("Computer Science, Information &General Works : " + data.CIGPagesRead);
            }
            if (data.PPPagesRead > 0)
            {
                Logger.Info("Philosophy & Psychology  : " + data.PPPagesRead);

            }
            if (data.RPagesRead > 0)
            {
                Logger.Info("Religion : " + data.RPagesRead);

            }
            if (data.SSPagesRead > 0)
            {
                Logger.Info("Social Sciences : " + data.SSPagesRead);

            }
            if (data.LPagesRead > 0)
            {
                Logger.Info("Language : " + data.LPagesRead);

            }
            if (data.PSPagesRead > 0)
            {
                Logger.Info("Pure Science : " + data.PSPagesRead);

            }
            if (data.ASPagesRead > 0)
            {
                Logger.Info("Applied Science : " + data.ASPagesRead);

            }
            if (data.ARPagesRead > 0)
            {
                Logger.Info("Arts & Recreation : " + data.ARPagesRead);

            }
            if (data.LitPagesRead > 0)
            {
                Logger.Info("Literature : " + data.LitPagesRead);

            }
            if (data.HGPagesRead > 0)
            {
                Logger.Info("History & Geography : " + data.HGPagesRead);

            }
        }

        /// <summary>
        /// Parse the CSV file and get data to data table.
        /// </summary>
        /// <param name="path">path of the csv file.</param>
        /// <returns>CSV file as DataTable.</returns>
        private DataTable GetDataTableFromCsv(string path)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[9] { new DataColumn("Name", typeof(string)),
            new DataColumn("IsTownResident", typeof(string)),
            new DataColumn("BookTitle", typeof(string)),
            new DataColumn("BookAuthor", typeof(string)),
            new DataColumn("NumberOfPages", typeof(int)),
            new DataColumn("DDC", typeof(string)),
            new DataColumn("BookRead", typeof(string)),
            new DataColumn("TimeTaken", typeof(string)),
            new DataColumn("Rating", typeof(int))
            });

            using (TextReader reader = File.OpenText(path))
            {
                var csv = new CsvHelper.CsvReader(reader);
                csv.Read();
                csv.ReadHeader();
                this.ValidateCSVHeaders(csv.Context.HeaderRecord.ToList());
                bool validCsv = true;
                while (csv.Read())
                {
                    var row = dt.NewRow();
                    foreach (DataColumn column in dt.Columns)
                    {
                        string fieldVal;
                        if (csv.TryGetField(column.ColumnName, out fieldVal))
                        {
                            row[column.ColumnName] = csv.GetField(column.DataType, column.ColumnName);

                            if (string.IsNullOrEmpty(row[column.ColumnName].ToString()))
                            {
                                Logger.Error("Value  for the column " + column.ColumnName + " must not be empty.");
                                validCsv = false;
                            }
                        }
                        else
                        {
                            row[column.ColumnName] = string.Empty;
                            Logger.Error("Value  for the column " + column.ColumnName + " must not be empty.");
                            validCsv = false;
                        }
                    }

                    dt.Rows.Add(row);
                }
                if (!validCsv)
                {
                    Assert.Fail();
                }
            }

            return dt;
        }

        /// <summary>
        /// Method to check the csv file contains all the columns or not.
        /// </summary>
        /// <param name="csvHeaders">List of the headers of csv file.</param>
        private void ValidateCSVHeaders(List<string> csvHeaders)
        {
            List<string> requiredCols = new List<string> { "Name", "IsTownResident", "BookTitle", "BookAuthor", "NumberOfPages", "DDC", "BookRead", "TimeTaken", "Rating" };

            List<string> missingColumns = requiredCols.Where(x => !csvHeaders.Any(y => y == x)).ToList();

            if (missingColumns.Count > 0)
            {
                foreach (string columnName in missingColumns)
                {
                    Logger.Error(columnName + " column is missing in CSV file.");
                }

                Assert.Fail();

            }
        }

    }
}
