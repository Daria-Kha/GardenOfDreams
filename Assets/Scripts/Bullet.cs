using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public bool goingRight;

    private void Start()
    {
        Destroy(gameObject, 0.5f); 
    }

    private void Update()
    {
        if (goingRight)
        {
            transform.Translate(Vector3.right * (speed * Time.deltaTime));
        }
        else
        {
            transform.Translate(Vector3.left * (speed * Time.deltaTime));
        }
    }
}