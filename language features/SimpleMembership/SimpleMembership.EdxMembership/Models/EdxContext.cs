using SimpleMembership.EdxMembership.Models.EdxMembershipModel;
using System.Data.Entity;

namespace SimpleMembership.EdxMembership.Models
{
    public class EdxContext : DbContext
    {
        // Укажем какую ConnectionString использовать из web.config
        public EdxContext() : base("DefaultConnection") {}

        public DbSet<EdxUserProfile> UserProfiles { get; set; }
    }
}