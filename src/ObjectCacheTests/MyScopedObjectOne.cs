namespace ObjectCacheTests
{
    public class MyScopedObjectOne
    {
        private MyScopedStringContainer _myScopedStringContainer;

        public MyScopedObjectOne(MyScopedStringContainer myScopedStringContainer)
        {
            _myScopedStringContainer = myScopedStringContainer;
        }
        public string Name { get; set; }
        public string ScopedName
        {
            get { return _myScopedStringContainer.ScopedName; }
            set { _myScopedStringContainer.ScopedName = value; }
        }
    }
}