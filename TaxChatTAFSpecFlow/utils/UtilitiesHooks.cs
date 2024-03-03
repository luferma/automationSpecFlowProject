using System.Collections.Generic;
using TaxChatTAF;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;
using TaxChatTAF.pages.documents.signUp;
using TaxChatTAFSpecFlow.models;
using System;
using OpenQA.Selenium;
using AventStack.ExtentReports;
using System.Diagnostics;
using TaxChatTAF.utils;
using NUnit.Framework;
using TechTalk.SpecFlow.Assist;
using TaxChatTAF.pages.preparer;
using TaxChatTAF.pages.participant;
using System.Globalization;

namespace TaxChatTAFSpecFlow.utils
{
    class UtilitiesHooks
    {                
        public static void manageCookies(IWebDriver driver)
        {
            if (File.Exists(Utilities.getRelativePathRoute(configConstants.COOKIES_FILE)))
            {
                using (StreamReader file = new StreamReader(Utilities.getRelativePathRoute(configConstants.COOKIES_FILE)))
                {
                    string ln;
                    while ((ln = file.ReadLine()) != null)
                    {                        
                        string[] mainChain = ln.Split(';');
                        string cookie1 = mainChain[0];
                        string[] listCookie1 = cookie1.Split('=');
                        string cookie11 = listCookie1[0];
                        string cookie12 = listCookie1[1];
                        string valueString = "";
                        try
                        {
                            string cookie13 = listCookie1[2];
                            valueString = cookie12 + "=" + cookie13;
                        }
                        catch (Exception)
                        {
                            valueString = cookie12;
                        }
                        string nameString = cookie11;
                        DateTime dateExpires;
                        try
                        {
                            string cookie2 = mainChain[1];
                            string[] listCookie2 = cookie2.Split('=');
                            string cookie22 = listCookie2[1];
                            dateExpires = DateTime.ParseExact(
                            cookie22,
                            "ddd MM/dd/yyyy HH:mm:ss UTC",
                            CultureInfo.InvariantCulture);

                            string cookie3 = mainChain[2];
                            string[] listCookie3 = cookie3.Split('=');
                            string cookie32 = listCookie3[1];
                            string path = cookie32;

                            string cookie4 = mainChain[3];
                            string[] listCookie4 = cookie4.Split('=');
                            string cookie42 = listCookie4[1];
                            string domain = cookie42;

                            Cookie cookieObj = new Cookie(nameString, valueString, domain, path, dateExpires);
                            driver.Manage().Cookies.AddCookie(cookieObj);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("{0}", "Error adding cookie" + ex.Message);
                        }
                    }
                    file.Close();
                }
            }
        }

        public static void updateCookieFile(IWebDriver driver)
        {
            var _cookies = driver.Manage().Cookies.AllCookies;
            using (StreamWriter outputFile = new StreamWriter(Utilities.getRelativePathRoute(configConstants.COOKIES_FILE)))
            {
                foreach (Cookie cookie in _cookies)
                {
                    outputFile.WriteLine(cookie);
                }
            }
        }
    }
}
