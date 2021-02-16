using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customers);
        IResult Update(Customer customers);
        IResult Delete(Customer customers);
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetById(int userId);
    }
}