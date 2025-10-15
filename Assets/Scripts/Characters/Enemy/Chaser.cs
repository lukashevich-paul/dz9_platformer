using UnityEngine;

public class Chaser : BehaviorType
{
    private Transform _targetTransform = null;

    public void Init(Transform transform)
    {
        _targetTransform = transform;
    }

    private void FixedUpdate()
    {
        if (_targetTransform != null)
        {
            float direction = _targetTransform.position.x - transform.position.x;

            if (direction != 0)
            {
                if (direction < 0)
                    direction = DirectionNegative;
                else if (direction > 0)
                    direction = DirectionPositive;

                Mover.Move(direction);
                Flipper.Flip(direction);
            }
        }
    }

}
