namespace ProjetTask_1.DataLayer
{
    internal class User
    {
        public string Surname { get; set; }
        public string Name { get; set; }

        public User(string name, string surname)
        {
            this.Surname = surname;
            this.Name = name;
        }

    }
}
