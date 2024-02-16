using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CameraScript : MonoBehaviour
{
    public float sceneWidth = 22f;

    Camera _camera;
    void Start() {
        _camera = GetComponent<Camera>();
    }

    void Update() {
        float unitsPerPixel = sceneWidth / Screen.width;

        float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;

        _camera.orthographicSize = desiredHalfHeight;
    }
}

