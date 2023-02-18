using System;
using PaktolusApp.Models;

namespace PaktolusApp.Interfaces
{
	public interface IHobbyRepository : IBaseRepository<Hobby>
	{
        IEnumerable<Hobby> getHobbiesByIds(IEnumerable<int> ids);

    }
}

