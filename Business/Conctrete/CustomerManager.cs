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
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(filter), Messages.CustomerListed);
        }

        public IDataResult<List<CustomerS>> GetAllDetailsForSingle(Expression<Func<CustomerS, bool>> filter = null)
        {
            return new SuccessDataResult<List<CustomerS>>(_customerDal.GetAllDetailsForSingle(filter),
                Messages.CustomerListed);
        }

        public IDataResult<List<CustomerL>> GetAllDetailsForList(Expression<Func<CustomerL, bool>> filter = null)
        {
            return new SuccessDataResult<List<CustomerL>>(_customerDal.GetAllDetailsForList(filter),
                Messages.CustomerListed);
        }

        public IDataResult<Customer> Get(int entityId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(x => x.CustomerId == entityId),
                Messages.CustomerGetted);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer entity)
        {
            _customerDal.Add(entity);
            return new SuccessResult(Messages.CustomerAdded);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer entity)
        {
            _customerDal.Update(entity);
            return new SuccessResult(Messages.CustomerUpdated);
        }

        public IResult Delete(Customer entity)
        {
            _customerDal.Delete(entity);
            return new SuccessResult(Messages.CustomerDeleted);
        }
    }
}