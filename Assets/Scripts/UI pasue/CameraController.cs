using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float minimizer = .25f;
    public Transform cam;

    public void RightClick()
    {
         cam.position += Vector3.right * minimizer;
        CameraPref.X_pos += minimizer;
    }

    public void LeftClick()
    {
        cam.position += Vector3.left * minimizer;
        CameraPref.X_pos -= minimizer;
    }

    public void UpClick()
    {
        cam.position += Vector3.up * minimizer;
        CameraPref.Y_pos += minimizer;
    }

    public void DownClick()
    {
         cam.position += Vector3.down * minimizer;
        CameraPref.Y_pos -= minimizer;
    }

    public void ZoomIn()
    {
        cam.position += new Vector3(0, 0, 1) * minimizer;
        CameraPref.Z_pos += minimizer;
    }

    public void ZoomOut()
    {
        cam.position += new Vector3(0, 0, -1) * minimizer;
        CameraPref.Z_pos -= minimizer;
    }
}
