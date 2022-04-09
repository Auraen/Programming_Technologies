//Unusefull warning: checked in the code with if(exist) statement
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
#pragma warning disable CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
#pragma warning disable CS8604 // Existence possible d'un argument de référence null.
#pragma warning disable CS8602 // Déréférencement d'une éventuelle référence null.

namespace ProjetTask_1.DataLayer
{
    public abstract class AbstractDataAPI
    {
        private List<Catalog> catalogs = new List<Catalog>();
        private List<State> states = new List<State>();
        private List<User> users = new List<User>();
        private List<Event> events = new List<Event>();

        private State SearchBook(string Title, string Author, bool available)
        {
            //If there is several copies of the book, there is several state in the list
            Predicate<State> predicate = x => x.Book.Title == Title && x.Book.Author == Author && x.Available == available;
            if (states.Exists(predicate))
            {
                return states.Find(predicate);
            }
            else
            {
                return null;
            }
        }
        private User SearchUser(string Name, string Surname)
        {
            //We suppose that there is only one user with the same name and surname
            Predicate<User> predicate = x => x.Name == Name && x.Surname == Surname;
            if (users.Exists(predicate))
            {
                return users.Find(predicate);
            }
            else
            {
                return null;
            }
        }
        
        public void ChangeState(bool available, string Title, String Author)
        {
            State state = SearchBook(Title, Author, !available);
            state.ChangeState();
        }
        public void newBorrow(String Title, String Author, String Name, String Surname)
        {
            State State = SearchBook(Title, Author, true);
            if (State != null)
            {
                User User = SearchUser(Name, Surname);
                if (User != null)
                {
                    events.Add(new BorrowEvent(State, User));
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
            else
            {
                throw new Exception("Book not found");
            }
        }
        public void newReturn(String Title, String Author, String Name, String Surname)
        {
            User User = SearchUser(Name, Surname);
            if (User == null)
            {
                throw new Exception("User not found");
            }
            else
            {
                State state = SearchBook(Title, Author, false);
                if (state != null)
                {
                    events.Add(new ReturnEvent(state, User));
                } else {
                    throw new Exception("Book not found");
                }
            }
        }
        public void newAddBook(String Title, String Author)
        {
            
            if (!catalogs.Exists(x => x.Title == Title && x.Author == Author))
            {
                catalogs.Add(new Catalog(Title, Author));
            }
            states.Add(new State(catalogs.Find(x => x.Title == Title && x.Author == Author)));

        }
        public void newDeleteBook(String Title, String Author)
        {
            Predicate<Catalog> Predicate = x => x.Title == Title && x.Author == Author;
            Catalog catalog;
            if (catalogs.Exists(Predicate))
            {
                catalog = catalogs.Find(Predicate);
            }
            else
            {
                throw new Exception("Book not found");
            }

            Predicate<State> predicate = x => x.Book == catalog;
            if (states.Exists(predicate) && !states.Find(predicate).Available)
            {
                throw new Exception("Book is borrowed and cannot be removed");
            }
            else
            {
                catalogs.Remove(catalog);
            }
        }
        public void newAddUser(String Name, String Surname)
        {
            users.Add(new User(Name, Surname));
        }
        public int newGetNbUser()
        {
            return users.Count;
        }
        public int newGetNbBook()
        {
            return states.Count;
        }
        public bool newGetAvailability(String Author, String Title)
        {
            State state = SearchBook(Title, Author, true);
            if (state != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public abstract void Borrow(String Title, String Author, String Name, String Surname);
        public abstract void Return(String Title, String Author, String Name, String Surname);

    }
}


#pragma warning restore CS8602 // Déréférencement d'une éventuelle référence null.
#pragma warning restore CS8604 // Existence possible d'un argument de référence null.
#pragma warning restore CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
