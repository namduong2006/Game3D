using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageBow4 : MonoBehaviour
{
    int damagebow4 = 1;
    Enemy enemybow4;
    Boss bossbow4;
    ItemBox box;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemybow4 = other.GetComponent<Enemy>();
            enemybow4.TakeDamage(damagebow4);
            
        }
        if (other.CompareTag("Boss"))
        {
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
