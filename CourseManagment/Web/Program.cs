using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using NLog;
<<<<<<<< HEAD:Practice-main/CourseManagment/Web/Program.cs
using Presentation;
========
>>>>>>>> 29a20d7bfa39aa64776ca5dc94fce333e8260878:CourseManagment/Web/Program.cs
using Repository.OtherRepository;
using Web.Extensions;

var builder = WebApplication.CreateBuilder(args);
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));

// Add services to the container.
builder.Services.AddControllers()
    .AddApplicationPart(typeof(AssemblyReference).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseHsts();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");
app.UseSwagger();
app.UseSwaggerUI();
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<RepositoryContext>();
    await dataContext.Database.MigrateAsync();
}
app.UseAuthorization();

app.MapControllers();

app.Run();