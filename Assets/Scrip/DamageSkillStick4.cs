using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageSkillStick4: MonoBehaviour
{
    int damagestick4 = 10;
    bool damageenemy = true;
    bool damageboss = true;
    Enemy enemystick4;
    Boss bossstick4;
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
            enemystick4 = other.GetComponent<Enemy>();
            enemystick4.TakeDamage(damagestick4);
            StartCoroutine(DamageEnemy());
        }
        if (other.CompareTag("Boss") && damageboss)
        {
            damageboss = false;
            bossstick4 = other.GetComponent<Boss>();
            bossstick4.TakeDamage(damagestick4);
            StartCoroutine(DamageBoss());
        }
        if (other.CompareTag("Box"))
        {
            box = other.GetComponent<ItemBox>();
            box.TakeDamage(damagestick4);
        }
    }
    
}
