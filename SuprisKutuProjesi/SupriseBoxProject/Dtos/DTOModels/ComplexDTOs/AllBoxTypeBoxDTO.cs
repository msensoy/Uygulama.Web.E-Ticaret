using DTOs.DTOModels.EntityDTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOModels.ComplexDTOs
{
    public class AllBoxTypesWithBoxDTO
    {
        public IEnumerable<BoxTypeDTO> BoxTypes { get; set; }
        public BoxDTO Box { get; set; }

    }
}
