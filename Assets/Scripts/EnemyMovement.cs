using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float detectionRange = 5.0f;
    private GameObject _player;
    private Vector2 _directionToPlayer;
    private bool _facingRight = true;

    private Rigidbody2D _rb;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        if (_player == null)
            throw new Exception("EnemyMovement can not find player");
        moveSpeed = Random.Range(1f, 3f);
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckForPlayer();
        MoveEnemy();
    }

    private void CheckForPlayer()
    {
        var distanceToPlayer = Vector2.Distance(transform.position, _player.transform.position);

        _directionToPlayer = distanceToPlayer <= detectionRange ? (_player.transform.position - transform.position).normalized : Vector2.zero;
        UpdateSpriteDirection();
    }

    private void UpdateSpriteDirection()
    {
        if (_directionToPlayer.x == 0)
            return;
        
        if (_directionToPlayer.x > 0 == !_facingRight)
            Flip();
    }

    private void MoveEnemy()
    {
        _rb.velocity = _directionToPlayer * moveSpeed;
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        var transform1 = transform;
        var tmp = transform1.localScale;
        tmp.x *= -1;
        transform1.localScale = tmp;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Bullet")) 
            return;
        
        GetComponent<EnemyHealth>().TakeDamage(1);
        other.gameObject.SetActive(false);
    }
}