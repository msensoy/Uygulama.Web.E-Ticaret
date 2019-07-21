using Bll.Abstract.ComplexType;
using Common;
using Core.DAL;
using DTOs.DTOModels.ComplexDTOs;
using DTOs.DTOModels.EntityDTOs;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ComplexType
{
    public class BoxBoxTypeService : IBoxBoxTypeService
    {
        IUnitOfWork _uow;
        IRepository<Box> _br;
        IRepository<BoxType> _btr;
        public BoxBoxTypeService(IUnitOfWork uow)
        {
            _uow = uow;
            _br = _uow.GetRepository<Box>();
            _btr = _uow.GetRepository<BoxType>();
        }

        public ServiceResult<AllBoxTypesWithBoxDTO> GetAllBoxTypesWithBox()
        {
            var boxTypeList = _btr.GetList();
            var boxTypeListDTO = Helper.Helpers.Mapping<BoxType, BoxTypeDTO>(boxTypeList);
            BoxDTO boxDTO = new BoxDTO();

            AllBoxTypesWithBoxDTO allBox = new AllBoxTypesWithBoxDTO()
            {
                BoxTypes = boxTypeListDTO,
                Box = boxDTO
            };

            return new ServiceResult<AllBoxTypesWithBoxDTO>(ProcessStateEnum.Success, "", allBox);

        }

        public ServiceResult<BoxBoxTypeDTO> GetBoxBoxType(int boxID)
        {

            var sorgu = (from b in _br.GetQuery()
                         join bt in _btr.GetQuery() on b.BoxTypeID equals bt.ID
                         where b.ID == boxID
                         select new BoxBoxTypeDTO
                         {
                             BoxID = boxID,
                             BoxName = b.BoxName,
                             Description = b.Description,
                             ImageUrl = b.ImageUrl,
                             Price = b.Price,
                             @BoxType = bt.Type,
                             UnitsInStock = b.UnitsInStock,
                             IsDelete = b.IsDelete

                         }
                       );
            var result = sorgu.FirstOrDefault();

            if (result == null)
            {
                return new ServiceResult<BoxBoxTypeDTO>(ProcessStateEnum.Warning, "Kutu bulunamadı", null);
            }

            return new ServiceResult<BoxBoxTypeDTO>(ProcessStateEnum.Success, "Kutu bilgileri bulundu", result);
        }

        public ServiceResult<IEnumerable<BoxBoxTypeDTO>> GetAllBoxBoxType()
        {

            var sorgu = (from b in _br.GetQuery()
                         join bt in _btr.GetQuery() on b.BoxTypeID equals bt.ID
                         select new BoxBoxTypeDTO
                         {
                             BoxID = b.ID,
                             BoxName = b.BoxName,
                             Description = b.Description,
                             ImageUrl = b.ImageUrl,
                             Price = b.Price,
                             @BoxType = bt.Type,
                             UnitsInStock = b.UnitsInStock,
                             IsDelete = b.IsDelete
                         }
                       );
            var result = sorgu.ToList();

            if (result == null)
            {
                return new ServiceResult<IEnumerable<BoxBoxTypeDTO>>(ProcessStateEnum.Warning, "Kutu bulunamadı", null);
            }

            return new ServiceResult<IEnumerable<BoxBoxTypeDTO>>(ProcessStateEnum.Success, "Kutu bilgileri bulundu", result);
        }
    }
}
