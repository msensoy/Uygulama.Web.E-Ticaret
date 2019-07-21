using BLL.Absract;
using Common;
using DTOs.DTOModels.EntityDTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Abstract.EntityType
{
    public interface IBoxService:IService<Box>
    {
        ServiceResult<IEnumerable<BoxDTO>> GetBoxes();
        ServiceResult AddBox(BoxDTO BoxDTO);
        ServiceResult<BoxDTO> UpdateBox(int id);
        ServiceResult<BoxDTO> GetBoxById(int id);
        ServiceResult UpdateBox(BoxDTO BoxDTO);
        ServiceResult DeleteBox(int id);

    }
}
