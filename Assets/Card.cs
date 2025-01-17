using System;

public class Card 
{
    public int Value { get; } // Значение карты (1 — туз, 11 — валет и т.д.)
    public string Suit { get; } // Масть карты (червы, пики, и т.д.)

    public Card(int value, string suit)
    {
        Value = value;
        Suit = suit;
    }
}