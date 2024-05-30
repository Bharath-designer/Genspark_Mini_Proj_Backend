
using System.Security.Cryptography;
using System.Text;
using EventManagementApp.Context;
using EventManagementApp.Enums;
using EventManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementTest
{
    class TestDBContext : EventManagementDBContext
    {
        public TestDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public static DbContextOptions<TestDBContext> GetInMemoryOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestDBContext>();
            optionsBuilder.UseInMemoryDatabase("EventManagementDB");
            return optionsBuilder.Options;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            (User user1, UserCredential userCred1) = CreateUser(2, "user@gmail.com");
            modelBuilder.Entity<User>()
                .HasData(user1);
            modelBuilder.Entity<UserCredential>()
                .HasData(userCred1);

            modelBuilder.Entity<EventCategory>()
                .HasData(
                    new EventCategory
                    {
                        EventCategoryId = 1,
                        EventName = "Testing Event",
                        Description = "Testing Description",
                        CreatedDate = DateTime.Now,
                        IsActive = true
                    }
                );

            #region Inactive EventCategory
            modelBuilder.Entity<EventCategory>()
                .HasData(
                    new EventCategory
                    {
                        EventCategoryId = 2,
                        EventName = "Testing Event",
                        Description = "Testing Description",
                        CreatedDate = DateTime.Now,
                        IsActive = false
                    }
                );
            #endregion

            #region Data for Creating ClientResponse

            modelBuilder.Entity<QuotationRequest>()
                .HasData(
                    new QuotationRequest
                    {
                        QuotationRequestId = 1,
                        EventCategoryId = 1,
                        VenueType = VenueType.PrivateVenue,
                        LocationDetails = "Testing location",
                        FoodPreference = FoodPreference.NoFood,
                        SpecialInstructions = "Special Instructions",
                        EventStartDate = DateTime.Parse("2025-06-27T03:18:23.396Z"),
                        EventEndDate = DateTime.Parse("2025-06-28T03:18:23.396Z"),
                        UserId = 2,
                        RequestDate = DateTime.Now,
                        QuotationStatus = QuotationStatus.Responded
                    }
                );


            modelBuilder.Entity<QuotationResponse>()
                .HasData(
                    new QuotationResponse
                    {
                        QuotationResponseId = 1,
                        QuotationRequestId = 1,
                        RequestStatus = RequestStatus.Accepted,
                        QuotedAmount = 1000,
                        Currency = Currency.INR,
                        ResponseMessage = "sample message",
                        ResponseDate = DateTime.Now
                    }
                );

            #endregion

            #region Data that throw RequestNotApprovedException
            modelBuilder.Entity<QuotationRequest>()
                .HasData(
                    new QuotationRequest
                    {
                        QuotationRequestId = 2,
                        EventCategoryId = 1,
                        VenueType = VenueType.PrivateVenue,
                        LocationDetails = "Testing location",
                        FoodPreference = FoodPreference.NoFood,
                        SpecialInstructions = "Special Instructions",
                        EventStartDate = DateTime.Parse("2025-06-27T03:18:23.396Z"),
                        EventEndDate = DateTime.Parse("2025-06-28T03:18:23.396Z"),
                        UserId = 2,
                        RequestDate = DateTime.Now,
                        QuotationStatus = QuotationStatus.Responded
                    }
                );


            modelBuilder.Entity<QuotationResponse>()
                .HasData(
                    new QuotationResponse
                    {
                        QuotationResponseId = 2,
                        QuotationRequestId = 2,
                        RequestStatus = RequestStatus.Denied,
                        QuotedAmount = null,
                        ResponseMessage = "sample message",
                        ResponseDate = DateTime.Now
                    }
                );
            #endregion

            #region Data that throw ClientAlreadyRespondedException
            modelBuilder.Entity<QuotationRequest>()
                .HasData(
                    new QuotationRequest
                    {
                        QuotationRequestId = 3,
                        EventCategoryId = 1,
                        VenueType = VenueType.PrivateVenue,
                        LocationDetails = "Testing location",
                        FoodPreference = FoodPreference.NoFood,
                        SpecialInstructions = "Special Instructions",
                        EventStartDate = DateTime.Parse("2025-06-27T03:18:23.396Z"),
                        EventEndDate = DateTime.Parse("2025-06-28T03:18:23.396Z"),
                        UserId = 2,
                        RequestDate = DateTime.Now,
                        QuotationStatus = QuotationStatus.Responded
                    }
                );


            modelBuilder.Entity<QuotationResponse>()
                .HasData(
                    new QuotationResponse
                    {
                        QuotationResponseId = 3,
                        QuotationRequestId = 3,
                        RequestStatus = RequestStatus.Accepted,
                        QuotedAmount = null,
                        ResponseMessage = "sample message",
                        ResponseDate = DateTime.Now
                    }
                );



            modelBuilder.Entity<ClientResponse>()
                .HasData(
                        new ClientResponse
                        {
                            ClientDecision = ClientDecision.Accepted,
                            ClientResponseId = 1,
                            ClientResponseDate = DateTime.Now,
                            QuotationResponseId = 3
                        }
                );
            #endregion

            #region Data for Creating QuotationResponse
            modelBuilder.Entity<QuotationRequest>()
               .HasData(
                   new QuotationRequest
                   {
                       QuotationRequestId = 4,
                       EventCategoryId = 1,
                       VenueType = VenueType.PrivateVenue,
                       LocationDetails = "Testing location",
                       FoodPreference = FoodPreference.NoFood,
                       SpecialInstructions = "Special Instructions",
                       EventStartDate = DateTime.Parse("2025-06-27T03:18:23.396Z"),
                       EventEndDate = DateTime.Parse("2025-06-28T03:18:23.396Z"),
                       UserId = 2,
                       RequestDate = DateTime.Now,
                       QuotationStatus = QuotationStatus.Initiated
                   }
               );

            #endregion

            #region Data for marking ScheduledEvent completed

            modelBuilder.Entity<ScheduledEvent>()
                .HasData(
                    new ScheduledEvent
                    {
                        ScheduledEventId = 1,
                        ClienResponseId = 1,
                        EventCategoryId = 1,
                        IsCompleted = false,
                        QuotationRequestId = 1,
                        UserId = 2
                    }
                );
            #endregion

            #region Completed Order

            modelBuilder.Entity<Order>()
                .HasData(
                    new Order
                    {
                        OrderId = 1,
                        ClientResponseId = 1,
                        EventCategoryId = 1,
                        OrderDate = DateTime.Now,
                        UserId = 2,
                        TotalAmount = 1000,
                        Currency = Currency.INR,
                        OrderStatus = OrderStatus.Completed
                    }
                );

            #endregion

            #region Completed ScheduledEvent

            modelBuilder.Entity<QuotationRequest>()
                .HasData(
                    new QuotationRequest
                    {
                        QuotationRequestId = 5,
                        EventCategoryId = 1,
                        VenueType = VenueType.PrivateVenue,
                        LocationDetails = "Testing location",
                        FoodPreference = FoodPreference.NoFood,
                        SpecialInstructions = "Special Instructions",
                        EventStartDate = DateTime.Parse("2025-06-27T03:18:23.396Z"),
                        EventEndDate = DateTime.Parse("2025-06-28T03:18:23.396Z"),
                        UserId = 2,
                        RequestDate = DateTime.Now,
                        QuotationStatus = QuotationStatus.Responded
                    }
                );


            modelBuilder.Entity<QuotationResponse>()
                .HasData(
                    new QuotationResponse
                    {
                        QuotationResponseId = 4,
                        QuotationRequestId = 5,
                        RequestStatus = RequestStatus.Accepted,
                        QuotedAmount = null,
                        ResponseMessage = "sample message",
                        ResponseDate = DateTime.Now
                    }
                );



            modelBuilder.Entity<ClientResponse>()
                .HasData(
                        new ClientResponse
                        {
                            ClientDecision = ClientDecision.Accepted,
                            ClientResponseId = 2,
                            ClientResponseDate = DateTime.Now,
                            QuotationResponseId = 4
                        }
                );

            modelBuilder.Entity<Order>()
                .HasData(
                    new Order
                    {
                        OrderId = 2,
                        EventCategoryId = 1,
                        UserId = 2,
                        ClientResponseId = 2,
                        OrderStatus = OrderStatus.Completed,
                        OrderDate = DateTime.Now,
                        Currency = Currency.INR,
                        TotalAmount = 1000
                    }
                );


            modelBuilder.Entity<ScheduledEvent>()
                .HasData(
                    new ScheduledEvent
                    {
                        ScheduledEventId = 2,
                        EventCategoryId = 1,
                        UserId = 2,
                        ClienResponseId = 2,
                        IsCompleted = true,
                        QuotationRequestId = 5
                    }
                );


            #endregion

            #region Incompleted Payment
            modelBuilder.Entity<QuotationRequest>()
               .HasData(
                   new QuotationRequest
                   {
                       QuotationRequestId = 6,
                       EventCategoryId = 1,
                       VenueType = VenueType.PrivateVenue,
                       LocationDetails = "Testing location",
                       FoodPreference = FoodPreference.NoFood,
                       SpecialInstructions = "Special Instructions",
                       EventStartDate = DateTime.Parse("2025-06-27T03:18:23.396Z"),
                       EventEndDate = DateTime.Parse("2025-06-28T03:18:23.396Z"),
                       UserId = 2,
                       RequestDate = DateTime.Now,
                       QuotationStatus = QuotationStatus.Responded
                   }
               );


            modelBuilder.Entity<QuotationResponse>()
                .HasData(
                    new QuotationResponse
                    {
                        QuotationResponseId = 5,
                        QuotationRequestId = 6,
                        RequestStatus = RequestStatus.Accepted,
                        QuotedAmount = null,
                        ResponseMessage = "sample message",
                        ResponseDate = DateTime.Now
                    }
                );



            modelBuilder.Entity<ClientResponse>()
                .HasData(
                        new ClientResponse
                        {
                            ClientDecision = ClientDecision.Accepted,
                            ClientResponseId = 3,
                            ClientResponseDate = DateTime.Now,
                            QuotationResponseId = 5
                        }
                );

            modelBuilder.Entity<Order>()
                .HasData(
                    new Order
                    {
                        OrderId = 3,
                        EventCategoryId = 1,
                        UserId = 2,
                        ClientResponseId = 3,
                        OrderStatus = OrderStatus.Pending,
                        OrderDate = DateTime.Now,
                        TotalAmount = 1000,
                        Currency = Currency.INR
                    }
                );

            modelBuilder.Entity<Transaction>()
                .HasData(
                    new Transaction
                    {
                        TransactionId = "1d431806-1830-41d7-befa-e2a9d7053896",
                        Amount = 10000,
                        Currency = Currency.INR,
                        OrderId = 3,
                        PaymentDate = DateTime.Now,
                        PaymentStatus = PaymentStatus.Pending,
                        PaymentURL = "http://localhost:3000/payment/1d431806-1830-41d7-befa-e2a9d7053896"
                    }
                );

            #endregion

            #region Notification
            modelBuilder.Entity<Notification>()
                .HasData(
                    new Notification
                    {
                        NotificationId=1,
                        Message = "Message",
                        SourceURL = "URL",
                        UserId = 2
                    }
                );
            #endregion

            base.OnModelCreating(modelBuilder);
        }

        private (User, UserCredential) CreateUser(int userId, string email)
        {
            User admin = new User();
            UserCredential credential = new UserCredential();
            HMACSHA512 hMACSHA = new HMACSHA512();
            credential.HashKey = hMACSHA.Key;
            credential.HashedPassword = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes("1234"));
            credential.Role = UserType.User;
            credential.UserId = userId;
            credential.UserCredentialId = userId;
            admin.UserId = userId;
            admin.FullName = "Book My Event";
            admin.Email = email;
            admin.PhoneNumber = "97343792398";
            return (admin, credential);
        }
    }
}
