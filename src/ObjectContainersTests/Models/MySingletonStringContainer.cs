using P7Core.ObjectCaches;

namespace ObjectContainersTests.Models
{
    public class MySingletonStringContainer
    {
        private ISingletonObjectContainer<MySingletonStringContainer, string> _mySingletonString;

        public MySingletonStringContainer(ISingletonObjectContainer<MySingletonStringContainer, string> mySingletonString)
        {
            _mySingletonString = mySingletonString;
        }

        public string SingletonName
        {
            get { return _mySingletonString.Value; }
            set { _mySingletonString.Value = value; }
        }
    }
}