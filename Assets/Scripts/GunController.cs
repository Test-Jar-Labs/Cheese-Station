using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    
    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float fireRate = 5f;

    [SerializeField]
    private float bulletForce = 40f;

    [SerializeField]
    private float damage = 30f;

    [SerializeField]
    private float reloadSpeed = 2.5f;

    [SerializeField]
    private float moveSpeedMultiplier = 1f;

    private PlayerInput playerInput;

    //TODO: Bullet Effect
    //TODO: Gun Type(fire spread, # of bullets per shot, auto/semi-auto)

    private void Awake()
    {
        playerInput = GetComponentInParent<PlayerInput>();

        if(playerInput == null)
        {
            Debug.Log("gun not on player");
            //TODO: Figure this edge case out
        }
    }

    private void OnEnable()
    {
        playerInput.ShootEvent += HandleShoot;
    }

    private void OnDisable()
    {
        playerInput.ShootEvent -= HandleShoot;
    }

    private void HandleShoot()
    {
        Shoot();
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
      
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        bullet.GetComponent<BulletController>().Damage = damage;
    }

    

    
}
