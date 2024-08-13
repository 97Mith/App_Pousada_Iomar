using PousadaIomar.Entities;

namespace PousadaIomar.Interfaces;

public interface ICompanyRepository
{
    Task<int> AddAsync(Company company);
    Task<int> DeleteAsync(Company company);
    Task<List<Company>> GetAllAsync();
    Task<Company> GetByIdAsync(int id);
    Task<List<Company>> GetByNameAsync(string name);
    Task<int> UpdateAsync(Company company);
}
