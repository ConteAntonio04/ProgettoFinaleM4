using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField]
    private int maxHealth = 100;

    public Slider healthBar;
    public TextMeshProUGUI healthText;

    private int currentHealth = 0;

    void Start()
    {
        currentHealth = 80;
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateUI();

        if (currentHealth <= 0)
        {
            GameManager.instance.LoseGame();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateUI();
    }

    void UpdateUI()
    {
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        healthText.text = currentHealth + " / " + maxHealth;
    }
}
