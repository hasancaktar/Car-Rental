using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rentals rental);
        IResult Delete(Rentals rental);
        IResult Update (Rentals rental);
        IResult Get(Rentals rental);
    }
}
