using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed;
    [SerializeField] float projectileLifetime;
    [SerializeField] float baseFiringRate = 0.2f;
    [HideInInspector] public bool isFiring;    

    [Header("AI")]
    [SerializeField] bool useAI;

    [SerializeField] float spawnTimeVariance;
    [SerializeField] float minSpawnTime;
    Coroutine firingCoroutine;
    void Start()
    {
       if(useAI){
           isFiring = true;
           
       } 
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire(){
        if(isFiring && firingCoroutine == null){
           firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine != null) {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously(){
        while(true){
            GameObject cloneProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            Rigidbody2D rb = cloneProjectile.GetComponent<Rigidbody2D>();
            if(rb != null){
                rb.velocity = transform.up * projectileSpeed;// transform up is 1 unit
            }

            Destroy(cloneProjectile, projectileLifetime);

            float timeToNextProjectile = Random.Range(baseFiringRate-spawnTimeVariance , baseFiringRate + spawnTimeVariance );
            Mathf.Clamp(timeToNextProjectile, minSpawnTime, float.MaxValue);

            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }
}
