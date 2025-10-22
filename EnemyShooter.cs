// EnemyShooter.cs (수정)
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    // ... 기존 변수 유지 ...
    public GameObject bulletPrefab; 
    public float shootInterval = 0.5f; 
    private float timer;

    public float initialBulletSpeed = 2f;   
    public float maxBulletSpeed = 15f;      
    public float speedIncreaseRate = 60f;   


  [System.Obsolete]
  void Shoot()
  {
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    if (player == null) return;

    float currentSpeed = initialBulletSpeed + (Time.time / speedIncreaseRate);


    currentSpeed = Mathf.Min(currentSpeed, maxBulletSpeed);

    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

    Vector2 direction = (player.transform.position - transform.position).normalized;

    Bullet bulletScript = bullet.GetComponent<Bullet>();
    if (bulletScript != null)
    {
      bulletScript.SetDirection(direction, currentSpeed);
    }
  }

  [System.Obsolete]
  void Update()
  {
      timer += Time.deltaTime;
      if (timer >= shootInterval)
      {
          Shoot();
          timer = 0f; 
      }
  }
}
