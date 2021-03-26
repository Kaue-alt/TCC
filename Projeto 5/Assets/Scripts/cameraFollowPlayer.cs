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
        holder.transform.SetPositionAndRotation(new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), Quaternion.identity);
    }
}
