using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CourierManager : ICourierService
    {
        ICourierRepository _courierRepository;

        public CourierManager(ICourierRepository courierRepository)
        {
            _courierRepository = courierRepository;
        }

        public IDataResult<List<Courier>> GetAll()
        {
            return new SuccessDataResult<List<Courier>>(_courierRepository.GetAll());
        }

        public IDataResult<Courier> GetById(int id)
        {
            return new SuccessDataResult<Courier>(_courierRepository.Get(c => c.Id == id));
        }

        public IResult Add(Courier courier)
        {
            _courierRepository.Add(courier);

            return new SuccessResult();
        }

        public IResult Update(Courier courier)
        {
            _courierRepository.Update(courier);

            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var courier = _courierRepository.Get(c => c.Id == id);

            _courierRepository.Delete(courier);

            return new SuccessResult();
        }
    }
}
