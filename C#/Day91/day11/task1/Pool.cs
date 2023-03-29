using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Pool
    {
    }
    public class Resource : IDisposable
    {
        public string? Name { get; set; }

        ResourcePool? p;
        public void useResource()
        {
            Console.WriteLine("Resource is processing...");
        }

        public void Dispose()
        {
            p?.addToPool(this);
            Console.WriteLine("Resource is disposed ...");
        }

        public Resource(ResourcePool pool)
        {
            p = pool;
            Console.WriteLine($"Resource {Name} {p.pool.Count} is being created ...");
            Thread.Sleep(2500);
            Console.WriteLine($"Resource {Name} is created ...");
        }

    }


    public class ResourcePool
    {
        public Queue<Resource> pool;

        int maxObjects = 5;
        int minObjects = 2;

        public ResourcePool()
        {
            pool = new Queue<Resource>(minObjects);

            for (int i = 0; i < minObjects; i++)
                pool.Enqueue(new Resource(this) { Name = $"R {pool.Count} " });
        }

        public void addToPool(Resource r1)
        {
            if (pool.Count < maxObjects)
                this.pool.Enqueue(r1);
        }



        public Resource getResource()
        {
            if (pool.Count > 0)
                return this.pool.Dequeue();
            else
                return new Resource(this) { Name = $"R {pool.Count}" };
        }

    }
}
