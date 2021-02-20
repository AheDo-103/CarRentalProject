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
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(filter), Messages.UserListed);
        }

        public IDataResult<User> Get(int entityId)
        {
            return new SuccessDataResult<User>(_userDal.Get(x => x.UserId == entityId), Messages.UserGetted);
        }

        public IResult Add(User entity)
        {
            ValidationTool.Validate(new UserValidator(), entity);
            _userDal.Add(entity);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Update(User entity)
        {
            ValidationTool.Validate(new UserValidator(), entity);
            _userDal.Update(entity);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult(Messages.UserDeleted);
        }
    }
}