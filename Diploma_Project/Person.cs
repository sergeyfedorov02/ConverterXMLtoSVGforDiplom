// ReSharper disable All

namespace Diploma_Project
{
 
// internal - компоненты класса или структуры доступен из любого места кода в той же сборке, однако он недоступен для других программ и сборок 
    internal class Person
    {
        public string Name { get;}
        public int Age { get; set; }
        public string Company { get; set; }
        public Person(string name, int age, string company)
        {
            Name = name;
            Age = age;
            Company = company;
        }
}
}