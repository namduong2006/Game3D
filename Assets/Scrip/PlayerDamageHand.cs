using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PlayerDamageHand : MonoBehaviour
{
    public static PlayerDamageHand instance;
    [SerializeField] int damage = 10;
    List<GameObject> hasdealdame;   
    bool candealdame;
    [SerializeField] Vector3 sizebox;
    [SerializeField] Transform vfx;
    [SerializeField] GameObject vfxpunch;
    public float weaponLength;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        candealdame = false;
        hasdealdame = new List<GameObject>();
    }

    private void Update()
    {

        if (candealdame)
        {
            // Lấy tất cả các Collider ở vùng gây damage
            Collider[] colliders = Physics.OverlapBox(transform.position, sizebox);

            foreach (Collider collider in colliders)
            {
                if (!hasdealdame.Contains(collider.gameObject))
                {

                    if (collider.TryGetComponent(out Enemy enemy))
                    {
                        enemy.TakeDamage(damage);
                        InsVfxhand();
                    }


                    if (collider.TryGetComponent(out Boss boss))
                    {
                        boss.TakeDamage(damage);
                        InsVfxhand();
                    }

                    if(collider.TryGetComponent(out ItemBox box))
                    {
                        box.TakeDamage(damage);
                        InsVfxhand();
                    }
                    hasdealdame.Add(collider.gameObject);
                }
            }

        }

        //if (candealdame)
        //{
        //    RaycastHit hit;
        //    if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength))
        //    {
        //        if (!hasdealdame.Contains(hit.transform.gameObject) && hit.transform.TryGetComponent(out Enemy enemy))
        //        {
        //            enemy.TakeDamagePlayer(damage);
        //            hasdealdame.Add(hit.transform.gameObject);
        //            GameObject vfxp = Instantiate(vfxpunch, vfx.position, vfx.rotation);
        //            Destroy(vfxp, 0.5f);
        //        }
        //        if (!hasdealdame.Contains(hit.transform.gameObject) && hit.transform.TryGetComponent(out Boss boss))
        //        {
        //            boss.TakeDamagePlayer(damage);
        //            hasdealdame.Add(hit.transform.gameObject);
        //            GameObject vfxp = Instantiate(vfxpunch, vfx.position, vfx.rotation);
        //            Destroy(vfxp, 0.5f);
        //        }
        //    }
        //}
    }
    void InsVfxhand()
    {
        GameObject vfxp = Instantiate(vfxpunch, vfx.position, vfx.rotation);
        Destroy(vfxp, 0.5f);
    }
    public void StartDamageHand()
    {
        
        candealdame = true;
        hasdealdame.Clear();
    }

    public void EndDamageHand()
    {
        candealdame = false;
    }   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, sizebox);
        //Gizmos.color = Color.red;
        //Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }

}
