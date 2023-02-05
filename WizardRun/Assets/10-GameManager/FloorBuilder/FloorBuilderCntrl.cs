using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBuilderCntrl : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float spacing;
    [SerializeField] private float nStart;
    [SerializeField] private GameObject floorPreFab;

    private float zposition;
    private float forwardDistance;

    // Start is called before the first frame update
    void Start()
    {
        zposition = 0.0f;
        forwardDistance = (nStart - 1.0f) * spacing;

        for (int i = 0; i < nStart; i++, zposition+=spacing) {
            Vector3 position = new Vector3(0.0f, 0.0f, zposition);
            Instantiate(floorPreFab, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z + forwardDistance > zposition)
        {
            Vector3 position = new Vector3(0.0f, 0.0f, zposition);
            Instantiate(floorPreFab, position, Quaternion.identity);
            zposition+=spacing;
        }
    }
}
