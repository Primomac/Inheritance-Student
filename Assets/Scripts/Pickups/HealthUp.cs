using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : PickUp
{
    // Variables

    public float flatHeal;
    public float scaleHeal;
    public float healthBonus;

    public Sprite smallHealth;
    public Sprite mediumHealth;
    public Sprite largeHealth;

    private void Awake()
    {
        // Determine Health Size
        float healthSize = Random.Range(0, 101);
        if (healthSize <= 66)
        {
            // Size: Small
            GetComponent<SpriteRenderer>().sprite = smallHealth;
            flatHeal = Random.Range(0, 11);
            scaleHeal = Random.Range(10, 26);
            healthBonus = 0;
        }
        else if (healthSize > 66 && healthSize <= 91)
        {
            // Size: Medium
            GetComponent<SpriteRenderer>().sprite = mediumHealth;
            flatHeal = Random.Range(5, 36);
            scaleHeal = Random.Range(25, 51);
            healthBonus = Random.Range(0, 11);
        }
        else if (healthSize > 91)
        {
            // Size: Large
            GetComponent<SpriteRenderer>().sprite = largeHealth;
            flatHeal = Random.Range(10, 66);
            scaleHeal = Random.Range(50, 76);
            healthBonus = Random.Range(10, 21);
        }
    }

    public override void ActivatePickUp()
    {
        base.ActivatePickUp();
        if (player.health < player.maxHealth)
        {
            player.health += Mathf.Round(player.maxHealth * (scaleHeal / 100)) + flatHeal;
            if (player.health > player.maxHealth)
            {
                player.health = player.maxHealth;
            }
        }
        else
        {
            player.maxHealth += healthBonus;
            player.health = player.maxHealth;
        }
    }
}
