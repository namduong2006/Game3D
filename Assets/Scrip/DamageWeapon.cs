using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageWeapon : MonoBehaviour
{
    [SerializeField] int damage = 10;
    List<GameObject> hasdealdame;
    public float weaponLength;
    bool candealdame;
    
    private void Start()
    {
        candealdame = false;
        hasdealdame = new List<GameObject>();
    }
    private void Update()
    {
        // raycat nhan va cham cua player

        if (candealdame)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength))
            {
                if (!hasdealdame.Contains(hit.transform.gameObject) && hit.transform.TryGetComponent(out Enemy enemy))
                {
                    enemy.TakeDamage(damage);
                    hasdealdame.Add(hit.transform.gameObject);                   
                }
                if (!hasdealdame.Contains(hit.transform.gameObject) && hit.transform.TryGetComponent(out Boss boss))
                {
                    boss.TakeDamage(damage);
                    hasdealdame.Add(hit.transform.gameObject);
                }
                if (!hasdealdame.Contains(hit.transform.gameObject) && hit.transform.TryGetComponent(out ItemBox box))
                {
                    box.TakeDamage(damage);
                    hasdealdame.Add(hit.transform.gameObject);
                }
                
                    //if (!hasdealdame.Contains(hit.transform.gameObject) && hit.collider.gameObject.CompareTag("Wall"))
                    //{
                    //    Debug.Log("==============");
                    //    hasdealdame.Add(hit.transform.gameObject);
                    //}
            }
        }
       
    }
    public void StartDamageWeapon()
    {
        
        candealdame = true;
        hasdealdame.Clear();
    }
    public void EndDamageWeapon()
    {
        candealdame = false;
    }
    // ve vung dame
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
    }
   
}
