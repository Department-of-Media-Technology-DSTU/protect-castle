using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float speed = 10; // projectile speed
    public int damage;

    // determine the direction of the projectile
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;

    

    // track the current position of the projectile
    private float distance;
    private float startTime;

    private GameManagerBehavior gameManager; // rewards the player when they kill an enemy

    void Start()
    {
        startTime = Time.time; // set the value of the current time
        distance = Vector3.Distance(startPosition, targetPosition); // calculate the distance between the start and target positions
        GameObject gm = GameObject.Find("GameManager");
        gameManager = gm.GetComponent<GameManagerBehavior>();
    }

    // projectile motion control
    void Update()
    {
        // calculating the new position of the projectile
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);

        // checking if target still exists
        if (gameObject.transform.position.Equals(targetPosition))
        {
            if (target != null)
            {
                // get the HealthBar component of the target and reduce its health by the amount of damage of the projectile
                Transform healthBarTransform = target.transform.Find("HealthBar");
                HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
                healthBar.currentHealth -= Mathf.Max(damage, 0);
                // destroy the object and reward the player
                if (healthBar.currentHealth <= 0)
                {
                    
                    Destroy(target);

                    gameManager.Gold += healthBar.gold;
                }
            }
            Destroy(gameObject);
        }
    }
}
