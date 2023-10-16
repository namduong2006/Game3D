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
        int it = Random.Range(1,101);
        if (it <= 75)
        {
            return;
        }
        else if (it <= 80)
        {
            Instantiate(items[0], transform.position, transform.rotation);
        }
        else if( it <= 85)
        {
            Instantiate(items[1], new Vector3(transform.position.x, transform.position.y- 0.5f, transform.position.z), transform.rotation);
        }
        else if (it <= 90)
        {
            Instantiate(items[2], new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), transform.rotation);
        }
        else if (it <= 95)
        {
            Instantiate(items[3], new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.rotation);
        }
        else if (it <= 100)
        {
            Instantiate(items[4], new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.rotation);
        }       
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
