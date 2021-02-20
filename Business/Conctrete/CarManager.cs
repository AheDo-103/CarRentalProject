﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Conctrete;
using DataAccess.Abstract;
using Entities.Conctrete;
using Entities.DTOs;

namespace Business.Conctrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(filter), Messages.CarsListed);
        }

        public IDataResult<List<CarS>> GetAllDetailsForSingle(Expression<Func<CarS, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarS>>(_carDal.GetAllDetailsForSingle(filter), Messages.CarsListed);
        }

        public IDataResult<List<CarL>> GetAllDetailsForList(Expression<Func<CarL, bool>> filter = null)
        {
            return new SuccessDataResult<List<CarL>>(_carDal.GetAllDetailsForList(filter), Messages.CarsListed);
        }

        public IDataResult<Car> Get(int entityId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(x => x.CarId == entityId), Messages.CarGetted);
        }

        public IResult Add(Car entity)
        {
            ValidationTool.Validate(new CarValidator(), entity);
            _carDal.Add(entity);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Update(Car entity)
        {
            ValidationTool.Validate(new CarValidator(), entity);
            _carDal.Update(entity);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccessResult(Messages.CarDeleted);
        }
    }
}