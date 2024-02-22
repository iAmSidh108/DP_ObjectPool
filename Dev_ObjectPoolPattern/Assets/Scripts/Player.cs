using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance = null;

    public float speed = 10.0f;
    public float health = 100;
    public float currentHealth;

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

    private void Start()
    {
        currentHealth = health;
    }

    void Update()
    {
        if (currentHealth >= 0)
        {
            Move();
        }
            
        healthTXT.text = $"Health#: {currentHealth}";
        Debug.Log(currentHealth);
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

    
}