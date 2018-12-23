using System;

namespace ObjectContainersTests.Models
{
    public class Person
    {
        public Person()
        {
            Name = Guid.NewGuid().ToString();
        }
        public string Name { get; set; }
    }
}