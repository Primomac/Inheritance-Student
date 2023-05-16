using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public int score;
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI healthDisplay;
    public TextMeshProUGUI speedDisplay;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = "Health: " + player.health + " / " + player.maxHealth;
        speedDisplay.text = "Speed: " + (player.moveSpeed * 10);
    }

    public void AddScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreDisplay.text = "Score: " + score;
    }
}
