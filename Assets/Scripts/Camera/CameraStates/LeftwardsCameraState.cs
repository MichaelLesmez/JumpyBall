using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftwardsCameraState : AbstactCamera
{

    private Quaternion _leftTargetAngle = Quaternion.Euler(30, 90, 0);

    public override void OnStateExit(CameraController camera)
    {
        camera._playerControllerScript._hitCameraObstacleLeft = false;
    }

    public override void OnStateUpdate(CameraController camera)
    {
        if (camera._playerControllerScript._hitCameraObstacleRight)
        {
            OnStateExit(camera);
            camera.MakeTransitionToNextState(camera.rightwardsCamera);
        }
        if (camera._playerControllerScript._hitCameraObstacleBackwards)
        {
            OnStateExit(camera);
            camera.MakeTransitionToNextState(camera.backwardsCamera);
        }
        camera.transform.position = new Vector3(camera.player.transform.position.x - 15, camera.player.transform.position.y + 10,
                camera.player.transform.position.z + 13);
        camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, _leftTargetAngle, .2f);
    }
}
