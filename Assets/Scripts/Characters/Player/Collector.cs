using UnityEngine;

[RequireComponent(typeof(Wallet))]
public class Collector : MonoBehaviour
{
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Collectible _collectible))
        {
            switch (_collectible.GetType().Name)
            {
                case nameof(Coin):
                    _wallet.AddCoins(_collectible.Value);
                    break;
                case nameof(PowerBonus):
                    _wallet.AddPower(_collectible.Value);
                    break;
                case nameof(HealthBonus):
                    _wallet.AddHealth(_collectible.Value);
                    break;
            }

            print(_wallet.ToString());
            _collectible.Collect();
        }
    }
}
