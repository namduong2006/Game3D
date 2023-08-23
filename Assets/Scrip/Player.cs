using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.AxisState;
using UnityEditor;


public class Player : MonoBehaviour
{   
    public static Player Instance;   
    [SerializeField] Rigidbody rb;
    public int maxHP = 1000; 
    public int HP;   
    float speed = 2.5f;
    public float move;
    float speedro = 150f;       
    bool gameover = false;      
    bool jump;
    float highjump = 6f;
    bool press = true;   
    [SerializeField]FixedJoystick joystick;   
    DamageWeapon damageweapon;
    [SerializeField] GameObject buff;
    
    private void Awake()
    {
        Instance = this;
    }
    
    void Start()
    { 
        rb = GetComponent<Rigidbody>();                         
        HP = maxHP;
        joystick = FindObjectOfType<FixedJoystick>();
    }

    
    void Update()
    {       
        
        MovePlayer();
    }
    
  
    public void ShootStick()
    {
        
        BulletStick.instance.InstanBulletStick();
        
    }
    public void ShootStick4()
    {
        BulletStick.instance.InstanBulletStick4();
    }
    public void OnAtk6()
    {
        DamageStick6.Instance.OnAtk();
    }
    public void OffAtk6()
    {
        DamageStick6.Instance.OffAtk();
    }
    public void ShootStick5()
    {
        BulletStick.instance.InstanBulletStick5();
    }
    public void ShootStick6()
    {
        BulletStick.instance.InstanBulletStick6();
    }
    public void ShootBow()
    {
        
        BulletBow.instance.InstanBulletBow();
    }
    public void ShootBow4()
    {
        
        BulletBow.instance.InstanBulletBow4();
    }
    
    
    public void TakeDamage(int enydamage)
    {        
        HP -= enydamage;
        if (HP <= 0)
        {
            
            Animation.instance.Death();
            StartCoroutine(TimeEnd());           
        }
    }
    public void Healing(int health)
    {
        HP += health;
        if (HP >= maxHP)
        {
            HP = maxHP;
        }
    }
    public void OnBuffHP()
    {
        buff.SetActive(true);
        StartCoroutine(TimeOffBuff());
    }
    public bool GameOver()
    {
        return gameover;
    }
          
    public void StartDealDamegeHand()
    {       
        PlayerDamageHand.instance.StartDamageHand();
    }
    public void EndDealDamegeHand()
    {        
        PlayerDamageHand.instance.EndDamageHand();
    }
    public void StartDealDamegeFoot()
    {       
        PlayerDamageFoot.Instace.StartDamageFoot();
    }
    public void EndDealDamegeFoot()
    {       
        PlayerDamageFoot.Instace.EndDamageFoot();
    }
    public void StartDealDamegeWeapon()
    {        
        damageweapon = FindObjectOfType<DamageWeapon>();
        if (damageweapon == null) { return; }
        damageweapon.StartDamageWeapon();
    }
    public void EndDealDamegeWeapon()
    {
        damageweapon = FindObjectOfType<DamageWeapon>();
        if(damageweapon == null) { return; }
        damageweapon.EndDamageWeapon();
    }
    
    
    void ComboPl()
    {
        Animation.instance.CheckCombo();
    }
    void ResetCombo()
    {
        Animation.instance.ResetCombo();
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Terrain"))
        {
            jump = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        jump = false;
    }
    public int MaxHPPlayer()
    {
        return maxHP;
    }
    public int HPPlayer()
    {
        return HP;
    }
    
    private IEnumerator TimeEnd()
    {
        yield return new WaitForSeconds(1f);
        UIManager.Instance.GameOver();

    }
    private IEnumerator TimeOffBuff()
    {
        yield return new WaitForSeconds(1.5f);
        buff.SetActive(false);
    }
    private void MovePlayer()
    {
        // di chuyen va xoay
        
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Rotate(0, h * Time.deltaTime * speedro, 0);
        transform.Translate(0, 0, v * Time.deltaTime * speed);
        float vjoy = joystick.Vertical;
        transform.Rotate(0, joystick.Horizontal * Time.deltaTime * speedro, 0);
        transform.Translate(0, 0, joystick.Vertical * Time.deltaTime * speed);
        if (v == 0)
        {
            move = vjoy;
        }
        else if (vjoy == 0)
        {
            move = v;
        }
        else if(v != 0 && vjoy != 0)
        {
            move = v;
            
        }
       
        
        // jump

        if (jump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Animation.instance.JumpTrue();
                rb.AddForce(new Vector3(0f, highjump, 0f), ForceMode.Impulse);
            }

            Animation.instance.GroundingTrue();
        }
        else
        {
            Animation.instance.JumpFalse();
            Animation.instance.GroundingFalse();
        }
    }
    public void OffPress()
    {
        press = false;
    }
    public void OnPress()
    {
        press = true;
    }
    public bool Press()
    {
        return press;
    }
    public void OffMove()
    {
        speed = 0;
    }
    public void OnMove()
    {
        speed = 2.5f;
    }
}
