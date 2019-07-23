using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1807
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var owner1 = new Owner("Jack");
            var dog1 = new Dog("Test", 9, owner1);

            
            var dog2 = dog1.Clone() as Dog;
            var owner2 = dog2.Owner;

            Console.WriteLine("Clone Own {0}", owner2.Name);
            owner1.Name = "Frank";
            Console.WriteLine("Clone Own2 {0}", owner2.Name);
            Console.ReadKey();
        }
        public static string SomeStr { get; set; }
        public static int SomeInt { get; set; }
    }
    public class Dog : ICloneable
    {
        public Dog() { }
        public Dog(string name, int age, Owner owner)
        {
            this.Name = name;
            this.Age = age;
            this.Owner = owner;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public Owner Owner { get; set; }
        public object Clone()
        {
            return new Dog(this.Name, this.Age, this.Owner.Clone());
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType().Equals(this.GetType()))
                return false;
            var item = (Dog)obj;
            bool isNameEquals;
            if (String.IsNullOrEmpty(item.Name) && String.IsNullOrEmpty(this.Name))
                isNameEquals = true;
            else if (String.IsNullOrEmpty(item.Name) || String.IsNullOrEmpty(this.Name))
                return false;
            else
                isNameEquals = this.Name.Equals(item.Name);
            return isNameEquals && this.Age.Equals(item.Age);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return "Dog " + Name + " " + Age;
        }
    }
    public class Pudge
    {
        public string Name { get; set; }
        public int Lvl { get; set; }
        public override string ToString()
        {
            return "Pudge " + Name + " " + Lvl;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType().Equals(this.GetType()))
                return false;
            var item = (Pudge)obj;
            bool isNameEquals;
            if (String.IsNullOrEmpty(item.Name) && String.IsNullOrEmpty(this.Name))
                isNameEquals = true;
            else if(String.IsNullOrEmpty(item.Name) || String.IsNullOrEmpty(this.Name))
                return false;
            else
                isNameEquals = this.Name.Equals(item.Name);
            return isNameEquals && this.Lvl.Equals(item.Lvl);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public class Owner
    {
        public Owner() { }
        public Owner(string Name)
        {
            this.Name = Name;
        }
        public string Name { get; set; }
        public override string ToString()
        {
            return "Owner " + Name;
        }

        internal Owner Clone()
        {
            return new Owner(this.Name);
        }
    }

}
