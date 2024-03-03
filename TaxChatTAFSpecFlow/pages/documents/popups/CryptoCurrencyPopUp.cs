using OpenQA.Selenium;

namespace TaxChatTAF.pages.documents.popups
{
    public class CryptoCurrencyPopUp : BasePopUp {

        public CryptoCurrencyPopUp(IWebDriver driver){
            this.driver = driver;
        }
       
        public void selectOption1(){
            selectCheckBoxByText("Did you have sale or exchange of cryptocurrency?");
        }

        public void selectOption2()
        {
            selectCheckBoxByText("Did you have any cryptocurrency peer-to-peer transactions?");
        }

        public void selectOption3()
        {
            selectCheckBoxByText("Did you purchase any products or services with cryptocurrency?");
        }

        public void selectOption4()
        {
            selectCheckBoxByText("Did you make any gifts or donations of cryptocurrency?");
        }

        public void selectOption5()
        {
            selectCheckBoxByText("Did you participate in cryptocurrency mining?");
        }

        public void selectOption6()
        {
            selectCheckBoxByText("Do you have cryptocurrency that is not reported on your exchange transaction history? (i.e forks, bonus)");
        }

        public void selectOption7()
        {
            selectCheckBoxByText("If you reported cryptocurrency on your prior year tax return, did you use any method other than FIFO?");
        }

        public void selectOption8()
        {
            selectCheckBoxByText("Did you participate in a lending arrangement (either borrower or lender) that involved cryptocurrency?");
        }

        public void selectOption9()
        {
            selectCheckBoxByText("Did you participate/invest in an initial coin offering (ICO), simple agreement for future tokens (SAFT), security token offering (STO), or similar event?");
        }

        public void selectOption10()
        {
            selectCheckBoxByText("Did you participate/invest in derivative contracts involving cryptocurrency (i.e., futures contracts, contracts for difference (CFDs), perpetual contracts)?");
        }

        public void selectOption11()
        {
            selectCheckBoxByText("Did you hold an interest in a cryptocurrency trust, fund, or similar type of investment vehicle during the year?");
        }

    }
}