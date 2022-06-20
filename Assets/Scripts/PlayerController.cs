using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public Camera cam;

    [SerializeField]
    private float movementSpeed = 20f;

    private Rigidbody2D rb;

    private PlayerInput playerInput;

    private Vector2 moveDirection;

    private Vector2 lookDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerInput.MovementEvent += HandleMovement;
        playerInput.LookEvent += HandleLook;
    }

    private void OnDisable()
    {
        playerInput.MovementEvent -= HandleMovement;
        playerInput.LookEvent -= HandleLook;
    }

    private void HandleMovement(Vector2 moveDirection)
    {
        this.moveDirection = moveDirection;
    }

    private void HandleLook(Vector2 lookDirection)
    {
        this.lookDirection = cam.ScreenToWorldPoint(lookDirection);
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDirection * movementSpeed * 10 * Time.fixedDeltaTime);

        Vector2 lookDir = lookDirection - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90;
        rb.rotation = angle;
         
    }








}
