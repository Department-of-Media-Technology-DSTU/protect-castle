using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    
    private float originalScale; // initial health bar size

    public float maxHealth; // maximum enemy health
    public float currentHealth; // remaining health
    public int gold;

    void Start()
    {
        
        originalScale = gameObject.transform.localScale.y;
    }

    void Update()
    {
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.y = currentHealth / maxHealth * originalScale;
        gameObject.transform.localScale = tmpScale;
    }
}
