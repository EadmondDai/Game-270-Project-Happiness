using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// Created by Eadmond, 10.21.2016
// The script enable the camera follow certain routine provided by the level.
// Other script should provide a gameobject contains all the routine point named from CameraPos1.
// The Camera will move to the first camera point, then continue to next point, untill there is no more point.
// If the character is outside of the cameraview, it will restart the scene.

// This script access the PlayerMove script to check if the player collected enough friend;

public class CameraMove : MonoBehaviour
{
    // Maybe use this in the future, to rotate the camera.
    //public Quaternion Rotation;

    public float DistanceAllow = 0.2f;

    private ArrayList CameraTransArray;

    public string CameraPosNameBas = "CameraPos";

    public GameObject CameraPosContainer;

    public GameObject PlayerObj;

    // Related to moving the camera. Using Lerp.

    public float Speed = 1.5f;

    private float StartTime;

    private float JourneyTime;

    private float JourneyDistance;

    private int NextPosIndex;

    public Vector3 StartPos;

    public Vector3 TargetPos;

    private Vector3 MoveDirection;

    // Related to Restart;

    public GameObject MySceneManaObj;

    // Related to level end check

    private float LevelCheckTime = 0;

    public float TimeLeftForLevelEnd = 5;

    private PlayerMove PlayerMoveScript;

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
        NextPosIndex = 1;
        MoveCameraToPoint((Transform)CameraTransArray[0]);
    }

    void MoveCameraToPoint(Transform targetTrans)
    {
        StartPos = transform.position;
        TargetPos = targetTrans.position;

        MoveDirection = TargetPos - StartPos;

        JourneyDistance = Vector3.Distance(StartPos, TargetPos);
        StartTime = Time.time;
    }

    // Use this to make the camera move from one pos to another.
    //public void StartMove()
    //{

    //}

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
        //GameObject manager = GameObject.Find("/CameraPosContainer");
        SetCameraPosWithGameobject(CameraPosContainer);

        PlayerMoveScript = PlayerObj.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraTransArray == null || CameraTransArray.Count == 0)
            return;

        JourneyTime = Time.time - StartTime;
        float timePerc = JourneyTime / Vector3.Distance(StartPos, TargetPos) * Speed;

        // Finished this little trip.
        if(timePerc >= 1)
        {
            MoveDirection = Vector3.zero;

            // Check if there is next element in the array, if not, stop all the moving.
            if (NextPosIndex < CameraTransArray.Count)
            {
                Transform nextTrans = (Transform)CameraTransArray[NextPosIndex++];
                MoveCameraToPoint(nextTrans);
            }
        }else
        {
            transform.position = Vector3.Lerp(StartPos, TargetPos, timePerc);
        }

        // Check if the playe is outside of the camera view.

        Vector3 screePoint = Camera.main.WorldToViewportPoint(PlayerObj.transform.position);
        bool onScreen = screePoint.x > 0 && screePoint.x < 1 && screePoint.y > 0 && screePoint.y < 1 && screePoint.z > 0;
        if (!onScreen)
        {
            MySceneManager MySceneManagerScript = MySceneManaObj.GetComponent<MySceneManager>();

            MySceneManagerScript.RestartLevel();
        }


        //  Check if the Camera has reached the last position.
        if (LevelCheckTime == 0 && IsTheLastPos())
        {
            LevelCheckTime = Time.time + TimeLeftForLevelEnd;
        }
        else if(LevelCheckTime <= Time.time && IsTheLastPos())
        {
            if (PlayerMoveScript.FriendResued >= PlayerMoveScript.FriendNeedForThisLevel)
            {
                MySceneManager MySceneManagerScript = MySceneManaObj.GetComponent<MySceneManager>();

                MySceneManagerScript.NextLevel();
            }
            else
            {
                MySceneManager MySceneManagerScript = MySceneManaObj.GetComponent<MySceneManager>();

                MySceneManagerScript.RestartLevel();
            }
            
        }
    }


    // Get current moving direction of the camera, if it is vector3.zero, means the camera is not moving.
    public Vector3 GetCameraMovingDirection()
    {
        return MoveDirection;
    }

    // Get the Camera view frame in the world.
    public void GetCameraViewRect(out float width, out float height)
    {
        Vector3 size = transform.FindChild("CameraViewFrame").GetComponent<MeshRenderer>().bounds.size;

        width = size.x;
        height = size.y;
    }


}
