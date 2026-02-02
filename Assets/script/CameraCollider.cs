using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    private float offset = 0f;

    void Start()
    {
        CreateEdgeCollider();
    }

    void CreateEdgeCollider()
    {
        Camera cam = Camera.main;
        Vector2[] edgePoints = new Vector2[5];

        Vector3 bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, -cam.transform.position.z));
        Vector3 topLeft = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, -cam.transform.position.z));
        Vector3 topRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -cam.transform.position.z));
        Vector3 bottomRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, -cam.transform.position.z));


        Vector2 offsetVec = new Vector2(offset, offset);

        edgePoints[0] = (Vector2)bottomLeft - offsetVec;
        edgePoints[1] = (Vector2)topLeft - new Vector2(offset, -offset);
        edgePoints[2] = (Vector2)topRight + offsetVec;
        edgePoints[3] = (Vector2)bottomRight - new Vector2(-offset, offset);
        edgePoints[4] = (Vector2)bottomLeft - offsetVec;

        EdgeCollider2D edgeCollider = gameObject.AddComponent<EdgeCollider2D>();
        edgeCollider.points = edgePoints;

    }
}
