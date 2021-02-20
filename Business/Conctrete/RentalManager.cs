using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Conctrete;
using DataAccess.Abstract;
using Entities.Conctrete;
using Entities.DTOs;

namespace Business.Conctrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(filter), Messages.RentalListed);
        }

        public IDataResult<List<RentalS>> GetAllDetailsForSingle(Expression<Func<RentalS, bool>> filter = null)
        {
            return new SuccessDataResult<List<RentalS>>(_rentalDal.GetAllDetailsForSingle(filter), Messages.RentalListed);
        }

        public IDataResult<List<RentalL>> GetAllDetailsForList(Expression<Func<RentalL, bool>> filter = null)
        {
            return new SuccessDataResult<List<RentalL>>(_rentalDal.GetAllDetailsForList(filter), Messages.RentalListed);
        }

        public IDataResult<Rental> Get(int entityId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(x => x.RentalId == entityId), Messages.RentalGetted);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental entity)
        {
            _rentalDal.Add(entity);
            return new SuccessResult(Messages.RentalAdded);
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Add(entity);
            return new SuccessResult(Messages.RentalDeleted);
        }
    }
}