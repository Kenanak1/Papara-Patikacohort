using Papara_cohort;

public interface ICustomerService
{
    List<Customer> GetAll();
    Customer GetById(int id);
    List<Customer> SearchByName(string name);
    List<Customer> ListByName(string name);
    List<Customer> Sort(string sortBy, bool descending);
    void Add(Customer customer);
    void Update(int id, Customer customer);
    void Delete(int id);
    void Patch(int id, CustomerUpdateModel updateModel);
}
