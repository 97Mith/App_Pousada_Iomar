using PousadaIomar.Entities.ValueObjects;

namespace PousadaIomar.Entities;

public sealed class Accommodation : Base
{
    public int Capacity { get; private set; }
    public Price Value { get; private set; }
    public bool HasBathroom { get; private set; }
    public DateTime? ReserveTo { get; private set; }
    public DateTime? AvaibleTo { get; private set; }
    public string Situation { get; private set; }

    public ICollection<Reservation> Reservations { get; set; }
    public ICollection<Person> Guests { get; set; }

    public Accommodation()
    {
        Reservations = new List<Reservation>();
        Guests = new List<Person>();
    }

    public Accommodation(int id, int capacity, Price value, bool hasBathroom, DateTime? reserveTo, DateTime? avaibleTo, string situation)
    {
        ExceptionValidation.When(id < 0, "Invalid ID");
        Id = id;
        Capacity = capacity;
        Value = value;
        HasBathroom = hasBathroom;
        ReserveTo = reserveTo;
        AvaibleTo = avaibleTo;
        Situation = situation;
        Reservations = new List<Reservation>();
        Guests = new List<Person>();
    }

    public Accommodation(int capacity, Price value, bool hasBathroom, DateTime? reserveTo, DateTime? avaibleTo, string situation)
    {
        Capacity = capacity;
        Value = value;
        HasBathroom = hasBathroom;
        ReserveTo = reserveTo;
        AvaibleTo = avaibleTo;
        Situation = situation;
        Reservations = new List<Reservation>();
        Guests = new List<Person>();
    }

    public void UpdateCapacity(int capacity)
    {
        Capacity = capacity;
    }

    public void UpdateValue(Price value)
    {
        Value = value;
    }

    public void UpdateHasBathroom(bool hasBathroom)
    {
        HasBathroom = hasBathroom;
    }

    public void UpdateReserveTo(DateTime? reserveTo)
    {
        ReserveTo = reserveTo;
    }

    public void UpdateAvaibleTo(DateTime? avaibleTo)
    {
        AvaibleTo = avaibleTo;
    }

    public void UpdateSituation(string situation)
    {
        Situation = situation;
    }

    public void AddReservation(Reservation reservation)
    {
        Reservations.Add(reservation);
    }

    public void RemoveReservation(Reservation reservation)
    {
        Reservations.Remove(reservation);
    }

    public void AddGuest(Person guest)
    {
        Guests.Add(guest);
    }

    public void RemoveGuest(Person guest)
    {
        Guests.Remove(guest);
    }
}

