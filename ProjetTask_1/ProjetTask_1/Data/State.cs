namespace ProjetTask_1.DataLayer
{
    internal class State
    {
        public Catalog Book { get; }
        public bool Available = true;

        public State(Catalog book)
        {
            Book = book;
        }

        internal void ChangeState()
        {
            if (Available)
            {
                Available = false;
            }
            else
            {
                Available = true;
            }
        }
    }
}
