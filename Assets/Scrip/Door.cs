using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    int enemycount;
    bool goboss = false;
    [SerializeField] GameObject boss;
    [SerializeField] Transform door;
    // Start is called before the first frame update
    void Start()
    {
        boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Enemy[] enemy = FindObjectsOfType<Enemy>();
        enemycount = enemy.Length;
        Vector3 ro = door.transform.eulerAngles;
        if (enemycount == 0 && goboss == false)
        {
            
            ro.y = 90f;
            door.transform.eulerAngles = ro;

        }
        if (goboss == true)
        {           
            ro.y = 0f;
            door.transform.eulerAngles = ro;
            boss.SetActive(true);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {            
            goboss = true;
        }
    }  
}
