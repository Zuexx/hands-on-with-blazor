using AuthPermissions.SetupCode;

namespace HandsOnWithBlazor.Application
{
    public static class AppAuthSetupData
    {
        public static readonly List<BulkLoadRolesDto> RolesDefinition = new List<BulkLoadRolesDto>()
        {
            new("Role1", null, "Permission1"),
            new("Role2", null, "Permission2"),
            new("SuperRole", null, "AccessAll"),
        };

        public static readonly List<BulkLoadUserWithRolesTenant> UsersRolesDefinition = new List<BulkLoadUserWithRolesTenant>
        {
            new ("P1@g1.com", null, "Role1"),
            new ("P2@g1.com", null, "Role2"),
            new ("Super@g1.com", null, "SuperRole"),

        };
    }
}