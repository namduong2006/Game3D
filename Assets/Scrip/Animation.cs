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
    public void LayerIndex(int index)
    {
        for (int i = 1; i <= animator.layerCount-1; i++)
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
            combo++;
            if (combo == 1)
            {
                animator.SetInteger("ATK", 1);
            }

        }
       
        if (Input.GetKeyDown(KeyCode.J) && timeJ >= 4f)
        {            
            timeJ = 0f;
            animator.SetTrigger("Atk4");
        }
        timeJ += Time.deltaTime;      
        if (Input.GetKeyDown(KeyCode.K) && timeK >= 8f)
        {
            timeK = 0f;
            animator.SetTrigger("Atk5");
        }
        timeK += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.L) && timeL >= 12f)
        {
            timeL = 0f;
            animator.SetTrigger("Atk6");
        }
        timeL += Time.deltaTime;
        //if (animator.GetCurrentAnimatorStateInfo(layer).IsName("Blend Tree"))
        //{
        //    timecombo += Time.deltaTime;
        //    if (timecombo > 3f)
        //    {
        //        timecombo = 0;
        //        ResetCombo();
        //    }
        //}
    }
    public void SkillJ()
    {
        if(timeJ>=4f)
        {
            timeJ = 0f;
            animator.SetTrigger("Atk4");
        }         
    }
    public void SkillK()
    {
        if (timeK >= 8f)
        {
            timeK = 0f;
            animator.SetTrigger("Atk5");
        }       
    }
    public void SkillL()
    {
        if (timeL >= 12f)
        {
            timeL = 0f;
            animator.SetTrigger("Atk6");
        }        
    }
    public void AtkPL()
    {
        combo++;
        if (combo == 1)
        {
            animator.SetInteger("ATK", 1);
        }
    }
    public void CheckCombo()
    {
        if (animator.GetCurrentAnimatorStateInfo(layer).IsName("1"))
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
        else if (animator.GetCurrentAnimatorStateInfo(layer).IsName("2"))
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
        else if (animator.GetCurrentAnimatorStateInfo(layer).IsName("3"))
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
        animator.SetInteger("ATK",0);
        
    }
    public void JumpTrue()
    {
        animator.SetBool("Jump", true);
    }
    public void JumpFalse()
    {
        animator.SetBool("Jump", false);
    }
    public void GroundingTrue()
    {
        animator.SetBool("Grounding", true);
    }
    public void GroundingFalse()
    {
        animator.SetBool("Grounding", false);
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
