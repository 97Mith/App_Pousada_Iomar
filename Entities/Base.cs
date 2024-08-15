using SQLite;

namespace PousadaIomar.Entities;

public abstract class Base
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; protected set; }
    
    [NotNull, MaxLength(50)]
    public string Name { get; protected set; }
}
