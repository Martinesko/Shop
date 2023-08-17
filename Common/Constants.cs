namespace Shop.Common
{
    public static class EntityValidationConstants
    {
          public static class Adress
        {
            public const int CityMinLength = 2;
            public const int CityMaxLength = 50;

            public const int StreetMinLength = 2;
            public const int StreetMaxLength = 50;
        }
          public static class User
        {
            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 16;

            public const int SurNameMinLength = 1;
            public const int SurNameMaxLength = 16;
        }
    }
 
}