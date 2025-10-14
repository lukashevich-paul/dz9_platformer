using System;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : BehaviorType
{
    private Player _player = null;

    public void Init(Player player)
    {
        _player = player;
    }

    private void FixedUpdate()
    {
        if (_player != null)
        {
            float direction = _player.transform.position.x - transform.position.x;

            if (direction != 0)
            {
                if (direction < 0)
                    direction = DirectionNegative;
                else if (direction > 0)
                    direction = DirectionPositive;

                _mover.Move(direction);
                _flipper.Flip(direction);
            }
        }
    }

}
