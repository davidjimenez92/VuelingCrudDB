using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using VuelingCrudDB.Domain.Entities;

namespace VuelingCrudDB.Distributed.WebServices.Migrations
{
    public sealed class Configuration: DbMigrationsConfiguration<StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StudentContext context)
        {
            base.Seed(context);
        }
    }
}