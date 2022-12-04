using System;

namespace HospitalV2.Infrastructure

public class Container : IContainer
{
    private readonly HospitalManagementDbContext context;


    private Hashtable repositorty;

    public Container(HospitalManagementDbContext context)
    {
        this.context = context;
        //this.context.Users.Include
    }

    public IGenericRepository<T> Repository<T>() where T : class
    {
        if (this.repositorty == null) this.repositorty = new Hashtable();

        var type = typeof(T).Name;

        if (!this.repositorty.ContainsKey(type))
        {
            var repositoryType = typeof(GenericRepository<>);
            var repositoryInstace = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)),
                this.context);

            this.repositorty.Add(type, repositoryInstace);
        }

        return (IGenericRepository<T>)this.repositorty[type];
    }
}
