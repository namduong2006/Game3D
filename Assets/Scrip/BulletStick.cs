using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletStick : MonoBehaviour
{
    public static BulletStick instance;
    [SerializeField] GameObject bulletstick1;
    [SerializeField] GameObject bulletstick4;
    [SerializeField] GameObject bulletstick5;
    [SerializeField] GameObject bulletstick6;    
    [SerializeField] Transform stick4;
    [SerializeField] Transform stick5;
    [SerializeField] Transform stick6;
    
    private void Awake()
    {
        instance = this;
    }
    public void InstanBulletStick()
    {
        Instantiate(bulletstick1,transform.position,transform.rotation);
    }
    public void InstanBulletStick4()
    {       
        GameObject skillstick4 = Instantiate(bulletstick4, stick4.position, stick4.rotation);        
        Destroy(skillstick4,3f);
    }
    public void InstanBulletStick5()
    {
        GameObject skillstick5 = Instantiate(bulletstick5, stick5.position, stick5.rotation);
        Destroy(skillstick5, 5f);
    }
    public void InstanBulletStick6()
    {
        GameObject skillstick6 = Instantiate(bulletstick6, stick6.position, stick6.rotation);
        Destroy(skillstick6, 3f);
    }
}
