using Papara_cohort;
using System.Collections.Generic;
using System.Linq;

public class FakeCustomerService : ICustomerService
{
    private readonly List<Customer> list;

    public FakeCustomerService()
    {
        list = new List<Customer>
        {
            new Customer() { Id = 1, Name = "FakeTest1", Age = 24 },
            new Customer() { Id = 2, Name = "FakeTest2", Age = 44 },
            new Customer() { Id = 3, Name = "FakeTest3", Age = 34 }
        };
    }

    public List<Customer> GetAll()
    {
        return list;
    }

    public Customer GetById(int id)
    {
        return list.FirstOrDefault(x => x.Id == id);
    }

    public List<Customer> SearchByName(string name)
    {
        return list.Where(x => x.Name.Contains(name)).ToList();
    }

    public List<Customer> ListByName(string name)
    {
        return string.IsNullOrEmpty(name) ? list : list.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
    }

    public List<Customer> Sort(string sortBy, bool descending)
    {
        switch (sortBy?.ToLower())
        {
            case "name":
                return descending ? list.OrderByDescending(x => x.Name).ToList() : list.OrderBy(x => x.Name).ToList();
            case "age":
                return descending ? list.OrderByDescending(x => x.Age).ToList() : list.OrderBy(x => x.Age).ToList();
            default:
                return list;
        }
    }

    public void Add(Customer customer)
    {
        list.Add(customer);
    }

    public void Update(int id, Customer customer)
    {
        var item = list.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            list.Remove(item);
            list.Add(customer);
        }
    }

    public void Delete(int id)
    {
        var item = list.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            list.Remove(item);
        }
    }

    public void Patch(int id, CustomerUpdateModel updateModel)
    {
        var item = list.FirstOrDefault(x => x.Id == id);
        if (item != null)
        {
            if (updateModel.Name != null)
            {
                item.Name = updateModel.Name;
            }

            if (updateModel.Age.HasValue)
            {
                item.Age = updateModel.Age.Value;
            }
        }
    }
}
