using OpenQA.Selenium;
using TaxChatTAF.utils;

namespace TaxChatTAF.pages.preparer
{
    class MenuBar : SeleniumActions
    {
        By searchParticipantsOption = By.CssSelector("");
        By IRQueueOption = By.CssSelector("");
        By sharePointEscalationOption = By.CssSelector("");
        By adminInterfaceOption = By.CssSelector("");
        By logOutButton = By.XPath("//button[contains(text(), 'Log Out')]");

        public void selectSearchParticipantsOption() 
        {
            driver.FindElement(searchParticipantsOption).Click();
        }

        public void selectIRQueueOption() 
        {
            driver.FindElement(IRQueueOption).Click();
        }

        public void selectSharepointEscalationOption() 
        {
            driver.FindElement(sharePointEscalationOption).Click();
        }

        public void selectAdminInterfaceOption()
        {
            driver.FindElement(adminInterfaceOption).Click();
        }

        public void clickOnLogOutButton() 
        {
            driver.FindElement(logOutButton).Click();
        }
    }
}
