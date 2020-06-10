using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPlaneController : MonoBehaviour
{

    public bool InverseVertical, InverseHorizontal;
    public float VerticalSmoothing = 1;
    public float HorizontalSmoothing = 1;
    public float MovementSpeed = 10;

    //private Vector2 mousePosition;
    private Transform CameraRig;
    // Start is called before the first frame update
    void Start()
    {
        CameraRig = new GameObject().transform;
        CameraRig.name = "PlaneRig";
        CameraRig.position = transform.position;
        transform.parent = CameraRig;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = 1;
        CameraRig.position += h * Time.deltaTime * transform.right * MovementSpeed + v * Time.deltaTime * transform.forward * MovementSpeed;

        //Vector2 deltaMouse = mousePosition - (Vector2)Input.mousePosition;
        //CameraRig.Rotate(new Vector3(0, -deltaMouse.x * HorizontalSmoothing * Time.deltaTime, 0));
        //transform.Rotate(new Vector3(deltaMouse.y * VerticalSmoothing * Time.deltaTime, 0, 0));

        float yRot = Input.GetAxis("Mouse X") * HorizontalSmoothing;
        float xRot = Input.GetAxis("Mouse Y") * VerticalSmoothing;

        CameraRig.Rotate(new Vector3(0, yRot, 0));
        transform.Rotate(new Vector3(-xRot, 0, 0));
    }
}
