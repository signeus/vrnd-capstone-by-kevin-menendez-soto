using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRaycastSelect : RaycastSelect
{
    bool detected = false;
    GameObject enemy;

    float rotateSpeed = 5f;

    protected override void OnRaycastEnter(GameObject target)
    {
        gm.GameOver();
        enemy = target;
        detected = true;
    }
    protected override void OnRaycastLeave(GameObject target)
    {

    }

    protected override void UpdateFromFather()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * selectionDistance;
        Debug.DrawRay(transform.position, forward, Color.green);

        if (detected)
        {
            Vector3 direction = Vector3.right * rotateSpeed;
            enemy.transform.Rotate(direction * Time.deltaTime);
        };
    }
}
