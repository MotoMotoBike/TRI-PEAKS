using System;
using System.Collections.Generic;
using System.Linq;

public class Deck
{
    private List<Card> _cards;

    public Deck()
    {
        _cards = new List<Card>();
        var suits = new[] { "Hearts", "Diamonds", "Clubs", "Spades" };

        foreach (var suit in suits)
        {
            for (int value = 1; value <= 13; value++)
            {
                _cards.Add(new Card(value, suit));
            }
        }
        Shuffle();
    }

    private void Shuffle()
    {
        var random = new Random();
        _cards = _cards.OrderBy(x => random.Next()).ToList();
    }

    public Card DrawCard()
    {
        if (_cards.Count == 0) throw new InvalidOperationException("Deck is empty.");
        var card = _cards[0];
        _cards.RemoveAt(0);
        return card;
    }

    public int Count => _cards.Count;
}