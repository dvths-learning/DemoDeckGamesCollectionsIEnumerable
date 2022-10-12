using DemosDeckGames.ConsoleApp.Models.DeckDefault.Enums;
namespace DemosDeckGames.ConsoleApp.Models.DeckDefault;

public class DeckDefault
{
    //Fields
    private Cards[] _cardsCollection;

    //Properties
    public IEnumerable<Cards> CardsCollection => _cardsCollection.AsEnumerable();

    public DeckDefault()
    {
        InicializePlaingCards();

    }

    // Public Methods
    public virtual void InicializePlaingCards()
    {
        // Obtem os valores do enum
        var suitArray = Enum.GetValues<Suit>();

        var cardsCollectionTemp = new List<Cards>();

        foreach (var suit in suitArray)
        {
            // Cria cartas as cartas de 0 a 10 ( as outras três serão adicionadas depois)
            for (int i = 1; i <= 10; i++)
                cardsCollectionTemp.Add(
                        new Cards
                        {
                            Suit = suit,
                            Symbol = i.ToString(),
                            Value = i
                        }
                );

            // Cria as ultimas 3 cartas restantes Q, J, K  
            cardsCollectionTemp.Add(new Cards { Suit = suit, Symbol = "J", Value = 11 });
            cardsCollectionTemp.Add(new Cards { Suit = suit, Symbol = "Q", Value = 12 });
            cardsCollectionTemp.Add(new Cards { Suit = suit, Symbol = "K", Value = 13 });

        }
        _cardsCollection = cardsCollectionTemp.ToArray();
    }

    public virtual void ShufleCards()
    {
        var random = new Random();

        var shuffledcards = 
            from card in CardsCollection
            // gera um objeto anônimo 
            select new {
                Card = card,
                Value = random.Next()
            };
        // Expression tree https://learn.microsoft.com/en-US/dotnet/csharp/programming-guide/concepts/expression-trees/
        MakeNewDeckGame(shuffledcards.OrderBy(q => q.Value).Select(q => q.Card).ToArray());
    }

    //Protected Methods
    protected void MakeNewDeckGame(Cards[] cardCollection)
    {
        _cardsCollection = cardCollection;
    }

}
