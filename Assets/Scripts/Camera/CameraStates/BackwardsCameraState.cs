using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackwardsCameraState : AbstactCamera
{

    private Quaternion _backwardsTargetAngle = Quaternion.Euler(30, 180, 0);

    public override void OnStateExit(CameraController camera)
    {
        camera._playerControllerScript._hitCameraObstacleBackwards = false;
    }

    public override void OnStateUpdate(CameraController camera)
    {
        if (camera._playerControllerScript._hitCameraObstacleLeft)
        {
            OnStateExit(camera);
            camera.MakeTransitionToNextState(camera.leftwardsCamera);
        }
        if (camera._playerControllerScript._hitCameraObstacleRight)
        {
            OnStateExit(camera);
            camera.MakeTransitionToNextState(camera.rightwardsCamera);
        }
        camera.transform.position = new Vector3(camera.player.transform.position.x, camera.player.transform.position.y + 10,
                camera.player.transform.position.z + 25);
        camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, _backwardsTargetAngle, .2f);
    }
}
