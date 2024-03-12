using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Data.Contracts
{
    public interface ITeamPrototype
    {
        ITeamPrototype Clone();
    }
}
