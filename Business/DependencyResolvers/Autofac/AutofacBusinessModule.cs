﻿using Autofac;
using Business.Abstract;
using Business.Conctrete;
using DataAccess.Abstract;
using DataAccess.Conctrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BrandManager>().As<IBrandService>();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>();
            
            builder.RegisterType<CarManager>().As<ICarService>();
            builder.RegisterType<EfCarDal>().As<ICarDal>();

            builder.RegisterType<ColorManager>().As<IColorService>();
            builder.RegisterType<EfColorDal>().As<IColorDal>();

            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();

            builder.RegisterType<RentalManager>().As<IRentalService>();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
        }
    }
}