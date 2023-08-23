using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    int HP = 1;
    [SerializeField] Transform pointitem;
    [SerializeField] Animator animator;
    [SerializeField] GameObject particles;
    [SerializeField] GameObject[] items;
    bool item;
    private void Start()
    {
        particles.SetActive(false);
        animator = GetComponent<Animator>();
        item = true;
    }
    
    void RandomItem()
    {
        int it = Random.Range(0,items.Length);
        GameObject item = items[it];
        Vector3 newpoint = new Vector3(pointitem.position.x,pointitem.position.y,pointitem.position.z);        
        switch (it)
        {
            case 0:
                newpoint.y = pointitem.position.y; break;
            case 1:
                newpoint.y = pointitem.position.y - 0.5f; break;
            case 2:
                newpoint.y = pointitem.position.y + 0.5f; break;
            case 3:
                newpoint.y = pointitem.position.y + 1f; break;
            case 4:
                newpoint.y = pointitem.position.y + 1f; break;
        }       
        pointitem.position = newpoint;
        Instantiate(item,pointitem.position,pointitem.rotation);
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if( HP <= 0 && item == true)
        {
            item = false;
            particles.SetActive(true);
            animator.SetTrigger("Bang");
            RandomItem();
            Destroy(gameObject,1f);
        }
    }
}
