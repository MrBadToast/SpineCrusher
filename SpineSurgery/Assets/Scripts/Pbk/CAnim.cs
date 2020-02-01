using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAnim : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Animator Left;
    [SerializeField]
    private Animator Right;
    void Start()
    {
        StartCoroutine(setAnimNum());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator setAnimNum()
    {
        while(true)
        {
            yield return new WaitForSeconds(5.0f);
            int res1 = Random.Range(0, 3);
            int res2 = Random.Range(0, 3);
            Left.SetInteger("LArmSwitch", res1);
            Right.SetInteger("RArmSwitch", res2);
        }
    }
}
