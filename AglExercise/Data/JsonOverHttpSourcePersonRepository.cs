using System.Collections.Generic;
using Contract;

namespace Data
{
    public class JsonOverHttpSourcePersonRepository : IPersonRepository
    {
        private readonly IJsonSource<PersonContract[]> source;

        public JsonOverHttpSourcePersonRepository(IJsonSource<PersonContract[]> source)
        {
            this.source = source;
        }

        public IEnumerable<PersonContract> GetAll()
        {
            return source.Load();
        }
    }
}