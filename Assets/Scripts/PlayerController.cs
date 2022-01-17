using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Current;
    public float runningSpeed;
    public float xSpeed;
    private float _currentRunningSpeed;
    public float limitX;
    public GameObject ridingCylinderPrefab;
    public List<RidingCylinder> cylinders;
    //public float xMin, xMax;
    // Start is called before the first frame update
    void Start()
    {
        Current = this;
        _currentRunningSpeed = runningSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float newX = 0;
        float touchXDelta = 0;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase== TouchPhase.Moved)
        {
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }

        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitX, limitX);
            
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + _currentRunningSpeed * Time.deltaTime);
        transform.position = newPosition;
        //Mathf.Clamp(transform.position.x, xMin, xMax);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="AddCylinder")
        {
            IncrementyCylinderVolume(0.1f);
            Destroy(other.gameObject);

        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Trap")
        {

            IncrementyCylinderVolume(-Time.fixedDeltaTime);
        }
    }
    public void IncrementyCylinderVolume(float value)
    {
        if (cylinders.Count == 0)
        {
            if (value > 0)
            {
                CreateCylinder(value);
            }
            else
            {
                // gameover
            }

        }
        else
        {
            cylinders[cylinders.Count - 1].IncrementyCylinderVolume(value);
        }

    }
    public void CreateCylinder( float value)
    {
        RidingCylinder createCylinder = Instantiate(ridingCylinderPrefab, transform).GetComponent<RidingCylinder>();
        cylinders.Add(createCylinder);
        createCylinder.IncrementyCylinderVolume(value);
    }
    public void DestroyCylinder(RidingCylinder cylinder)
    {
        cylinders.Remove(cylinder);
        Destroy(cylinder.gameObject);
    }
}
