var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BazaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BazaCS"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORS", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowAnyOrigin();
    });
});
//------------------------OVDE PROMENITI CORS!

builder.Services.AddHttpContextAccessor();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
IronBarCode.License.LicenseKey = "IRONBARCODE.JOVANJOVANOVIC.23238-72ACF41B98-TBBVKX5LACZBU2RZ-X33GEAM3BOYI-H33UDIRI3RGR-RL5ZRC4ZT7HS-DZYPSPEQSUWJ-7KAJT6-TDJSA2COBCKKEA-DEPLOYMENT.TRIAL-JRFUZX.TRIAL.EXPIRES.08.JUL.2023";
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CORS");

app.UseHttpsRedirection();


app.UseAuthorization();


app.MapControllers();

app.Run();
