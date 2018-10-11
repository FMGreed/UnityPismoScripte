using UnityEngine;

public class Health : MonoBehaviour
{
    public const int maxHealth = 100;       // health maksimalni
    public int currentHealth = maxHealth;   // health trenutni

    public void TakeDamage(int amount)      // funkcija za štetu prati koliko štete primamo
    {
        currentHealth -= amount;            // 
        if (currentHealth <= 0)             // if uvjet prati jel imamo manje ili jednako nuli health-a
        {
            currentHealth <= 0;              // ako je health jednak nuli mrtav igrač
            Debug.Log("Dead!");
        }
    }
}