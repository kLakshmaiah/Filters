using Filters.DTO;
using Filters.Filters;
using Filters.Filters.Action;
using Filters.Filters.ServiceFilter.Action;
using Filters.Identity;
using Filters.Middlewares;
using Filters.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//automapper configuration
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));
builder.Services.AddDbContext<IdentityDbContextClass1>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDbContextClassConnectionString")));
builder.Services.AddScoped<AtrributeActionIsNotWOrking>();
//identity start
builder.Services.AddIdentity<ApplicationUser, ApplicationRoles>().AddEntityFrameworkStores<IdentityDbContextClass1>()
.AddUserStore<UserStore<ApplicationUser, ApplicationRoles, IdentityDbContextClass1, Guid>>();
//.AddRoleStore<RoleStore<ApplicationRoles, IdentityDbContextClass1,Guid>>();

//identity end
// Add services to the container.
builder.Services.AddControllers();
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
//app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseRouting();
//app.UseMiddleware<AuthorizationMiddleware>();
app.UseAuthorization();

app.MapControllers();

//middlware 1

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Hello");
//    await next(context);
//});

////middleware 2
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Hello again");
//    await next(context);
//});

////middleware 3
//app.Run(async (HttpContext context) => {
//    await context.Response.WriteAsync("Hello again this from run 1");
//});
//app.Run(async (HttpContext context) => {
//    await context.Response.WriteAsync("Hello again this from run 2");
//});


app.Run();