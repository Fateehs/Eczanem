using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPharmacyService
    {
        IDataResult<List<Pharmacy>> GetAll();
        IDataResult<Pharmacy> GetById(int id);
        IResult Add(Pharmacy pharmacy);
        IResult Update(Pharmacy pharmacy);
        IResult Delete(int id);
    }
}
