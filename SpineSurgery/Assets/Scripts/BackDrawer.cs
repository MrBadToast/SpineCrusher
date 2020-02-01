using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackDrawer : MonoBehaviour
{
    public SpineManager Spine;

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lineRenderer.positionCount = 0;

        lineRenderer.positionCount++;
        lineRenderer.SetPosition(0, new Vector3(0, -10f));

        for (int i = 0; i < Spine.Spines.Length; i++)
        {
            Debug.Log(i < Spine.Spines.Length);
            lineRenderer.positionCount++;

            lineRenderer.SetPosition(i + 1, Spine.Spines[i].transform.position);
        }

        lineRenderer.positionCount++;
        lineRenderer.SetPosition(Spine.Spines.Length + 1, new Vector3(0, 10f));
    }

}
