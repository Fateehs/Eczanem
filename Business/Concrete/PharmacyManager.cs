using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PharmacyManager : IPharmacyService
    {
        IPharmacyRepository _pharmacyRepository;

        public PharmacyManager(IPharmacyRepository pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }

        public IDataResult<List<Pharmacy>> GetAll()
        {
            return new SuccessDataResult<List<Pharmacy>>(_pharmacyRepository.GetAll());
        }

        public IDataResult<Pharmacy> GetById(int id)
        {
            return new SuccessDataResult<Pharmacy>(_pharmacyRepository.Get(p => p.Id == id));
        }

        public IResult Add(Pharmacy pharmacy)
        {
            _pharmacyRepository.Add(pharmacy);

            return new SuccessResult();
        }

        public IResult Update(Pharmacy pharmacy)
        {
            _pharmacyRepository.Update(pharmacy);

            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var pharmacy = _pharmacyRepository.Get(p => p.Id == id);

            if (pharmacy != null)

                _pharmacyRepository.Delete(pharmacy);

            return new SuccessResult();
        }
    }
}
