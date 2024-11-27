namespace CalorieTrackerApp.Models
{
    public class ErrorViewModel
    {
        // This property stores the request ID, which is a unique identifier for the error request.
        public string? RequestId { get; set; }

        // This is a read-only property that checks if the RequestId is not null or empty.
        // It returns true if RequestId has a value.
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
