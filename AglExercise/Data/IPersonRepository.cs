using System;
using System.Collections.Generic;
using Contract;

namespace Data
{
    public interface IPersonRepository
    {
        IEnumerable<PersonContract> GetAll();
    }
}
