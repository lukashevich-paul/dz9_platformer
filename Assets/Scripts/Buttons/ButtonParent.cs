using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonParent : MonoBehaviour
{
    [SerializeField, Range(0, 99)] protected float HealthValue = 25f;
    [SerializeField] protected Health Health;

    protected Button Button;

    private void Awake()
    {
        Button = GetComponent<Button>();
    }
}
