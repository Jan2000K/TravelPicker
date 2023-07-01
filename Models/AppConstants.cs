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
}
public enum ActionStatusCode
{
    ActionSuccess = 0,
    ActionFailed = 1,
    UnexpectedError = 2,
    ExceptionThrown  =3
}