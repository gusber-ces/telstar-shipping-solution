using RoutePlanning.Infrastructure.Database;

namespace RoutePlanning.Domain.Users;

public class UserService
{
    private RoutePlanningDatabaseContext _context;

    public UserService(RoutePlanningDatabaseContext context)
    {
        _context = context;
    }

    public List<User> GetUsers()
    {
        var users = _context.Users ?? throw new ArgumentNullException();
        return users.AsQueryable().ToList();
    }

    public void AddUser(User user)
    {
        var users = _context.Users ?? throw new ArgumentNullException();
        users.Add(user);
        _context.SaveChangesAsync();
    }
}
