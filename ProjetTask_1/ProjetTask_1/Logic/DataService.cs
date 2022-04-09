namespace ProjetTask_1.LogicLayer
{
    public class DataService
    {
        private BusinessLogicAPI LogicAPI;
        
        public DataService(BusinessLogicAPI logicAPI)
        {
            LogicAPI = logicAPI;
        }

        public void BorrowBook(String Author, String Title, String Name, String Surname)
        {
            LogicAPI.dataAPI.Borrow(Title, Author, Name, Surname);
        }
        public void ReturnBook(String Author, String Title, String Name, String Surname)
        {
            LogicAPI.dataAPI.Return(Title, Author, Name, Surname);
        }

        public void AddBook(String Author, String Title)
        {
            LogicAPI.dataAPI.newAddBook(Title, Author);
        }
        public void AddUser(String Name, String Surname)
        {
            LogicAPI.dataAPI.newAddUser(Name, Surname);
        }
        public void DeleteBook(String Author, String Title)
        {
            LogicAPI.dataAPI.newDeleteBook(Title, Author);
        }
        
        public int getNbBook()
        {
            return LogicAPI.dataAPI.newGetNbBook();
        }
        public int getNbUser()
        {
            return LogicAPI.dataAPI.newGetNbUser();
        }

        public bool getAvailability(String Author, String Title)
        {
            return LogicAPI.dataAPI.newGetAvailability(Author, Title);
        }
    }
}
