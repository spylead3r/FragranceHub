

namespace PetPals.Common
{
    public static class EntityValidationConstants
    {
        // Pet Entity
        public static class Pet
        {
            public const int NameMaxLength = 50;
            public const int SpeciesMaxLength = 30;
            public const int BreedMaxLength = 50;
            public const int AgeMinValue = 0;
            public const int AgeMaxValue = 25;
        }

        // AdoptionRequest Entity
        public static class AdoptionRequest
        {
            public const int StatusMaxLength = 20; // e.g., "Pending", "Approved"
        }

        // Donation Entity
        public static class Donation
        {
            public const decimal MinAmount = 1.0m; // Minimum donation amount
            public const decimal MaxAmount = 10000.0m; // Maximum donation amount
        }

        // Event Entity
        public static class Event
        {
            public const int TitleMaxLength = 100;
            public const int DescriptionMaxLength = 500;
            public const int LocationMaxLength = 100;
        }

        // Volunteer Entity
        public static class Volunteer
        {
            public const int NameMaxLength = 100;
            public const int ContactInfoMaxLength = 100;
            public const int TaskMaxLength = 200;
        }

        // User Entity
        public static class ApplicationUser
        {
            public const int FirstNameMaxLength = 35;
            public const int LastNameMaxLength = 35;
            public const int AddressMaxLength = 200;
            public const int PhoneNumberMaxLength = 15;
        }

        public static class Feedback
        {
            public const int RatingMinValue = 1;
            public const int RatingMaxValue = 5;
            public const int MessageMaxLength = 500;
        }
    }
}

