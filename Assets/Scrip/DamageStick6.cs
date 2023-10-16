using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageStick6 : MonoBehaviour
{
    public static DamageStick6 Instance;
    int damagestick6 = 30;
    Enemy enemy;
    Boss bosss;
    bool atk;
    ItemBox box;
    bool damageenemy = true;
    bool damageboss = true;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        atk = false;
    }
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
        if (atk)
        {
            if (other.CompareTag("Enemy") && damageenemy)
            {
                damageenemy = false;
                enemy = other.GetComponent<Enemy>();
                enemy.TakeDamage(damagestick6);
                StartCoroutine(DamageEnemy());
            }
            if (other.CompareTag("Boss") && damageboss)
            {
                damageboss = false;
                bosss = other.GetComponent<Boss>();
                bosss.TakeDamage(damagestick6);
                StartCoroutine(DamageBoss());
            }
            if (other.CompareTag("Box"))
            {               
                box = other.GetComponent<ItemBox>();
                box.TakeDamage(damagestick6);
            }
        }
        else return;  
        
    }

    public void OnAtk()
    {
        atk = true;
    }
    public void OffAtk()
    {
        atk = false;
    }
}
