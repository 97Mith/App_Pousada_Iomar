using PousadaIomar.Entities;
using PousadaIomar.Interfaces;
using SQLite;

namespace PousadaIomar.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly SQLiteAsyncConnection _connection;

    public PersonRepository(SQLiteAsyncConnection dbPath)
    {
        _connection = dbPath;
        _connection.CreateTableAsync<Person>().Wait();
    }

    public Task<List<Person>> GetAllAsync()
    {
        return _connection.Table<Person>().ToListAsync();
    }

    public Task<int> AddAsync(Person person)
    {
        return _connection.InsertAsync(person);
    }

    public Task<int> UpdateAsync(Person person)
    {
        return _connection.UpdateAsync(person);
    }

    public Task<int> DeleteAsync(Person person)
    {
        return _connection.DeleteAsync(person);
    }

    public Task<Person> GetByIdAsync(int id)
    {
        return _connection.Table<Person>().Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Person>> GetByNameAsync(string name)
    {
        var allPersons = await _connection.Table<Person>().ToListAsync();
        return allPersons.Where(p => p.Name.Value.Contains(name)).ToList();
    }

    public Task<List<Person>> GetByCompanyAsync(int companyId)
    {
        return _connection.Table<Person>().Where(p => p.CompanyId == companyId).ToListAsync();
    }
}
