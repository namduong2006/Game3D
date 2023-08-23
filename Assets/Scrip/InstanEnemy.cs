using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InstanEnemy : MonoBehaviour
{
    public static InstanEnemy Instance;
    [SerializeField] GameObject[] enemyprefabs;
    [SerializeField] GameObject enemybossprefabs;
    [SerializeField] GameObject plgameobject;        
    [SerializeField] Transform spawnboss;
    [SerializeField] Transform player;
    [SerializeField] GameObject door;
    //float timeInstan;     
    //int totalenemy = 5;    
    int boss;
    bool goboss = false;   
    //int spawn = 0;
    //int die = 0;
    //int pawnx;
    //int pawnz;
    int enemycount;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {       
        boss = 0;
        
        Instantiate(plgameobject, player.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
        Instanenemy();
    }
    void Instanenemy()
    {
        Enemy[] enemy = FindObjectsOfType<Enemy>();
        enemycount = enemy.Length;
        //if (spawn<totalenemy && timeInstan >=1f)
        //{
        //    spawn++;           
        //    timeInstan = 0;
        //    int randomenemy = Random.Range(0, enemyprefabs.Length);
        //    pawnx = Random.Range(5, 20);
        //    pawnz = Random.Range(15, 35);           
        //    GameObject enemyrd = enemyprefabs[randomenemy];
        //    Instantiate(enemyrd, new Vector3(pawnx,0f,pawnz), Quaternion.identity);                      
        //}        
        //timeInstan += Time.deltaTime;
        
        if (enemycount == 0 && goboss == false)
        {
            Vector3 ro = door.transform.eulerAngles;
            ro.y = 90f;
            door.transform.eulerAngles = ro;
            
        }
        if (goboss == true)
        {
            Vector3 ro = door.transform.eulerAngles;
            ro.y = 0f;
            door.transform.eulerAngles = ro;
            if (boss < 1)
            {
                Instantiate(enemybossprefabs, spawnboss.position, Quaternion.identity);
                boss++;
            }
        }
        

    }
    public void EnemyDie()
    {       
        //die++;       
    }   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            goboss = true;
        }
    }
}
