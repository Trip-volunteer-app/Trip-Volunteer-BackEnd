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
