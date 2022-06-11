using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float speed;

    Vector3 target;
    Vector3 targetRotation;

    public void Update()
    {
        if (target == Vector3.zero || targetRotation == Vector3.zero)
            return;

        transform.position = Vector3.Lerp(transform.position, target, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, targetRotation, speed * Time.deltaTime));
    }

    public void MoveTo(Transform t)
    {
        target = t.position;
        targetRotation = t.rotation.eulerAngles;
    }
}
