using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CButton : MonoBehaviour
{
    [SerializeField]
    private GameObject Openning;

    public void Start()
    {
    }
    public void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Openning.activeSelf)
                SceneManager.LoadScene(1);
            if (!Openning.activeSelf)
                Openning.SetActive(true);
        }
    }
}
