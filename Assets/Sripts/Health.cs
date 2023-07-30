using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] bool applyCameraShake;

    CameraShake cameraShake;

    private void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if(damageDealer != null){
            TakeDamage(damageDealer.GetDamage());
            ShakeCamera();
            damageDealer.Hit();
        }
    }


    void TakeDamage(int damage){
        health -= damage;
        if(health <= 0){
            Destroy(gameObject);
        }
    }

    void ShakeCamera(){
        Debug.Log("cameraShake: " + cameraShake);
        if(cameraShake != null && applyCameraShake){
            cameraShake.Play();
            Debug.Log("Shaking");
        }
    }
}
