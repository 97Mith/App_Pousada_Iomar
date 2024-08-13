using PousadaIomar.Entities;
using PousadaIomar.Interfaces;
using SQLite;

namespace PousadaIomar.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly SQLiteAsyncConnection _connection;


    public CompanyRepository(SQLiteAsyncConnection dbPath)
    {
        _connection = dbPath;
        _connection.CreateTableAsync<Company>().Wait();
    }

    public Task<List<Company>> GetAllAsync()
    {
        return _connection.Table<Company>().ToListAsync();
    }

    public Task<int> AddAsync(Company company)
    {
        return _connection.InsertAsync(company);
    }

    public Task<int> UpdateAsync(Company company)
    {
        return _connection.UpdateAsync(company);
    }

    public Task<int> DeleteAsync(Company company)
    {
        return _connection.DeleteAsync(company);
    }

    public Task<Company> GetByIdAsync(int id)
    {
        return _connection.Table<Company>()
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
    }
    public async Task<List<Company>> GetByNameAsync(string name)
    {
        var allCompanies = await GetAllAsync();
        return allCompanies.Where(c => c.Name.Value.Contains(name)).ToList();
    }
}
