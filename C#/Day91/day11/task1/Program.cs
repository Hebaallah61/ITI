// See https://aka.ms/new-console-template for more information
using task1;

Console.WriteLine("Hello, World!");
ResourcePool pool = new ResourcePool();

Resource? r = pool.getResource();

Console.WriteLine(r.GetHashCode());

r.useResource();

r.Dispose();

r = null;