using UnityEngine;

public class BarParent : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Show();
        Health.Changed += Show;
    }

    private void OnDisable()
    {
        Health.Changed -= Show;
    }

    protected virtual void Show()
    {
        print($"Health: {Health.Value} / {Health.MaxValue}");
    }
}
