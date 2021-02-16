using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User users);
        IResult Update(User users);
        IResult Delete(User users);
        IDataResult<List<User>> GetAll();
    }
}