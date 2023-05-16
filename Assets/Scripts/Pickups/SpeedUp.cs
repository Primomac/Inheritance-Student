using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : PickUp
{
    // Variables

    public float speedBonus;

    private void Awake()
    {
        speedBonus = Mathf.Round(Random.Range(1f, 6f) * 1) / 10;
    }

    public override void ActivatePickUp()
    {
        base.ActivatePickUp();
        player.moveSpeed += speedBonus;
    }
}
