using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Data;
using Logic;

namespace AglExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Bootstrap();

            using (var scope = container.BeginLifetimeScope())
            {
                var registryDisplayer = scope.Resolve<IRegistryDisplayer>();
                var registry = scope.Resolve<PetRegistry>();

                var registrations = registry.ProduceDailyCatGenderReassignments();
                registryDisplayer.DisplayPetGenderRegistry(registrations);
            }

        }

        public static IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ConsoleRegistryDisplayer>().As<IRegistryDisplayer>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(JsonHttpSource<>))
                .As(typeof(IJsonSource<>))
                .WithParameter("uri", new Uri("http://agl-developer-test.azurewebsites.net/people.json"))
                .InstancePerLifetimeScope();
            builder.RegisterType<PetRegistry>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<JsonOverHttpSourcePersonRepository>().As(typeof(IPersonRepository)).InstancePerLifetimeScope();

            return builder.Build();
        }

    }
}
