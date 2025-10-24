using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    public Image healthBar;
    public int maxHealth = 100;
    public int currentHealth;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp((float)currentHealth / maxHealth,0,1);
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Player Died");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}