using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using RepairShop.Server.DataBase;

namespace RepairShop.Server.Extentions
{
    public static class PrebDb
    {

        public static void PrepDB(IApplicationBuilder app)
        {

            using var serviceScoped = app.ApplicationServices.CreateScope();
            var database = serviceScoped.ServiceProvider.GetService<AppDbContext>().Database;
            Console.WriteLine("Getting Migrations List");
            var migrations = database.GetMigrations();

            if (migrations != null)
            {
                foreach (var migration in migrations)
                {

                    Console.WriteLine(migration);

                }

            }
            IEnumerable<string> appliedmigrations = null;
            Console.WriteLine("Getting Applied Migrations List");
            try
            {
                appliedmigrations = database.GetAppliedMigrations();
            }
            catch (Exception)
            {

                Console.WriteLine("Error connecting to sql server");
            }

            if (appliedmigrations != null)
            {
                foreach (var migration in appliedmigrations)
                {
                    Console.WriteLine(migration);

                }
                if (migrations.LastOrDefault() == appliedmigrations.LastOrDefault())
                {

                    Console.WriteLine("Latest is applied");
                }
                else
                {
                    Console.WriteLine("Applying latest migration");
                    database.Migrate();
                }

            }
        }
    }

}