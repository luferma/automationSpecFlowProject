using OpenQA.Selenium;

namespace TaxChatTAF.pages.documents.popups
{
    public class OwnedRentalPropertyPopUp : BasePopUp {

        public OwnedRentalPropertyPopUp(IWebDriver driver){
            this.driver = driver;
        }
        public void selectOption1(){
            selectCheckBoxByText("I used my rental property for personal use part of the year");
        }
        public void selectOption2(){
            selectCheckBoxByText("I bought a rental property in 2019");
        }
        public void selectOption3(){
            selectCheckBoxByText("I sold a rental property in 2019");  
        }
    }
}