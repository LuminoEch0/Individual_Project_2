namespace Individual_Project_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();//Registers Razor Pages services with the dependency injection container.

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Add services to the container.


            app.UseHttpsRedirection();// Redirect HTTP requests to HTTPS

            app.UseRouting();//Enables routing capabilities in the middleware pipeline

            app.UseAuthorization();//Adds authorization middleware to enforce access control policies.

            app.MapStaticAssets();//- Maps static assets (like CSS, JS, images) to be served from the wwwroot folder.

            app.MapRazorPages()
               .WithStaticAssets();//Maps Razor Pages endpoints and ensures static assets are available to them.

            //app.MapFallback(context =>
            //{
            //    context.Response.Redirect("/Dashboard");
            //    return Task.CompletedTask;
            //});

            app.MapFallbackToPage("/Dashboard");

            app.Run();
        }
    }
}
