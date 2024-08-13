using PousadaIomar.Entities.ValueObjects;
using SQLite;

namespace PousadaIomar.Entities;

public abstract class Base
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; protected set; }
    public Name Name { get; protected set; }
}
