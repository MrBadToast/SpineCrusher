using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleStage
{
    public int stageIndex;
    public 

}

public class StageManager : MonoBehaviour
{
    [HideInInspector]
    public static StageManager instance;

    public int life = 3;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    public void OnNoteCorrect()
    {

    }

    public void OnNoteMiss()
    {
        life--;

        if (life == 0)
            GameOver();
    }

    public void GameOver()
    {

    }

    public void NextStage()
    {

    }

}
