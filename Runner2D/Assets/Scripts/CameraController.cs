using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Atributo para seguir siempre al PLAYER
    public Transform seguidorPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Unity3D. Una camara siempre trabaja en 3d -> Vector3()
        transform.position = new Vector3(seguidorPlayer.position.x + 4, 0 , transform.position.z);
    }
}
