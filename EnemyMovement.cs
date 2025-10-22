using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f; 
    

    private int spawnSide; 
    private float boundaryX, boundaryY;

    private int direction = 1; 


    public void InitializeMovement(int side, float boundX, float boundY)
    {
        spawnSide = side;
        boundaryX = boundX;
        boundaryY = boundY;

        direction = (Random.value > 0.5f) ? 1 : -1;
    }

    void Update()
    {
        Vector3 newPosition = transform.position;

        if (spawnSide == 0 || spawnSide == 1) 
        {
            newPosition.x += moveSpeed * direction * Time.deltaTime;
        }
        else 
        {
            newPosition.y += moveSpeed * direction * Time.deltaTime;
        }
        
        if (spawnSide == 0 || spawnSide == 1)
        {

            float maxPositionX = boundaryX - 1f; 
            float minPositionX = -(boundaryX - 1f);

            if (newPosition.x >= maxPositionX || newPosition.x <= minPositionX)
            {
                direction *= -1; 
                newPosition.x = Mathf.Clamp(newPosition.x, minPositionX, maxPositionX);
            }
        }
        else 
        {
            float maxPositionY = boundaryY - 1f;
            float minPositionY = -(boundaryY - 1f);
            if (newPosition.y >= maxPositionY || newPosition.y <= minPositionY)
            {
                direction *= -1; 
                newPosition.y = Mathf.Clamp(newPosition.y, minPositionY, maxPositionY);
            }
        }

        transform.position = newPosition;
    }
}
