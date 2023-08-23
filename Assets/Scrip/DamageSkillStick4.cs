using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageSkillStick4: MonoBehaviour
{
    int damagestick4 = 1;
    Enemy enemystick4;
    Boss bossstick4;
    ItemBox box;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemystick4 = other.GetComponent<Enemy>();
            enemystick4.TakeDamage(damagestick4);
        }
        if (other.CompareTag("Boss"))
        {
            bossstick4 = other.GetComponent<Boss>();
            bossstick4.TakeDamage(damagestick4);
        }
        if (other.CompareTag("Box"))
        {
            box = other.GetComponent<ItemBox>();
            box.TakeDamage(damagestick4);
        }
    }
    
}
