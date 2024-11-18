namespace basketball.Models
{
    public record CreatePlayerDto(string Name, int Height, int Weight);//create new player
    public record UpdatePlayerDto(string Name, int Height, int Weight);//update player
    public record CreateMatchdataDto(DateTime CreatedTime,DateTime Belep, int Try, int Goal, int Fault, Guid PlayerId);//create new matchdata
    public record UpdateMatchdataDto(DateTime Lejon, int Try, int Goal, int Fault, DateTime UpdatedTime);//update matchdata
}
