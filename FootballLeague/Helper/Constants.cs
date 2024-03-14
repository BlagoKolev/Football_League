namespace FootballLeague.Helper
{
    public static class Constants
    {
        public const string LeagueNotFound = "League with such name does not exist.";
        public const string ErrorProcessingRequest = "An error occurred while processing the request.";
        public const string LeagueCreationFailed = "The League was not created successfully";
        public const string LeagueCreationSuccessfull = "The League was created successfully";
        public const string LeagueAlreadyHasFixturesCreated = "This League already has Fixtures created.";
        public const string FixturesForLeagueCreatedSuccessfully = "Fixtures for this League was created. Please proceed with playing maches.";
        public const string LeagueOrTeamNotExist = "League or Team does not exists.";
        public const string InvaildInputData = "Invalid input data";

        public const byte WinPoints = 3;
        public const byte DrawPoints = 1;
        public const byte LosePoints = 0;
    }
}
