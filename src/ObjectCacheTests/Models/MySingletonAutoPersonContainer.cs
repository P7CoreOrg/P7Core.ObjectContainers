using P7Core.ObjectCaches;

namespace ObjectCacheTests.Models
{
    public class MySingletonAutoPersonContainer
    {
        private ISingletonAutoObjectCache<MySingletonAutoPersonContainer, Person> _mySingletonPerson;

        public MySingletonAutoPersonContainer(ISingletonAutoObjectCache<MySingletonAutoPersonContainer, Person> mySingletonPerson)
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