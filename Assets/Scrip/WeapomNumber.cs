using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// tao so cho weapon dung de hien vu khi va chhuyen layer animator
public class WeapomNumber : MonoBehaviour
{
    public static WeapomNumber instance;   
    WeaponPL plweapon;
    public int number;
    UIManager manager;
    
    private void Awake()
    {
        instance = this;
    }
    
    //public int Number() { return number; }
    private void OnTriggerStay(Collider other)
    {
        
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.G))
        {
            
            manager = FindObjectOfType<UIManager>();
            //manager.UISkill();
            manager.OnTimeSkill();
            manager.OnSkill(number+1);
            plweapon = FindObjectOfType<WeaponPL>();
            plweapon.ActivarArmar(number);           
            Animation.instance.LayerIndex(number);           
            Destroy(gameObject);
        }
    }   
}
