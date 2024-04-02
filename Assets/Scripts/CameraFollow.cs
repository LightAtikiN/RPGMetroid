using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class CameraFollow : NetworkBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;
    private void Start()
    {
        if (!isLocalPlayer) gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + Vector3.back * 10, speed * Time.deltaTime);
    }
}
