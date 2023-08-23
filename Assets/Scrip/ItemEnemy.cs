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
        int it = Random.Range(0, items.Length);
        GameObject item = items[it];       
        Vector3 newpoint = new Vector3(positionenemy.x, positionenemy.y, positionenemy.z);
        switch (it)
        {
            case 0:
                newpoint.y = 0f; break;
            case 1:
                newpoint.y = - 0.5f; break;
            case 2:
                newpoint.y =  0.5f; break;

        }
        pointitem = newpoint;
        Instantiate(item,pointitem, Quaternion.identity);
    }
}
