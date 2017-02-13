namespace SampleAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SampleAPI.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<SampleAPI.DataAccessLayer.CRMContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SampleAPI.DataAccessLayer.CRMContext context)
        {
            var userList = new List<User>();
            userList.Add(new User { username = "user123", password = "123user" });
            userList.Add(new User { username = "sampleuser", password = "123456" });

            userList.ForEach(u => context.Users.AddOrUpdate(u));
            context.SaveChanges();
        }
    }
}
