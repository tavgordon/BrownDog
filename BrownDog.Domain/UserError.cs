using FluentResults;

namespace BrownDog.Domain;

public class UserError : Error
{
    public UserError(string message) : base(message)
    {
    }
}