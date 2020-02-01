using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongNote : MonoBehaviour
{
    public GameObject SucceedParticle;
    public GameObject FailParticle;
    public RingDrawer Ring;
    public Transform EndPosition;

    public float TolleranceMin = 0.75f;
    public float TolleranceMax = 1.25f;
    public float FullShrinkTime = 2f;
    public float FullRingSize = 10f;
    public float RollTime = 2.0f;

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        StartCoroutine("Cor_ShrinkRing");

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, EndPosition.position);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D rayhit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
            if (rayhit.collider.gameObject == this.gameObject)
            {
                GetComponent<CircleCollider2D>().enabled = false;
                StartCoroutine(Cor_CheckCorrect());
            }

        }
    }

    private IEnumerator Cor_CheckCorrect()
    {
        float tMinus = 0;

        StopCoroutine("Cor_ShrinkRing");

        if (Ring.radius > TolleranceMin && Ring.radius < TolleranceMax)
        {

            Vector3 leagcyPos = this.transform.position;
            while (Input.GetMouseButton(0) && Vector2.Distance(transform.position, EndPosition.position) > 0.1f)
            {
                tMinus += Time.deltaTime;
                this.transform.position = Vector3.Lerp(leagcyPos, EndPosition.position, 1 - (RollTime - tMinus) / RollTime);
                yield return new WaitForFixedUpdate();
                if (!Input.GetMouseButton(0))
                {
                    Instantiate(FailParticle, transform.position, Quaternion.identity);
                    StageManager.instance.OnNoteMiss();
                    Destroy(this.gameObject);
                    yield break;
                }
            }

            Instantiate(SucceedParticle, transform.position, Quaternion.identity);
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

        while (Ring.radius >= 0.1f)
        {
            tMinus += Time.deltaTime;
            Ring.radius = Mathf.Lerp(FullRingSize, 0, 1 - (FullShrinkTime - tMinus) / FullShrinkTime);
            yield return new WaitForFixedUpdate();
        }

        Instantiate(FailParticle, transform.position, Quaternion.identity);
        StageManager.instance.OnNoteMiss();
        Destroy(this.gameObject);
    }

    private void OnGUI()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(EndPosition.position, 1.0f);
        Gizmos.DrawLine(transform.position, EndPosition.position);
    }

}
