
using DTOs.DTOModels.EntityDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{

    public static class ShoppingDetails
    {
        public static int? UserID { get; set; }
        public static List<OrderDetailDTO> items { get; set; }

    }
}

