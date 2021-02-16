using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rentals);
        IResult Update(Rental rentals);
        IResult Delete(Rental rentals);
        IDataResult<List<Rental>> GetAll();
    }
}