using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageSkillStick5 : MonoBehaviour
{
    int damageskillstick5 = 1;
    Enemy enemystick5;
    Boss bossstick5;
    ItemBox box;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemystick5 = other.GetComponent<Enemy>();
            enemystick5.TakeDamage(damageskillstick5);
        }
        if (other.CompareTag("Boss"))
        {
            bossstick5 = other.GetComponent<Boss>();
            bossstick5.TakeDamage(damageskillstick5);
        }
        if (other.CompareTag("Box"))
        {
            box = other.GetComponent<ItemBox>();
            box.TakeDamage(damageskillstick5);
        }
    }
}
