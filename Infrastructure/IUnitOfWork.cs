using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebJayThomDhuang.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}