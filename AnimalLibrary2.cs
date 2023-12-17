using System;
using System.Xml.Serialization;

namespace AnimalLibrary2
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommentAtt : Attribute
    {
        public string Comment { get; set; }

        public CommentAtt(string comment)
        {
            Comment = comment;
        }
    }

    public enum AnimalClassification
    {
        Herbivores,
        Carnivores,
        Omnivores
    }

    public enum FavouriteFood
    {
        Meat,
        Plants,
        Everything
    }

    [Serializable]
    [XmlInclude(typeof(Cow))]
    [XmlInclude(typeof(Lion))]
    [XmlInclude(typeof(Pig))]
    [XmlRoot("Animal")]

    [CommentAtt("Абстрактный класс для объектов, представляющих животных")]
    public abstract class Animal
    {
        private AnimalClassification classification;

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Country")]
        public string Country { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }

        [XmlElement("HideFromOtherAnimals")]
        public bool HideFromOtherAnimals { get; set; }

        public abstract void SayHello();
        public abstract FavouriteFood GetFavouriteFood();

        public Animal(string country, string name, string description, bool hideFromOtherAnimals)
        {
            Name = name;
            Country = country;
            Description = description;
            HideFromOtherAnimals = hideFromOtherAnimals;
        }

        public void Deconstruct(out string out_name)
        {
            out_name = Name;
        }

        public void Deconstruct(out string out_name, out string out_desc)
        {
            out_name = Name;
            out_desc = Description;
        }

        public void Deconstruct(out string out_name, out string out_desc, out string out_count)
        {
            out_name = Name;
            out_count = Country;
            out_desc = Description;
        }

        public void Deconstruct(out string out_name, out string out_desc, out string out_count, out bool out_hide)
        {
            out_name = Name;
            out_count = Country;
            out_desc = Description;
            out_hide = HideFromOtherAnimals;
        }
    }

    [CommentAtt("Класс описания коровы")]
    public class Cow : Animal
    {
        public Cow() : base("", "", "", false)
        {
        }

        public Cow(string country, string name, string description, bool hideFromOtherAnimals) :
            base(country, name, description, hideFromOtherAnimals)
        {
        }

        public override FavouriteFood GetFavouriteFood()
        {
            return FavouriteFood.Plants;
        }

        public override void SayHello()
        {
            Console.WriteLine("Moo\n");
        }
    }

    [CommentAtt("Класс описания льва")]
    public class Lion : Animal
    {
        public Lion() : base("", "", "", false)
        {
        }

        public Lion(string country, string name, string description, bool hideFromOtherAnimals) :
            base(country, name, description, hideFromOtherAnimals)
        {
        }

        public override FavouriteFood GetFavouriteFood()
        {
            return FavouriteFood.Meat;
        }

        public override void SayHello()
        {
            Console.WriteLine("Roar\n");
        }
    }

    [CommentAtt("Класс описания свиньи")]
    public class Pig : Animal
    {
        public Pig() : base("", "", "", false)
        {
        }

        public Pig(string country, string name, string description, bool hideFromOtherAnimals) :
            base(country, name, description, hideFromOtherAnimals)
        {
        }

        public override FavouriteFood GetFavouriteFood()
        {
            return FavouriteFood.Everything;
        }

        public override void SayHello()
        {
            Console.WriteLine("Oink\n");
        }
    }
}
