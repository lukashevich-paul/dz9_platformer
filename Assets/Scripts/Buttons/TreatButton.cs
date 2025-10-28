using UnityEngine.UI;

public class TreatButton : ButtonParent
{
    private void OnEnable()
    {
        Button.onClick.AddListener(ToTreat);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(ToTreat);
    }

    private void ToTreat()
    {
        Health.TakeCure();
    }
}
