using Trip_Volunteer.Core.Common;
<<<<<<< HEAD
=======
using Trip_Volunteer.Core.Data;
>>>>>>> 0055f59c3d83a49482bffae8a5728055883a98d9
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
<<<<<<< HEAD
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IVolunteerRolesRepository, VolunteerRolesRepository>();
builder.Services.AddScoped<IVolunteersRepository, VolunteersRepository>();
builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();



builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IVolunteerRolesService, VolunteerRolesService>();
builder.Services.AddScoped<IVolunteersService, VolunteersService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();


ITestimonialService
=======
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

>>>>>>> 0055f59c3d83a49482bffae8a5728055883a98d9


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
