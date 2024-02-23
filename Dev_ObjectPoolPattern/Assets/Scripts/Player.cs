using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance = null;

    public float speed = 10.0f;
    float health = 100;
    

    float currentHealth;
    float currentScore;
    bool isDead = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private Player()
    {

    }
    

    [SerializeField] TextMeshProUGUI healthTXT;
    [SerializeField] TextMeshProUGUI scoreTXT;

    private void Start()
    {
        currentHealth = health;
        currentScore = 0;
    }

    void Update()
    {
        if (isDead) return;

        if (currentHealth >= 0)
        {
            Move();
            healthTXT.text = $"Health: {currentHealth}";
            scoreTXT.text = $"Score: {currentScore}";

        }
        else
        {
            healthTXT.text = $"Health#: 0";
            isDead = true;
            RotatePlayer();
            GetComponent<Collider2D>().enabled = false;
        }
    }

    private void Move()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);
    }

    public void GetDamage(float damage)
    {
        currentHealth -= damage;
    }

    public void AddScore(int score)
    {
        currentScore += score;
    }

    public bool CheckIsDead()
    {
        return isDead;
    }

    private void RotatePlayer()
    {
        // Choose your preferred rotation method from the previous solution
        transform.Rotate(0, 0, 180f); // Example: Using Transform.Rotate
    }


}