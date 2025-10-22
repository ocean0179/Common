using UnityEngine;
using System.Collections; 

public class PatternManager : MonoBehaviour
{
    public GameObject bulletPrefab; 
    
    public float patternInterval = 10f;
    public float patternBulletSpeed = 4f;
    private float patternTimer = 0f;

  [System.Obsolete]
  void Start()
    {
        StartCoroutine(StartPatternRoutine());
    }

    void Update()
    {
        patternTimer += Time.deltaTime;
    }

  [System.Obsolete]
  IEnumerator StartPatternRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(patternInterval);
            patternTimer = 0f; 

            PerformCirclePattern();
        }
    }

    public float GetCurrentPatternTimer()
    {
        return patternTimer;
    }

  [System.Obsolete]
  void PerformCirclePattern()
    {
        Vector3 centerPosition = Vector3.zero; 
        int bulletCount = 20; 
        float angleStep = 360f / bulletCount;

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * angleStep;
            float x = Mathf.Cos(angle * Mathf.Deg2Rad);
            float y = Mathf.Sin(angle * Mathf.Deg2Rad);
            Vector2 direction = new Vector2(x, y).normalized;
            
            GameObject bullet = Instantiate(bulletPrefab, centerPosition, Quaternion.identity);

            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.SetDirection(direction, patternBulletSpeed); 
            }
        }
    }
}
