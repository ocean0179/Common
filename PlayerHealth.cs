using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3; 
    [HideInInspector] 
    public int currentHealth;

    public GameObject gameOverPanel; 

    private UIManager uiManager;

  [System.Obsolete]
  void Start()
    {
        currentHealth = maxHealth;
        uiManager = FindObjectOfType<UIManager>();
        
        if (uiManager != null)
        {
            uiManager.UpdateHealthDisplay();
        }
        Time.timeScale = 1f; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); 

            currentHealth--;
            
            if (uiManager != null)
            {
                uiManager.UpdateHealthDisplay();
            }

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        Destroy(gameObject); 
        
        Time.timeScale = 0f; 

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
    
  public static void RestartGameStatic() 
  {
      Time.timeScale = 1f; 
      SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
  }
}
