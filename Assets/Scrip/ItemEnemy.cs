using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEnemy : MonoBehaviour
{
    public static ItemEnemy Instance;
    [SerializeField] GameObject[] items;   
    Vector3 pointitem;
    private void Awake()
    {
        Instance = this;
    }
    
    public void RandomItem(Vector3 positionenemy)
    {              
        Vector3 newpoint = new Vector3(positionenemy.x, positionenemy.y, positionenemy.z);        
        int it = Random.Range(1,101); //lay gai tri tu 1 den 100       
        if (it <= 70)
        {
            return;
        }
        else if (it <= 85)
        {
            Instantiate(items[0], new Vector3(positionenemy.x, 0.5f, positionenemy.z), transform.rotation);
        }
        else if(it <= 95)
        {
            Instantiate(items[1], new Vector3(positionenemy.x, 0f, positionenemy.z), transform.rotation);
        }
        else if (it <= 100)
        {
            Instantiate(items[2], new Vector3(positionenemy.x, -0.5f, positionenemy.z), transform.rotation);
        }
        
    }
}
