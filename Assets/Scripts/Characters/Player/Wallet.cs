using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int Coins { get; private set; }
    public int Power { get; private set; }
    public int Health { get; private set; }

    public void AddCoins(int value)
    {
        Coins += value;
    }

    public void AddPower(int value)
    {
        Power += value;
    }

    public void AddHealth(int value)
    {
        Health += value;
    }

    public void DecreaseHealth()
    {
        Health--;
    }

    public string ToString()
    {
        return $"coins: {Coins},  power: {Power},  health: {Health}";
    }
}
