using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalsDal;
        public RentalManager(IRentalDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }
        public IResult Add(Rental rentals)
        {
            var dateRent = rentals.RentDate;
            var dateReturn = rentals.ReturnDate;
            var result = DateTime.Compare(dateRent,dateReturn);
            if (dateRent<dateReturn ||dateReturn == null)
                return new ErrorResult(Messages.RentalsError);
            else
            {
                _rentalsDal.Add(rentals);
                return new SuccessResult(Messages.RentalsAdded);
            }          
        }

        public IResult Delete(Rental rentals)
        {
            _rentalsDal.Delete(rentals);
           return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
           return new SuccessDataResult<List<Rental>>(_rentalsDal.GetAll(),Messages.Listed);
        }

        public IResult Update(Rental rentals)
        {
            if (rentals.ReturnDate == null)
            {
                return new ErrorResult(Messages.RentalsError);
            }
            _rentalsDal.Update(rentals);
            return new SuccessResult(Messages.Update);
        }
    }
}