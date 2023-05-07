using VirtualServiceWeb.Data.Models;
using VirtualServiceWeb.Repositories.Interfaces;

namespace VirtualServiceWeb.Data.DbSeed;

public class DbSeed : IDbSeed
{
    private readonly IInstanceRepository _instanceRepository;

    public DbSeed(IInstanceRepository instanceRepository)
    {
        _instanceRepository = instanceRepository;
    }

    public void Seed()
    {
        InstancesSeed();   
    }

    private void InstancesSeed()
    {
        if (!_instanceRepository.Any())
        {
            List<InstanceModel> instances = new List<InstanceModel>();
            for (int i = 0; i < 10; i++)
            {
                var instance = new InstanceModel()
                {
                    OperationSystem = "Ubuntu",
                    InstanceName = $"Test{i}",
                    Ram = 2,
                    CoreCount = 1
                };

                instances.Add(instance);
            }

            _instanceRepository.AddList(instances);
        }
    }
}