using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;


public class Enemydamage : MonoBehaviour
{
    [SerializeField] int enemydamage = 50;        
    List<GameObject> listob;
    public float weaponlength;
    bool candealDame;
    
    private void Start()
    {       
        listob = new List<GameObject>();
        candealDame = false;
    }
    

    private void Update()
    {

        // raycat va cham cua enemy

        if (candealDame)
        {
            RaycastHit hitenemy;
            if (Physics.Raycast(transform.position, -transform.up, out hitenemy, weaponlength))
            {
                if (!listob.Contains(hitenemy.transform.gameObject) && hitenemy.transform.TryGetComponent(out Player plr))
                {
                    plr.TakeDamage(enemydamage);
                    listob.Add(hitenemy.transform.gameObject);
                }               
            }
        }
    }

    public void StartDamageEnemy()
    {
        candealDame = true;
        listob.Clear();

    }
    public void EndDamageEnemy()
    {
        candealDame = false;
    }
    // ve vung dame
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponlength);
    }
}
