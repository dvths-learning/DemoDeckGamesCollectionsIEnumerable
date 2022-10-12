namespace DemosDeckGames.ConsoleApp.Models.DeckDefault;

public class TrucoDeck
    : DeckDefault
{
    public override void InicializePlaingCards()
    {
        base.InicializePlaingCards();

        var invalidCardsForThisDackGame = new[]{8, 9, 10};

        // Cursor que irá passar por cada carta filtrando todos os valores das cartas que não estão nas cartas invalidas para o baralho do truco
        var trucoCards = CardsCollection.Where(carta => !invalidCardsForThisDackGame.Contains(carta.Value));

        // Materializ as cartas do truco
        MakeNewDeckGame(trucoCards.ToArray());
    }
}
