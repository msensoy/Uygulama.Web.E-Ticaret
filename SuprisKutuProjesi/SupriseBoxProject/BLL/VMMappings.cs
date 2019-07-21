
using DTOs.DTOModels.EntityDTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class VMMappings
    {
        public static Box MappingBoxVMtoBoxEntity(BoxDTO BoxDTO)
        {
            Box box = new Box()
            {
                BoxName = BoxDTO.BoxName,
                BoxTypeID = BoxDTO.BoxTypeID,
                Description = BoxDTO.Description,
                ImageUrl = BoxDTO.ImageUrl,
                Price = BoxDTO.Price,
                UnitsInStock = BoxDTO.UnitsInStock


            };

            return box;
        }
        public static Box MappingBoxVMtoBoxEntityUpdate(BoxDTO BoxDTO)
        {
            Box box = new Box()
            {
                ID = BoxDTO.ID,
                BoxName = BoxDTO.BoxName,
                BoxTypeID = BoxDTO.BoxTypeID,
                Description = BoxDTO.Description,
                ImageUrl = BoxDTO.ImageUrl,
                Price = BoxDTO.Price,
                UnitsInStock = BoxDTO.UnitsInStock,
                BoxType = new BoxType { ID = BoxDTO.ID }

            };

            return box;
        }

    }
}
