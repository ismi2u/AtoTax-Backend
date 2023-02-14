
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

var builder = WebApplication.CreateBuilder(args);


//serilog
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
var _loggerconf = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).Enrich.FromLogContext()
    //.MinimumLevel.Information()
    //.WriteTo.File("AtoTax-.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Logging.AddSerilog(_loggerconf);
//flyiopostgres
//PostgreSQLInLocalAppInContainer
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddDbContextPool<AtoTaxDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("flyiopostgres")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AtoTaxDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);


builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IGSTClientRepository, GSTClientRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IMultimediaTypeRepository, MultimediaTypeRepository>();
builder.Services.AddScoped<IAddressTypeRepository, AddressTypeRepository>();
builder.Services.AddScoped<IServiceCategoryRepository, ServiceCategoryRepository>();

builder.Services.AddScoped<ICollectionAndBalanceRepository, CollectionAndBalanceRepository>();
builder.Services.AddScoped<IFeeCollectionLedgerRepository, FeeCollectionLedgerRepository>();
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
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetValue<string>("ApiSettings:Secret"))),
        ValidateIssuer = false,
        ValidateAudience= false
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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

IWebHostEnvironment env = app.Environment;


// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AtoTaxCorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication(); //add before MVC
app.UseAuthorization();

app.MapControllers();

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
