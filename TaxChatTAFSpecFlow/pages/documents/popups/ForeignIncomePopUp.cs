using OpenQA.Selenium;

namespace TaxChatTAF.pages.documents.popups
{
    public class ForeignIncomePopUp : BasePopUp {

        public ForeignIncomePopUp(IWebDriver driver){
            this.driver = driver;
        }

        public void selectOption1(){
            selectCheckBoxByText("Investment income through US brokerage account or foreign interest");
        }
        public void selectOption2(){
            selectCheckBoxByText("Foreign rental");
        }
        public void selectOption3()
        {
            selectCheckBoxByText("Foreign mutual funds or similar investments");
        }
        public void selectOption4()
        {
            selectCheckBoxByText("Direct investment in a foreign corporation or partnership");
        }
        public void selectOption5()
        {
            selectCheckBoxByText("Foreign wages (Form 2555)");
        }
        public void selectOption6()
        {
            selectCheckBoxByText("Is this your first year filing a US tax return as a result of relocating to US?");
        }

    }
}