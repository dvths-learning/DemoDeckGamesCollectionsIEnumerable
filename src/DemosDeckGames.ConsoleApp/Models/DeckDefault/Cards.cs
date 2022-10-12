using DemosDeckGames.ConsoleApp.Models.DeckDefault.Enums;
namespace DemosDeckGames.ConsoleApp.Models.DeckDefault;

public class Cards
{
    // `init` inidica que o valort será provido na inicialização da classe
    public Suit Suit { get; init; }
    public int Value { get; init;  }
    public string Symbol { get; init; }

}
