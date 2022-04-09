using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetTask_1.DataLayer;
using System;

namespace UnitTest_ProjetTask_1
{
    public class DataAPI : AbstractDataAPI
    {
        public override void Borrow(string Title, string Author, string Name, string Surname)
        {
            try
            {
                newBorrow(Title, Author, Name, Surname);
                ChangeState(false, Title, Author);                
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
   
        }

        public override void Return(string Title, string Author, string Name, string Surname)
        {
            try
            {
                newReturn(Title, Author, Name, Surname);
                ChangeState(true, Title, Author);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
        }
    }
}