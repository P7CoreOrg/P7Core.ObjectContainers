using P7Core.ObjectCaches;

namespace ObjectCacheTests.Models
{
    public class MyScopedAutoPersonContainer
    {
        private IScopedAutoObjectCache<MyScopedAutoPersonContainer, Person> _myScopedPerson;

        public MyScopedAutoPersonContainer(IScopedAutoObjectCache<MyScopedAutoPersonContainer, Person> myScopedPerson)
        {
            _myScopedPerson = myScopedPerson;
        }

        public Person ScopedPerson
        {
            get { return _myScopedPerson.Value; }
            set { _myScopedPerson.Value = value; }
        }
    }
}