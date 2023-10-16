using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageBow4 : MonoBehaviour
{
    int damagebow4 = 10;
    bool damageenemy = true;
    bool damageboss = true;
    Enemy enemybow4;
    Boss bossbow4;
    ItemBox box;
    private IEnumerator DamageEnemy()
    {
        yield return new WaitForSeconds(0.5f);
        damageenemy = true;
    }
    private IEnumerator DamageBoss()
    {
        yield return new WaitForSeconds(0.5f);
        damageboss = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && damageenemy)
        {
            damageenemy = false;
            enemybow4 = other.GetComponent<Enemy>();
            enemybow4.TakeDamage(damagebow4);
            StartCoroutine(DamageEnemy());

        }
        if (other.CompareTag("Boss") && damageboss)
        {
            damageboss = false;
            bossbow4 = other.GetComponent<Boss>();
            bossbow4.TakeDamage(damagebow4);
            
        }
        if (other.CompareTag("Box"))
        {
            box = other.GetComponent<ItemBox>();
            box.TakeDamage(damagebow4);           
        }

    }
    
}
