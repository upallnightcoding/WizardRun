using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerCntrl : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float trackerDistance;
    [SerializeField] private float xDisplacement;

    private Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = new Vector3(
            player.transform.position.x,
            player.transform.position.y,
            player.transform.position.z + trackerDistance
        );

        transform.position = position;
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKey(KeyCode.A)) 
         {
            position.x -= xDisplacement;
         }

         if (Input.GetKey(KeyCode.D)) 
         {
            position.x += xDisplacement;
         }

         transform.position = 
            new Vector3(
                position.x,
                player.transform.position.y,
                player.transform.position.z + trackerDistance
            );
    }
}
