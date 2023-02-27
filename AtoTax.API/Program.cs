
using AtoTax.API.Authentication;
using AtoTax.API.GenericRepository;
using AtoTax.API.Mapping;
using AtoTax.API.Repository.Interfaces;
using AtoTax.API.Repository.Repos;
using AtoTax.API.Authentication;
using AtoTaxAPI.Data;
using EmailService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Configuration;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using Prometheus;
using Hangfire;
using Hangfire.MemoryStorage;

var builder = WebApplication.CreateBuilder(args);


//serilog
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
var _loggerconf = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext()
    //.MinimumLevel.Information()
    //.WriteTo.File("AtoTax-.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();


builder.Services.AddHangfire(c => c.UseMemoryStorage());
builder.Services.AddHangfireServer();
builder.Logging.AddSerilog(_loggerconf);


//flyiopostgres
//PostgreSQLInLocalAppInContainer
//137.66.10.59
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddDbContextPool<AtoTaxDbContext>(options => options.UseNpgsql(
                                            builder.Configuration.GetConnectionString("digitalOceanPostgres")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
    options =>
    {
        options.User.AllowedUserNameCharacters= "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 4;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    })
                .AddEntityFrameworkStores<AtoTaxDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);

builder.Services.AddResponseCaching();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IGSTClientRepository, GSTClientRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IApprovalStatusTypeRepository, ApprovalStatusTypeRepository>();
builder.Services.AddScoped<IMultimediaTypeRepository, MultimediaTypeRepository>();
builder.Services.AddScoped<IAddressTypeRepository, AddressTypeRepository>();
builder.Services.AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>();

builder.Services.AddScoped<ICollectionAndBalanceRepository, CollectionAndBalanceRepository>();
builder.Services.AddScoped<IAccountLedgerRepository, AccountLedgerRepository>();
builder.Services.AddScoped<IServiceChargeUpdateHistoryRepository, ServiceChargeUpdateHistoryRepository>();
builder.Services.AddScoped<IUserLoggedActivityRepository, UserLoggedActivityRepository>();
builder.Services.AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmpJobRoleRepository, EmpJobRoleRepository>();
builder.Services.AddScoped<IAmendTypeRepository, AmendTypeRepository>();
builder.Services.AddScoped<IAmendmentRepository, AmendmentRepository>();
builder.Services.AddScoped<IClientFeeMapRepository, ClientFeeMapRepository>();

builder.Services.AddScoped<IGSTFilingTypeRepository, GSTFilingTypeRepository>();
builder.Services.AddScoped<IGSTClientAddressExtensionRepository, GSTClientAddressExtensionRepository>();
builder.Services.AddScoped<IGSTBillAndFeeCollectionRepository, GSTBillAndFeeCollectionRepository>();
builder.Services.AddScoped<IGSTPaidDetailRepository, GSTPaidDetailRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opts => {
    opts.RequireHttpsMetadata = false;
    opts.SaveToken = true;

    opts.TokenValidationParameters = new TokenValidationParameters
    {

    
        //ValidateLifetime = true,
        //ValidateIssuerSigningKey = true,


        //ValidIssuer = "https://localhost:5000",
        //ValidAudience = "https://localhost:5000",



        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetValue<string>("ApiSettings:Secret")))
        
    };
});

builder.Services.AddCors(options =>
               options.AddPolicy("AtoTaxCorsPolicy", builder =>
               {
                   builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
               }
               ));

//email service
builder.Services.AddSingleton(builder.Configuration.GetSection("EmailConfiguration").Get<EmailDto>());
builder.Services.AddScoped<IEmailSender, EmailSender>();

//for file upload from Front-End Application "FORM"
builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

// Add services to the container.
//adding caching profile for optimized memory use
builder.Services.AddControllers(option =>
{
    option.CacheProfiles.Add("Default30", new CacheProfile() { Duration = 30 });

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n" +
        "Enter 'Bearer' (space) and then your token in the text input below \r\n\r\n" +
        "Example: \"Bearer 1234567889 \"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"

    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });





});

var app = builder.Build();

IWebHostEnvironment env = app.Environment;


// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.UseMetricServer(); //add before app.UseEndPoints
app.UseCors("AtoTaxCorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication(); //add before MVC
app.UseAuthorization();

app.MapControllers();

app.UseHangfireDashboard();
app.MapHangfireDashboard();
RecurringJob.AddOrUpdate<ICollectionAndBalanceRepository>(x => x.SyncDataAsync(), Cron.Hourly);

//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, @"Images")),
//    RequestPath = "/app/Images"
//    //RequestPath = Path.DirectorySeparatorChar + "app" + Path.DirectorySeparatorChar + "Images"
//});
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, @"Reportdocs")),
//    RequestPath = "/app/Reportdocs"
//    //RequestPath = Path.DirectorySeparatorChar + "app" + Path.DirectorySeparatorChar + "Reportdocs"
//});

app.Run();
