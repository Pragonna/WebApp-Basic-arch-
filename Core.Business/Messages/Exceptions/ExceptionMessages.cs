
namespace Core.Business.Messages.Exceptions
{
    public static class ExceptionMessages
    {
        public static string EmailAlreadyRegistered =>
            "This email already registered";
        public static string EmailOrPasswordInCorrect =>
            "Email or Password is incorrect";
        public static string ClaimsNotFound =>
         "Claims not found.";
        public static string Forbidden403 =>
         "You are not authorized";
        public static string CategoryAlreadyExists => "This Category already is exists";
        public static string CategoryNotFound => "This Category is not found";
        public static string FieldCanNotBeNullOrEmpty => "This field is required";
        public static string PriceGreatThanZero => "Price must be great than zero";
        public static string ProductCanNotBeNull => "Products can not be null or empty";
        public static string ProductNotFound => "This Product is not found";
        public static string ProductAlreadyExists => "This Product already added";
        public static string ClaimRoleNotFound => "This role does not exists";
        public static string RoleAlreadyAdded => "This user already have role";
    }
}
