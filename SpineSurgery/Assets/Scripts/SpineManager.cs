using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineManager : MonoBehaviour
{
    public GameObject[] Spines;              // 척추 오브젝트를 저장해둡니다.
    public float GenerateIntensity = 10f;    // 값이  높을수록 척추가 심하게 구부러진 채로 생성됩니다.
    [Range(0,1)]
    public float Intensity = 1f;             // 값이 척추 구부러짐 비율 (0 ~ 1)
    private float[] SpineAngles;    // 각 척추의 각도를 저장해둡니다.

    private void Start()
    {
        SpineAngles = new float[Spines.Length];
        InitializeAngles();
    }

    private void Update()
    {
        for (int spineCount = 0; spineCount < Spines.Length; spineCount++)
        {
            Spines[spineCount].transform.rotation = Quaternion.Euler(0, 0, SpineAngles[spineCount] * Intensity);
        }
    }

    public void Dance()
    // 호출하면 척추가 춤을 춥니다!
    { StartCoroutine("Cor_Dance"); }

    public void StopDance()
    { StopCoroutine("Cor_Dance"); }

    public void ScrambleSpine()
    // 척추를 랜덤하게 구부립니다.
    {
        float randomFactor = Random.Range(0f, 1f);
        for (int spineCount = 0; spineCount < Spines.Length; spineCount++)
        {
            SetSpineAngle(spineCount, (Mathf.Sin((Time.time + randomFactor) * 8f + (spineCount + 1) * 0.8f)) * GenerateIntensity);
        }
    }

    public void InitializeAngles()
        // 현재 척추 각도를 SpineAngles에 저장합니다.
    { 
        for(int spineCount = 0; spineCount < Spines.Length; spineCount++)
        {
            SpineAngles[spineCount] = Spines[spineCount].transform.rotation.eulerAngles.z;
        }
    }

    public void RepiarSpine(int spineIndex)
        // 미사용 || spineIndex 번호의 척추를 교정합니다(각도를 0으로 만듭)
    {
       // StartCoroutine(Cor_RepairSpine(spineIndex));
    }

    public void RepairSpineTest()
        // 미사용 || 척추 교정 테스트용. 점진적으로 척추를 교정합니다.
    {
       // StartCoroutine(Cor_RepairSpineTest());
    }
    
    private IEnumerator Cor_Dance()
    {
        while (true) 
        {
            for (int spineCount = 0; spineCount < Spines.Length; spineCount++)
            {
                SetSpineAngle(spineCount, (Mathf.Sin(Time.time * 8f + (spineCount+1)*0.8f)) * GenerateIntensity);
            }
                yield return null;
        }
    }

    //private IEnumerator Cor_RepairSpine(int spineIndex)
    //{
    //    if (Spines[spineIndex] == null)
    //    {
    //        Debug.LogError("접근할 수 없는 Spines에 접근하려 들었습니다.");
    //        yield break;
    //    }

    //    while(Mathf.Abs(Spines[spineIndex].transform.localRotation.eulerAngles.z) >= 1f)
    //    {
    //        SetSpineAngle(spineIndex, Mathf.LerpAngle(Spines[spineIndex].transform.localRotation.eulerAngles.z, 0, 0.15f));
    //       // Spines[spineIndex].transform.localRotation = Quaternion.Euler(0f,0f, Mathf.LerpAngle(Spines[spineIndex].transform.localRotation.eulerAngles.z, 0, 0.15f));
    //        yield return new WaitForFixedUpdate();
    //    }
    //    Spines[spineIndex].transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    //}

    //private IEnumerator Cor_RepairSpineTest()
    //{
    //    for(int i = Spines.Length - 1; i >= 0; --i)
    //    {
    //        yield return StartCoroutine(Cor_RepairSpine(i));
    //    }
    //}

    private void SetSpineAngle(int spineIndex, float angle)
    {
        Spines[spineIndex].transform.rotation = Quaternion.Euler(0f, 0f, Mathf.DeltaAngle(Spines[spineIndex].transform.rotation.z, angle));
        SpineAngles[spineIndex] = angle;
        Spines[spineIndex].transform.rotation = Quaternion.Euler(0, 0, SpineAngles[spineIndex] * Intensity);
    }


}
