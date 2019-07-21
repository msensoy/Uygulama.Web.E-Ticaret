using Bll.Abstract.EntityType;
using BLL.Base;
using Common;
using Core.DAL;
using DTOs.DTOModels.EntityDTOs;
using Entity;
using Helper;
using System.Collections.Generic;


namespace BLL.EntityType
{
    public class BoxService : BaseService<Box>, IBoxService
    {
        IRepository<Box> _br;
        IUnitOfWork _uow;

        public BoxService(IUnitOfWork uow)
        {
            _uow = uow;
            _br = _uow.GetRepository<Box>();
        }

        public ServiceResult AddBox(BoxDTO BoxDTO)
        {

            int ess = 0;
            Box box = new Box();
            box = VMMappings.MappingBoxVMtoBoxEntity(BoxDTO);
            ess = _br.Add(box);

            if (ess > 0)
            {
                return new ServiceResult(ProcessStateEnum.Success, "Kayıt başarılı");
            }
            else
            {
                return new ServiceResult(ProcessStateEnum.Warning, "Herhangi değişiklik algılanmadığından kayıt yapılmamıştır.");
            }
        }

        public ServiceResult DeleteBox(int id)
        {
            var box = _br.Get(x => x.ID == id);
            var result = _br.SoftDelete(box);
            if (result > 0)
            {

                return new ServiceResult(ProcessStateEnum.Success, "Box has deleted");
            }
            return new ServiceResult<BoxDTO>(ProcessStateEnum.Warning, "Box has not deleted", null);
        }

        public ServiceResult<BoxDTO> GetBoxById(int id)
        {
            var box = _br.Get(x => x.ID == id);
            if (box != null)
            {
                var boxDTO = Helpers.Mapping<Box, BoxDTO>(box);
                return new ServiceResult<BoxDTO>(ProcessStateEnum.Success, "Box has found", boxDTO);
            }
            return new ServiceResult<BoxDTO>(ProcessStateEnum.Warning, "Box has not found", null);
        }

        public ServiceResult<IEnumerable<BoxDTO>> GetBoxes()
        {
            var listBox = _br.GetList();
            var listBoxDTO = Helpers.Mapping<Box, BoxDTO>(listBox);
            return new ServiceResult<IEnumerable<BoxDTO>>(ProcessStateEnum.Success, "", listBoxDTO);
        }

        public ServiceResult<BoxDTO> UpdateBox(int id)
        {
            return null;
        }

        public ServiceResult UpdateBox(BoxDTO BoxDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
