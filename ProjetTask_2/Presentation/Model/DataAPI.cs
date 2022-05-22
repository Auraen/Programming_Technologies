using ProjetTask_2.DataLayer;
using System;

namespace View.Model
{
    public class DataAPI : AbstractDataAPI
    {
        public override void Borrow(string Title, string Author, string Name, string Surname)
        {
            newBorrow(Title, Author, Name, Surname);
            newChangeAvailabilityState(Title, Author, true);

        }

        public override void Return(string Title, string Author, string Name, string Surname)
        {
            newReturn(Title, Author, Name, Surname);
            newChangeAvailabilityState(Title, Author, false);
        }
    }
}