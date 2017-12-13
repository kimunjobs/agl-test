using Autofac;
using Data;
using Logic;

namespace Test
{
    public class PetRegistryFixture 
    {
        public PetRegistryFixture()
        {
            var builder = new ContainerBuilder();

            builder.RegisterGeneric(typeof(JsonLocalSource<>))
                .As(typeof(IJsonSource<>))
                .WithParameter("fileSystemPath", @"..\..\..\people.json")
                .InstancePerLifetimeScope();
            builder.RegisterType<PetRegistry>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<JsonOverHttpSourcePersonRepository>().As(typeof(IPersonRepository)).InstancePerLifetimeScope();

            this.Resolver = builder.Build();


        }
        public IContainer Resolver { get; }
    }
}