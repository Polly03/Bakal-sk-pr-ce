namespace Shared.Models
{
    public enum RookWays
    {
        up,
        down, 
        left, 
        right
    }

    public enum BishopWays
    {
        upLeft,
        upRight,
        downLeft,
        downRight
    }
    public enum RegisterError
    {
        None = 0,
        UsernameTaken = 1,
        EmailTaken = 2,
        InternalError = 3
    }
}
