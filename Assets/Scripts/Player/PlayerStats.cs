using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int level = 1;
    public int experience = 0;
    public int experienceForNextLevel = 100;
    public float attackDamage = 10f;

    private Text healthUI;
    private Text levelUI;
    private Text expUI;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();
        FindUIElements();
    }

    void FindUIElements()
    {
        Text[] allTexts = FindObjectsOfType<Text>();
        foreach (Text t in allTexts)
        {
            if (t.name == "HealthText") healthUI = t;
            if (t.name == "LevelText") levelUI = t;
            if (t.name == "ExpText") expUI = t;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("플레이어가 " + damage + "의 피해를 받았습니다. 남은 체력: " + currentHealth);
        
        if (currentHealth <= 0)
        {
            Die();
        }
        UpdateUI();
    }

    public void GainExperience(int exp)
    {
        experience += exp;
        Debug.Log("경험치 +" + exp + " (" + experience + "/" + experienceForNextLevel + ")");
        
        if (experience >= experienceForNextLevel)
        {
            LevelUp();
        }
        UpdateUI();
    }

    void LevelUp()
    {
        level++;
        experience -= experienceForNextLevel;
        experienceForNextLevel = Mathf.RoundToInt(experienceForNextLevel * 1.5f);
        attackDamage += 5f;
        maxHealth += 20;
        currentHealth = maxHealth;
        
        Debug.Log("레벨 " + level + "로 올랐습니다!");
        UpdateUI();
    }

    void Die()
    {
        Debug.Log("플레이어 사망...");
        // 게임 오버 처리
    }

    void UpdateUI()
    {
        if (healthUI != null)
            healthUI.text = "HP: " + currentHealth + "/" + maxHealth;
        if (levelUI != null)
            levelUI.text = "Level: " + level;
        if (expUI != null)
            expUI.text = "EXP: " + experience + "/" + experienceForNextLevel;
    }
}
