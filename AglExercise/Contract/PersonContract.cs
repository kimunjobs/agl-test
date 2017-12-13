using System.Collections.Generic;

namespace Contract
{
    public class PersonContract
    {
        public string Name { get; set; }

        public uint Age { get; set; }

        public Gender Gender { get; set; }

        public IEnumerable<PetContract> Pets { get; } = new List<PetContract>();
    }
}