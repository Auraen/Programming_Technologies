namespace ProjetTask_1.DataLayer
{
    internal abstract class Event
    {
        public State state { get; set; }
        public User user { get; set; }
        public String description { get; set; }
    }

    internal class BorrowEvent : Event
    {
        internal BorrowEvent(State state, User User)
        {
            this.state = state;
            this.user = User;
            this.description = "Borrowed";
        }

    }

    internal class ReturnEvent : Event
    {
        internal ReturnEvent(State state, User User)
        {
            this.state = state;
            this.user = User;
            this.description = "Returned";
        }

    }
}
