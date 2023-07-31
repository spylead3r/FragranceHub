namespace FragranceHub.Common
{
    public static class EntityValidationConstants
    {
        public static class Fragrance
        {
            //Fragrance
            public const int FragranceNameMinLength = 2;
            public const int FragranceNameMaxLength = 50;

            //Description
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 200;

            //ImageUrl
            public const int ImageUrlMaxLength = 2048;

            //Price
            public const string PriceMinValue = "0";
            public const string PriceMaxValue = "2000";



        }
        public static class Category
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;

        }

        public static class Review
        {
            //Title
            public const int TitleMinLength = 2;
            public const int TitleMaxLength = 100;

            //Description
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 200;

            //Rating
            public const int RatingMinValue = 1;
            public const int RatingMaxValue = 5;

        }

        public static class User
        {
            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 15;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 15;
        }
    }
}
