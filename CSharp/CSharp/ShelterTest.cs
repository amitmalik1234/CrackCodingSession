using System;
using System.Collections.Generic;
namespace CSharp
{
    public abstract class Animal
    {
        private int order;
        protected string name;
        public Animal(string n)
        {
            this.name = n;
        }
        public void setOrder(int ord) => this.order = ord;
        public int getOrder() => this.order;
    }

    public class Dog : Animal
    {
        public Dog(string n):base(n) {             this.name = n;         }
    }

    public class Cat : Animal
    {
        public Cat(string n) : base(n) { this.name = n; }
    }

    public class AnimalQueue
    {
        List<Dog> dogs = new List<Dog>();
        List<Cat> cats = new List<Cat>();
        private int order=0;

        public void enqueue(Animal a)
        {
            a.setOrder(order);
            order++;

            if(a.GetType() == typeof(Dog))
            {
                dogs.Add((Dog)a);
            }
            else if (a.GetType() == typeof(Cat))
            {
                cats.Add((Cat)a);
            }
        }

        public Animal dequeueAny()
        {
            if (dogs.Count == 0) return dequeueCat();
            else if (cats.Count == 0) return dequeueDog();

            Dog dog = dogs[0];
            Cat cat = cats[0];

            if (dog.getOrder() > cat.getOrder()) return dequeueCat(); else return dequeueDog();

        }

        public Dog dequeueDog()
        {
            Dog dog = dogs[0];
            dogs.Remove(dog);
            return dog;
        }
        public Cat dequeueCat()
        {
            Cat cat = cats[0];
            cats.Remove(cat);
            return cat;
        }

    }
}
