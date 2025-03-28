namespace FinishedGamesAPI.Models;

public class Game : Base
{
    public string Title {get; set; }

    public string Description {get; set; }

    public string Platform {get; set; }

    public string Genre {get; set; }

    public string Grade {get; set; }
}