using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingWeapon : Weapon
{
    // Variables

    public float swingDegrees = 90;

    public override void Attack()
    {
        if (canAttack)
        {
            // Start the attack cooldown
            Invoke("AttackReset", 60f / attackRate);
            // Rotate to starting position
            transform.localEulerAngles = new Vector3(0, 0, swingDegrees);
            // Turn on the weapon
            EnableWeapon();
            // Swing down
            StartCoroutine(Swing());
            // Disable the weapon
            Invoke("DisableWeapon", attackDuration);
        }
    }

    IEnumerator Swing() // Swings the weapon
    {
        float degs = 0;
        while (degs < swingDegrees)
        {
            transform.Rotate(Vector3.forward * (1 / attackDuration * swingDegrees * 2) * Time.deltaTime);
            degs += 1 / attackDuration * swingDegrees * 2 * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
