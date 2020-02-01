using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMgr : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Image[] Life = new Image[3];
    [SerializeField]
    private Sprite DieLife;
    [SerializeField]
    private int MaxTime;
    [SerializeField]
    private Slider Timebar;
    private float curTime;
    private GameObject LifeObject;//클래스
    private int Lifevalue;
    public float CurTime { get => curTime; }

    void Start()
    {
        //LifeObject.GetComponentInChildren<>변수가져오기
        Lifevalue = 0;
        curTime = Timebar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Lifevalue++;
        for (int i=0; i<Lifevalue;i++)
        {
            Life[i].sprite = DieLife;
        }
        
        ///////////////////////////
        //Debug.Log(res);
        curTime -= Time.deltaTime;
        Timebar.value=curTime;
        if (Lifevalue == 3||curTime<=0.0f)
            SceneManager.LoadScene(2);
    }
}
