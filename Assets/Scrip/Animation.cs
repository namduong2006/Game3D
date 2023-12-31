using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Animation : MonoBehaviour
{
    public static Animation instance;
    [SerializeField] Animator animator;
    
    float timeJ = 0f;
    float timeK = 0f;
    float timeL = 0f;  
    int combo = 0;   
    int layer;
    //float timecombo = 0;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        
        timeJ += Time.deltaTime;
        timeK += Time.deltaTime;
        timeL += Time.deltaTime;        
        combo = 0;        
    }
    void Update()
    {
        
        AnimationPlayer();
        
    }

    public void Death()
    {
        animator.SetTrigger("Death");
    }

    // chi so cua layer dem tu 0, con layerCount dem tu 1
    public void LayerIndex(int index)
    {
        for (int i = 1; i <= animator.layerCount-1; i++)  // chi so LayerWeight cua layer dau tien khong chinh duoc nen i chay tu 1 tuc layer thu 2 
        {
            animator.SetLayerWeight(i, 0f);
        }
        animator.SetLayerWeight(index + 1, 1f);
        layer = index +1;
    }
    void AnimationPlayer()
    {
        // combo
        animator.SetFloat("speed", Player.Instance.move);
        if (Input.GetKeyDown(KeyCode.H))
        {          
            AtkPL();
        }
       
        if (Input.GetKeyDown(KeyCode.J) && timeJ >= 4f)
        {            
            timeJ = 0f;
            Skill4();
            
        }
        timeJ += Time.deltaTime;      
        if (Input.GetKeyDown(KeyCode.K) && timeK >= 8f)
        {
            timeK = 0f;
            Skill5();
        }
        timeK += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.L) && timeL >= 12f)
        {
            timeL = 0f;
            Skill6();
        }
        timeL += Time.deltaTime;
       
        
    }
    public void Skill4()
    {
        if (layer == 1)
        {
            animator.SetTrigger("AtkSword4");
        }
        else if (layer == 2)
        {
            animator.SetTrigger("AtkStick4");
        }
    }
    public void Skill5()
    {
        if (layer == 1)
        {
            animator.SetTrigger("AtkSword5");
        }
        else if (layer == 2)
        {
            animator.SetTrigger("AtkStick5");
        }
    }
    public void Skill6()
    {
        if (layer == 1)
        {
            animator.SetTrigger("AtkSword6");
        }
        else if (layer == 2)
        {
            animator.SetTrigger("AtkStick6");
        }
    }
    public void ComboLayer()
    {
        switch (layer)
        {
            case 0:
                animator.SetInteger("ATK", 1);
                break;
            case 1:
                animator.SetInteger("ATKSword", 1);
                break;
            case 2:
                animator.SetInteger("ATKStick", 1);
                break;

        }
    }
    public void SkillJ()
    {
        if(timeJ>=4f)
        {
            timeJ = 0f;
            Skill4();
        }         
    }
    public void SkillK()
    {
        if (timeK >= 8f)
        {
            timeK = 0f;
            Skill5();
        }       
    }
    public void SkillL()
    {
        if (timeL >= 12f)
        {
            timeL = 0f;
            Skill6();
        }        
    }
    public void AtkPL()
    {
        combo++;
        if (combo == 1)
        {            
            ComboLayer();
        }
    }
    public void CheckCombo()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("1"))
        {           
            if (combo > 1)
            {
                animator.SetInteger("ATK", 2);
            }
            else
            {
                ResetCombo();
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("2"))
        {           
            if (combo > 2)
            {
                animator.SetInteger("ATK", 3);
            }
            else
            {
                ResetCombo();
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("3"))
        {           
            if (combo >= 3)
            {
                ResetCombo();
            }
        }        
        
    }
    public void CheckComboSword()
    {
        if (animator.GetCurrentAnimatorStateInfo(1).IsName("1"))
        {
            if (combo > 1)
            {
                animator.SetInteger("ATKSword", 2);
            }
            else
            {
                ResetCombo();
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(1).IsName("2"))
        {
            if (combo > 2)
            {
                animator.SetInteger("ATKSword", 3);
            }
            else
            {
                ResetCombo();
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(1).IsName("3"))
        {
            if (combo >= 3)
            {
                ResetCombo();
            }
        }

    }
    public void CheckComboStick()
    {
        if (animator.GetCurrentAnimatorStateInfo(2).IsName("1"))
        {
            if (combo > 1)
            {
                animator.SetInteger("ATKStick", 2);
            }
            else
            {
                ResetCombo();
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(2).IsName("2"))
        {
            if (combo > 2)
            {
                animator.SetInteger("ATKStick", 3);
            }
            else
            {
                ResetCombo();
            }
        }
        else if (animator.GetCurrentAnimatorStateInfo(2).IsName("3"))
        {
            if (combo >= 3)
            {
                ResetCombo();
            }
        }

    }
    public void ResetCombo()
    {
        combo = 0;
        //animator.SetInteger("ATK",0);
        switch (layer)
        {
            case 0:
                animator.SetInteger("ATK", 0);
                break;
            case 1:
                animator.SetInteger("ATKSword", 0);
                break;
            case 2:
                animator.SetInteger("ATKStick", 0);
                break;

        }

    }
    
    public float TimeJ()
    {
        return timeJ;
    }
    public float TimeK()
    {
        return timeK;
    }
    public float TimeL()
    {
        return timeL;
    }

}
