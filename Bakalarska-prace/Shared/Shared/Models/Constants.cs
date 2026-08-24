namespace Shared.Constants
{
    public static class Constants
    {
        public static class ServerUrls
        {
            public const string HttpUrl = "http://localhost:7000";
            public const string SignalRUrl = "https://localhost:7000";
        }

        public static class Routes
        {
            public const string Auth = "Auth";
            public const string ChatHub = "ChatHub";
            public const string GameHub = "GameHub";
        }

        public static class AuthMethods
        {
            public const string Register = Routes.Auth + "/register";
            public const string Login = Routes.Auth + "/login";
        }

        public static class ChatHubMethods
        {
            public const string SendMessage = "/SendMessage";
            public const string ReceiveMessage = "/ReceiveMessage";
        }
    }
}
