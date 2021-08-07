using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 1f;
    CharacterController characterController;
    PlayerAnimator playerAnimator;
    Rigidbody2D rbody;
    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    public void InputControlVector(Vector2 inputVector)
    {

        Vector2 currentPos = rbody.position;
        Vector2 movement = inputVector * movementSpeed;
        Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        rbody.MovePosition(newPos);
        if (inputVector.x != 0.0f)
        {
            if (inputVector.x > 0)
            {
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
