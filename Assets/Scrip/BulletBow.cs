using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletBow : MonoBehaviour
{
    public static BulletBow instance;
    [SerializeField] Transform bow;
    [SerializeField] Transform bow4;    
    [SerializeField] GameObject bulletbow;
    [SerializeField] GameObject bulletbow4;
    float speedbullet = 20f;
    float[] angles = { 0f, -15f, 15f };

    private void Awake()
    {
        instance = this;
    }
    public void InstanBulletBow()
    {
        foreach (float angle in angles)
        {            
            GameObject bullet = Instantiate(bulletbow, bow.transform.position, Quaternion.identity);            
            bullet.transform.forward = bow.transform.forward;            
            bullet.transform.Rotate(Vector3.up, angle);           
            Vector3 direction = bullet.transform.forward;            
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();           
            bulletRigidbody.velocity = direction * speedbullet;
        }       
    }
    public void InstanBulletBow4()
    {
        GameObject bullet4 = Instantiate(bulletbow4, bow4.transform.position, bow4.transform.rotation);
        Destroy(bullet4,3f );
    }
    
}
