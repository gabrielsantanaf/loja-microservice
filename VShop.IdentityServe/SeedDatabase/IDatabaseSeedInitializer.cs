namespace VShop.IdentityServe.SeedDatabase
{
    public interface IDatabaseSeedInitializer
    {
        void InitializeSeedRoles();
        void InitializeSeedUsers();
    }
}
