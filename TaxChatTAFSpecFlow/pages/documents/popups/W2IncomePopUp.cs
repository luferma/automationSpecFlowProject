using OpenQA.Selenium;

namespace TaxChatTAF.pages.documents.popups
{
    public class W2IncomePopUp : BasePopUp {

        public W2IncomePopUp(IWebDriver driver){
            this.driver = driver;
        }
       
        public void selectOption1(){
            selectCheckBoxByText("Do you have W-2 income?");
        }
        public void selectOption2()
        {
            selectCheckBoxByText("Does your spouse (if applicable) have W-2 income?");
        }
        public void selectOption3()
        {
            selectCheckBoxByText("report income in more than three states?");
        }

    }
}