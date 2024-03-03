using TaxChatTAF.utils;
using OpenQA.Selenium;
using System.Collections.Generic;
using NUnit.Framework;
using TaxChatTAFSpecFlow.utils;
using TechTalk.SpecFlow;
using System;
using TaxChatTAFSpecFlow.models;

namespace TaxChatTAF.pages.participant
{
    class ParticipantDocumentsPage : SeleniumActions
    {      
        By titleDocumentsPage = By.XPath("//div[contains(@class,'Documents')]//h1[contains(text(),'Tax Documents')]");
        By titleMessagePage = By.XPath("//div[contains(@class,'Message')]//h1");
        By documentsTab = By.XPath("//div[contains(@class,'wrapper')]//ul//a[contains(@href,'documents')]");
        By listDocuments = By.XPath("//ul[contains(@class,'DocRequest--list Required')]//li");        
        By fileXpath = By.XPath("//input[@type='file']");
        By textDocument = By.XPath("//div[contains(@class,'left')]//h4");
        By container = By.XPath("//div[contains(@class,'popup--container')]");
        By buttonConfirm = By.Id("confirm");
        By buttonFinishUpload = By.XPath("(//button[@id='confirm'])[2]");
        By buttonFinishSuccessful = By.XPath("//div[contains(@class,'popup--container')]//button");
        By profileTab = By.XPath("//div[contains(@class,'wrapper')]//ul//a[contains(@href,'profile')]");
        By buttonsStep = By.XPath("//div[contains(@class,'group')]//button[@id='submit']");
        By buttonMyFamily = By.XPath("//div[contains(@class,'hide-sm')]//button[@id='edit' and contains(text(),'resume')]");
        By buttonsStart = By.XPath("//div[contains(@class,'hide-sm')]//button[@id='edit' and contains(text(),'start')]");
        By firstNameSpouse = By.XPath("//label[@for='spouse_name_first']//input[@id='name_first']");
        By lastNameSpouse = By.XPath("//label[@for='spouse_name_last']//input[@id='name_last']");
        By titleWelcomeB2CUser = By.XPath("//h1[contains(text(),'trying TaxChat')]");
        By listDocumentsTable = By.XPath("(//div[contains(@class,'TabBar')]//div[@class='DocRequest'] )[1]");
        By textDocuments = By.XPath("//a[@href='/documents']//span[@class='num']");

        public ParticipantDocumentsPage(IWebDriver driver) {
            this.driver = driver;
        }
        
        public void waitTillParticipantMessageIsDisplayedVoid()
        {
            waitTillElementIsDisplayedVoid(titleMessagePage, 70);
        }

        public void uploadDocuments(string listTitle, string isRandomUploadFile)
        {
            RandomEmail randomEmailObject = new RandomEmail();
            List<string> listTextDocumentUpload;
            try
            {            
                listTextDocumentUpload = (List<string>)ScenarioContext.Current[listTitle];
            }
            catch (Exception)
            {
                listTextDocumentUpload = new List<string>();
            }
            string stringDocuments = getTextElement(textDocuments);
            int numDocuments = 0;
            if (!stringDocuments.Equals(""))
            {
                numDocuments = Int32.Parse(stringDocuments);
            }            
            if (numDocuments>0)            
            {                
                clickJavaScriptExecutor(documentsTab);               
                waitTillElementIsDisplayedVoid(titleDocumentsPage, 50);
                waitTillElementIsDisplayedVoid(listDocumentsTable, 50);
                List<IWebElement> listDocumentsElements = new List<IWebElement>(driver.FindElements(listDocuments));            
                int countList = listDocumentsElements.Count;
                string fileLocation = Utilities.getRelativePathRoute(configConstants.ROUTE_COMPLETE_UPLOAD);
            
                int contUpload = 1;
                string fileName;
                foreach (var element in listDocumentsElements)
                {                
                    IWebElement fileInput = element.FindElement(fileXpath);
                                      
                    if (isRandomUploadFile.Equals("Yes"))
                    {
                        string nextSequenceFileUpload = randomEmailObject.GenerateRandomStringGetFile(1);
                        fileName = Utilities.getRandomFileUpload(nextSequenceFileUpload);
                        fileInput.SendKeys(fileLocation + fileName);                        
                    }
                    else
                    {
                        IWebElement textDocumentElement = element.FindElement(textDocument);
                        string texto = textDocumentElement.Text;
                        foreach (var elementTextValidate in listTextDocumentUpload)
                        {
                            if (elementTextValidate.Equals(texto))
                            {
                                Assert.AreEqual(elementTextValidate, texto);
                                listTextDocumentUpload.Remove(texto);
                                break;
                            }
                        }

                        fileName = Utilities.getNameFileUpload(texto);
                        if (!fileName.Equals(""))
                        {
                            fileInput.SendKeys(fileLocation + fileName);
                        }
                        else
                        {
                            fileInput.SendKeys(fileLocation + nameFilesConstants.FILE_TEST_UPLOAD);
                        }
                    }
                    
                    waitTillElementIsDisplayedVoid(container, 50);                
                    if(contUpload == countList)
                    {
                        IWebElement buttonFinishUploadClick = waitTillElementIsClickable(buttonFinishUpload);
                        buttonFinishUploadClick.Click();
                    }else
                    {
                        IWebElement buttonConfirmFile = waitTillElementIsClickable(buttonConfirm);
                        buttonConfirmFile.Click();
                    }
                    contUpload++;
                }
                int sizeListDocuments = listTextDocumentUpload.Count;
                ScenarioContext.Current["DocumentsSizeList"] = sizeListDocuments;

                IWebElement buttonSuccessfullClick = waitTillElementIsClickable(buttonFinishSuccessful);
                buttonSuccessfullClick.Click();
            }
        }

        public void clickStepsParticipant()
        {
            IWebElement clickStepsParticipant;
            for (int i = 1; i <= 3; i++)
            {                
               clickStepsParticipant = waitTillElementIsClickable(buttonsStep);
               clickStepsParticipant.Click();             
            }
        }

        public void validateDocumentsQuantity(string listTitle, string input, string isItin)
        {            
            List<string> listTextDocumentUpload;
            try
            {
                listTextDocumentUpload = (List<string>)ScenarioContext.Current[listTitle];
            }
            catch (Exception)
            {
                listTextDocumentUpload = new List<string>();
            }
            if (listTextDocumentUpload.Count > 0)
            {
                clickJavaScriptExecutor(documentsTab);
                waitTillElementIsDisplayedVoid(titleDocumentsPage, 20);
                List<IWebElement> listDocumentsElements = new List<IWebElement>(driver.FindElements(listDocuments));
                int countList = listDocumentsElements.Count;
                if(isItin.Equals("Yes"))
                {
                    Assert.AreEqual(countList, Int32.Parse(input) + configConstants.QUANTTY_BASE_ITIN_DOCUMENTS);
                }
                else
                {
                    Assert.AreEqual(countList, Int32.Parse(input) + configConstants.QUANTTY_BASE_DOCUMENTS);
                }
            }
        }

    }
}
