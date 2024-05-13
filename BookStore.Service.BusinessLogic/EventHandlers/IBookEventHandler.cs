using BookStore.Service.BusinessLogic.EventArgs;

namespace BookStore.Service.BusinessLogic.EventHandlers
{
    public interface IBookEventHandler
    {
        void OnBookAdded(object sender, BookEventArgs e);
    }
}
