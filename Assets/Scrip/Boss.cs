using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class Boss : MonoBehaviour
{
    int hpboss;
    [SerializeField] int hpbossmax = 1000;
    //[SerializeField] Slider hpSliderboss;
    [SerializeField] Animator enemyaninboss;
    [SerializeField] GameObject door;
    NavMeshAgent agentboss;
    [SerializeField] float attackCDboss = 3f;  // 3s tan cong 1 lan
    [SerializeField] float attackRangeboss = 1f; // vung tan cong player
    [SerializeField] float aggroRangeboss = 4f;  // vung nhan dien va di chuyen toi player
    float timePassedboss = 0;
    public GameObject damageofenenyboss;
    float newdestinationcd = 0.5f; 



    void Start()
    {
        hpboss = hpbossmax;
        agentboss = GetComponent<NavMeshAgent>();        
        enemyaninboss = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
               
        AutoBoss();
    }

    // nhan damege
    public void TakeDamage(int dame)
    {
        hpboss -= dame;
        UIManager.Instance.InfoEnemyOn(gameObject.name,hpbossmax,hpboss);
        if (hpboss <= 0)
        {
            UIManager.Instance.InfoEnemyOff();
            Instantiate(door, transform.position + new Vector3(0f,1f,0f), transform.rotation);
            InstanEnemy.Instance.EnemyDie();                      
            Destroy(gameObject);
        }
    }


    // bat dau gay damage
    void StartDamege()
    {
        damageofenenyboss.GetComponentInChildren<Enemydamage>().StartDamageEnemy();
    }

    // ket thuc gay damage
    void EndDamege()
    {
        damageofenenyboss.GetComponentInChildren<Enemydamage>().EndDamageEnemy();
    }

    
    void AutoBoss()
    {
        // set float blend tree

        enemyaninboss.SetFloat("speedboss",agentboss.velocity.magnitude/agentboss.speed);

        // thoi gian delay tan cong (attackCDboss) neu player trong vung tan cong

        if (timePassedboss >= attackCDboss)
        {
            if (Vector3.Distance(Player.Instance.transform.position, transform.position) <= attackRangeboss)
            {
                enemyaninboss.SetTrigger("Atk");
                timePassedboss = 0;
            }
        }
        timePassedboss += Time.deltaTime;

        // thoi gian delay di chuyen toi player sau khi tan cong 

        if (newdestinationcd <= 0 && Vector3.Distance(Player.Instance.transform.position, transform.position) <= aggroRangeboss)
        {
            newdestinationcd = 0.5f;
            agentboss.SetDestination(Player.Instance.transform.position);
        }
        newdestinationcd -= Time.deltaTime;
          
        // huong phia truoc ve phia player

        Vector3 plpositionboss = new Vector3(Player.Instance.transform.position.x, 0f, Player.Instance.transform.position.z);
        transform.LookAt(plpositionboss);
    }

    // khong gian tan cong va di chuyen toi player
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRangeboss);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, aggroRangeboss);
    }



}
