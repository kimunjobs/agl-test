using Xunit;

namespace Test
{
    [CollectionDefinition("PetRegistry")]
    public class PetRegistryCollection : ICollectionFixture<PetRegistryFixture>
    {
    }
}