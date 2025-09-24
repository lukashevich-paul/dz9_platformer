using UnityEngine;

public class Flipper : MonoBehaviour
{
    public void Flip(float direction)
    {
        if (direction > 0)
        {
            transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (direction < 0)
        {
            transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        }
    }
}
