using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    
    
    public static Enemy Instance;
    [SerializeField] int maxhp = 100;
    int hp;   
    [SerializeField] Animator enemyanin;    
    [SerializeField] Transform play;
    NavMeshAgent agent;    
    [SerializeField] float attackCD = 3f; // 3s tan cong 1 lan
    [SerializeField] float attackRange = 1f; // vung tan cong player
    [SerializeField] float aggroRange = 4f; // vung nhan dien va di chuyen toi player
    float timePassed =0f;
    float newdestinationcd = 0.5f;
    public GameObject damageofeneny;
    bool move = true;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {        
        
        agent = GetComponent<NavMeshAgent>();
       
        enemyanin = GetComponent<Animator>();
        hp = maxhp;
    }

    
    void Update()
    {             
        AutoEnemy();          
    }   

    // nhan damage
    public void TakeDamage(int dame)
    {        
        hp -= dame;
        
        UIManager.Instance.InfoEnemyOn(gameObject.name,maxhp,hp);
        if (move)
        {
            aggroRange += 20;
            move = false;
        }
        
        if (hp <= 0)
        {
            UIManager.Instance.InfoEnemyOff();
            ItemEnemy.Instance.RandomItem(transform.position);           
            Destroy(gameObject);           
        }       
    }
   


    void StartDamege()
    {
        damageofeneny.GetComponentInChildren<Enemydamage>().StartDamageEnemy();
    }
    void EndDamege()
    {
        damageofeneny.GetComponentInChildren<Enemydamage>().EndDamageEnemy();
    }

    
    void AutoEnemy()
    {
        
        enemyanin.SetFloat("speedenemy",agent.velocity.magnitude/agent.speed);

        // thoi gian delay tan cong (attackCDboss) neu player trong vung tan cong

        if (timePassed >= attackCD && (Vector3.Distance(Player.Instance.transform.position, transform.position) <= attackRange))
        {           
            enemyanin.SetTrigger("Atk");
            timePassed = 0;            
        }
        timePassed += Time.deltaTime;

        // thoi gian delay di chuyen toi player sau khi tan cong 

        if (newdestinationcd <=0 && Vector3.Distance(Player.Instance.transform.position , transform.position) <= aggroRange)
        {
            newdestinationcd = 0.5f;
            agent.SetDestination(Player.Instance.transform.position);
        }
        newdestinationcd -= Time.deltaTime;
        // huong ve phia player

        Vector3 plposition = new Vector3(Player.Instance.transform.position.x,0f,Player.Instance.transform.position.z);
        transform.LookAt(plposition);
    }

    // khong gian tan cong va di chuyen toi player
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, attackRange);
    //    Gizmos.color= Color.yellow;
    //    Gizmos.DrawWireSphere(transform.position, aggroRange);
    //}

    
    
}
