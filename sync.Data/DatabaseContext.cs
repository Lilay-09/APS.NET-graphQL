
using Microsoft.EntityFrameworkCore;
using sync.Domain;
using sync.Domain.Items;
using sync.Domain.UM;

namespace sync.Data
{
    public class DatabaseContext:DbContext
    {
        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Permission> Permissions { get; set; }

   



        private readonly string? _connectionString = "Server=localhost;Port=5432;Database=synix_dev;Username=postgres;Password=010102;";

        public DatabaseContext()
        {
            _connectionString = "Server=localhost;Port=5432;Database=synix_dev;Username=postgres;Password=010102;";
        }
        public DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entities = modelBuilder.Model.GetEntityTypes();

            foreach (var entity in entities)
            {
                var properties = entity.GetProperties();

                foreach (var property in properties)
                {
                    // Configure DateTime properties
                    if (property.ClrType == typeof(DateTime))
                    {
                        modelBuilder.Entity(entity.ClrType)
                            .Property(property.Name)
                            .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
                    }

                    // Configure primary key properties of type Guid
                    if (property.ClrType == typeof(Guid) && property.IsPrimaryKey())
                    {
                        modelBuilder.Entity(entity.ClrType)
                            .Property(property.Name)
                            .HasDefaultValueSql("uuid_generate_v4()")
                            .ValueGeneratedOnAdd();
                    }
                }
            }
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

        }
    }
}
