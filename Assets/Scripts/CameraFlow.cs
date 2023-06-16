using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    private Vector3Int locationOffset = new Vector3Int(0, 5, -10);
    [SerializeField]
    private Vector3Int rotationOffset;
    private Transform target;
    [SerializeField]
    private float smoothSpeed = 0.125f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {

            target = player.GetComponent<Transform>();

        }
    }

    // Update is called once per frame
    /*
    void Update()
    {
        if (target != null)
        {
            Vector3 newPos = new Vector3(target.position.x + xOffset, target.position.y + yOffset, target.position.z + zOffset);
            this.transform.position = Vector3.Slerp(this.transform.position, newPos, speedFollow * Time.deltaTime);
        }
    }*/
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + target.rotation * locationOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        Quaternion desiredrotation = target.rotation * Quaternion.Euler(rotationOffset);
        Quaternion smoothedrotation = Quaternion.Lerp(transform.rotation, desiredrotation, smoothSpeed);
        transform.rotation = smoothedrotation;
    }

}
