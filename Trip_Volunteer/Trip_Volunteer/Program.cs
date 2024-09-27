using Trip_Volunteer.Core.Common;
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

builder.Services.AddScoped<IBankService, BankService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IcategoriesService, categoriesService>();
builder.Services.AddScoped<IContactusElementService, ContactusElementService>();
builder.Services.AddScoped<IContactUsService, ContactUsService>();
builder.Services.AddScoped<ILocationService, LocationService>();
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











builder.Services.AddScoped<IWebsiteInformationRepository, WebsiteInformationRepository>();
builder.Services.AddScoped<IWebsiteInformationService, WebsiteInformationService>();










var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
