﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
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
        IResult Add(Courier courier);
        IResult Update(Courier courier);
        IResult Delete(int id);
    }
}
