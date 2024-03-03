using OpenQA.Selenium;

namespace TaxChatTAF.pages.documents.popups
{
    class IRAPopUp : BasePopUp {

        public IRAPopUp(IWebDriver driver){
            this.driver = driver;
        }
        public void selectOption1(){
            selectCheckBoxByText("Did you or your spouse make or plan to make contributions before April 15, 2020?");
        }
        public void selectOption2(){
            selectCheckBoxByText("Did you or your spouse have a rollover or conversion?");
            
        }
        public void selectOption3(){
            selectCheckBoxByText("Did you or your spouse receive a distribution from an IRA?");  
        }

        public void selectOption4(){
            selectCheckBoxByText("None of the above (just have an IRA)");  
        }
    }
}