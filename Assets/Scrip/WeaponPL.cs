using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// danh sach weapon
public class WeaponPL : MonoBehaviour
{
    public GameObject[] Weapon ;
    
    
    public void ActivarArmar(int number)
    {
       
        for (int i = 0; i < Weapon.Length; i++)
        {
            Weapon[i].SetActive(false);
        }
        Weapon[number].SetActive(true);
        
    }
}
