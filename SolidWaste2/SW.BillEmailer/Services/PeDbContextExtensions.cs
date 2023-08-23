﻿using Microsoft.EntityFrameworkCore;
using PE.DAL.Contexts;
using PE.DM;
using SW.DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SW.BillEmailer.Services;

public static class PeDbContextExtensions
{
    #region Person Entity

    public static Task<PersonEntity> GetPersonEntityById(this PeDbContext db, int id)
    {
        return db.People
            .Include(p => p.Code)
            .Include(p => p.Addresses)
            .Include(p => p.Emails)
            .Include(p => p.Phones)
            .Where(p => p.Id == id)
            .SingleAsync();
    }

    #endregion

    #region Email



    #endregion
}