namespace ObjectCacheTests
{
    public class MyScopedObjectTwo
    {
        private MyScopedStringContainer _myScopedStringContainer;

        public MyScopedObjectTwo(MyScopedStringContainer myScopedStringContainer)
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