﻿using Solidify.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solidify.Domain.Interfaces
{
    public interface ICompanyRepository
    {
        Task AddCompany(Company company);
    }
}
