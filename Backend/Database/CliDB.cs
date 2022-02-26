using Microsoft.EntityFrameworkCore;

namespace Backend.Database
{
    public class CliDB : DbContext
    {
        public CliDB(DbContextOptions<CliDB> options)
            :base(options)
        {
            
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subscribe> Subscribes  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Account>(entity=>
            {
                entity.HasKey(m=>m.Username);
                entity.Property(m=>m.Username).IsRequired();
                entity.Property(m=>m.Password).HasMaxLength(35);
            });

            modelBuilder.Entity<User>(entity=>
            {
                entity.HasKey(m=>m.AccountUsername);
                entity.HasOne(m=>m.Account).WithOne(m=>m.User).HasForeignKey<User>(m=>m.AccountUsername);
            });

            modelBuilder.Entity<Writer>(entity=>
            {
                entity.HasKey(m=>m.AccountUsername);
                entity.HasOne(m=>m.Account).WithOne(m=>m.Writer).HasForeignKey<Writer>(m=>m.AccountUsername);
            });

            modelBuilder.Entity<Manager>(entity=>
            {
                entity.HasKey(m=>m.AccountUsername);
                entity.HasOne(m=>m.Account).WithOne(m=>m.Manager).HasForeignKey<Manager>(m=>m.AccountUsername);
            });
        }
    }
}