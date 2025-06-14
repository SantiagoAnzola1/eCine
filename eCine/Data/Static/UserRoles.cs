namespace eCine.Data.Static
{

    public static class UserRoles
    {
        public const string Admin = "Admin"; 
        public const string User = "User";

        public static IEnumerable<string> Roles=> new List<string> { Admin, User };
    }
}
