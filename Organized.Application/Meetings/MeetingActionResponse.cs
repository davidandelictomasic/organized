namespace Organized.Application.Meetings
{
    public class MeetingActionResponse
    {
        public bool Success { get; init; }
        public int? MeetingId { get; init; }
        public string? ErrorMessage { get; init; }

        public MeetingActionResponse(bool success, int? meetingId = null, string? errorMessage = null)
        {
            Success = success;
            MeetingId = meetingId;
            ErrorMessage = errorMessage;
        }

        public MeetingActionResponse() { }
    }
}
