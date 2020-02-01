using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cmouse : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform tr;
    private Animator anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        tr = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("bAttack", Input.GetMouseButton(0));
        tr.position = Input.mousePosition;
       if(tr.position.x<Screen.width/2)
       {
           tr.localScale = new Vector3(1.0f, 1.0f);
       }
       else
       {
           tr.localScale = new Vector3(-1.0f, 1.0f);
       }
    } 
}
