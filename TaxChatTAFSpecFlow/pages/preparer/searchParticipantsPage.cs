using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TaxChatTAFSpecFlow.models;
using TaxChatTAFSpecFlow.utils;

namespace TaxChatTAF.pages.preparer
{
    class SearchParticipantsPage : MenuBar
    {
        By searchField = By.Id("SearchBox");
        By allGorupsDropDownButton = By.CssSelector("div.filter-multi-group-button");
        By filterGroupLabel = By.CssSelector("div.filter-multi-group-dropdown > label.ng-scope");
        By allGroupsInput = By.XPath("//input[@ng-model='multi_group_search']");
        By allGroupsCloseButton = By.XPath("//div[@class='filter-multi-group-dropdown']//button[contains(text(), 'Close')]");
        string filterCheckBoxXpath = "//text()[contains(., '{0}')]/preceding-sibling::input";
        By allGroupsDropDown = By.CssSelector("div.filter-multi-group-dropdown");
        By resultsList = By.XPath("//tr[@class='ng-scope']");
        By searchResultTable = By.XPath("//td[contains(@ng-class, 'name_last')]");
        By labelOriginalComplexity = By.XPath("//label[text()='Original Complexity:']");
        By valueOriginalComplexity = By.XPath("//div[@class='ng-binding']//label[text()='Original Complexity:']/parent::div");
        By valueOriginalComplexityLabel = By.XPath("//div[@class='ng-binding']//label[text()='Original Complexity:']");
        By labelCurrentComplexity = By.XPath("//span[@ng-show='current_complexity.show']");
        By valueCurrentComplexity = By.XPath("//span[contains(@ng-show, 'current_complexity.show')]");
        By valueCurrentStatus = By.XPath("(//section[@class='status']//div[@class='status-value ng-binding'])[1]");
        By tableSearchResults = By.XPath("//grid[contains(@config, 'partgridconfig')]//tbody");
        By totalPage = By.XPath("//ng-container[contains(@ng-show, 'total')]");
        By footerTotalPage = By.XPath("(//span[contains(@class, 'ng-binding')])[2]");
        By nextPage = By.XPath("(//button[contains(@class, 'page-next')])[1]");
        By currentPriceDiv = By.XPath("//label[contains(text(),'Current Price')]//parent::div");
        By originalQuoteDiv = By.XPath("//label[contains(text(),'Original Quote')]//parent::div");
        By buttonDocuments = By.XPath("//li[@title='Documents']");
        By buttonAllDocsReceived = By.XPath("//button[contains(text(), 'All docs received')]");
        By windowConfirm = By.XPath("//form[@name='frmStatusConfirm']");
        By buttonConfirmWindow = By.XPath("//button[contains(@ng-click, 'on_yes_click')]");
        By columnTable = By.XPath("//div[contains(@title, 'Not uploaded') and contains(text(), 'Prior year return')]");
        By editAdditionalState = By.XPath("//i[@title='Edit states']");
        By preparerInformation = By.XPath("//li[@title='Info']");
        By titleAdditionalStates = By.XPath("//div[contains(@ng-show,'edit_additional_states')]//h2[@class='title']");
        By buttonAddState = By.XPath("//button[contains(@ng-click,'add_state')]");
        By selectListState = By.XPath("//select[@name='state']");
        By titleStateSection = By.XPath("//h2[text()='States']");
        By buttonPaidExtension = By.XPath("//button[contains(@ng-click,'PaidExtension')]");
        By buttonSaveState = By.XPath("//button[contains(@ng-click,'edit_additional_states.confirm')]");
        By titleConfirmConfiguration = By.XPath("//h2[contains(text(), 'Confirm Configuration')]");
        By buttonConfirmSaveState = By.XPath("//button[contains(@ng-click,'edit_additional_states.save')]");
        By labelAdditionalState = By.XPath("//ng-container[contains(@ng-if,'participant.states.manual')]");
        By buttonManualDeliver = By.XPath("//button[contains(@ng-click,'ready_to_release_manual')]");
        By titleWindowManualDeliver = By.XPath("//h3[contains(text(), 'Ready To Release')]");
        By confirmManualDeliver = By.XPath("//button[contains(@ng-click, 'YesClick')]");
        By totalIncome = By.XPath("//input[contains(@ng-model, 'total_income')]");
        By taxableIncome = By.XPath("//input[contains(@ng-model, 'taxable_income')]");
        By federalState = By.XPath("//input[contains(@ng-model, 'federal')]");
        By amount = By.XPath("//input[contains(@ng-model, 'amount')]");
        By fileAttachReturn = By.Id("returnFileInput");
        By confirmManualReturn = By.XPath("//button[contains(@ng-click, 'manual_return.submit') and contains(text(), 'Submit')]");
        By titlePreparingSubmit = By.XPath("//h1[contains(@ng-if, 'manual_return.summary')]");
        By buttonReturnConfirmed = By.XPath("//button[contains(@ng-click, 'manual_return.submitConfirmed()')]");
        By testElement = By.XPath("//pre[@class='ng-binding']");
        By preparerSyncButton = By.XPath("//div[contains(@ng-show,'!sync.isPending()')]");
        By titleSyncMessage = By.XPath("//div[contains(@class,'message')]");
        By buttonCloseConfirmSync = By.XPath("//button[contains(@ng-click,'close')]");
        By editOtherInformation = By.XPath("//button[contains(@ng-click,'editDialog')]//i[contains(@class,'fa-edit')]");
        By inputZipCodeOtherInformation = By.XPath("//input[contains(@name,'zip_code')]");
        By saveButton = By.XPath("//button[contains(@ng-click,'move_to_confirm')]");
        By confirmButton = By.XPath("//button[@ng-click='save()']");
        By panelOtherInfo = By.XPath("//section[contains(@class,'other-info')]//h2");
        By country = By.XPath("//strong[text()='Country']//parent::div");
        By state = By.XPath("//strong[text()='State']//parent::div");
        By residentState = By.XPath("//span[contains(@ng-show,'resident_state')]");
        By emailPreparer = By.XPath("//div[contains(@class,'email')]");
        By closeSelectedParticipant = By.XPath("//li[contains(@ng-click,'closeSelectedParticipant')]");        

        public SearchParticipantsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void searchByNameOrEmail(string nameOrEmail)
        {
            IWebElement searchFieldElement = driver.FindElement(searchField);           
            searchFieldElement.SendKeys(Keys.Control + "a" + Keys.Delete);
            searchFieldElement.SendKeys(nameOrEmail);
            searchFieldElement.SendKeys(Keys.Tab);
        }

        public void selectFilter(string filterName)
        {
            string checkBoxFilterComplete = string.Format(filterCheckBoxXpath, filterName);
            driver.FindElement(By.XPath(checkBoxFilterComplete)).Click() ;
        }

        public void selectFiltersIntoAllGroupsDropDown(params string[] filtersList)
        {
            IWebElement allGroupsInputElement = driver.FindElement(allGroupsInput);

            driver.FindElement(allGorupsDropDownButton).Click();
            waitTillElementIsDisplayed(allGroupsDropDown);

            foreach (string filter in filtersList)
            {
                allGroupsInputElement.Clear();
                allGroupsInputElement.SendKeys(filter);
                driver.FindElement(filterGroupLabel).Click();
                allGroupsInputElement.Clear();
            }
            driver.FindElement(allGroupsCloseButton);
        }

        public List<string> reviewParticipantComplexity(string nameOrEmail, string lastname, string isStatusValidation)
        {
            string answer;
            List<string> answerList = new List<string>();            
            searchParticipantOnPreparerPage(nameOrEmail, lastname, true);

            if (isStatusValidation.Equals("Yes"))
            {                
                answer = getTextElement(valueCurrentStatus);
                answerList.Add(answer);                
            }
            else
            {
                string currentPrice = getTextElement(currentPriceDiv);
                string originalQuote = getTextElement(originalQuoteDiv);
                string priceConvert = UtilitiesSteps.getTestPricing(currentPrice);
                string quoteConvert = UtilitiesSteps.getTestPricing(originalQuote);
                answer = getTextElement(valueCurrentComplexity);
                answerList.Add(answer);
                answerList.Add(priceConvert);
                answerList.Add(quoteConvert);
            }
            return answerList;
        }

        public void preparerConfirmsDocuments(string nameOrEmail, string lastname)
        {
            string status;            
            searchParticipantOnPreparerPage(nameOrEmail, lastname, true);

            clickButton(buttonDocuments);

            waitTillElementIsDisplayed(columnTable);
            waitTillElementIsClickable(buttonAllDocsReceived);

            clickJavaScriptExecutor(buttonAllDocsReceived);            
            waitTillElementIsDisplayed(windowConfirm);
            clickJavaScriptExecutor(buttonConfirmWindow);

            status = getTextElement(valueCurrentStatus);            
            DateTime date1 = DateTime.UtcNow;
            string answer = UtilitiesPage.searchStatus(driver, true, status, date1, valueCurrentStatus, configConstants.ALL_DOCS_CONFIRMED_STATUS);
            Assert.AreEqual(configConstants.ALL_DOCS_CONFIRMED_STATUS, answer);
        }

        public void preparerAssignAditionalState()
        {
            clickButton(preparerInformation);
            waitTillElementIsDisplayed(buttonPaidExtension);
            clickButton(editAdditionalState);
            waitTillElementIsDisplayed(titleAdditionalStates);
            clickButton(buttonAddState);
            selectFromListValue(selectListState, configConstants.LABEL_NEW_YORK_SELECT_VALUE);
            clickButton(buttonSaveState);
            waitTillElementIsDisplayed(titleConfirmConfiguration);
            clickButton(buttonConfirmSaveState);
            waitTillElementIsDisplayed(labelAdditionalState);

            string textAdditionalState = getTextElement(labelAdditionalState);            
            DateTime date1 = DateTime.UtcNow;
            UtilitiesPage.searchStatusVoid(driver, true, textAdditionalState, date1, labelAdditionalState, configConstants.LABEL_NEW_YORK_SELECT_VALUE);
        }

        public void manualReturnRelease()
        {
            clickButton(buttonManualDeliver);
            waitTillElementIsDisplayed(titleWindowManualDeliver);
            clickButton(confirmManualDeliver);
            waitTillElementIsDisplayed(totalIncome);
            sendValue("15000", totalIncome);
            sendValue("12000", taxableIncome);
            sendValue("10000", federalState);
            sendValue("5000", amount);
            string fileLocation = Utilities.getRelativePathRoute(configConstants.ROUTE_COMPLETE_UPLOAD);
            string fileAttach = fileLocation + nameFilesConstants.FILE_TEST_UPLOAD;
            scrollMoveElementJavaScript(fileAttachReturn);            
            fileAttach.Replace("\\", "\\\\");
            IWebElement fileAttachElement = driver.FindElement(fileAttachReturn);
            fileAttachElement.SendKeys(fileAttach);
            
            clickButton(confirmManualReturn);
            waitTillElementIsDisplayed(titlePreparingSubmit);
            clickButton(buttonReturnConfirmed);

            string status = getTextElement(valueCurrentStatus);            
            DateTime date1 = DateTime.UtcNow;
            string answer = UtilitiesPage.searchStatus(driver, true, status, date1, valueCurrentStatus, configConstants.RETURN_RELEASED_STATUS);
            Assert.AreEqual(configConstants.RETURN_RELEASED_STATUS, answer);
        }

        public void preparerValidateCchProcess(string nameOrEmail, string lastname)
        {
            string status;            
            searchParticipantOnPreparerPage(nameOrEmail, lastname, true);

            clickButton(buttonDocuments);

            waitTillElementIsDisplayed(columnTable);            
            waitTillElementIsClickable(buttonAllDocsReceived);

            clickJavaScriptExecutor(buttonAllDocsReceived);
            waitTillElementIsDisplayed(windowConfirm);
            clickJavaScriptExecutor(buttonConfirmWindow);

            status = getTextElement(valueCurrentStatus);
            DateTime date1 = DateTime.UtcNow;
            string answer = UtilitiesPage.searchStatus(driver, true, status, date1, valueCurrentStatus, configConstants.ALL_DOCS_CONFIRMED_STATUS);
            Assert.AreEqual(configConstants.ALL_DOCS_CONFIRMED_STATUS, answer);

            clickButton(preparerInformation);
            waitTillElementIsDisplayed(labelCurrentComplexity);

            scrollMoveElementJavaScript(panelOtherInfo);
            clickButton(panelOtherInfo);
            waitTillElementIsClickable(editOtherInformation);
            clickButton(editOtherInformation);
            waitTillElementIsDisplayed(inputZipCodeOtherInformation);
            sendValue("67890", inputZipCodeOtherInformation);
            clickButton(saveButton);
            waitTillElementIsClickable(confirmButton);
            clickButton(confirmButton);

            waitTillElementIsClickable(preparerSyncButton);
            clickButton(preparerSyncButton);
            waitTillElementIsDisplayed(titleSyncMessage);
            string messageSync = getTextElement(titleSyncMessage);
            StringAssert.DoesNotContain(configConstants.ERROR_500, messageSync);
            clickButton(buttonCloseConfirmSync);            
        }

        public void preparerValidateCountryAndStateValidation(ParticipantData participant)
        {
            searchParticipantOnPreparerPage(participant.email, "", false);                       
            string stringResidentState = getTextElement(residentState);            

            //Assert.AreEqual("TX", stringResidentState);           
            
            scrollMoveElementJavaScript(panelOtherInfo);
            clickButton(panelOtherInfo);
            waitTillElementIsDisplayed(country);

            string stringCountry = getTextElement(country);
            string stringState = getTextElement(state);
            string countryComparate;
            string stateComparate;
            string[] separateCountry;
            string[] separateState;

            if (participant.isCountryUs.Equals("Yes"))
            {
                separateCountry = stringCountry.Split(' ');
                separateState = stringState.Split(' ');
                string country1 = separateCountry[1];
                string country2 = separateCountry[2];
                countryComparate = country1 + " " + country2;
                stateComparate = separateState[1];
            }
            else
            {
                separateCountry = stringCountry.Split(' ');
                separateState = stringState.Split(' ');
                countryComparate = separateCountry[1];
                stateComparate = separateState[1];
            }
           
            Assert.AreEqual(participant.country.Replace("_", " "), countryComparate);
            Assert.AreEqual(participant.stateSelect, stateComparate);
        }

        public void preparerSearchsAndValidatesConsentName(ParticipantData participant)
        {
            searchParticipantOnPreparerPage(participant.email, participant.lastName, true);
        }

        public void searchParticipantOnPreparerPage(string nameOrEmail, string lastname, Boolean isComparateWithName)
        {                        
            searchByNameOrEmail(nameOrEmail);
            driver.FindElement(totalPage).Click();
            waitTillElementIsDisplayed(totalPage);

            IWebElement totalPageElement = driver.FindElement(totalPage);
            string results = totalPageElement.Text.Trim();
            IWebElement searchResultText = driver.FindElement(searchResultTable);
            string nameResult = searchResultText.Text.Trim();

            IWebElement footerTotalPageElement = driver.FindElement(footerTotalPage);
            string footerTotalPageText = footerTotalPageElement.Text.Trim();

            IWebElement nextPageElement = driver.FindElement(nextPage);
            string nextPagAttribute = nextPageElement.GetAttribute("disabled");

            List<IWebElement> listElementsResultSearch = new List<IWebElement>(driver.FindElements(tableSearchResults));
            int contTable = listElementsResultSearch.Count;
            bool searhResultCont = true;
            string emailPreparerString;

            while (searhResultCont)
            {
                searchByNameOrEmail(nameOrEmail);
                waitTillElementIsDisplayed(totalPage);
                driver.FindElement(totalPage).Click();                

                listElementsResultSearch = new List<IWebElement>(driver.FindElements(tableSearchResults));
                contTable = listElementsResultSearch.Count;
                waitTillElementIsDisplayed(searchResultTable);
                searchResultText = driver.FindElement(searchResultTable);                
                nameResult = searchResultText.Text.Trim();

                totalPageElement = driver.FindElement(totalPage);
                results = totalPageElement.Text.Trim();

                footerTotalPageElement = driver.FindElement(footerTotalPage);
                footerTotalPageText = footerTotalPageElement.Text.Trim();

                nextPageElement = driver.FindElement(nextPage);
                nextPagAttribute = nextPageElement.GetAttribute("disabled");

                if(isComparateWithName)
                {
                    try
                    {
                        if (nameResult.Equals(lastname) && results.Equals(configConstants.SEARCH_RESULTS)
                        && footerTotalPageText.Equals(configConstants.SEARCH_RESULTS) && nextPagAttribute.Equals("true") && contTable == 1)
                        {
                            searhResultCont = false;
                        }
                        else
                        {
                            driver.Navigate().Refresh();
                        }
                    }
                    catch
                    {
                        searhResultCont = true;
                    }
                }
                else
                {
                    if (results.Equals(configConstants.SEARCH_RESULTS)
                        && footerTotalPageText.Equals(configConstants.SEARCH_RESULTS) && nextPagAttribute.Equals("true") && contTable == 1)
                    {
                        searhResultCont = false;
                    }
                    else
                    {
                        driver.Navigate().Refresh();
                    }
                }
                
                if (searhResultCont == false)
                {
                    try
                    {
                        driver.FindElement(searchResultTable).Click();
                        waitTillElementIsDisplayed(labelCurrentComplexity);
                        emailPreparerString = getTextElement(emailPreparer);
                        if (!emailPreparerString.Equals(nameOrEmail))
                        {
                            clickButton(closeSelectedParticipant);
                            waitTillElementIsDisplayed(searchField);
                            searhResultCont = true;
                        }
                    }
                    catch
                    {
                        searhResultCont = true;
                    }
                }
            }
        }
    }
}
