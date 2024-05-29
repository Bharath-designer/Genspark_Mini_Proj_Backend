﻿// <auto-generated />
using System;
using EventManagementApp.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventManagementApp.Migrations
{
    [DbContext(typeof(EventManagementDBContext))]
    [Migration("20240528161940_RatingAddeddd")]
    partial class RatingAddeddd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventManagementApp.Models.ClientResponse", b =>
                {
                    b.Property<int>("ClientResponseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientResponseId"));

                    b.Property<string>("ClientDecision")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ClientResponseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuotationResponseId")
                        .HasColumnType("int");

                    b.HasKey("ClientResponseId");

                    b.HasIndex("QuotationResponseId")
                        .IsUnique();

                    b.ToTable("ClientResponses");
                });

            modelBuilder.Entity("EventManagementApp.Models.EventCategory", b =>
                {
                    b.Property<int>("EventCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventCategoryId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfRatings")
                        .HasColumnType("int");

                    b.Property<float?>("Rating")
                        .HasColumnType("real");

                    b.Property<int>("TotalRating")
                        .HasColumnType("int");

                    b.HasKey("EventCategoryId");

                    b.ToTable("EventCategories");
                });

            modelBuilder.Entity("EventManagementApp.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int>("ClientResponseId")
                        .HasColumnType("int");

                    b.Property<int>("EventCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("ClientResponseId")
                        .IsUnique();

                    b.HasIndex("EventCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EventManagementApp.Models.QuotationRequest", b =>
                {
                    b.Property<int>("QuotationRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuotationRequestId"));

                    b.Property<string>("CateringInstructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EventEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EventStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FoodPreference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuotationStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SpecialInstructions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("VenueType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuotationRequestId");

                    b.HasIndex("EventCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("QuotationRequests");
                });

            modelBuilder.Entity("EventManagementApp.Models.QuotationResponse", b =>
                {
                    b.Property<int>("QuotationResponseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuotationResponseId"));

                    b.Property<int>("QuotationRequestId")
                        .HasColumnType("int");

                    b.Property<double?>("QuotedAmount")
                        .HasColumnType("float");

                    b.Property<string>("RequestStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ResponseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ResponseMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuotationResponseId");

                    b.HasIndex("QuotationRequestId")
                        .IsUnique();

                    b.ToTable("QuotationResponses");
                });

            modelBuilder.Entity("EventManagementApp.Models.Refund", b =>
                {
                    b.Property<int>("RefundId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RefundId"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("RefundAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("RefundDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefundStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RefundId");

                    b.HasIndex("OrderId");

                    b.ToTable("Refunds");
                });

            modelBuilder.Entity("EventManagementApp.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewId"));

                    b.Property<int>("ClientResponseId")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventCategoryId")
                        .HasColumnType("int");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ReviewId");

                    b.HasIndex("ClientResponseId")
                        .IsUnique();

                    b.HasIndex("EventCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("EventManagementApp.Models.ScheduledEvent", b =>
                {
                    b.Property<int>("ScheduledEventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduledEventId"));

                    b.Property<int>("ClienResponseId")
                        .HasColumnType("int");

                    b.Property<int>("EventCategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("QuotationRequestId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ScheduledEventId");

                    b.HasIndex("ClienResponseId")
                        .IsUnique();

                    b.HasIndex("EventCategoryId");

                    b.HasIndex("QuotationRequestId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("ScheduledEvents");
                });

            modelBuilder.Entity("EventManagementApp.Models.Transaction", b =>
                {
                    b.Property<string>("TransactionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionId");

                    b.HasIndex("OrderId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("EventManagementApp.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            CreatedAt = new DateTime(2024, 5, 28, 21, 49, 40, 277, DateTimeKind.Local).AddTicks(8244),
                            Email = "admin@bookmyevent.in",
                            FullName = "Book My Event",
                            PhoneNumber = "97343792398"
                        });
                });

            modelBuilder.Entity("EventManagementApp.Models.UserCredential", b =>
                {
                    b.Property<int>("UserCredentialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserCredentialId"));

                    b.Property<byte[]>("HashKey")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UserCredentialId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserCredentials");

                    b.HasData(
                        new
                        {
                            UserCredentialId = 1,
                            HashKey = new byte[] { 71, 120, 45, 47, 255, 222, 116, 94, 255, 35, 159, 58, 155, 207, 95, 58, 161, 216, 227, 184, 210, 9, 61, 114, 226, 48, 104, 248, 12, 218, 142, 102, 9, 230, 169, 65, 217, 39, 142, 105, 117, 216, 178, 113, 121, 125, 83, 42, 42, 41, 108, 137, 80, 228, 38, 78, 195, 96, 236, 191, 115, 144, 80, 118, 115, 116, 51, 206, 20, 140, 251, 201, 29, 95, 140, 166, 50, 129, 59, 8, 254, 147, 63, 214, 39, 210, 181, 52, 216, 0, 59, 189, 221, 48, 12, 48, 9, 235, 44, 48, 251, 159, 124, 96, 14, 120, 42, 104, 181, 59, 169, 113, 23, 240, 91, 205, 46, 49, 65, 213, 228, 148, 130, 219, 45, 9, 69, 118 },
                            HashedPassword = new byte[] { 14, 171, 174, 71, 33, 209, 59, 236, 47, 137, 251, 136, 221, 127, 188, 92, 197, 133, 4, 28, 16, 62, 72, 72, 111, 242, 141, 192, 235, 207, 27, 92, 93, 124, 35, 154, 116, 146, 225, 121, 153, 8, 213, 61, 177, 83, 52, 43, 204, 215, 208, 243, 216, 206, 181, 231, 107, 155, 78, 132, 160, 242, 67, 235 },
                            Role = "Admin",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("EventManagementApp.Models.ClientResponse", b =>
                {
                    b.HasOne("EventManagementApp.Models.QuotationResponse", "QuotationResponse")
                        .WithOne("ClientResponse")
                        .HasForeignKey("EventManagementApp.Models.ClientResponse", "QuotationResponseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("QuotationResponse");
                });

            modelBuilder.Entity("EventManagementApp.Models.Order", b =>
                {
                    b.HasOne("EventManagementApp.Models.ClientResponse", "ClientResponse")
                        .WithOne("Order")
                        .HasForeignKey("EventManagementApp.Models.Order", "ClientResponseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EventManagementApp.Models.EventCategory", "EventCategory")
                        .WithMany("Orders")
                        .HasForeignKey("EventCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EventManagementApp.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ClientResponse");

                    b.Navigation("EventCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventManagementApp.Models.QuotationRequest", b =>
                {
                    b.HasOne("EventManagementApp.Models.EventCategory", "EventCategory")
                        .WithMany("QuotationRequests")
                        .HasForeignKey("EventCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EventManagementApp.Models.User", "User")
                        .WithMany("QuotationRequests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EventCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventManagementApp.Models.QuotationResponse", b =>
                {
                    b.HasOne("EventManagementApp.Models.QuotationRequest", "QuotationRequest")
                        .WithOne("QuotationResponse")
                        .HasForeignKey("EventManagementApp.Models.QuotationResponse", "QuotationRequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("QuotationRequest");
                });

            modelBuilder.Entity("EventManagementApp.Models.Refund", b =>
                {
                    b.HasOne("EventManagementApp.Models.Order", "Order")
                        .WithMany("Refunds")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("EventManagementApp.Models.Review", b =>
                {
                    b.HasOne("EventManagementApp.Models.ClientResponse", "ClientResponse")
                        .WithOne("Review")
                        .HasForeignKey("EventManagementApp.Models.Review", "ClientResponseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EventManagementApp.Models.EventCategory", "EventCategory")
                        .WithMany("Reviews")
                        .HasForeignKey("EventCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EventManagementApp.Models.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ClientResponse");

                    b.Navigation("EventCategory");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventManagementApp.Models.ScheduledEvent", b =>
                {
                    b.HasOne("EventManagementApp.Models.ClientResponse", "ClientResponse")
                        .WithOne()
                        .HasForeignKey("EventManagementApp.Models.ScheduledEvent", "ClienResponseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EventManagementApp.Models.EventCategory", "EventCategory")
                        .WithMany("ScheduledEvents")
                        .HasForeignKey("EventCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EventManagementApp.Models.QuotationRequest", "QuotationRequest")
                        .WithOne()
                        .HasForeignKey("EventManagementApp.Models.ScheduledEvent", "QuotationRequestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EventManagementApp.Models.User", "User")
                        .WithMany("ScheduledEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ClientResponse");

                    b.Navigation("EventCategory");

                    b.Navigation("QuotationRequest");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventManagementApp.Models.Transaction", b =>
                {
                    b.HasOne("EventManagementApp.Models.Order", "Order")
                        .WithMany("Transactions")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("EventManagementApp.Models.UserCredential", b =>
                {
                    b.HasOne("EventManagementApp.Models.User", "User")
                        .WithOne("UserCredential")
                        .HasForeignKey("EventManagementApp.Models.UserCredential", "UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EventManagementApp.Models.ClientResponse", b =>
                {
                    b.Navigation("Order")
                        .IsRequired();

                    b.Navigation("Review")
                        .IsRequired();
                });

            modelBuilder.Entity("EventManagementApp.Models.EventCategory", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("QuotationRequests");

                    b.Navigation("Reviews");

                    b.Navigation("ScheduledEvents");
                });

            modelBuilder.Entity("EventManagementApp.Models.Order", b =>
                {
                    b.Navigation("Refunds");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("EventManagementApp.Models.QuotationRequest", b =>
                {
                    b.Navigation("QuotationResponse")
                        .IsRequired();
                });

            modelBuilder.Entity("EventManagementApp.Models.QuotationResponse", b =>
                {
                    b.Navigation("ClientResponse")
                        .IsRequired();
                });

            modelBuilder.Entity("EventManagementApp.Models.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("QuotationRequests");

                    b.Navigation("Reviews");

                    b.Navigation("ScheduledEvents");

                    b.Navigation("UserCredential")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
