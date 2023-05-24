namespace Models
{
    public class Person
    {
        public string? Id { get; set; } = null;
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; } = default;

        // paramerelesss ctor used for serialization
        public Person() { }

        public Person(string PersonName, int PersonAge)
        {
            Id = Guid.NewGuid().ToString();
            Name = PersonName;
            Age = PersonAge;
        }
    }
}
