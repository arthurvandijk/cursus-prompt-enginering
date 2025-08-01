
namespace Cursus.Functions.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidEmail(string email)
        {
            // Basic validation - trainees can enhance this
            return !string.IsNullOrEmpty(email) && email.Contains("@");
        }

        public static bool IsValidTaskTitle(string title)
        {
            // Simple validation - can be improved
            return !string.IsNullOrEmpty(title) && title.Length > 2;
        }

        public static List<string> ValidateCreateTaskRequest(object request)
        {
            var errors = new List<string>();
            
            // Basic validation - trainees can enhance with proper validation
            // This is intentionally simple for training purposes
            
            return errors;
        }
    }

    public static class ResponseHelper
    {
        public static object CreateErrorResponse(string message, int statusCode = 400)
        {
            return new
            {
                Error = true,
                Message = message,
                StatusCode = statusCode,
                Timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")
            };
        }

        public static object CreateSuccessResponse(object data, string message = "Success")
        {
            return new
            {
                Success = true,
                Message = message,
                Data = data,
                Timestamp = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")
            };
        }
    }
}
