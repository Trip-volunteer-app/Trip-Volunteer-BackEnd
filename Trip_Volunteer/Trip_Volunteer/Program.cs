using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Trip_Volunteer.Core.Common;
<<<<<<< HEAD
using Trip_Volunteer.Core.Data;
=======
<<<<<<< HEAD
<<<<<<< HEAD
using Trip_Volunteer.Core.Data;
=======
<<<<<<< HEAD
<<<<<<< HEAD
=======
using Trip_Volunteer.Core.Data;
>>>>>>> 0055f59c3d83a49482bffae8a5728055883a98d9
=======
>>>>>>> 12407fa9651d03d62ac832f1034499c214c00399
>>>>>>> 5eae04a522cc98ebf81749c04e51503c82ca0eea
=======

using Trip_Volunteer.Core.Data;


>>>>>>> de721206ce294c7216656a02c6a85d4340ef3641
>>>>>>> b5a3b4d936aa3eaae13cd35954baf7d00ecce430
using Trip_Volunteer.Core.Repository;
using Trip_Volunteer.Core.Service;
using Trip_Volunteer.Infra.Common;
using Trip_Volunteer.Infra.Repository;
using Trip_Volunteer.Infra.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDbContext, DbContext>();
builder.Services.AddScoped<IBookingRepository,BookingRepository>();
builder.Services.AddScoped<IContactUsRepository,ContactUsRepository>();
builder.Services.AddScoped<IReviewRepository,ReviewRepository>();
builder.Services.AddScoped<IServiceRepository,ServiceRepository>();
builder.Services.AddScoped<ITripServiceRepository,TripServiceRepository>();
builder.Services.AddScoped<IBookingService,BookingService>();
builder.Services.AddScoped<IContactUsService,ContactUsService>();
builder.Services.AddScoped<IReviewService,ReviewService>();
builder.Services.AddScoped<IServicesService,ServicesService>();
builder.Services.AddScoped<ITripServicesService,TripServicesService>();


builder.Services.AddScoped<IDbContext, DbContext>();
<<<<<<< HEAD

=======
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 5eae04a522cc98ebf81749c04e51503c82ca0eea
=======

>>>>>>> de721206ce294c7216656a02c6a85d4340ef3641
>>>>>>> b5a3b4d936aa3eaae13cd35954baf7d00ecce430
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IVolunteerRolesRepository, VolunteerRolesRepository>();
builder.Services.AddScoped<IVolunteersRepository, VolunteersRepository>();
builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();



builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IVolunteerRolesService, VolunteerRolesService>();
builder.Services.AddScoped<IVolunteersService, VolunteersService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();


<<<<<<< HEAD

=======
>>>>>>> b5a3b4d936aa3eaae13cd35954baf7d00ecce430
builder.Services.AddScoped<ILocationRepository, LocationRepository>();
builder.Services.AddScoped<ILocationService, LocationService>();

builder.Services.AddScoped<IcategoriesRepository, categoriesRepository>();
builder.Services.AddScoped<IcategoriesService, categoriesService>();

builder.Services.AddScoped<ITripImageRepository, TripImageRepository>();
builder.Services.AddScoped<ITripImageService, TripImageService>();

builder.Services.AddScoped<ITripsRepository, TripsRepository>();
builder.Services.AddScoped<ITripsService, TripsService>();


builder.Services.AddScoped<IWebsiteInformationRepository, WebsiteInformationRepository>();
builder.Services.AddScoped<IWebsiteInformationService, WebsiteInformationService>();

<<<<<<< HEAD
=======
<<<<<<< HEAD

builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
=======
>>>>>>> de721206ce294c7216656a02c6a85d4340ef3641



>>>>>>> b5a3b4d936aa3eaae13cd35954baf7d00ecce430
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ITestimonialElementRepository, TestimonialElementRepository>();
builder.Services.AddScoped<IContactusElementRepository, ContactusElementRepository>();
builder.Services.AddScoped<IUserLoginRepository, UserLoginRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IBankService, BankService>();
builder.Services.AddScoped<ITestimonialElementService, TestimonialElementService>();
builder.Services.AddScoped<IContactusElementService, ContactusElementService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey@ApiCourse123456"))
    };
});
<<<<<<< HEAD
=======

>>>>>>> b5a3b4d936aa3eaae13cd35954baf7d00ecce430

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

app.MapControllers();

app.Run();
