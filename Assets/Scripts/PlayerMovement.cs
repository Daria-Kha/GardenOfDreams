using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public float playerSpeed;
    private Rigidbody2D _rb;
    public InvScr inventorySystem; // Добавляем ссылку на InventorySystem
    public bool rightDirection;

    private Animator _animator;
    private static readonly int Walk = Animator.StringToHash("Walk");

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }


    public void FixedUpdate()
    {
        if (joystick.joystickVec.y != 0)
        {
            _rb.velocity = new Vector2(joystick.joystickVec.x * playerSpeed, joystick.joystickVec.y * playerSpeed);
            _animator.SetBool(Walk, true);
        }
        else
        {
            _rb.velocity = Vector2.zero;
            _animator.SetBool(Walk, false);
        }

        UpdateSpriteDirection();
    }

    private void UpdateSpriteDirection()
    {
        switch (joystick.joystickVec.x)
        {
            case > 0:
                rightDirection = true;
                gameObject.transform.localScale = new Vector3(1, 1, 1);
                break;
            case < 0:
                rightDirection = false;
                gameObject.transform.localScale = new Vector3(-1, 1, 1);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.enabled)
            return;
        var item = other.GetComponent<Item>();

        if (item == null) 
            return;
        other.enabled = false;   
        inventorySystem.AddItem(item);      
        //item.UseItem(); 
        Debug.Log("pick");
        Destroy(other.gameObject);
    }
    
}

