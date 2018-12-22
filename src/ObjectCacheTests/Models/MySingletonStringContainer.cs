using P7Core.ObjectCaches;

namespace ObjectCacheTests.Models
{
    public class MySingletonStringContainer
    {
        private ISingletonObjectCache<MySingletonStringContainer, string> _mySingletonString;

        public MySingletonStringContainer(ISingletonObjectCache<MySingletonStringContainer, string> mySingletonString)
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