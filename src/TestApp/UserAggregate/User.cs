namespace TestApp.UserAggregate;

public class User
{
    public int Id { get; private set; }
    public required FirstName FirstName { get; set; }
    public required LastName LastName { get; set; }
    public BirthDate? BirthDate { get; set; }
}
