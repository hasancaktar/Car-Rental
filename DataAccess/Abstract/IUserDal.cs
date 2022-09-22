using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal :IEntityRepository<User>
    {
        //burda bir join atacağız. yani kullanıcı eklemesi yapılacak ve ayn zamanda claimlerini çekmek için
        List<OperationClaim> GetClaims(User user);
    }
}
