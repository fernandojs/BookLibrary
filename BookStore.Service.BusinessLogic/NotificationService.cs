using BookStore.Service.BusinessLogic.EventArgs;
using BookStore.Service.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.BusinessLogic
{
    public class NotificationService : INotificationService
    {
        public void OnBookAdded(object sender, BookEventArgs e)
        {         
            Console.WriteLine($"Notification: A book has been added: {e.Title}, Authorr: {e.Author}, Status: {e.Status}");
        }
    }
}
