using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalV2.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void Save();
        void Rollback();
        void Dispose();
    }
}

