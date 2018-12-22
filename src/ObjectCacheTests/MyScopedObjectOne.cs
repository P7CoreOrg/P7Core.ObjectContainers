namespace ObjectCacheTests
{
    public class MyScopedObjectOne
    {
        private MyScopedStringContainer _myScopedStringContainer;
        private MySingletonStringContainer _mySingletonStringContainer;

        public MyScopedObjectOne(
            MyScopedStringContainer myScopedStringContainer,
            MySingletonStringContainer mySingletonStringContainer)
        {
            _myScopedStringContainer = myScopedStringContainer;
            _mySingletonStringContainer = mySingletonStringContainer;
        }
        public string Name { get; set; }
        public string ScopedName
        {
            get { return _myScopedStringContainer.ScopedName; }
            set { _myScopedStringContainer.ScopedName = value; }
        }
        public string SingletonName
        {
            get { return _mySingletonStringContainer.SingletonName; }
            set { _mySingletonStringContainer.SingletonName = value; }
        }
    }
}