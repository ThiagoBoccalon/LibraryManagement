﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core.Repositories
{
    public interface IBasedRepository
    {
        Task SaveChangesAsync();
    }
}
