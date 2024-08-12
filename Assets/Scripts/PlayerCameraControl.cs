using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraControl : NetworkBehaviour
{
    [SerializeField] GameObject cam;

    public override void OnStartAuthority()
    {
        cam.SetActive(true);
    }
}
