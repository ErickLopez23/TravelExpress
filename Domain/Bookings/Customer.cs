namespace Domain.Bookings;

public partial record Customer
{
    public string Name { get; init; }
    public string Phone { get; init; }
    public string Email { get; init; }

    public Customer(string name, string phone, string email)
    {
        Name = name;
        Phone = phone;
        Email = email;
    }

    public static Customer? Create(string name, string phone, string email)
    {
        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(email))
        {
            return null;
        }

        return new Customer(name, phone, email);
    }
}
