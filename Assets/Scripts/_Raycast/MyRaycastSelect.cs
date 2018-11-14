using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRaycastSelect : RaycastSelect {

    protected override void OnRaycastEnter(GameObject target)
    {
        print("Activated trigger");
    }
    protected override void OnRaycastLeave(GameObject target)
    {
        print("Hey ya no me miras!");
    }

    protected override void UpdateFromFather()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * selectionDistance;
        Debug.DrawRay(transform.position, forward, Color.green);
    }
}
