using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CameraActionFollowPerspective cameraActionFollowPerspective;

    private void Awake()
    {

    }

    /*private void ActivateBoxFollower(List<Player> players)
    {
        var targetList = players.ConvertAll(x => x.transform);

        cameraActionFollowPerspective.SetTargets(targetList);
    }*/

    private void SetTargetsToBox()
    {

    }

}
