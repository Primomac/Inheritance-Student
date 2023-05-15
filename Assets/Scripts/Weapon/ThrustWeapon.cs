using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustWeapon : Weapon
{
    // Variables

    public float thrustDistance = 1;

    public override void Attack()
    {
        if (canAttack)
        {
            // Start the attack cooldown
            Invoke("AttackReset", 60f / attackRate);
            // Turn on the weapon
            EnableWeapon();
            // Push weapon forward
            StartCoroutine(Thrust());
            // Disable the weapon
            Invoke("DisableWeapon", attackDuration);
        }
    }

    public IEnumerator Thrust()
    {
        float dist = 0;
        while (dist < thrustDistance)
        {
            transform.Translate(Vector2.right * (1 / attackDuration * thrustDistance * 2) * Time.deltaTime);
            dist += 1 / attackDuration * thrustDistance * 2 * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        while (thrustDistance < dist && dist < thrustDistance * 2)
        {
            transform.Translate(Vector2.left * (1 / attackDuration * thrustDistance * 2) * Time.deltaTime);
            dist += 1 / attackDuration * thrustDistance * 2 * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
