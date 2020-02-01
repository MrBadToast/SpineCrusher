using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackDrawer : MonoBehaviour
{
    public SpineManager Spine;

    private LineRenderer lineRenderer;
    private GameObject[] Spines;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        for(int i = 0; i < Spine.Spines.Length; i++)
        {

        }
    }
}
