using System;
using PaktolusApp.Interfaces;
using PaktolusApp.Models;

namespace PaktolusApp.Repositories
{
    public class HobbyRepository : BaseRepository<Hobby>, IHobbyRepository
    {
        protected DbTestContext context;

        public HobbyRepository(DbTestContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Hobby> getHobbiesByIds(IEnumerable<int> ids)
        {
            if (ids == null) return null;

            return this.context.Hobbies.Where(x => ids.Contains(x.Id));
        }
    }
}

