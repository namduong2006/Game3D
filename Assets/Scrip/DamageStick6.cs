using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageStick6 : MonoBehaviour
{
    public static DamageStick6 Instance;
    int damagestick6 = 1;
    Enemy enemystick6;
    Boss bossstick6;
    bool atk;
    ItemBox box;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        atk = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (atk)
        {
            if (other.CompareTag("Enemy"))
            {
                enemystick6 = other.GetComponent<Enemy>();
                enemystick6.TakeDamage(damagestick6);
            }
            if (other.CompareTag("Boss"))
            {
                bossstick6 = other.GetComponent<Boss>();
                bossstick6.TakeDamage(damagestick6);
            }
            if (other.CompareTag("Box"))
            {
                Debug.Log("Hello");
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
