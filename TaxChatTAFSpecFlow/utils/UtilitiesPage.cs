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
using TaxChatTAF.pages.documents.popups;

namespace TaxChatTAFSpecFlow.utils
{
    class UtilitiesPage
    {

        public static string searchStatus(IWebDriver driver, Boolean searchStatus, string status, DateTime date1, By elementGetTextcurrentStatus, string labelToComparate)
        {            
            SeleniumActions seleniumAction = new SeleniumActions();
            seleniumAction.driver = driver;
            while (searchStatus)
            {
                DateTime date2 = DateTime.UtcNow;
                TimeSpan timeDifference = date1.Subtract(date2);
                if (status.Equals(labelToComparate) || timeDifference.TotalSeconds > 60)
                {
                    searchStatus = false;
                }
                else
                {
                    try
                    {
                        status = seleniumAction.getTextElement(elementGetTextcurrentStatus);
                    }
                    catch (StaleElementReferenceException)
                    {
                    }
                }
            }
            return status;
        }

        public static void searchStatusVoid(IWebDriver driver, Boolean searchStatus, string status, DateTime date1, By elementGetTextcurrentStatus, string labelToComparate)
        {
            SeleniumActions seleniumAction = new SeleniumActions();
            seleniumAction.driver = driver;
            while (searchStatus)
            {
                DateTime date2 = DateTime.UtcNow;
                TimeSpan timeDifference = date1.Subtract(date2);
                if (status.Equals(labelToComparate) || timeDifference.TotalSeconds > 60)
                {
                    searchStatus = false;
                }
                else
                {
                    try
                    {
                        status = seleniumAction.getTextElement(elementGetTextcurrentStatus);
                    }
                    catch (StaleElementReferenceException)
                    {
                    }
                }
            }            
        }

        public static void validateCCHConnection(IWebDriver driver, By title1, By title2)
        {
            SeleniumActions seleniumAction = new SeleniumActions();
            seleniumAction.driver = driver;
            seleniumAction.waitTillElementIsDisplayed(title1);            
            string title1Window2 = seleniumAction.getTextElement(title2);            
            StringAssert.Contains(configConstants.TITLE_WINDOW_2, title1Window2);
        }
    }
}
