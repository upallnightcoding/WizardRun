using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraCntrl : MonoBehaviour
{
    [SerializeField] private Transform player;

    // Difference between camera and player position
    private Vector3 difference;

    // Start is called before the first frame update
    void Start()
    {
        difference = gameObject.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.position = 
            new Vector3(
                0.0f,
                difference.y + player.transform.position.y,
                difference.z + player.transform.position.z
            );
    }
}
