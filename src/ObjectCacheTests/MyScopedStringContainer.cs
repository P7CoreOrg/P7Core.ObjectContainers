using P7Core.ObjectCaches;

namespace ObjectCacheTests
{
    public class MyScopedStringContainer
    {
        private IScopedObjectCache<MyScopedStringContainer, string> _myScopedString;

        public MyScopedStringContainer(IScopedObjectCache<MyScopedStringContainer, string> myScopedString)
        {
            _myScopedString = myScopedString;
        }

        public string ScopedName
        {
            get { return _myScopedString.Value; }
            set { _myScopedString.Value = value; }
        }
    }
}