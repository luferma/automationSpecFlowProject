using OpenQA.Selenium;

namespace TaxChatTAF.pages.documents.popups
{
    class EducationExpensesPopup : BasePopUp {

        public EducationExpensesPopup(IWebDriver driver){
            this.driver = driver;
        }
        public void selectOption1(){
            selectCheckBoxByText("Student loan interest");
        }
        public void selectOption2(){
            selectCheckBoxByText("Tuition expenses");
            
        }       
    }
}