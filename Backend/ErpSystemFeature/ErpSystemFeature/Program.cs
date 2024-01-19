
using ErpSystemFeatureBLL.Managers.CallsManager;
using ErpSystemFeatureBLL.Managers.CustomerManager;
using ErpSystemFeatureBLL.Managers.EmployeeManager;
using ErpSystemFeatureDAL;
using ErpSystemFeatureDAL.Data.Context;
using ErpSystemFeatureDAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace ErpSystemFeature
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region Default
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            #region DataBase
            var connectionString = builder.Configuration.GetConnectionString("ERP");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
            #endregion

            #region Repos
            builder.Services.AddScoped<ICallsRepo,CallsRepo>();
            builder.Services.AddScoped<ICustomerRepo,CustomerRepo>();
            builder.Services.AddScoped<IEmployeeRepo,EmployeeRepo>();
            #endregion

            #region UnitOfWork
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

            #region Managers
            builder.Services.AddScoped<ICallsManager,CallsManager>();
            builder.Services.AddScoped<ICustomerManager,CustomerManager>();
            builder.Services.AddScoped<IEmployeeManager,EmployeeManager>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}