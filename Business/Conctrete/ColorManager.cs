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
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(filter), Messages.ColorsListed);
        }

        public IDataResult<Color> Get(int entityId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(x => x.ColorId == entityId), Messages.ColorGetted);
        }

        public IResult Add(Color entity)
        {
            ValidationTool.Validate(new ColorValidator(), entity);
            _colorDal.Add(entity);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Update(Color entity)
        {
            ValidationTool.Validate(new ColorValidator(), entity);
            _colorDal.Update(entity);
            return new SuccessResult(Messages.ColorUpdated);
        }

        public IResult Delete(Color entity)
        {
            _colorDal.Delete(entity);
            return new SuccessResult(Messages.ColorDeleted);
        }
    }
}