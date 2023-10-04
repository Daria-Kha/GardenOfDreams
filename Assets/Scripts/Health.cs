using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    
    private bool _isInvulnerable;
    private float _invulnerabilityTimer;
    [ReadOnly] public float invulnerabilityDuration = 0.7f;

    protected bool IsDead;
    
    public Slider healthBar;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    
    private void Update()
    {
        healthBar.value = currentHealth;

        if (!_isInvulnerable) 
            return;
        
        _invulnerabilityTimer += Time.deltaTime;
        if (_invulnerabilityTimer >= invulnerabilityDuration)
        {
            _isInvulnerable = false;
        }
    }
    
    public void TakeDamage(in int amount)
    {
        if (IsDead)
            return;
        
        Debug.Log(gameObject.tag + " got damage");
        if (!_isInvulnerable)
            currentHealth -= amount;

        if (currentHealth <= 0)
        {
            IsDead = true;
            Die();
        }
        else
        {
            _isInvulnerable = true;
            _invulnerabilityTimer = 0f;
        }
    }

    protected abstract void Die();

}