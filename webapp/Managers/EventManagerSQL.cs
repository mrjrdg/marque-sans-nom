using System;
using Services;
using Models;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Managers
{
    public class EventManagerSQL : IEventServices
    {
        public Task<Event> Create(Event model)
        {
            throw new NotImplementedException();
        }

        public Task<Event> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Event> Edit(Event model)
        {
            throw new NotImplementedException();
        }

        public Task<Event> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Event>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}