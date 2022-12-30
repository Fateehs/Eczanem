using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICourierService
    {
        IDataResult<List<Courier>> GetAll();
        IDataResult<Courier> GetById(int id);
        IDataResult<List<Order>> ListOrdersToBeDelivered();
        IResult OrderDelivered(Order order);
        IResult GetPackage(Order order);
        IResult AcceptDelivery(AssignCourierDTO assignCourierDTO);
        IResult Add(Courier courier);
        IResult Update(Courier courier);
        IResult Delete(int id);
    }
}
