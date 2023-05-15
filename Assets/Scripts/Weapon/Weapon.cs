using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the Weapon class, which all weapons will inherit from.
public class Weapon : MonoBehaviour
{
    // These variables will be used by all subclasses of Weapon.
    public Rigidbody2D rb; // The rigidbody component of the weapon.
    public SpriteRenderer sr; // The sprite renderer component of the weapon.
    public BoxCollider2D boxCollider; // The box collider component of the weapon.

    // These variables can be adjusted for each subclass of Weapon.
    public bool canAttack = true; // Whether or not the weapon can currently attack.
    public float attackDuration; // The duration of the weapon's attack.
    public float attackRate; // The rate at which the weapon can attack.
    public float damage; // The amount of damage the weapon can deal.
    public float elementChance = 10;
    public float elementDamage = 0;
    public string element = "Physical"; // What type of damage the weapon deals. Enemies may take more or less damage from certain elements.
    public string subElement = "Fire";


    // Start is called before the first frame update.
    void Start()
    {
        // Get the rigidbody, sprite renderer, and box collider components of the weapon.
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        // Disable the weapon to start with.
        DisableWeapon();
    }

    // This is a virtual function that can be overridden by subclasses of Weapon.
    public virtual void Attack()
    {
        // Check if the weapon can currently attack.
        if (canAttack)
        {
            // Enable the weapon and the box collider, and set a timer to disable the weapon.
            EnableWeapon();
            Invoke("DisableWeapon", attackDuration);

            // Set a timer to reset the weapon's attack ability.
            Invoke("AttackReset", 60f / attackRate);
        }
    }

    // Disable the weapon by hiding the sprite and disabling the box collider.
    public void DisableWeapon()
    {
        sr.enabled = false;
        boxCollider.enabled = false;
    }

    // Enable the weapon by showing the sprite, enabling the box collider, and disabling the attack ability.
    public void EnableWeapon()
    {
        canAttack = false;
        sr.enabled = true;
        boxCollider.enabled = true;
    }

    // Reset the weapon's attack ability.
    public void AttackReset()
    {
        canAttack = true;
    }

    // This function is called when the weapon's box collider collides with another collider.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collider belongs to an enemy.
        if (collision.CompareTag("Enemy"))
        {
            // If it does, deal damage to the enemy.
            float incomingDamage = damage;
            string incomingElement = element;
            collision.GetComponent<Enemy>().TakeDamage(damage, element);
            if (Random.Range(1, 101) <= elementChance)
            {
                Debug.Log("Elemental damage triggered!");
                collision.GetComponent<Enemy>().TakeDamage(elementDamage, subElement);
            }
        }
    }

}
