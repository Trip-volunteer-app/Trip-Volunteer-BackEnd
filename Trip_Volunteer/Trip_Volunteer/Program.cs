using Trip_Volunteer.Core.Common;
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;
using Trip_Volunteer.Infra.Common;
using Trip_Volunteer.Infra.Repository;
using Trip_Volunteer.Infra.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Trip_Volunteer.API.Controllers;
using Microsoft.AspNetCore.Http.Features;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddCors(corsOptions => {
            corsOptions.AddPolicy("policy",
                builder => {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
        });

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IDbContext, DbContext>();

        builder.Services.AddScoped<IBankRepository, BankRepository>();
        builder.Services.AddScoped<IBookingRepository, BookingRepository>();
        builder.Services.AddScoped<IcategoriesRepository, categoriesRepository>();
        builder.Services.AddScoped<IContactusElementRepository, ContactusElementRepository>();
        builder.Services.AddScoped<IContactUsRepository, ContactUsRepository>();
        builder.Services.AddScoped<ILocationRepository, LocationRepository>();
        builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
        builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();
        builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
        builder.Services.AddScoped<ITestimonialElementRepository, TestimonialElementRepository>();
        builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
        builder.Services.AddScoped<ITripImageRepository, TripImageRepository>();
        builder.Services.AddScoped<ITripServiceRepository, TripServiceRepository>();
        builder.Services.AddScoped<ITripsRepository, TripsRepository>();
        builder.Services.AddScoped<IUserLoginRepository, UserLoginRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IVolunteerRolesRepository, VolunteerRolesRepository>();
        builder.Services.AddScoped<IVolunteersRepository, VolunteersRepository>();
        builder.Services.AddScoped<IWebsiteInformationRepository, WebsiteInformationRepository>();
        builder.Services.AddScoped<IHomePageElementsRepository, HomePageElementsRepository>();
        builder.Services.AddScoped<IAboutUsRepository, AboutUsRepository>();
        builder.Services.AddScoped<IMonthlyRepository, MonthlyRepository>();
        builder.Services.AddScoped<IAnnualRepository, AnnualRepository>();
        builder.Services.AddHttpClient<Location_ApiController>(); // Register the HttpClient for the controller
        builder.Services.AddScoped<ITripVolunteerroleRepository, TripVolunteerroleRepository>();
        builder.Services.AddScoped<IBookingServiceRepository, BookingServiceRepository>();
        builder.Services.AddScoped<ICardRepository, CardRepository>();



        builder.Services.AddScoped<IBankService, BankService>();
        builder.Services.AddScoped<IBookingService, BookingService>();
        builder.Services.AddScoped<IcategoriesService, categoriesService>();
        builder.Services.AddScoped<IContactusElementService, ContactusElementService>();
        builder.Services.AddScoped<IContactUsService, ContactUsService>();
        builder.Services.AddScoped<ILocationService, LocationsService>();
        builder.Services.AddScoped<IPaymentService, PaymentService>();
        builder.Services.AddScoped<IReviewService, ReviewService>();
        builder.Services.AddScoped<IRoleService, RoleService>();
        builder.Services.AddScoped<IServicesService, ServicesService>();
        builder.Services.AddScoped<ITestimonialElementService, TestimonialElementService>();
        builder.Services.AddScoped<ITestimonialService, TestimonialService>();
        builder.Services.AddScoped<ITripImageService, TripImageService>();
        builder.Services.AddScoped<ITripServicesService, TripServicesService>();
        builder.Services.AddScoped<ITripsService, TripsService>();
        builder.Services.AddScoped<IUserLoginService, UserLoginService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IVolunteerRolesService, VolunteerRolesService>();
        builder.Services.AddScoped<IVolunteersService, VolunteersService>();
        builder.Services.AddScoped<IWebsiteInformationService, WebsiteInformationService>();
        builder.Services.AddScoped<IHomePageElementsService, HomePageElementsService>();
        builder.Services.AddScoped<IAboutUsService, AboutUsService>();
        builder.Services.AddScoped<IMonthlyService, MonthlyService>();
        builder.Services.AddScoped<IAnnualService, AnnualService>();
        builder.Services.AddScoped<ITripVolunteerroleService, TripVolunteerroleService>();
        builder.Services.AddScoped<IBookingServicesServices, BookingServicesServices>();
        builder.Services.AddScoped<ICardService, CardService>();


        builder.Services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey@ApiCourse123456"))
            };
        });
        builder.Services.AddHttpClient<Location_ApiController>();
        builder.Services.Configure<FormOptions>(options =>
        {
            options.MultipartBodyLengthLimit = 104857600; // Limit to 100 MB, for example
        });

        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();

        app.UseAuthorization();

        app.UseCors("policy");

        app.MapControllers();

        app.Run();
    }
}