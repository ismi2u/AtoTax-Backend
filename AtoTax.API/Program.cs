
using AtoTax.API.Mapping;
using AtoTax.API.Repository.Interfaces;
using AtoTax.API.Repository.Repos;
using AtoTaxAPI.Authentication;
using AtoTaxAPI.Data;
using EmailService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddDbContextPool<AtoTaxDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLInLocalAppInContainer")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AtoTaxDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);


builder.Services.AddScoped<IGSTClientRepository, GSTClientRepository>();
builder.Services.AddScoped<IMediaTypeRepository, MediaTypeRepository>();
builder.Services.AddScoped<IAddressTypeRepository, AddressTypeRepository>();
builder.Services.AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();
builder.Services.AddScoped<IEmpJobRoleRepository, EmpJobRoleRepository>();
builder.Services.AddScoped<IAmendTypeRepository, AmendTypeRepository>();
builder.Services.AddScoped<IAmendmentRepository, AmendmentRepository>();
builder.Services.AddScoped<IClientFeeChargeRepository, ClientFeeChargeRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IGSTFilingTypeRepository, GSTFilingTypeRepository>();
builder.Services.AddScoped<IGSTClientAddressExtensionRepository, GSTClientAddressExtensionRepository>();
builder.Services.AddScoped<IGSTBillAndFeeCollectionRepository, GSTBillAndFeeCollectionRepository>();
builder.Services.AddScoped<IGSTPaidDetailRepository, GSTPaidDetailRepository>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opts =>
{
    opts.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false, // setting it to false, as we dont know the users connecting to this server
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,


        ValidIssuer = "https://localhost:5000",
        ValidAudience = "https://localhost:5000",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("b3dd2402-61bd-469e-9589-f6f5dfec7cbb"))
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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
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
