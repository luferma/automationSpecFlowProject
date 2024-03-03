using TaxChatTAF.utils;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TaxChatTAF.pages.documents.signUp;
using NUnit.Framework;
using TaxChatTAFSpecFlow.models;
using System;

namespace TaxChatTAF.pages.participant
{
    class ParticipantRecoveryPasswordProcessPage : SeleniumActions
    {
        By linkForgotPassword = By.XPath("//a[@href='/password/forgot']");
        By titleRecoveryPassword = By.XPath("//h2[contains(text(),'password')]");
        By emailRecoveryPassword = By.XPath("//input[@id='email']");
        By buttonNext = By.XPath("//button[@id='submit']");
        By receiveEmailTitle = By.XPath("//h3[contains(text(),'receive an email')]");
        By inputTokenToEnter = By.XPath("//input[@id='token']");
        By newPasswordTitle = By.XPath("//h2[contains(text(),'new password')]");
        By inputPassword = By.Id("password");
        By inputReEnterPassword = By.Id("passwordConf");

        public ParticipantRecoveryPasswordProcessPage(IWebDriver driver) {
            this.driver = driver;         
        }

        public void startTheRecoveryPasswordProcess(string email)
        {
            waitTillElementIsDisplayed(linkForgotPassword);
            clickButton(linkForgotPassword);
            waitTillElementIsDisplayed(titleRecoveryPassword);
            sendValue(email, emailRecoveryPassword);
            clickButton(buttonNext);
            waitTillElementIsDisplayed(receiveEmailTitle);            
        }

        public void createNewPassword(string recoveryCode)
        {           
            sendValue(recoveryCode, inputTokenToEnter);
            clickButton(buttonNext);
            waitTillElementIsDisplayed(newPasswordTitle);
            sendValue(configConstants.NEW_PASSWORD, inputPassword);
            sendValue(configConstants.NEW_PASSWORD, inputReEnterPassword);
            clickButton(buttonNext);
        }
    }
}

