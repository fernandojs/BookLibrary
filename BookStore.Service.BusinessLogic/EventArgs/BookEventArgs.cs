namespace BookStore.Service.BusinessLogic.EventArgs
{
    public class BookEventArgs
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Status { get; private set; }

        public BookEventArgs(string title, string author, string status)
        {
            Title = title;
            Author = author;
            Status = status;
        }
    }
}
