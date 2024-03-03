using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TaxChatTAFSpecFlow.models;
using TaxChatTAFSpecFlow.utils;

namespace TaxChatTAF.pages.preparer
{
    class ConfigPreparerPage : MenuBar
    {
        By editButton = By.XPath("//li[contains(@ui-sref,'participant.config')]");
        By nameParticipantConsent = By.XPath("//li[contains(@class, 'ng-scope') and contains(text(), '7216 Taxpayer')]//ng-container//span");

        public ConfigPreparerPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void openConfigPageAndValidatesName(ParticipantData participant)
        {
            waitTillElementIsDisplayed(editButton);
            driver.FindElement(editButton).Click();
            scrollMoveElementJavaScript(nameParticipantConsent);
            string nameParticipant = getTextElement(nameParticipantConsent);
            string participantName = participant.name + " " + participant.lastName;
            Assert.AreEqual(nameParticipant, participantName);
        }
    }
}
