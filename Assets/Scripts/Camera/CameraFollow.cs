using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public CameraSetUp cameraSetUp;
    [SerializeField] private GameObject playerObject;

    private Vector3 offset;
    void Start()
    {
        offset = cameraSetUp.offset;
    }

    void Update()
    {
        FollowPlayer(offset);
    }

    private void FollowPlayer(Vector3 offset)
    {
        transform.position = playerObject.transform.position + offset;
    }

    public void SwitchOffset(CameraSetUp cameraSetUp)
    {
        offset = cameraSetUp.offset;
    }
}

public enum SizeState
{
    Small,
    Medium,
    Large
}
