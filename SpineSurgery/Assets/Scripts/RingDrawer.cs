using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingDrawer : MonoBehaviour
{
    public float theta_scale = 0.01f;        //Set lower to add more points
    public float radius = 3f;
    public float width = 0.1f;

    private int size;
    LineRenderer lineRenderer;

    void Awake()
    {
        float sizeValue = (2.0f * Mathf.PI) / theta_scale;
        size = (int)sizeValue;
        size++;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = size;
        StartCoroutine(StartRing());
    }

    void Update()
    {
        Vector3 pos;
        float theta = 0f;
        for (int i = 0; i < size; i++)
        {
            theta += (2.0f * Mathf.PI * theta_scale);
            float x = radius / 2 * Mathf.Cos(theta);
            float y = radius / 2 * Mathf.Sin(theta);
            x += gameObject.transform.position.x;
            y += gameObject.transform.position.y;
            pos = new Vector3(x, y, 0);
            lineRenderer.SetPosition(i, pos);
        }
    }

    IEnumerator StartRing()
    {
        lineRenderer.startWidth = 0f; lineRenderer.endWidth = 0f;

        while(lineRenderer.startWidth < this.width)
        {
            lineRenderer.startWidth += 0.005f; lineRenderer.endWidth += 0.005f;
            yield return new WaitForFixedUpdate();
        }

        lineRenderer.startWidth = width; lineRenderer.endWidth = width;

    }
}
