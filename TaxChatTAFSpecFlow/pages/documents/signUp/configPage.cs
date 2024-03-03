using OpenQA.Selenium;


namespace TaxChatTAF.pages.documents.signUp
{
    class ConfigPage : SignUpPage
    {
        By childrenDependentOption = By.ClassName("children-1");
        By mortgageOption = By.ClassName("mortgage-2");        
        By ownedRentalOption = By.ClassName("properties-3");
        By selfEmployedOption = By.ClassName("contract-4");
        By investmentIncomeOption = By.ClassName("stocks-5");
        By foreignIncomeOption = By.ClassName("foreign-6");
        By k1Option = By.ClassName("K1-7");
        By cryptoCurrencyOption = By.XPath("//figure[contains(@class, 'crypto')]");
        By w2Option = By.XPath("//figure[contains(@class, 'w2')]");
        By educationExpensesOption = By.ClassName("education-8");
        By IRAOption = By.ClassName("ira-9");

        public ConfigPage(IWebDriver driver) 
        {
            this.driver = driver;
        }

        public void selectChildrenDependents()
        {
            driver.FindElement(childrenDependentOption).Click();
        }
        public void selectMortgage()
        {
            driver.FindElement(mortgageOption).Click();
        }
        public void selectOwnedRentalProperty()
        {
            driver.FindElement(ownedRentalOption).Click();
        }
        public void selectSelfEmployedIncome()
        {
            driver.FindElement(selfEmployedOption).Click();
        }
        public void selectInvestmentIncome()
        {
            driver.FindElement(investmentIncomeOption).Click();
        }
        public void selectForeignIncome()
        {
            driver.FindElement(foreignIncomeOption).Click();
        }
        public void selectK1Income()
        {
            driver.FindElement(k1Option).Click();
        }
        public void selectCryptoCurrency()
        {
            driver.FindElement(cryptoCurrencyOption).Click();
        }
        public void selectW2()
        {
            driver.FindElement(w2Option).Click();
        }

        public void selectEducationExpenses()
        {
            driver.FindElement(educationExpensesOption).Click();
        }
        public void selectIRA()
        {
            driver.FindElement(IRAOption).Click();
        }
    }
}
