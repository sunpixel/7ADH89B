namespace Back
{
    public class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        //public Dictionary<string, List<int>> Marks { get; set; }

        public Person(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
            //Marks = new Dictionary<string, List<int>>();
        }
    }
}
