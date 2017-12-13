using System;
using Logic;

namespace AglExercise
{
    public interface IRegistryDisplayer
    {
        void DisplayPetGenderRegistry(PetGenderRegistrations registrations);
    }

    public class ConsoleRegistryDisplayer : IRegistryDisplayer
    {
        public void DisplayPetGenderRegistry(PetGenderRegistrations registrations)
        {
            foreach (var genderEntry in registrations)
            {
                Console.WriteLine(genderEntry.Key.ToString());
                Console.WriteLine(new string('-', genderEntry.Key.ToString().Length));

                foreach (var name in genderEntry.Value)
                {
                    Console.WriteLine(name);
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }

    }
}    

