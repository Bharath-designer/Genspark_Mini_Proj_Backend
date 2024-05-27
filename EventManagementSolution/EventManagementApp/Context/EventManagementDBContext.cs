using System.Security.Cryptography;
using System.Text;
using EventManagementApp.Enums;
using EventManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementApp.Context
{
    public class EventManagementDBContext : DbContext
    {
        public EventManagementDBContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        #region DbSets
        public DbSet<ClientResponse> ClientResponses { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<QuotationRequest> QuotationRequests { get; set; }
        public DbSet<QuotationResponse> QuotationResponses { get; set; }
        public DbSet<Refund> Refunds { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ScheduledEvent> ScheduledEvents { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCredential> UserCredentials { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ClientResponse>()
                .HasOne(c => c.QuotationResponse)
                .WithOne(q => q.ClientResponse)
                .HasForeignKey<ClientResponse>(c => c.QuotationResponseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.EventCategory)
                .WithMany(e => e.Orders)
                .HasForeignKey(o => o.EventCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.ClientResponse)
                .WithOne(c => c.Order)
                .HasForeignKey<Order>(o => o.ClientResponseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<QuotationRequest>()
                .HasOne(o => o.User)
                .WithMany(u => u.QuotationRequests)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<QuotationRequest>()
                .HasOne(o => o.EventCategory)
                .WithMany(e => e.QuotationRequests)
                .HasForeignKey(o => o.EventCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<QuotationResponse>()
                .HasOne(q => q.QuotationRequest)
                .WithOne(q => q.QuotationResponse)
                .HasForeignKey<QuotationResponse>(q => q.QuotationRequestId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Refund>()
                .HasOne(r => r.Order)
                .WithMany(o => o.Refunds)
                .HasForeignKey(r => r.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.ClientResponse)
                .WithOne(c => c.Review)
                .HasForeignKey<Review>(r => r.ClientResponseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r=>r.EventCategory)
                .WithMany(e=>e.Reviews)
                .HasForeignKey(r=>r.EventCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u=>u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ScheduledEvent>()
                .HasOne(s=>s.EventCategory)
                .WithMany(e=>e.ScheduledEvents)
                .HasForeignKey(s=>s.EventCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ScheduledEvent>()
                .HasOne(s => s.ClientResponse)
                .WithOne()
                .HasForeignKey<ScheduledEvent>(s=>s.ClienResponseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ScheduledEvent>()
                .HasOne(s => s.User)
                .WithMany(u => u.ScheduledEvents)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Order)
                .WithMany(o => o.Transactions)
                .HasForeignKey(t => t.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserCredential>()
                .HasOne(u=>u.User)
                .WithOne(u=>u.UserCredential)
                .HasForeignKey<UserCredential>(u=>u.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // For converting enum to string (int by default)
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var enumProperties = entityType.ClrType.GetProperties()
                    .Where(p => p.PropertyType.IsEnum);

                foreach (var property in enumProperties)
                {
                    modelBuilder.Entity(entityType.Name)
                        .Property(property.Name)
                        .HasConversion<string>();
                }
            }

            (User adminUser, UserCredential adminUserCredential) = CreateAdminUser();
            modelBuilder.Entity<User>().HasData(adminUser);
            modelBuilder.Entity<UserCredential>().HasData(adminUserCredential);

            base.OnModelCreating(modelBuilder);
        }

        private (User, UserCredential) CreateAdminUser()
        {
            User admin = new User();
            UserCredential credential = new UserCredential();
            HMACSHA512 hMACSHA = new HMACSHA512();
            credential.HashKey = hMACSHA.Key;
            credential.HashedPassword = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes("admin@1289"));
            credential.Role = UserType.Admin;
            credential.UserId = 1;
            credential.UserCredentialId = 1;
            admin.UserId = 1;
            admin.FullName = "Book My Event";
            admin.Email = "admin@bookmyevent.in";
            admin.PhoneNumber = "97343792398";
            return (admin, credential);
        }

    }
}
