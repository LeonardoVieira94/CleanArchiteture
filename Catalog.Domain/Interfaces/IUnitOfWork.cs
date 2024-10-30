﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Interfaces;

public interface IUnitOfWork
{
    IRepository<T> Repository<T> () where T : class;
    Task CommitAsync();
}