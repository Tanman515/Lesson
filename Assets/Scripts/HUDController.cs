using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI coinsText;

    public int maxHealth = 3;
    public int currentHealth = 3;

    public int coinsCollected = 0;
    public int coinsTotal = 10;

    void Start()
    {
        UpdateHealthUI();
        UpdateCoinsUI();
    }

    void Update()
    {
        // Переход в главное меню
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void TakeDamage(int value)
{
    currentHealth -= value;
    if (currentHealth < 0) currentHealth = 0;
    UpdateHealthUI();

    // Если здоровье закончилось — возвращаемся в главное меню
    if (currentHealth == 0)
    {
        SceneManager.LoadScene("MainMenu");
    }
}

    public void RestoreHealth(int value)
    {
        currentHealth += value;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        healthText.text = "";
        for (int i = 0; i < currentHealth; i++)
        {
            healthText.text += "♥ ";
        }
        for (int i = currentHealth; i < maxHealth; i++)
            healthText.text += "<color=#808080>♥</color> ";
    }

    public void AddCoin()
    {
        coinsCollected++;
        UpdateCoinsUI();
    }

    void UpdateCoinsUI()
    {
        coinsText.text = $"Монеты: {coinsCollected} / {coinsTotal}";
    }
}