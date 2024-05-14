using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.BusinessLogic.Events.Notifications
{

    public class SearchNotification : INotification
    {
        public string Type { get; }
        public string Value { get; }
        public string SearchDate { get; }

        public SearchNotification(string type, string value, string searchDate)
        {
            Type = type;
            Value = value;
            SearchDate = searchDate;
        }
    }
}
