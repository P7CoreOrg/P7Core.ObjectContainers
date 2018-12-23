using P7Core.ObjectCaches;

namespace ObjectContainersTests.Models
{
    public class MyScopedAutoPersonContainer
    {
        private IScopedAutoObjectContainer<MyScopedAutoPersonContainer, Person> _myScopedPerson;

        public MyScopedAutoPersonContainer(IScopedAutoObjectContainer<MyScopedAutoPersonContainer, Person> myScopedPerson)
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