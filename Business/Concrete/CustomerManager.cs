﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.SucceededMessage);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new ErrorResult(Messages.FailedMessage);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.SucceededMessage);
        }

        public IDataResult<Customer> GetById(int Id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.CustomerId == Id),Messages.SucceededMessage);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new ErrorResult(Messages.FailedMessage);
        }
    }
}
