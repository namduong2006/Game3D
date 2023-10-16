using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDamageFoot : MonoBehaviour
{
    public static PlayerDamageFoot Instace;
    [SerializeField] int damage = 10;
    List<GameObject> hasdealdame;
    bool candealdame;
    [SerializeField] Vector3 sizebox;
    [SerializeField] Transform vfx;
    [SerializeField] GameObject vfxfoot;
    [SerializeField] float radius;
    private void Awake()
    {
        Instace = this;
    }
    private void Start()
    {
        candealdame = false;
        hasdealdame = new List<GameObject>();
    }

    private void Update()
    {

        //if (candealdame)
        //{

        //    Collider[] colliders = Physics.OverlapBox(transform.position, sizebox);

        //    foreach (Collider collider in colliders)
        //    {
        //        if (!hasdealdame.Contains(collider.gameObject))
        //        {

        //            if (collider.TryGetComponent(out Enemy enemy))
        //            {
        //                enemy.TakeDamage(damage);
        //                Insvfxfoot();
        //            }


        //            if (collider.TryGetComponent(out Boss boss))
        //            {
        //                boss.TakeDamage(damage);
        //                Insvfxfoot();
        //            }
        //            if (collider.TryGetComponent(out ItemBox box))
        //            {
        //                box.TakeDamage(damage);
        //                Insvfxfoot();
        //            }

        //                hasdealdame.Add(collider.gameObject);
        //        }
        //    }

        //}
        
        if (candealdame)
        {

            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            foreach (Collider collider in colliders)
            {
                if (!hasdealdame.Contains(collider.gameObject))
                {

                    if (collider.TryGetComponent(out Enemy enemy))
                    {
                        enemy.TakeDamage(damage);
                        Insvfxfoot();
                    }


                    if (collider.TryGetComponent(out Boss boss))
                    {
                        boss.TakeDamage(damage);
                        Insvfxfoot();
                    }
                    if (collider.TryGetComponent(out ItemBox box))
                    {
                        box.TakeDamage(damage);
                        Insvfxfoot();
                    }

                    hasdealdame.Add(collider.gameObject);
                }
            }

        }
    }
    void Insvfxfoot()
    {
        GameObject vfxp = Instantiate(vfxfoot, vfx.position, vfx.rotation);
        Destroy(vfxp, 0.5f);
    }
    public void StartDamageFoot()
    {
        
        candealdame = true;
        hasdealdame.Clear();
    }

    public void EndDamageFoot()
    {
        candealdame = false;
    }
    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireCube(transform.position, sizebox);
        Gizmos.DrawSphere(transform.position,radius);
    }


}
