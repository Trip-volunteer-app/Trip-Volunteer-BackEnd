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
        public virtual DbSet<TripVolunteerrole> TripVolunteerroles { get; set; } = null!;
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
                optionsBuilder.UseOracle("User Id=C##TRIP;PASSWORD=Test321;DATA SOURCE=localhost:1521/xe");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##TRIP")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Aboutu>(entity =>
            {
                entity.ToTable("ABOUTUS");

                entity.Property(e => e.Aboutus_Page_Id)
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

                entity.Property(e => e.Bank_Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BANK_ID");

                entity.Property(e => e.Balance)
                    .HasColumnType("NUMBER")
                    .HasColumnName("BALANCE");

                entity.Property(e => e.Card_Number)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CARD_NUMBER");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CVV");

                entity.Property(e => e.Expiration_Date)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRATION_DATE");

                entity.Property(e => e.Full_Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FULL_NAME");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("BOOKING");

                entity.Property(e => e.Booking_Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BOOKING_ID");

                entity.Property(e => e.Create_At)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATE_AT")
                    .HasDefaultValueSql("SYSDATE");

                entity.Property(e => e.Login_Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("LOGIN_ID");

                entity.Property(e => e.Payment_Status)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PAYMENT_STATUS")
                    .HasDefaultValueSql("'Not Paid'");

                entity.Property(e => e.Total_Amount)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TOTAL_AMOUNT");

                entity.Property(e => e.Trip_Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TRIP_ID");

                entity.HasOne(d => d.Login)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.Login_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_BOOKING_LOGIN_ID");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.Trip_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_BOOKING_TRIPS_ID");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORIES");

                entity.Property(e => e.Category_Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.Category_Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_NAME");
            });

            modelBuilder.Entity<ContactU>(entity =>
            {
                entity.ToTable("CONTACT_US");

                entity.Property(e => e.Contact_Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTACT_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Full_Name)
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
                entity.ToTable("CONTACTUS_ELEMENTS");
                entity.Property(e => e.Contactus_Elements_Id)
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
                entity.ToTable("HOME_PAGE_ELEMENTS");

                entity.Property(e => e.Home_Page_Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("HOME_PAGE_ID");

                entity.Property(e => e.Hero_Image)
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

                entity.Property(e => e.Logo_Image)
                    .HasMaxLength(600)
                    .IsUnicode(false)
                    .HasColumnName("LOGO_IMAGE");

                entity.Property(e => e.Logo_Text)
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

                entity.Property(e => e.Location_Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOCATION_ID");

                entity.Property(e => e.Departure_Latitude)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DEPARTURE_LATITUDE");

                entity.Property(e => e.Departure_Location)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTURE_LOCATION");

                entity.Property(e => e.Departure_Longitude)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DEPARTURE_LONGITUDE");

                entity.Property(e => e.Destination_Latitude)
                    .HasColumnType("NUMBER")
                    .HasColumnName("DESTINATION_LATITUDE");

                entity.Property(e => e.Destination_Location)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESTINATION_LOCATION");

                entity.Property(e => e.Destination_Longitude)
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

                entity.Property(e => e.Review_Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("REVIEW_ID");

                entity.Property(e => e.Booking_Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("BOOKING_ID");

                entity.Property(e => e.Create_At)
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

                entity.Property(e => e.Volunteer_Id)
                    .HasColumnType("NUMBER")
                    .HasColumnName("VOLUNTEER_ID");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Booking_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_REVIEW_BOOKING_ID");

                entity.HasOne(d => d.Volunteer)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.Volunteer_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_REVIEW_VOLUNTEER_ID");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("SERVICE");

                entity.Property(e => e.Service_Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SERVICE_ID");

                entity.Property(e => e.Service_Cost)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SERVICE_COST");

                entity.Property(e => e.Service_Name)
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
                entity.ToTable("TESTIMONIAL_ELEMENTS");

                entity.Property(e => e.Testimonial_Elements_Id)
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

                entity.Property(e => e.Trip_Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TRIP_ID");

                entity.Property(e => e.Category_Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.End_Date)
                    .HasColumnType("DATE")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.Max_Number_Of_Users)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MAX_NUMBER_OF_USERS");

                entity.Property(e => e.Max_Number_Of_Volunteers)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MAX_NUMBER_OF_VOLUNTEERS");

                entity.Property(e => e.Start_Date)
                    .HasColumnType("DATE")
                    .HasColumnName("START_DATE");

                entity.Property(e => e.Trip_Location_Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TRIP_LOCATION_ID");

                entity.Property(e => e.Trip_Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TRIP_NAME");

                entity.Property(e => e.Trip_Price)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TRIP_PRICE");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.Category_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TRIPS_CATEGORY_ID");

                entity.HasOne(d => d.TripLocation)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.Trip_Location_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TRIPS_LOCATION_ID");
            });

            modelBuilder.Entity<TripImage>(entity =>
            {
                entity.ToTable("TRIP_IMAGE");

                entity.Property(e => e.Trip_Image_Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TRIP_IMAGE_ID");

                entity.Property(e => e.Image_Name)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_NAME");

                entity.Property(e => e.Trip_Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TRIP_ID");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.TripImages)
                    .HasForeignKey(d => d.Trip_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TRIP_IMAGE_TRIP_ID");
            });

            modelBuilder.Entity<TripService>(entity =>
            {
                entity.ToTable("TRIP_SERVICE");

                entity.Property(e => e.Trip_Service_Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TRIP_SERVICE_ID");

                entity.Property(e => e.Service_Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SERVICE_ID");

                entity.Property(e => e.Trip_Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TRIP_ID");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.TripServices)
                    .HasForeignKey(d => d.Service_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TRIP_SERVICE_SERVICE_ID");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.TripServices)
                    .HasForeignKey(d => d.Trip_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TRIP_SERVICE_TRIP_ID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.User_Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USER_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.Birth_Date)
                    .HasColumnType("DATE")
                    .HasColumnName("BIRTH_DATE");

                entity.Property(e => e.First_Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.Image_Path)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Last_Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.Phone_Number)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.ToTable("USER_LOGIN");

                entity.HasIndex(e => e.Email, "SYS_C009322")
                    .IsUnique();

                entity.Property(e => e.Login_Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOGIN_ID");

                entity.Property(e => e.Date_Register)
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

                entity.Property(e => e.Role_Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.User_Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.Role_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_USER_LOGIN_USER_ROLE_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.User_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_USER_LOGIN_USERS_ID");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("USER_ROLE");
                entity.HasIndex(e => e.Role_Name, "SYS_C009314")
                    .IsUnique();

                entity.Property(e => e.Role_Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.Role_Name)
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
                    .HasForeignKey(d => d.Volunteer_Id)
                    .HasConstraintName("FK_VOLUNTEERS_VOLUNTEER_ROLE");
            });

            modelBuilder.Entity<TripVolunteerrole>(entity =>
            {
                entity.HasKey(e => e.Trip_Volunteerroles_Id)
                    .HasName("SYS_C009389");

                entity.ToTable("TRIP_VOLUNTEERROLES");

                entity.Property(e => e.Trip_Volunteerroles_Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TRIP_VOLUNTEERROLES_ID");

                entity.Property(e => e.Trip_Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("TRIP_ID");

                entity.Property(e => e.Volunteer_Role_Id)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("VOLUNTEER_ROLE_ID");

                entity.HasOne(d => d.Trip)
                    .WithMany(p => p.TripVolunteerroles)
                    .HasForeignKey(d => d.Trip_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TRIP_VOLUNTEERROLES_ID");

                entity.HasOne(d => d.VolunteerRole)
                    .WithMany(p => p.TripVolunteerroles)
                    .HasForeignKey(d => d.Volunteer_Role_Id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TRIP_VOLUNTEER_ROLES_ID");
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
            });
            modelBuilder.Entity<WebsiteInformation>(entity =>
            {
                entity.HasKey(e => e.Website_Id)
                    .HasName("SYS_C009372");

                entity.ToTable("WEBSITE_INFORMATION");

                entity.Property(e => e.Website_Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("WEBSITE_ID");

                entity.Property(e => e.Adress)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ADRESS");

                entity.Property(e => e.Closing_Time)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CLOSING_TIME");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Open_Time)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("OPEN_TIME");

                entity.Property(e => e.Phone_Number)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NUMBER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}