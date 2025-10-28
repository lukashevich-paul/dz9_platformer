using UnityEngine.UI;

public class DamageButton : ButtonParent
{
    private void OnEnable()
    {
        Button.onClick.AddListener(Damage);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(Damage);
    }

    private void Damage()
    {
        Health.TakeDamage(HealthValue);
    }
}
