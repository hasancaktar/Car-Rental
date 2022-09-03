using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUsersDal _usersDal;

        public UserManager(IUsersDal usersDal)
        {
            _usersDal= usersDal;
        }
      
        public IResult Add(Users users)
        {
            _usersDal.Add(users);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Update(Users users)
        {
            _usersDal.Update(users);
            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult Delete(Users users)
        {
            _usersDal.Delete(users);
            return new SuccessResult(Messages.UserDeleted);
        }

        
    }
}
