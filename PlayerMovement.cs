using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; 
    
    private Rigidbody2D rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        float xMin = -8f;
        float xMax = 8f;
        float yMin = -4.5f;
        float yMax = 4.5f;
        pos.x = Mathf.Clamp(pos.x, xMin, xMax);
        pos.y = Mathf.Clamp(pos.y, yMin, yMax);
        
        transform.position = pos;
    }
}
