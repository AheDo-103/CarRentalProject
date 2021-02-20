using System;
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

namespace Business.Conctrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IDataResult<List<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(filter), Messages.BrandListed);
        }

        public IDataResult<Brand> Get(int entityId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(x => x.BrandId == entityId), Messages.BrandGetted);
        }

        public IResult Add(Brand entity)
        {
            ValidationTool.Validate(new BrandValidator(), entity);
            _brandDal.Add(entity);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Update(Brand entity)
        {
            ValidationTool.Validate(new BrandValidator(), entity);
            _brandDal.Update(entity);
            return new SuccessResult(Messages.BrandUpdated);
        }

        public IResult Delete(Brand entity)
        {
            _brandDal.Delete(entity);
            return new SuccessResult(Messages.BrandDeleted);
        }
    }
}