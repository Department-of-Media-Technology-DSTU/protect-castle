using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemies : MonoBehaviour
{
    public List<GameObject> enemiesInRange; // tracking all enemies in range
    private float lastShotTime;
    public TowerData towerData;

    public AudioSource death;

    void Start()
    {
        enemiesInRange = new List<GameObject>(); // At the very beginning, there are no enemies in range, so we create an empty list
        lastShotTime = Time.time;
    }

    // In OnEnemyDestroy we remove the enemy from enemiesInRange
    void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);
    }

    void OnTriggerEnter(Collider other)
    {
        // add an enemy to the enemiesInRange list and add an EnemyDestructionDelegate event to the OnEnemyDestroy. This way we ensure that when the enemy is destroyed, OnEnemyDestroy will be called.
        if (other.gameObject.CompareTag("Tower"))
        {
            enemiesInRange.Add(other.gameObject);
            EnemyDestructionDelegate del =
                other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }
    // remove the enemy from the list and unregister the delegate
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Tower"))
        {
            enemiesInRange.Remove(other.gameObject);
            EnemyDestructionDelegate del =
                other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }

    void Shoot(Collider target)
    {
        GameObject bulletPrefab = towerData.CurrentLevel.bullet;
        // We get the initial and target bullet positions
        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;
        startPosition.y = bulletPrefab.transform.position.y;
        targetPosition.y = bulletPrefab.transform.position.y;

        // A copy of the new projectile 
        GameObject newBullet = (GameObject)Instantiate(bulletPrefab);
        newBullet.transform.position = startPosition;
        BulletBehavior bulletComp = newBullet.GetComponent<BulletBehavior>();
        bulletComp.target = target.gameObject;
        bulletComp.startPosition = startPosition;
        bulletComp.targetPosition = targetPosition;
    }

    void Update()
    {
        GameObject target = null;
        // Defining the monster's target
        float minimalEnemyDistance = float.MaxValue;
        foreach (GameObject enemy in enemiesInRange)
        {
            float distanceToGoal = enemy.GetComponent<MoveToCheckPoint>().DistanceToGoal();
            if (distanceToGoal < minimalEnemyDistance)
            {
                target = enemy;
                minimalEnemyDistance = distanceToGoal;
            }
        }
        // Call Shoot if the elapsed time is greater than the monster's shooting rate and set lastShotTime to the current time.
        if (target != null)
        {
            if (Time.time - lastShotTime > towerData.CurrentLevel.fireRate)
            {
                Shoot(target.GetComponent<Collider>());
                lastShotTime = Time.time;
            }
        }
    }
}
