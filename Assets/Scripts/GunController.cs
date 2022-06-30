using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    
    private enum FiringType
    {
        fullAuto,
        semiAuto,
        burst
    }

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float fireRate = 10f;

    [SerializeField]
    private float bulletForce = 40f;

    [SerializeField]
    private float damage = 30f;

    [SerializeField]
    private float reloadSpeed = 2.5f;

    [SerializeField]
    private float moveSpeedMultiplier = 1f;

    private PlayerInput playerInput;

    private Coroutine current;

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
        playerInput.StartShootEvent += HandleStartShoot;
        playerInput.StopShootEvent += HandleStopShoot;
    }

    private void OnDisable()
    {
        playerInput.StartShootEvent -= HandleStartShoot;
        playerInput.StopShootEvent -= HandleStopShoot;
    }

    private void HandleStartShoot()
    {
        if (current != null) StopCoroutine(current);
        current = StartCoroutine(ShootRoutine());
    }

    private void HandleStopShoot()
    {
        if (current != null) StopCoroutine(current);
    }

    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            //TODO: Bullet spread at firePoint.rotation.
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

            //TODO: more efficient way of this?
            bullet.GetComponent<BulletController>().Damage = damage;

            yield return new WaitForSeconds(1f / fireRate);
        }
        
    }
}
