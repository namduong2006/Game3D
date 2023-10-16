using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageSkillStick5 : MonoBehaviour
{
    int damageskillstick5 = 20;
    bool damageenemy = true;
    bool damageboss = true;
    Enemy enemystick5;
    Boss bossstick5;
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
            enemystick5 = other.GetComponent<Enemy>();
            enemystick5.TakeDamage(damageskillstick5);
            StartCoroutine(DamageEnemy());
        }
        if (other.CompareTag("Boss") && damageboss)
        {
            damageboss = false;
            bossstick5 = other.GetComponent<Boss>();
            bossstick5.TakeDamage(damageskillstick5);
            StartCoroutine(DamageBoss());
        }
        if (other.CompareTag("Box"))
        {
            box = other.GetComponent<ItemBox>();
            box.TakeDamage(damageskillstick5);
        }
    }
}
