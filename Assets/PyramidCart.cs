using System;
using System.Collections.Generic;
using System.Linq;

public class PyramidCard 
{
    public Card Card { get; }
    public bool IsOpen => DependsOn.Count == 0;
    public List<PyramidCard> DependsOn { get; }

    public PyramidCard(Card card)
    {
        Card = card;
        DependsOn = new List<PyramidCard>();
    }
}