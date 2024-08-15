using PousadaIomar.Entities;

namespace PousadaIomar.Interfaces;

public interface IPersonRepository
{
    Task InitializeAsync();
    Task<int> AddAsync(Person person);
    Task<int> DeleteAsync(Person person);
    Task<int> UpdateAsync(Person person);

    Task<List<Person>> GetAllAsync();
    Task<List<Person>> GetByCompanyAsync(int companyId);
    Task<Person> GetByIdAsync(int id);
    Task<List<Person>> GetByNameAsync(string name);
    
}
