namespace TravelPickerApp.Models;

public static class AppConstants
{
    public static class UserRoles
    {
        public static readonly Guid Admin = new("9F325469-1363-4FCE-9715-9724CE9EF4AF");
        public static readonly Guid User = new("D3879C65-A5E2-48FA-9E65-7DA129062974");
    }

    public static class AuthPolicies
    {
        /// <summary>
        /// Requires user to be admin
        /// </summary>
        public const string AdminOnly = "AdminOnly";
        /// <summary>
        /// User must have role 'User' or above
        /// </summary>
        public const string UserOrAbove = "UserOrAbove";
    }

    public static class CommonMessages
    {
        public static class UserRelated
        {
            public const string ErrorProcessingData = "Error processing user data";
            public const string UserNotFound = "User not found";
        }

        public static class LocationRelated
        {
            public const string LocationNotFound = "Location not found";
        }

        public static class CountryRelated
        {
            public const string CountryDoesntExist = "Supplied country does not exist";
        }
    }
    public static class ContinentCountryPhoneCodes
    {
        public static int[] Europe = 
        {
            43,
            32,
            359,
            385,
            357,
            420,
            45,
            372,
            358,
            33,
            49,
            30,
            36,
            353,
            39,
            371,
            370,
            352,
            356,
            31,
            48,
            351,
            40,
            421,
            386,
            34,
            46,
            355,
            376,
            374,
            375,
            387,
            298,
            995,
            350,
            354,
            44,
            381,
            423,
            389,
            373,
            377,
            7,
            378,
            381,
            41,
            90,
            380,
            44,
            39
        };
    }
    public static class TestConstants
    {
        public static class TestUsers
        {
            public static  readonly Guid AdminUser = new("CE651EAC-D35E-4C7F-99A4-39D48C4D2B46");
            public static  readonly Guid NormalUser = new("C0F8B026-B01C-4A01-96AE-8D293825A87A");
        }
    }
}
public enum ActionStatusCode
{
    ActionSuccess = 0,
    ActionFailed = 1,
    UnexpectedError = 2,
    ExceptionThrown  =3,
    ExecutedWithWarnings = 4
}