using P7Core.ObjectCaches;

namespace ObjectContainersTests.Models
{
    public class MySingletonAutoPersonContainer
    {
        private ISingletonAutoObjectContainer<MySingletonAutoPersonContainer, Person> _mySingletonPerson;

        public MySingletonAutoPersonContainer(ISingletonAutoObjectContainer<MySingletonAutoPersonContainer, Person> mySingletonPerson)
        {
            _mySingletonPerson = mySingletonPerson;
        }

        public Person SingletonPerson
        {
            get { return _mySingletonPerson.Value; }
            set { _mySingletonPerson.Value = value; }
        }
    }
}