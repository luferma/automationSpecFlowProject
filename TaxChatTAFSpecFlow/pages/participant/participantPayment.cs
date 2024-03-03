using TaxChatTAF.utils;
using OpenQA.Selenium;
using System.Collections.Generic;
using NUnit.Framework;
using TaxChatTAFSpecFlow.utils;
using TechTalk.SpecFlow;
using TaxChatTAF.pages.documents.signUp;
using OpenQA.Selenium.Interactions;
using TaxChatTAFSpecFlow.models;
using System;

namespace TaxChatTAF.pages.participant
{
    class ParticipantPayment : SeleniumActions
    {      
        By paymentButton = By.XPath("//a[contains(text(), 'Pay & review')]");
        By paymentTitle = By.XPath("//p[contains(text(), 'tax return after')]");
        By paymentTitleService = By.XPath("//h2[contains(text(), 'Your EY TaxChat service fee is')]");
        By buttonPay = By.Id("pay");        

        By textCardName = By.Id("card_name");
        By textCardNumber = By.Id("card_number");
        By textCardExpiration = By.Id("card_expiration");
        By textCardCVV = By.Id("card_cvv");
        By checkSameMailingAndress = By.Id("same_address");
        By textStreetAdress1 = By.Id("streetAddress1");
        By textStreetAdress2 = By.Id("streetAddress2");
        By selectListCountry = By.Id("country");
        By selectListState = By.Id("state_id");
        By textCity = By.Id("city");
        By textZipCode = By.Id("zip_code");
        By textForeignMailState = By.Id("foreign_mailing_state");
        By buttonSave = By.Id("save");

        By titlePaymentComplete = By.XPath("//h4[contains(text(), 'Payment Complete')]");
        By buttonConfirmPaymentComplete = By.Id("confirm");

        By buttonConfirmPayment = By.Id("confirm");
        By clickStar = By.XPath("//button[@name='star-5']");
        By buttonSubmit = By.Id("Submit");
        By almostDoneTitle = By.XPath("//h1[contains(text(), 'almost done')]");
        By buttonViewNow = By.Id("edit");
        By buttonReviewReturn = By.Id("Review your return");
        By buttonEFile = By.Id("E-File");

        By valueTotalIncome = By.XPath("//td[contains(text(),'Total income')]/following-sibling::td");
        By valueTaxableIncome = By.XPath("//td[contains(text(),'Taxable income')]/following-sibling::td");
        By refund1 = By.XPath("(//td[contains(@class,'positive')])[1]");
        By refund2 = By.XPath("(//td[contains(@class,'positive')])[2]");
        By payValue = By.XPath("(//h3[contains(text(),'return')]/following-sibling::div)[1]");

        public ParticipantPayment(IWebDriver driver) {
            this.driver = driver;
        }

        public void processPayment(ParticipantData participant, Boolean isMarkingAddress)
        {
            waitTillElementIsClickable(paymentButton);
            clickButton(paymentButton);
            waitTillElementIsDisplayedVoid(paymentTitle);
            waitTillElementIsDisplayedVoid(valueTotalIncome);

            string compareValueTotalIncome = getTextElement(valueTotalIncome);
            string compareValueTaxableIncome = getTextElement(valueTaxableIncome);
            string compareRefund1 = getTextElement(refund1);
            string compareRefund2 = getTextElement(refund2);
            string stringPayValue = getTextElement(payValue);

            Assert.AreEqual(compareValueTotalIncome, "$15,000");
            Assert.AreEqual(compareValueTaxableIncome, "$12,000");
            Assert.AreEqual(compareRefund1, "$10,000");
            Assert.AreEqual(compareRefund2, "$5,000");            
            StringAssert.Contains("$"+participant.expectedQuote.ToString(), stringPayValue);

            clickButton(buttonPay);            

            waitTillElementIsDisplayedVoid(paymentTitleService);
            sendValue(participant.name + " " + participant.lastName, textCardName);
            sendValue("4003830171874018", textCardNumber);
            sendValue("10/25", textCardExpiration);
            sendValue("123", textCardCVV);
            string compareCountry;
            string compareState;
            string compareCity;
            string compareZip;
            if (isMarkingAddress)
            {
                clickButton(checkSameMailingAndress);
                string compareStreetMain1 = getValueElement(textStreetAdress1);
                string compareStreetMain2 = getValueElement(textStreetAdress2);
                Assert.AreEqual(compareStreetMain1, "Main Street");
                Assert.AreEqual(compareStreetMain2, "Main Street Corner");
                compareCountry = getValueElement(selectListCountry);
                compareCity = getValueElement(textCity);
                compareZip = getValueElement(textZipCode);
                if (participant.country.Equals("United_States"))
                {                    
                    compareState = getValueElement(selectListState);                                       
                    Assert.AreEqual(compareCountry, "United States");
                    Assert.AreEqual(compareState, "NY");
                    Assert.AreEqual(compareCity, "Manhattan");
                    Assert.AreEqual(compareZip, "12345");
                }
                else
                {                    
                    compareState = getValueElement(textForeignMailState);                    
                    Assert.AreEqual(compareCountry, "Colombia");
                    Assert.AreEqual(compareState, "Medellin");
                    Assert.AreEqual(compareCity, "Manhattan");
                    Assert.AreEqual(compareZip, "12345");
                }
            }
            else
            {
                sendValue("Stratford, London, Usa", textStreetAdress1);
                sendValue("Stratford, London, Usa", textStreetAdress2);
                if (!participant.country.Equals("United_States"))
                {
                    selectFromList(selectListCountry, "United States");
                    selectFromList(selectListState, "New York");
                    sendValue("Manhattan", textCity);
                }
                else
                {
                    selectFromList(selectListCountry, "Colombia");
                    sendValue("Antioquia", textForeignMailState);
                    sendValue("Medellin", textCity);
                }
                sendValue("12345", textZipCode);
            }
            
            clickButton(buttonSave);
            waitTillElementIsDisplayed(titlePaymentComplete);
            clickButton(buttonConfirmPaymentComplete);
            waitTillElementIsDisplayed(clickStar);
            clickButton(clickStar);
            clickButton(buttonSubmit);
            waitTillElementIsDisplayed(almostDoneTitle);
            clickButton(buttonViewNow);            
            if (participant.isCreatedUser.Equals("No"))
            {
                changeTabAndRefresh(2);
            }
            else
            {
                changeTabAndRefresh(0);
            }
            waitTillElementIsDisplayed(buttonReviewReturn);
            waitTillElementIsDisplayed(buttonEFile);
        }
    }
}
