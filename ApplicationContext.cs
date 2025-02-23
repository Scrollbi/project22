using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace project.Entities
{
    public class ApplicationContext : IDisposable
    {
        private bool _isDisposed = false;
        private static readonly ObservableCollection<Request> requests = new();
        private static readonly ObservableCollection<Mechanic> mechanics = new();
        private static readonly ObservableCollection<MechanicRequests> mechanicRequests = new();

        public ObservableCollection<Request> Requests => requests;
        public ObservableCollection<Mechanic> Mechanics => mechanics;
        public ObservableCollection<MechanicRequests> MechanicRequests => mechanicRequests;

       
        public ObservableCollection<Request> GetAllRequests()
        {
            return Requests;
        }

        
        public List<string> GetRequestStatusDescriptions()
        {
            return Enum.GetValues(typeof(RequestStatus))
                       .Cast<RequestStatus>()
                       .Select(status => GetEnumDescription(status))
                       .ToList();
        }

        
        private string GetEnumDescription(RequestStatus status)
        {
            var fieldInfo = status.GetType().GetField(status.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : status.ToString();
        }

        public void AddMechanic(string fullName)
        {
            mechanics.Add(new Mechanic { LFP = fullName });
        }

        public void AddRequest(Request request)
        {
            requests.Add(request); 
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
               
                if (disposing)
                {
                    
                }
                _isDisposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
