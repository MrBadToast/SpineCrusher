using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public RingDrawer Ring;
    
    public float TolleranceMin = 0.75f;
    public float TolleranceMax = 1.25f;
    public float FullShrinkTime = 2f;
    public float FullRingSize = 10f;

    private void Start()
    {
        StartCoroutine(Cor_ShrinkRing());
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D rayhit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            if(rayhit.collider.gameObject == this.gameObject)
            {
                
            }
            
        }
    }

    private void CheckCorrect()
    {
        if (Ring.radius > TolleranceMin && Ring.radius < TolleranceMax)
        {
            StageManager.instance.OnNoteCorrect();
        }
        else
        {
            StageManager.instance.OnNoteMiss();
        }
    }

    IEnumerator Cor_ShrinkRing()
    {
        float tMinus = 0;

        while(Ring.radius >= 0.1f)
        {
            tMinus += Time.deltaTime;
            Ring.radius = Mathf.Lerp(FullRingSize, 0, 1 - (FullShrinkTime - tMinus)/FullShrinkTime);
            yield return new WaitForFixedUpdate();
        }
    }

    

}
