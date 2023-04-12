using ProductAPI.DAL;
using Serilog.Events;
using Serilog;
using Ocelot.Middleware;
using Ocelot.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var services=builder.Services;
// Add services to the container.
builder.Services.AddCors(options => {
    options.AddPolicy("CORSPolicy", builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed((hosts) => true));
});
builder.Services.AddControllers();
//json file created for ocelot
///builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("ocelot.json")
                            .Build();
//builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddOcelot(configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CORSPolicy");
app.UseHttpsRedirection();
app.UseOcelot();
app.UseAuthorization();
app.MapControllers();
app.Run();
