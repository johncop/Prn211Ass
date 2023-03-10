using Repository;
using Repository.Models;
using Repository.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession();
builder.Services.AddDbContext<EventScheduleContext>();
builder.Services.AddScoped(typeof(RepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<TblAdminRepository>();
builder.Services.AddScoped<TblEventRepository>();
builder.Services.AddScoped<TblCategoryRepository>();
builder.Services.AddScoped<TblLocationRepository>();
builder.Services.AddScoped<TblEventParticipatedRepository>();
builder.Services.AddScoped<TblUserRepository>();

// Add services to the container.
builder.Services.AddRazorPages();

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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
