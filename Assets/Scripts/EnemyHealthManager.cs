using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    public float startingHealth;
    private float currentHealth;
    public static EnemyHealthManager instance;

    
    public int scoreValue = 1;
    public int coinNumber = 5;
    public int killNumber = 1;

    public Image healthBar;
    LevelSystem system;
    Xp playerXp;

    void Start()
    {
        currentHealth = startingHealth;
        if (instance == null && instance != this)
        {
            instance = this;
        }
        else
        {
            return;

        }
    }

    
    void Update()
    {
        system = FindObjectOfType<LevelSystem>();

        playerXp = FindObjectOfType<Xp>();
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
            Coin.coin++;
            ScoreManager.score += scoreValue;
            Xp.XpValue += 5;
            //Coin.CoinInstance.coin += coinNumber;
            //playerXp.XpValue += 5;
            Kills.kills += killNumber;
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / startingHealth;

    }
   
}
