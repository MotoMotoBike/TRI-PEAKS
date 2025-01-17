using System.Collections.Generic;
using System.Linq;

public class PyramidCard
{
    public Card Card { get; }
    public bool IsOpen => DependsOn.Count == 0 || DependsOn.Count(x => x.IsTaken) == 2;
    public bool IsTaken { get; set; } = false;
    public List<PyramidCard> DependsOn { get; }

    public PyramidCard(Card card)
    {
        Card = card;
        DependsOn = new List<PyramidCard>();
    }
}