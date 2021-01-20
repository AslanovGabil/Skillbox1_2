﻿using Bot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
    public interface IJsonService<T>
    {
        IEnumerable<User> GetUsers();
        Task AddUsers(User user);
    }
}
