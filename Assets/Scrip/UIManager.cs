using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public static UIManager Instance;           
    [SerializeField] Slider HPpl;
    [SerializeField] Image timeJ;
    [SerializeField] Image timeK;
    [SerializeField] Image timeL;
    [SerializeField] GameObject UIskill;
    [SerializeField] GameObject timeSKJ;
    [SerializeField] GameObject timeSKK;
    [SerializeField] GameObject timeSKL;
    [SerializeField] GameObject gameover;
    [SerializeField] GameObject infoenemmy;
    [SerializeField] Slider HpEnemy;
    [SerializeField] TMP_Text nameEnemy;
    float timeofinfo = 0f;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {      
        UIskill.SetActive(false);
        HPpl.maxValue = Player.Instance.MaxHPPlayer();
        gameover.SetActive(false); 
        Time.timeScale = 1.0f;
        infoenemmy.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {      
        GameUI();   
        
    }

    public void GameUI()
    {
        timeofinfo += Time.deltaTime;
        if (timeofinfo > 10f)
        {
            infoenemmy.SetActive(false);
        }        
        HPpl.value = Player.Instance.HPPlayer();       
        timeJ.fillAmount = 0.25f * Animation.instance.TimeJ();
        timeK.fillAmount = 0.125f * Animation.instance.TimeK();
        timeL.fillAmount = 0.083f * Animation.instance.TimeL();
        if(timeJ.fillAmount >= 1)
        {
            timeSKJ.SetActive(false);
        }
        else timeSKJ.SetActive(true);
        if (timeL.fillAmount >= 1)
        {
            timeSKL.SetActive(false);
        }
        else timeSKL.SetActive(true);
        if (timeK.fillAmount >= 1)
        {
            timeSKK.SetActive(false);
        }
        else timeSKK.SetActive(true);
    }
    public void OffTimeScale()
    {
        Time.timeScale = 0f;
    }
    public void OnTimeScale()
    {
        Time.timeScale = 1f;
    }
    public void UISkill()
    {
        UIskill.SetActive(true);
    }    
    public void ATKPL()
    {
        Animation.instance.AtkPL();
    }   
    public void BTSkillJ()
    {
        Animation.instance.SkillJ();
    }   
    public void BTSkillK()
    {
        Animation.instance.SkillK();
    }
    public void BTSkillL()
    {
        Animation.instance.SkillL();
    }
    public void GameOver()
    {
        gameover.SetActive(true);
        Time.timeScale = 0f;
    }
    public void InfoEnemyOn(string name, int maxhp,int hp)
    {
        SetTimeInfo();
        HpEnemy.maxValue = maxhp;
        HpEnemy.value = hp;
        nameEnemy.text = name.ToString();
    }
    public void InfoEnemyOff()
    {
        infoenemmy.SetActive(false);
    }
    public void SetTimeInfo()
    {
        timeofinfo = 0f;
        infoenemmy.SetActive(true);
        
    }
}
