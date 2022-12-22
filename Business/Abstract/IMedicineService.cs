using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMedicineService
    {
        IDataResult<List<Medicine>> GetAll();
        IDataResult<Medicine> GetById(int id);
        IResult Add(Medicine medicine);
        IResult Update(Medicine medicine);
        IResult Delete(int id);
    }
}
