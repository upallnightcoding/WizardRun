using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCntrl : MonoBehaviour
{
    [SerializeField] private Transform hero;

    private Vector3 difference;

    // Start is called before the first frame update
    void Start()
    {
        difference = gameObject.transform.position - hero.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = difference + hero.transform.position;
    }
}
