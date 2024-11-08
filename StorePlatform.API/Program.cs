using FluentValidation;
using FluentValidation.AspNetCore;
using Karmed.External.Auth.Library;
using Karmed.External.Auth.Library.Filters;
using StorePlatform.Application;
using StorePlatform.Infrastructure;
using StorePlatform.Infrastructure.Filters;
using StorePlatform.Persistence;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
	.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
	.AddEnvironmentVariables()
	.Build();

// Add services to the container.
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

builder.Services.AddExternalAuthServices(builder.Configuration);
builder.Services.AddAuthorization();

builder.Services.AddCors(
  options => options.AddDefaultPolicy(policy =>
	policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().DisallowCredentials()
  )
);

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddControllers(options =>
{
	options.Filters.Add<RolePermissionFilter>();
	options.Filters.Add<ValidationFilter>();
})
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
		options.JsonSerializerOptions.WriteIndented = true;
	})
	.ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(opt =>
{
	// XML yorumlarını dahil edin
	var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
	var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
	opt.IncludeXmlComments(xmlPath);
});

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
	options.SerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.UseCors();
app.Run();
