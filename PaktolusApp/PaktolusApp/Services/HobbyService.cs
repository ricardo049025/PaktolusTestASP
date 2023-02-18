using System;
using PaktolusApp.Interfaces;
using PaktolusApp.Interfaces.Services;
using PaktolusApp.Models;

namespace PaktolusApp.Services
{
    public class HobbyService : BaseService<Hobby>, IHobbyService
    {
        protected IHobbyRepository hobbyRepository;

        public HobbyService(IHobbyRepository hobbyRepository) : base(hobbyRepository)
        {
            this.hobbyRepository = hobbyRepository;
        }

    }
}

