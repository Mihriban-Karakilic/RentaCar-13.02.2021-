using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        public IResult Add(Customer customers)
        {
            _customerDal.Add(customers);
            return new SuccessResult(Messages.Added);
        }

        public IResult Update(Customer customers)
        {
            _customerDal.Update(customers);
            return new SuccessResult(Messages.Update);
        }

        public IResult Delete(Customer customers)
        {
            _customerDal.Delete(customers);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {           
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Customer> GetById(int userId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(I=>I.UserId == userId));
        }
    }
}