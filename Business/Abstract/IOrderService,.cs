using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetAll();
        IDataResult<Order> GetById(int id);
        IDataResult<Order> GetDetailsByNumber(string number);
        IResult Add(Order order);
        IResult Update(Order order);
        IResult Delete(int id);
    }
}
