using UnityEngine;

public class Flipper : MonoBehaviour
{
    private Quaternion _forward = Quaternion.Euler(Vector3.zero);
    private Quaternion _back = Quaternion.Euler(Vector3.up * 180f);

    public void Flip(float direction)
    {
        if (direction > 0)
        {
            transform.rotation = _forward;
        }
        else if (direction < 0)
        {
            transform.rotation = _back;
        }
    }
}
