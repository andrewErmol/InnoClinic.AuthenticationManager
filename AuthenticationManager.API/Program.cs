using AuthenticationManager.API.Extensions;
using AuthenticationManager.BLL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.ConfigureIdentityServer(builder.Configuration);
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureServices();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MigrateDatabase();

app.UseStaticFiles();
app.UseRouting();

app.UseCors("CorsPolicy");
app.UseIdentityServer();

app.UseHttpsRedirection();

app.UseIdentityServer();

app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.MapControllers();

app.Run();
