using BLL.Absract;
using Common;
using DTOs.DTOModels;
using DTOs.DTOModels.ComplexDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Abstract.ComplexType
{
    public interface IBoxBoxTypeService
    {
        ServiceResult<BoxBoxTypeDTO> GetBoxBoxType(int boxID);
        ServiceResult<AllBoxTypesWithBoxDTO> GetAllBoxTypesWithBox();
        ServiceResult<IEnumerable<BoxBoxTypeDTO>> GetAllBoxBoxType();

    }
}
