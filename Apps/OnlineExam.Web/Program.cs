using Infrastructure.Helpers;
using Infrastructure.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        );
});
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
//builder.Services.AddSession();

/* Settings */
HttpSettings httpSettings = new HttpSettings();
var settingSection = builder.Configuration.GetSection("HttpSettings");
settingSection.Bind(httpSettings);
builder.Services.AddSingleton<HttpSettings>(httpSettings);
builder.Services.AddScoped<HttpHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
//app.UseSession();
app.UseCors("CorsPolicy");
app.UseRouting();
//app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=OnlineExam}/{action=Index?assignmentId=1}");
});

//app.MapRazorPages();

app.Run();
