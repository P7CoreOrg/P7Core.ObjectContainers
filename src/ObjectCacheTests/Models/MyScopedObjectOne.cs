namespace ObjectCacheTests.Models
{
    public class MyScopedObjectOne
    {
        private MyScopedStringContainer _myScopedStringContainer;
        private MySingletonStringContainer _mySingletonStringContainer;
        private MyScopedAutoPersonContainer _myScopedAutoPersonContainer;
        private MySingletonAutoPersonContainer _mySingletonAutoPersonContainer;

        public MyScopedObjectOne(
            MyScopedStringContainer myScopedStringContainer,
            MySingletonStringContainer mySingletonStringContainer,
            MyScopedAutoPersonContainer myScopedAutoPersonContainer,
            MySingletonAutoPersonContainer mySingletonAutoPersonContainer)
        {
            _myScopedStringContainer = myScopedStringContainer;
            _mySingletonStringContainer = mySingletonStringContainer;

            _myScopedAutoPersonContainer = myScopedAutoPersonContainer;
            _mySingletonAutoPersonContainer = mySingletonAutoPersonContainer;

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
        public Person ScopedPerson
        {
            get { return _myScopedAutoPersonContainer.ScopedPerson; }
            set { _myScopedAutoPersonContainer.ScopedPerson = value; }
        }

        public Person SingletonPerson
        {
            get { return _mySingletonAutoPersonContainer.SingletonPerson; }
            set { _mySingletonAutoPersonContainer.SingletonPerson = value; }
        }
    }
}