using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageBulletStick : MonoBehaviour
{
    int damagestick = 50;
    Enemy enemy;
    Boss boss;
    ItemBox box;
    [SerializeField] GameObject effectstick;
    [SerializeField] Transform pointeff;
    private void Update()
    {
        Destroy(gameObject, 2f);
    }
    void VFXStick()
    {
        GameObject effect = Instantiate(effectstick, pointeff.position, pointeff.rotation);
        Destroy(effect, 0.4f);
    }
    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Enemy"))
        {
            VFXStick();
            enemy = other.GetComponent<Enemy>();
            enemy.TakeDamage(damagestick);           
            Destroy(gameObject);
        }
        if (other.CompareTag("Boss"))
        {
            VFXStick();
            boss = other.GetComponent<Boss>();
            boss.TakeDamage(damagestick);
            Destroy(gameObject);
        }
        if (other.CompareTag("Wall"))
        {
            VFXStick();
            Destroy(gameObject);
        }
        if (other.CompareTag("Box"))
        {
            VFXStick();
            box = other.GetComponent<ItemBox>();
            box.TakeDamage(damagestick);
            Destroy(gameObject);
        }
    }
}
