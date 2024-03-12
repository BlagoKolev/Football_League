﻿using FootballLeague.DTOs;

namespace FootballLeague.Services.Contracts
{
    public interface IStatisticService
    {
        Task<ICollection<GetLeagueDto>> GetAllLeagues();
    }
}
