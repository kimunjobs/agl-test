using System.Linq;
using Autofac;
using Contract;
using Logic;
using Xunit;

namespace Test
{
    /// <summary>
    /// End-to-end test
    /// </summary>
    public class IntegrationTest: TestBase
    {
        private readonly PetRegistry registry;

        public IntegrationTest(PetRegistryFixture fixture)
        {
            // Resolve the registry we are testing
            this.registry = fixture.Resolver.Resolve<PetRegistry>();
        }

        [Fact]
        public void GenderReassignmentReportHasCorrectGroupings()
        {
            var catGenders = this.registry.ProduceDailyCatGenderReassignments();

            Assert.Equal(2, catGenders.Keys.Count);            
            Assert.Equal(catGenders.Keys, new [] { Gender.Male, Gender.Female});
        }

        [Fact]
        public void GenderReassignmentReportSortedCorrectly()
        {
            var catGenders = this.registry.ProduceDailyCatGenderReassignments();

            foreach (var names in catGenders.Values)
            {
                var sortedNames = names.OrderBy(n => n);
                Assert.Equal(sortedNames, names);
            }
            
        }

    }
}