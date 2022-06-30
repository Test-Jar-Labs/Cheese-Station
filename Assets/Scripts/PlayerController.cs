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

    [SerializeField]
    private float lookDirectionOffset = 0;

    private Rigidbody2D rb;

    private PlayerInput playerInput;

    private InventorySystem inventory;

    private Vector2 moveDirection;

    private Vector2 lookDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        inventory = GetComponent<InventorySystem>(); 
    }

    private void OnEnable()
    {
        playerInput.MovementEvent += HandleMovement;
        playerInput.LookEvent += HandleLook;
        playerInput.StartInteractEvent += HandleStartInteract; 
    }

    private void OnDisable()
    {
        playerInput.MovementEvent -= HandleMovement;
        playerInput.LookEvent -= HandleLook;
        playerInput.StartInteractEvent -= HandleStartInteract;
    }

    private void HandleMovement(Vector2 moveDirection)
    {
        this.moveDirection = moveDirection;
    }

    private void HandleLook(Vector2 lookDirection)
    {
        this.lookDirection = cam.ScreenToWorldPoint(lookDirection);
    }

    private void HandleStartInteract()
    {
        StartInteract();
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveDirection * movementSpeed * 10 * Time.fixedDeltaTime);

        Vector2 lookDir = lookDirection - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - lookDirectionOffset;
        rb.rotation = angle;
    }


    private void StartInteract()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);

        if (hit.collider.tag == "Gun")
        {
            Debug.Log(hit.collider.name);
            hit.collider.gameObject.GetComponent<ItemObject>()?.OnHandlePickupItem(this.inventory);
        }
    }

  






}
