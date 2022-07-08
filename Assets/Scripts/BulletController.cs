using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{


    public float Damage
    {
        get => damage;
        set => damage = value;
    }

    [SerializeField]
    private GameObject hitEffect;

    private float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"deal {damage} damage to {collision}");



        GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
        

        

        Destroy(effect, 5f);
        Destroy(this.gameObject);
    }
}
