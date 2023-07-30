using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveAmount = 1f;
    Vector2 rawInput;

    Vector2 minBound;
    Vector2 maxBound;
    [SerializeField] float leftPadding = 1f;
    [SerializeField] float rightPadding = 1f;
    [SerializeField] float topPadding = 1f;
    [SerializeField] float bottomPadding = 1f;

    Shooter shooter;

    private void Awake() {
        shooter = GetComponent<Shooter>();
    }
    private void Start(){
        InitBounds();
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 delta = rawInput * moveAmount * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBound.x + leftPadding, maxBound.x - rightPadding);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBound.y + bottomPadding, maxBound.y - topPadding);
        transform.position = newPos;
    }
    private void InitBounds(){
        Camera mainCamera = Camera.main;
        minBound = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBound = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }
    void OnMove(InputValue value){
        rawInput = value.Get<Vector2>();
        // The on move method is called by unity implicitly whenever player presses one of the movement keys. By default, it is called when player presses or lifts up the key.
        // Debug.Log("moving");
    }

    void OnFire(InputValue value){
        if(shooter != null){
            shooter.isFiring = value.isPressed;
        }
    }
}
