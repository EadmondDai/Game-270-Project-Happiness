using UnityEngine;
using System.Collections;

// Created by Eadmond, 10.21.2016
// The script enable the camera follow certain routine provided by the level.
// Other script should provide a gameobject contains all the routine point named from CameraPos1.
// The Camera will stay at the first camera point. The level can ask the camera to move when it's ready.


public class CameraMove : MonoBehaviour
{

    public Quaternion Rotation;

    public float DistanceAllow = 0.2f;

    private ArrayList CameraTransArray;

    public string CameraPosNameBas = "CameraPos";

    // Related to moving the camera. Using Lerp.

    public float Speed = 1.5f;

    private float StartTime;

    private float JourneyTime;

    private int PosIndex;

    public Vector3 StartPos;

    public Vector3 TargetPos;

    private bool test = true;

    public void SetCameraPosWithGameobject(GameObject cameraPosContainer)
    {
        // Before setting the array, clear it first.
        if (CameraTransArray == null)
            CameraTransArray = new ArrayList();

            CameraTransArray.Clear();

        // When get the cameraPosContainer
        // Extract all the pos information, then make main camera stay on pos 1.
        int count = 1;
        Transform cameraPosTempTrans = cameraPosContainer.transform.FindChild(CameraPosNameBas + count.ToString());
        CameraTransArray.Add(cameraPosTempTrans);
        count++;
        while (true)
        {
            Transform cameraTempTrans = cameraPosContainer.transform.FindChild(CameraPosNameBas + count.ToString());
            if (cameraTempTrans == null)
                break;

            CameraTransArray.Add(cameraTempTrans);
            count++;
        }

        // Move to the first point.
        PosIndex = 1;
        MoveCameraToPoint((Transform)CameraTransArray[0]);
    }

    void MoveCameraToPoint(Transform targetTrans)
    {
        StartPos = transform.position;
        TargetPos = targetTrans.position;
    }

    // Use this to make the camera move from one pos to another.
    public void StartMove()
    {

    }

    public bool IsTheLastPos()
    {
        // Get the last trans in array, and compare the distance.
        int lastIndex = CameraTransArray.Count - 1;
        Transform lastTrans = (Transform)CameraTransArray[lastIndex];
        if (Vector3.Distance(lastTrans.position, transform.position) <= DistanceAllow)
            return true;

        return false;
    }


    // Use this for initialization
    void Start()
    {
        StartTime = Time.time;

        GameObject manager = GameObject.Find("/CameraPosContainer");
        SetCameraPosWithGameobject(manager);
    }

    // Update is called once per frame
    void Update()
    {
        JourneyTime = Time.time - StartTime;
        float timePerc = JourneyTime / Vector3.Distance(StartPos, TargetPos) * Speed;
        transform.position = Vector3.Lerp(StartPos, TargetPos, timePerc);
    }

}
