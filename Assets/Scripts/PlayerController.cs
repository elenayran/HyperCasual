using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed;
    private float _currentRunningSpeed;
    public float limitX;
    //public float xMin, xMax;
    // Start is called before the first frame update
    void Start()
    {
        _currentRunningSpeed = runningSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float newX = 0;
        float touchDelta = 0;
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + _currentRunningSpeed * Time.deltaTime);
        transform.position = newPosition;
        //Mathf.Clamp(transform.position.x, xMin, xMax);

    }
}
