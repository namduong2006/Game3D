using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageBulletBow : MonoBehaviour
{
    int damagebow = 50;
    Enemy enemy;
    Boss boss;
    public GameObject effectbow;
    ItemBox box;
    private void Update()
    {
        Destroy(gameObject,2f);
    }
    void VFX()
    {
        GameObject effectb = Instantiate(effectbow, transform.position, transform.rotation);
        Destroy(effectb, 0.4f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            VFX();
            enemy = other.GetComponent<Enemy>();           
            enemy.TakeDamage(damagebow);
            Destroy(gameObject);
        }
        if (other.CompareTag("Boss"))
        {
            VFX();    
            boss = other.GetComponent<Boss>();
            boss.TakeDamage(damagebow);           
            Destroy(gameObject);
        }
        if (other.CompareTag("Wall"))
        {
            VFX();
            Destroy(gameObject);
        }
        if (other.CompareTag("Box"))
        {
            VFX();
            box = other.GetComponent<ItemBox>();
            box.TakeDamage(damagebow);
            Destroy(gameObject);
        }
    }
}
