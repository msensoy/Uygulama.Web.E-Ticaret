using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    class SurpriseBoxDBInitializer: DropCreateDatabaseIfModelChanges<SurpriseBoxDbContext>
    {
        protected override void Seed(SurpriseBoxDbContext context)
        {
            //silinecek....

            IList<BoxType> defaultBoxTypes = new List<BoxType>();
            //IList<Box> defaultBoxes = new List<Box>();

            //Seedlere default box eklemede sıkıntı var...

            defaultBoxTypes.Add(new BoxType() { Type = "Standart" });
            defaultBoxTypes.Add(new BoxType() { Type = "Klasik" });

            //defaultBoxes.Add(new Box() { BoxName = "Kahve", Description = "3 çeşit kahve mevcut" });



            context.BoxTypes.AddRange(defaultBoxTypes);
            //context.Boxes.AddRange(defaultBoxes);

            base.Seed(context);
        }
    }
}
