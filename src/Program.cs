using IdentityPasswordHasher.Extensions;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ProjectSettings();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(o =>
{
    o.DocExpansion(DocExpansion.Full);
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
