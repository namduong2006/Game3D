using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.AxisState;
using UnityEditor;
using UnityEngine.AI;
using static UnityEngine.InputManagerEntry;

public class Player : MonoBehaviour
{   
    
    public static Player Instance;   
    [SerializeField] Rigidbody rb;
    int maxHP = 1000; 
    public int HP;   
    float speed = 2.5f;
    public float move;
    public float speedro = 600f;       
    bool gameover = false;               
    [SerializeField]FixedJoystick joystick;   
    DamageWeapon damageweapon;
    [SerializeField] GameObject buff;
    public enum MoveMode
    {
        Keyboard,
        Joystick
    }
    public MoveMode currentMoveMode = MoveMode.Joystick;

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
    
    void ComboPlSword()
    {
        Animation.instance.CheckComboSword();
    }
    void ComboPlStick()
    {
        Animation.instance.CheckComboStick();
    }
    void ComboPl()
    {
        Animation.instance.CheckCombo();
    }
    void ResetCombo()
    {
        Animation.instance.ResetCombo();
    }  
    public int MaxHPPlayer()
    {
        return maxHP;
    }
    public int HPPlayer()
    {
        return HP;
    }
    
    // Canvas GameOver hien len sau 1s
    private IEnumerator TimeEnd()
    {
        yield return new WaitForSeconds(1f);
        UIManager.Instance.GameOver();

    }

    // Tat buff HP sau 1.5s
    private IEnumerator TimeOffBuff()
    {
        yield return new WaitForSeconds(1.5f);
        buff.SetActive(false);
        
    }
    private void MovePlayer()
    {
        // di chuyen joystick va keyboard  
        if (currentMoveMode == MoveMode.Joystick)
        {
            float joyh = joystick.Horizontal;
            float joyv = joystick.Vertical;
            rb.velocity = new Vector3(joyh * speed, rb.velocity.y, joyv * speed);
            if (joyh != 0 || joyv != 0)
            {
                transform.rotation = Quaternion.LookRotation(rb.velocity);
            }
            float _joyh = Mathf.Abs(joyh);
            float _joyv = Mathf.Abs(joyv);
            move =Mathf.Clamp01( _joyh + _joyv);
            joystick.gameObject.SetActive(true);
        }
        else if (currentMoveMode == MoveMode.Keyboard)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(h,0f,v);  
            movement.Normalize();
            transform.Translate( movement * Time.deltaTime * speed,Space.World);
            if (movement != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(movement, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, speedro * Time.deltaTime);
            }
            float _h=Mathf.Abs(h);
            float _v=Mathf.Abs(v);
            move =Mathf.Clamp01( _v+_h);
            joystick.gameObject.SetActive(false); 
        }
        
    }
    
    public void OffMove()
    {
        speed = 0;
        speedro = 0;
    }
    public void OnMove()
    {
        speed = 2.5f;
        speedro = 600f;
    }
}
