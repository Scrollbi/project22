using project.Entities;
using project;

public class RequestStatusChangedEventArgs : EventArgs
{
    public Request Request { get; set; }
    public RequestStatus NewStatus { get; set; }

    public RequestStatusChangedEventArgs(Request request, RequestStatus newStatus)
    {
        Request = request;
        NewStatus = newStatus;
    }
}
