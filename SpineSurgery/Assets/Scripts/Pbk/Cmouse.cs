using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cmouse : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform tr;
    void Start()
    {
        tr = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.position = Input.mousePosition;
    }
}
