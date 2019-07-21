namespace Dal.Migrations
{
    using Entity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Dal.SurpriseBoxDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Dal.SurpriseBoxDbContext context)
        {
            context.BoxTypes.AddOrUpdate(x => x.ID,
          new BoxType() { ID = 1, @Type = "standart" },
          new BoxType() { ID = 2, @Type = "premium" },
          new BoxType() { ID = 3, @Type = "lux" }
          );

        context.Boxes.AddOrUpdate(x => x.ID,
            new Box() { BoxName = "birincikutu", BoxTypeID = 1, Description = "jkhkjhj" },
            new Box() { BoxName = "ikincikutu", BoxTypeID = 2, Description = "jkhkjhj" },
            new Box() { BoxName = "ucuncukutu", BoxTypeID = 3, Description = "jkhkjhj" }
            );

        context.Roles.AddOrUpdate(x => x.ID,
            new Role() { Name = "NormalUser"},
            new Role() { Name = "Admin"}
            );

        context.MemberTypes.AddOrUpdate(x => x.ID,
            new MemberType() { Type = "1Aylık" },
            new MemberType() { Type = "3Aylık" },
            new MemberType() { Type = "9Aylık" }
            );
        }
    }
}
