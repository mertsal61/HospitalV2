using System;

namespace HospitalV2.Infrastructure

    public interface IContainer
{
    IGenericRepository<T> Repository<T>() where T : class;
}