using System;
using System.Collections.Generic;
using System.Text;

namespace TaxChatTAFSpecFlow.models
{
    public class ParticipantData{

        public string name { get; set; }
        public string lastName { get; set; }
        public string email  { get; set; }
        public string tile { get; set; }
        public string internalOption { get; set; }
        public int input { get; set; }

        public string isValidationSpigotGroup { get; set; }

        public string isValidationTileByParts { get; set; }

        public string emailPattern { get; set; }

        public string isB2B2CUser { get; set; }

        public string consentAditionalQuestion { get; set; }

        public string consentMarried { get; set; }

        public string consentFinantialReport { get; set; }

        public string consentReportableTransaction { get; set; }

        public string isMarriedOnBoarding { get; set; }

        public int expectedQuote { get; set; }

        public string typeDependent { get; set; }

        public string firstNameDependent { get; set; }

        public string lastNameDependent { get; set; }

        public string dateOfBirth { get; set; }

        public string ssn { get; set; }

        public string dependentNotSsn { get; set; }

        public string isMarriedDependent { get; set; }

        public string maritalStatus { get; set; }

        public string markCompleteOptions { get; set; }

        public string howDidYouHearAboutList { get; set; }

        public string validateAdditionalConsents { get; set; }

        public string validatePasswordMessage { get; set; }

        public string validateDateOfBirth { get; set; }

        public string discountCode { get; set; }

        public string discountFixed { get; set; }

        public string discountPercentage { get; set; }

        public string discountFlat { get; set; }

        public string country { get; set; }

        public string stateSelect { get; set; }

        public string stateCompare { get; set; }

        public string isStateSelect { get; set; }

        public string isCreatedUser { get; set; }

        public string spouseNotSsn { get; set; }

        public string hadDistributions { get; set; }

        public string directAndsameBankAccount { get; set; }

        public string checkMailedAndDirect { get; set; }

        public string isRandomUploadFile { get; set; }

        public string isCitizen { get; set; }

        public string isBuySell { get; set; }

        public string isCCHValidation { get; set; }

        public string isCountryUs { get; set; }

        public string otherOptionHowDidYouHearList { get; set; }

        public string isReferralDiscount { get; set; }

        public string complexityExpected { get; set; }

        public string showQuotePage { get; set; }
    }
}
