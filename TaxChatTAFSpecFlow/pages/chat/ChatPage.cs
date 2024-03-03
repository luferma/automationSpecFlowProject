using NUnit.Framework;
using OpenQA.Selenium;
using TaxChatTAF.utils;

namespace TaxChatTAF.pages.documents
{
    class ChatPage : SeleniumActions {
        By chatTab = By.XPath("//div[contains(@class,'wrapper')]//ul//a[contains(@href,'chat')]");
        By firstChatTitle = By.XPath("//div[contains(@class, 'Header')]//h3");
        By secondChatTitle = By.XPath("//div[contains(@class, 'Header')]//p");
        By chatMessage = By.XPath("//div[contains(@class, 'message')]");

        public ChatPage(IWebDriver driver){
            this.driver = driver;
        }

        public void reviewAndValidateChatTitles()
        {
            clickJavaScriptExecutor(chatTab);
            waitTillElementIsDisplayedVoid(firstChatTitle);
            string chatFirstTitle = getTextElement(firstChatTitle);
            string chatSecondTitle = getTextElement(secondChatTitle);
            string stringChatMessage = getTextElement(chatMessage);
            StringAssert.Contains(configConstants.FIRST_CHAT_TITLE, chatFirstTitle);
            StringAssert.Contains(configConstants.SECOND_CHAT_TITLE, chatSecondTitle);
            waitTillElementIsDisplayedVoid(chatMessage);
            StringAssert.Contains(configConstants.CHAT_MESSAGE, stringChatMessage);
        }
    }
}
