using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTracking : MonoBehaviour
{
    public float factor = 0.25f;
    public float followFactor = 2.5f;
    public float limit = 0.08f;

    private Vector3 center;
    private Vector3 followPos;

    private void Start()
    {
        center = transform.position;
    }
    private void Update()
    {
        //Convert mouse pointer to worldspace
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0.0f;

        followPos = Vector3.Lerp(followPos, pos, Time.deltaTime * followFactor);

        //Create a direction target based on mouse vector * factor
        Vector3 dir = followPos * factor;

        //Clamp the direction target
        dir = Vector3.ClampMagnitude(dir, limit);

        //Update pupil position
        transform.position = center + dir;
    }
}
