using P7Core.ObjectCaches;

namespace ObjectContainersTests.Models
{
    public class MyScopedStringContainer
    {
        private IScopedObjectContainer<MyScopedStringContainer, string> _myScopedString;

        public MyScopedStringContainer(IScopedObjectContainer<MyScopedStringContainer, string> myScopedString)
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