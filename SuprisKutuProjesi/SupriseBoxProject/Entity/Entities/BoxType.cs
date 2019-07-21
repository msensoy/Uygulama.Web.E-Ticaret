namespace Entity
{
    using Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BoxType : IEntity
    {
        public BoxType()
        {
            Boxes = new HashSet<Box>();
        }

        public int ID { get; set; }

      
        public string Type { get; set; }

        public bool IsDelete { get; set; }


        public virtual ICollection<Box> Boxes { get; set; }
    }
}
