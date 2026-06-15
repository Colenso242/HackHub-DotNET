using HackHub_DotNET.Domain.Enums;

namespace HackHub_DotNET.Domain;

public class User : BaseEntity
{
    public string Username { get; private set; }
    //Todo: hash and salt pw
    public string Password { get; private set; }
    public UserRole UserRole { get; internal set; } = UserRole.User;

    // Optional: a user is not necessarily tied to a team or a hackathon.
    public Team? Team { get; internal set; }
    public Hackathon? Hackathon { get; internal set; }

    public User(string username, string password, UserRole userRole = UserRole.User)
    {
        Username = ValidateUsername(username);
        Password = ValidatePassword(password);
        UserRole = userRole;
    }

    public bool IsTeamLeader() => Team is not null && this == Team.Leader;

    private static string ValidateUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username is required.", nameof(username));
        if (username.Length > 50)
            throw new ArgumentException("Username must be at most 50 characters.", nameof(username));
        return username;
    }

    private static string ValidatePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password is required.", nameof(password));
        if (password.Length > 120)
            throw new ArgumentException("Password must be at most 120 characters.", nameof(password));
        return password;
    }
}