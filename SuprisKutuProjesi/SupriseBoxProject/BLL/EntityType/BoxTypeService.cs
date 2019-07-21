using Bll.Abstract.EntityType;
using BLL.Base;
using Common;
using Core.DAL;
using DTOs.DTOModels.EntityDTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.EntityType
{
    public class BoxTypeService : BaseService<BoxType>, IBoxTypeService
    {
        IUnitOfWork _uow;
        IRepository<BoxType> _btr;
        public BoxTypeService(IUnitOfWork uow)
        {
            _uow = uow;
            _btr = _uow.GetRepository<BoxType>();
        }
        public ServiceResult<IEnumerable<BoxTypeDTO>> GetBoxTypes()
        {
            var boxTypes = _btr.GetList();
            var listBoxTypes = Helper.Helpers.Mapping<BoxType, BoxTypeDTO>(boxTypes);
            if (listBoxTypes==null)
            {
                return new ServiceResult<IEnumerable<BoxTypeDTO>>(ProcessStateEnum.Warning, "Gösterilecek kutu tipi bulunamadı", null);
            }
            return new ServiceResult<IEnumerable<BoxTypeDTO>>(ProcessStateEnum.Success, "Kayıtlar başarıyla bulundu", listBoxTypes);

        }
    }
}
