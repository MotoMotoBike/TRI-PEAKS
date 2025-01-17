using System.Collections.Generic;

public class Table
{
    private readonly List<List<PyramidCard>> _rows;

    public Table(Deck deck)
    {
        _rows = new List<List<PyramidCard>>();
        GenerateTable(deck);
    }

    private void GenerateTable(Deck deck)
    {
        for (int i = 0; i < 4; i++) // создаем строки
        {
            _rows.Add(new List<PyramidCard>());
        }
        
        for (int i = 0; i < 10; i++) // Заполняем нижнюю строку
        {
            _rows[0].Add(new PyramidCard(deck.DrawCard()));
        }
        
        for (int i = 0; i < 9; i++) // Заполняем 2-ю строку
        {
            _rows[1].Add(new PyramidCard(deck.DrawCard()));
            _rows[1][i].DependsOn.Add(_rows[0][i]);
            _rows[1][i].DependsOn.Add(_rows[0][i+1]);
        }

        var dependsOnId = 0;
        for (int i = 0; i < 6; i++) // Заполняем 3-ю строку
        {
            _rows[2].Add(new PyramidCard(deck.DrawCard()));
            _rows[2][i].DependsOn.Add(_rows[1][dependsOnId]);
            _rows[2][i].DependsOn.Add(_rows[1][dependsOnId + 1]);
            if (dependsOnId == 1 || dependsOnId == 5) 
                dependsOnId+=1;
            dependsOnId++;
        }
        dependsOnId = 0;
        for (int i = 0; i < 3; i++) //Заполняем 4-ю строку
        {
            _rows[3].Add(new PyramidCard(deck.DrawCard()));
            _rows[3][i].DependsOn.Add(_rows[2][dependsOnId]);
            _rows[3][i].DependsOn.Add(_rows[2][dependsOnId+1]);
            dependsOnId += 2;
        }
    }

    public bool TryToTakeCard(int row, int index)
    {
        if (_rows[row][index].IsOpen)
        {
            _rows[row][index].IsTaken = true;
            return true;
        }

        return false;
    }

    public List<List<PyramidCard>> GetRows() => _rows;
}