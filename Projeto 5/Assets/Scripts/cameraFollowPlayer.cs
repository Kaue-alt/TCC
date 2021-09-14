using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowPlayer : MonoBehaviour
{

    public GameObject player, holder;

    void Start()
    {
        
    }

    void Update()
    {
        //0.33f, 2.79f, 6.81f
        holder.transform.SetPositionAndRotation(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), Quaternion.Euler(0.0f, 0.0f, 0.0f));
    }
}
