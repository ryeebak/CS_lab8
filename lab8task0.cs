using System;
using System.IO;
using System.Xml.Serialization;
using AnimalLibrary2;

class AnimalConsoleApp
{
    static void Main(string[] args)
    {
        Animal animal = new Cow("Russia", "Murka", "A tsar cow", false);

        XmlSerializer serializer = new XmlSerializer(typeof(Animal));
        using (TextWriter writer = new StreamWriter("animal.xml"))
        {
            serializer.Serialize(writer, animal);
        }

        Console.WriteLine("Animal object has been serialized to animal.xml");

        using (TextReader reader = new StreamReader("animal.xml"))
        {
            Animal deserializedAnimal = (Animal)serializer.Deserialize(reader);

            Console.WriteLine("\nDeserialized Animal Object:");
            Console.WriteLine($"Name: {deserializedAnimal.Name}");
            Console.WriteLine($"Country: {deserializedAnimal.Country}");
            Console.WriteLine($"Description: {deserializedAnimal.Description}");
            Console.WriteLine($"HideFromOtherAnimals: {deserializedAnimal.HideFromOtherAnimals}");

            deserializedAnimal.SayHello();
            Console.WriteLine($"Favorite Food: {deserializedAnimal.GetFavouriteFood()}");
        }
    }
}
