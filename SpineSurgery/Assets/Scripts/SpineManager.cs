using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineManager : MonoBehaviour
{
    public GameObject[] Spines;
    public float Intensity = 10f;
    private float[] SpineAngles;

    private void Start()
    {
        SpineAngles = new float[Spines.Length];
        InitializeAngles();
    }

    public void FixedUpdate()
    {
    }

    public void Dance()
    { StartCoroutine(Cor_Dance()); }

    public void ScrambleSpine()
    { StartCoroutine(Cor_ScrambleSpine()); }

    public void InitializeAngles()
    { 
        for(int spineCount = 0; spineCount < Spines.Length; spineCount++)
        {
            SpineAngles[spineCount] = Spines[spineCount].transform.rotation.eulerAngles.z;
        }
    }

    public void RepairSpineTest()
    {
        StartCoroutine(Cor_RepairSpineTest());
    }
    
    private IEnumerator Cor_Dance()
    {
        while (true) 
        {
            for (int spineCount = 0; spineCount < Spines.Length; spineCount++)
            {
                SetSpineAngle(spineCount, (Mathf.Sin(Time.time * 8f + (spineCount+1)*0.8f)) * Intensity);
            }
                yield return null;
        }
    }

    private IEnumerator Cor_ScrambleSpine()
    {
        float randomFactor = Random.Range(0f, 1f);
        for (int spineCount = 0; spineCount < Spines.Length; spineCount++)
        {
            SetSpineAngle(spineCount, (Mathf.Sin((Time.time + randomFactor) * 8f + (spineCount + 1) * 0.8f)) * Intensity);
        }
        yield return null;
    }

    private IEnumerator Cor_RepairSpine(int spineIndex)
    {
        while(Mathf.Abs(Spines[spineIndex].transform.localRotation.eulerAngles.z) >= 1f)
        {
            Spines[spineIndex].transform.localRotation = Quaternion.Euler(0f,0f, Mathf.LerpAngle(Spines[spineIndex].transform.localRotation.eulerAngles.z, 0,0.15f));
            yield return new WaitForFixedUpdate();
        }
        Spines[spineIndex].transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }

    private IEnumerator Cor_RepairSpineTest()
    {
        for(int i = 6; i >= 0; --i)
        {
            yield return StartCoroutine(Cor_RepairSpine(i));
        }
    }

    private void SetSpineAngle(int spineIndex, float angle)
    {
        Spines[spineIndex].transform.rotation = Quaternion.Euler(0f, 0f, angle);
        SpineAngles[spineIndex] = angle;
    }


}
