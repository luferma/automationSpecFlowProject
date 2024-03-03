using Faker;

namespace TaxChatTAF
{
    static class fakeDataGenerator
    {
        public static string firstName() => Name.First();

        public static string lastName() => Name.Last();

        public static string fullName() => Name.FullName();
        
        public static string companyName() => Company.Name();

        public static string phoneNumber() => Phone.Number();

        public static string email() => Name.First() + "@" + "test.com";
    }
}
