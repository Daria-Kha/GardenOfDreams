using System;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private PlayerHealth _heroHealth;
    private void Start()
    {
        _heroHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        if (_heroHealth == null)
            throw new Exception("EnemyAttack did not find Player");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            _heroHealth.TakeDamage(1);
        }
    }
}
