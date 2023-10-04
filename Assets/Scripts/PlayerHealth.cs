
public class PlayerHealth : Health
{


    protected override void Die()
    {
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        IsDead = true;
        if (healthBar != null)
        {
            healthBar.gameObject.SetActive(false);
        }
    }
}
