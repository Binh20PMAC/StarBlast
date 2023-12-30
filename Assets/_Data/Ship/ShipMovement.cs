using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{

    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.1f;

    private void FixedUpdate()
    {
        this.GetTargetPosition();
        this.LookAtTarget();
        this.Moving();
    }

    protected virtual void GetTargetPosition()
    {
        this.targetPosition = InputManager.Instance.MouseWorldPos;
        this.targetPosition.z = 0;
    }

    protected virtual void LookAtTarget()
    {
        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
    protected virtual void Moving()
    {
        transform.parent.position = Vector3.Lerp(transform.parent.position, this.targetPosition, this.speed);
    }
}
