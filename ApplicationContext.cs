using System;
using System.Collections.ObjectModel;
using project.Entities;

namespace project
{
    public class RequestStatusChangedEventArgs : EventArgs
    {
        public Request Request { get; }
        public RequestStatus NewStatus { get; }

        public RequestStatusChangedEventArgs(Request request, RequestStatus newStatus)
        {
            Request = request;
            NewStatus = newStatus;
        }
    }


    public class ApplicationContext : IDisposable
    {
        private bool _isDisposed = false;
        private static readonly ObservableCollection<Request> requests = new();
        private static readonly ObservableCollection<Mechanic> mechanics = new();
        private static readonly ObservableCollection<MechanicRequests> mechanicRequests = new();

        public ObservableCollection<Request> Requests => requests;
        public ObservableCollection<Mechanic> Mechanics => mechanics;
        public ObservableCollection<MechanicRequests> MechanicRequests => mechanicRequests;

        
        public event EventHandler<RequestStatusChangedEventArgs> RequestStatusChanged;

       
        public void UpdateRequestStatus(Request request, RequestStatus newStatus)
        {
            
            request.Status = newStatus;
            

            
            OnRequestStatusChanged(new RequestStatusChangedEventArgs(request, newStatus));
        }
        public void AddRequest(Request request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Заявка не может быть null.");
            }

            requests.Add(request);
            
        }
       
        protected virtual void OnRequestStatusChanged(RequestStatusChangedEventArgs e)
        {
            RequestStatusChanged?.Invoke(this, e);
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
