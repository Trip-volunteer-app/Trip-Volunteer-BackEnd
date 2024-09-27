using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Trip_Volunteer.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aboutu> Aboutus { get; set; } = null!;
        public virtual DbSet<Bank> Banks { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<ContactU> ContactUs { get; set; } = null!;
        public virtual DbSet<ContactusElement> ContactusElements { get; set; } = null!;
        public virtual DbSet<HomePageElement> HomePageElements { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Testimonial> Testimonials { get; set; } = null!;
        public virtual DbSet<TestimonialElement> TestimonialElements { get; set; } = null!;
        public virtual DbSet<Trip> Trips { get; set; } = null!;
        public virtual DbSet<TripImage> TripImages { get; set; } = null!;
        public virtual DbSet<TripService> TripServices { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserLogin> UserLogins { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<Volunteer> Volunteers { get; set; } = null!;
        public virtual DbSet<VolunteerRole> VolunteerRoles { get; set; } = null!;
        public virtual DbSet<WebsiteInformation> WebsiteInformations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=C##TRIP;PASSWORD=Test321;DATA SOURCE=localhost:1521/xe");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##TRIP")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Aboutu>(entity =>
            {
                entity.HasKey(e => e.AboutusPageId)
                    .HasName("SYS_C008461");

                entity.ToTable("ABOUTUS");

                entity.Property(e => e.AboutusPageId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ABOUTUS_PAGE_ID");

                entity.Property(e => e.Image1)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE1");

                entity.Property(e => e.Image2)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE2");

                entity.Property(e => e.Text1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TEXT1");

                entity.Property(e => e.Text2)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TEXT2");
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.ToTable("BANK");

                entity.Property(e => e.BankId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BANK_ID");

                entity.Property(e => e.Balance)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BALANCE");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CARD_NUMBER");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CVV");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRATION_DATE");

                entity.Property(e => e.FullName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FULL_NAME");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("BOOKING");

                entity.Property(e => e.BookingId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BOOKING_ID");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_AT")
                    .HasDefaultValueSql("SYSDATE");

                entity.Property(e => e.LoginId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LOGIN_ID");

                entity.Property(e => e.PaymentStatus)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PAYMENT_STATUS")
                    .HasDefaultValueSql("'Not Paid'");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_AMOUNT");

                entity.Property(e => e.TripId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TRIP_ID");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.LoginId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_BOOKING_LOGIN_ID");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.TripId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_BOOKING_TRIPS_ID");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORIES");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_NAME");
            });

            modelBuilder.Entity<ContactU>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("SYS_C008449");

                entity.ToTable("CONTACT_US");

                entity.Property(e => e.ContactId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTACT_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FullName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FULL_NAME");

                entity.Property(e => e.Messages)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGES");

                entity.Property(e => e.Query)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QUERY");
            });

            modelBuilder.Entity<ContactusElement>(entity =>
            {
                entity.HasKey(e => e.ContactusElementsId)
                    .HasName("SYS_C008465");

                entity.ToTable("CONTACTUS_ELEMENTS");

                entity.Property(e => e.ContactusElementsId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTACTUS_ELEMENTS_ID");

                entity.Property(e => e.Image1)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE1");

                entity.Property(e => e.Text1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TEXT1");
            });

            modelBuilder.Entity<HomePageElement>(entity =>
            {
                entity.HasKey(e => e.HomePageId)
                    .HasName("SYS_C008459");

                entity.ToTable("HOME_PAGE_ELEMENTS");

                entity.Property(e => e.HomePageId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("HOME_PAGE_ID");

                entity.Property(e => e.HeroImage)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("HERO_IMAGE");

                entity.Property(e => e.Image1)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE1");

                entity.Property(e => e.Image2)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE2");

                entity.Property(e => e.Image3)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE3");

                entity.Property(e => e.Image4)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE4");

                entity.Property(e => e.Image5)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE5");

                entity.Property(e => e.LogoImage)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("LOGO_IMAGE");

                entity.Property(e => e.LogoText)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("LOGO_TEXT");

                entity.Property(e => e.Text1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TEXT1");

                entity.Property(e => e.Title)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("LOCATION");

                entity.Property(e => e.LocationId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOCATION_ID");

                entity.Property(e => e.DepartureLatitude)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DEPARTURE_LATITUDE");

                entity.Property(e => e.DepartureLocation)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTURE_LOCATION");

                entity.Property(e => e.DepartureLongitude)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DEPARTURE_LONGITUDE");

                entity.Property(e => e.DestinationLatitude)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DESTINATION_LATITUDE");

                entity.Property(e => e.DestinationLocation)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESTINATION_LOCATION");

                entity.Property(e => e.DestinationLongitude)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DESTINATION_LONGITUDE");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("PAYMENTS");

                entity.Property(e => e.Payment_Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PAYMENT_ID");

                entity.Property(e => e.Bank_Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("BANK_ID");

                entity.Property(e => e.Create_At)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_AT")
                    .HasDefaultValueSql("sysdate");

                entity.Property(e => e.Login_Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LOGIN_ID");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRICE");

                entity.Property(e => e.Trip_Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TRIP_ID");

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.Bank_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_PAYMENTS_BANK_ID");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.Login_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_PAYMENTS_LOGIN_ID");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.Trip_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_PAYMENTS_TRIP_ID");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("REVIEW");

                entity.Property(e => e.ReviewId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("REVIEW_ID");

                entity.Property(e => e.BookingId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("BOOKING_ID");

                entity.Property(e => e.CreateAt)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_AT")
                    .HasDefaultValueSql("SYSDATE");

                entity.Property(e => e.Feedback)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("FEEDBACK");

                entity.Property(e => e.Rate)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RATE");

                entity.Property(e => e.VolunteerId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("VOLUNTEER_ID");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_REVIEW_BOOKING_ID");

                entity.HasOne(d => d.Volunteer)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.VolunteerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_REVIEW_VOLUNTEER_ID");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("SERVICE");

                entity.Property(e => e.ServiceId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SERVICE_ID");

                entity.Property(e => e.ServiceCost)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SERVICE_COST");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SERVICE_NAME");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.ToTable("TESTIMONIAL");

                entity.Property(e => e.Testimonial_Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIAL_ID");

                entity.Property(e => e.Case)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CASE");

                entity.Property(e => e.Create_At)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_AT")
                    .HasDefaultValueSql("sysdate");

                entity.Property(e => e.Feedback)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("FEEDBACK");

                entity.Property(e => e.Login_Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LOGIN_ID");

                entity.Property(e => e.Rating)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RATING");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("'pending' ");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.Login_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TESTIMONIAL_LOGIN_ID");
            });

            modelBuilder.Entity<TestimonialElement>(entity =>
            {
                entity.HasKey(e => e.TestimonialElementsId)
                    .HasName("SYS_C008463");

                entity.ToTable("TESTIMONIAL_ELEMENTS");

                entity.Property(e => e.TestimonialElementsId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIAL_ELEMENTS_ID");

                entity.Property(e => e.Image1)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE1");

                entity.Property(e => e.Text1)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TEXT1");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ToTable("TRIPS");

                entity.Property(e => e.TripId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TRIP_ID");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.EndDate)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.MaxNumberOfUsers)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MAX_NUMBER_OF_USERS");

                entity.Property(e => e.MaxNumberOfVolunteers)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MAX_NUMBER_OF_VOLUNTEERS");

                entity.Property(e => e.StartDate)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.TripLocationId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TRIP_LOCATION_ID");

                entity.Property(e => e.TripName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TRIP_NAME");

                entity.Property(e => e.TripPrice)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TRIP_PRICE");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TRIPS_CATEGORY_ID");

                entity.HasOne(d => d.TripLocation)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.TripLocationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TRIPS_LOCATION_ID");
            });

            modelBuilder.Entity<TripImage>(entity =>
            {
                entity.ToTable("TRIP_IMAGE");

                entity.Property(e => e.TripImageId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TRIP_IMAGE_ID");

                entity.Property(e => e.ImageName)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_NAME");

                entity.Property(e => e.TripId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TRIP_ID");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.TripImages)
                    .HasForeignKey(d => d.TripId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TRIP_IMAGE_TRIP_ID");
            });

            modelBuilder.Entity<TripService>(entity =>
            {
                entity.ToTable("TRIP_SERVICE");

                entity.Property(e => e.TripServiceId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TRIP_SERVICE_ID");

                entity.Property(e => e.ServiceId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SERVICE_ID");

                entity.Property(e => e.TripId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TRIP_ID");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.TripServices)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TRIP_SERVICE_SERVICE_ID");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.TripServices)
                    .HasForeignKey(d => d.TripId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TRIP_SERVICE_TRIP_ID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USER_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("DATE")
                    .HasColumnName("BIRTH_DATE");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.LastName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.LoginId)
                    .HasName("SYS_C008401");

                entity.ToTable("USER_LOGIN");

                entity.HasIndex(e => e.Email, "SYS_C008402")
                    .IsUnique();

                entity.Property(e => e.LoginId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOGIN_ID");

                entity.Property(e => e.DateRegister)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_REGISTER")
                    .HasDefaultValueSql("SYSDATE");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Repassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REPASSWORD");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_USER_LOGIN_USER_ROLE_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_USER_LOGIN_USERS_ID");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("SYS_C008393");

                entity.ToTable("USER_ROLE");

                entity.HasIndex(e => e.RoleName, "SYS_C008394")
                    .IsUnique();

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");
            });

            modelBuilder.Entity<Volunteer>(entity =>
            {
                entity.ToTable("VOLUNTEERS");

                entity.Property(e => e.Volunteer_Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("VOLUNTEER_ID");

                entity.Property(e => e.Date_Applied)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_APPLIED")
                    .HasDefaultValueSql("SYSDATE");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Emergency_Contact)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMERGENCY_CONTACT");

                entity.Property(e => e.Experience)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("EXPERIENCE");

                entity.Property(e => e.Login_Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LOGIN_ID");

                entity.Property(e => e.Notes)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NOTES");

                entity.Property(e => e.Phone_Number)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("'pending'");

                entity.Property(e => e.Trip_Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TRIP_ID");

                entity.Property(e => e.Volunteer_Role_Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("VOLUNTEER_ROLE_ID");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Volunteers)
                    .HasForeignKey(d => d.Login_Id)
                    .HasConstraintName("FK_VOLUNTEERS_LOGIN");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Volunteers)
                    .HasForeignKey(d => d.Trip_Id)
                    .HasConstraintName("FK_VOLUNTEERS_TRIPS");

                entity.HasOne(d => d.VolunteerRole)
                    .WithMany(p => p.Volunteers)
                    .HasForeignKey(d => d.Volunteer_Role_Id)
                    .HasConstraintName("FK_VOLUNTEERS_VOLUNTEER_ROLE");
            });

            modelBuilder.Entity<VolunteerRole>(entity =>
            {
                entity.ToTable("VOLUNTEER_ROLES");

                entity.Property(e => e.Volunteer_Role_Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("VOLUNTEER_ROLE_ID");

                entity.Property(e => e.Role_Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");

                entity.Property(e => e.Trip_Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TRIP_ID");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.VolunteerRoles)
                    .HasForeignKey(d => d.Trip_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_VOLUNTEER_ROLES_TRIP_ID");
            });

            modelBuilder.Entity<WebsiteInformation>(entity =>
            {
                entity.HasKey(e => e.WebsiteId)
                    .HasName("SYS_C008451");

                entity.ToTable("WEBSITE_INFORMATION");

                entity.Property(e => e.WebsiteId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("WEBSITE_ID");

                entity.Property(e => e.Adress)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ADRESS");

                entity.Property(e => e.ClosingTime)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CLOSING_TIME");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.OpenTime)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("OPEN_TIME");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
