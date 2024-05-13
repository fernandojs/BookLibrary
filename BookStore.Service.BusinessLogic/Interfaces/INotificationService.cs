using BookStore.Service.BusinessLogic.EventArgs;

namespace BookStore.Service.BusinessLogic.Interfaces
{
    public interface INotificationService
    {
        void OnBookAdded(object sender, BookEventArgs e);
    }
}
