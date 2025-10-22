using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float currentBulletSpeed;

  [System.Obsolete]
  public void SetDirection(Vector2 direction, float speed)
    {
        currentBulletSpeed = speed; 

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction.normalized * currentBulletSpeed;
        }
    }
    void Update()
    {
        Destroy(gameObject, 20f); 
    }
}
