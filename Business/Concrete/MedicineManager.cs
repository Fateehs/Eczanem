using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MedicineManager : IMedicineService
    {
        IMedicineRepository _medicineRepository;

        public MedicineManager(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public IDataResult<List<Medicine>> GetAll()
        {
            return new SuccessDataResult<List<Medicine>>(_medicineRepository.GetAll());
        }

        public IDataResult<Medicine> GetById(int id)
        {
            return new SuccessDataResult<Medicine>(_medicineRepository.Get(p => p.Id == id));
        }

        public IResult Add(Medicine medicine)
        {
            _medicineRepository.Add(medicine);

            return new SuccessResult();
        }

        public IResult Update(Medicine medicine)
        {
            _medicineRepository.Update(medicine);

            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var medicine = _medicineRepository.Get(m => m.Id == id);

            if (medicine != null)

                _medicineRepository.Delete(medicine);

            return new SuccessResult();
        }
    }
}
