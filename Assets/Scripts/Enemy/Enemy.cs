using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public bool canMove = true;
    public float health;
    public float stunTime;
    public float knockbackForce;
    public string weakness;
    public float dropChance = 100;
    public GameObject dropItem;
    public Rigidbody2D rb;
    public Collider2D enemyCollider;
    public int pointValue;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<Collider2D>();
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
        Move();
    }

    public void LookAtPlayer()
    {
        GameObject player = GameObject.Find("Player");
        transform.right = player.transform.position - transform.position;
    }

    public void Move()
    {
        if (canMove)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    public void TakeDamage(float damageToTake, string damageType)
    {
        float incomingDamage = damageToTake;
        if (damageType == weakness)
        {
            Debug.Log("Weakness hit!");
            incomingDamage *= 2;
        }
        health -= incomingDamage;
        if(health <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(Knockback());
        }
    }

    public IEnumerator Knockback()
    {
        canMove = false;
        enemyCollider.enabled = false;
        rb.AddRelativeForce(Vector2.left * knockbackForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(stunTime);
        rb.velocity = Vector2.zero;
        canMove = true;
        enemyCollider.enabled = true;
    }

    public void Die()
    {
        float dropRoll = Random.Range(0, 101);
        if (dropRoll <= (GameObject.Find("Player").GetComponent<PlayerController>().luck * dropChance / 100))
        {
            Instantiate(dropItem, transform.position, transform.rotation);
        }
        gm.AddScore(pointValue);
        Destroy(gameObject);
    }
    

}
