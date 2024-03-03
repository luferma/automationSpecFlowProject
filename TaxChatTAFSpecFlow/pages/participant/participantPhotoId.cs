using TaxChatTAF.utils;
using OpenQA.Selenium;
using TaxChatTAFSpecFlow.utils;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text;
using System.Diagnostics;

namespace TaxChatTAF.pages.participant
{
    class ParticipantPhotoId : SeleniumActions
    {      
        By driverLicense = By.XPath("//div[contains(text(),'Valid state')]");
        By validPassport = By.XPath("//div[contains(text(),'Valid passport')]");
        By licenseImageFront = By.XPath("//img[@id='licenseFrontPreview']");
        By licenseImageBack = By.XPath("//img[@id='licenseBackPreview']");
        By passportImage = By.XPath("//img[@id='imagePreview");
        By nextButton = By.XPath("//button[text()='Next']");
        By sendButton = By.Id("extractDataButton");
        By uploadButton = By.Id("frontCaptureButton");
        By uploadBackCapture = By.Id("backCaptureButton");
        By uploadPassportButton = By.Id("captureButton");
        By fileTest = By.XPath("//input[@type='file']");
        By fileTest2 = By.XPath("(//input[@type='file'])[2]");
        By titleAlmost = By.XPath("//h1[contains(text(),'almost')]");

        public ParticipantPhotoId(IWebDriver driver) {
            this.driver = driver;
        }
        
        public void waitLoadImageDocument(IWebElement fileInput)
        {
            Boolean isNotLoadImage = true;
            string srcImage = "";
            while (isNotLoadImage)
            {
                srcImage = fileInput.GetAttribute("src").Trim();
                if(!srcImage.Equals(""))
                {
                    isNotLoadImage = false;
                }
            }
        }
        
        public void loadLicenseDocuments()
        {
            clickButton(uploadButton);            
            string fileLocation = Utilities.getRelativePathRoute(configConstants.ROUTE_COMPLETE_UPLOAD);
            IWebElement fileInputFront = driver.FindElement(fileTest);
            fileInputFront.SendKeys(fileLocation + nameFilesConstants.PHOTO_FRONT_LICENSE);

            clickButton(uploadBackCapture);
            IWebElement fileInputBack = driver.FindElement(fileTest2);
            fileInputBack.SendKeys(fileLocation + nameFilesConstants.PHOTO_BACK_LICENSE);
            Utilities.executeFile(configConstants.NAME_FILE_AUTOIT, Utilities.getRelativePathRoute(configConstants.ROUTE_COMPLETE_UPLOAD));
        }

        public void loadPassportDocument()
        {
            clickButton(uploadPassportButton);
            string fileLocation = Utilities.getRelativePathRoute(configConstants.ROUTE_COMPLETE_UPLOAD);
            IWebElement fileInputFront = driver.FindElement(fileTest);
            fileInputFront.SendKeys(fileLocation + nameFilesConstants.PASSPORT);
            Utilities.executeFile(configConstants.NAME_FILE_AUTOIT, Utilities.getRelativePathRoute(configConstants.ROUTE_COMPLETE_UPLOAD));
        }

        public void processLicenseDocuments()
        {            
            clickButton(driverLicense);
            waitTillElementIsDisplayedVoid(uploadButton);            
            loadLicenseDocuments();
            clickButton(sendButton);
            waitTillElementIsDisplayedVoid(titleAlmost);
        }

        public void processPassportDocuments()
        {
            clickButton(validPassport);
            waitTillElementIsDisplayedVoid(uploadPassportButton);
            loadPassportDocument();
            clickButton(sendButton);
            waitTillElementIsDisplayedVoid(titleAlmost);
        }
    }
}
