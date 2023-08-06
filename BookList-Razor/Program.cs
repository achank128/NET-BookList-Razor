
using BookList_Razor.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString  = builder.Configuration.GetConnectionString("DefaultConnection");//
// Add services to the container.
builder.Services.AddDbContext<ApplicationDBContext>(option => option.UseSqlServer(connectionString));//
builder.Services.AddControllersWithViews();//
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();//

app.MapRazorPages();

app.Run();
