using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public GameObject SucceedParticle;
    public GameObject FailParticle;
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
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D rayhit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            if(rayhit.collider.gameObject == this.gameObject)
            {
                CheckCorrect();
            }
            
        }
    }

    private void CheckCorrect()
    {
        Debug.Log(Ring.radius);
        if (Ring.radius > TolleranceMin && Ring.radius < TolleranceMax)
        {
            Instantiate(SucceedParticle,transform.position,Quaternion.identity);
            StageManager.instance.OnNoteCorrect();
            Destroy(this.gameObject);
        }
        else
        {
            Instantiate(FailParticle, transform.position, Quaternion.identity);
            StageManager.instance.OnNoteMiss();
            Destroy(this.gameObject);
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

        CheckCorrect();
    }

    

}
