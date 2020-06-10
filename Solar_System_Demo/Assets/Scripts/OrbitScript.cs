using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitScript : MonoBehaviour
{
    Transform parent;
    Transform parentOrbit;
    public float RotationSpeed = 1;
    public float OribitSpeed = 1;
    private const float YearInSeconds = 60;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.parent)
        {
            parent = transform.parent;
            parentOrbit = new GameObject().transform;
            parentOrbit.name = gameObject.name + "_pivot";
            parentOrbit.position = parent.position;
            transform.parent = parentOrbit;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (parentOrbit)
        {
            parentOrbit.Rotate(new Vector3(0, getRotation(OribitSpeed / 365), 0));
            parentOrbit.position = parent.position;
        }
        transform.Rotate(new Vector3(0, getRotation(RotationSpeed), 0));
    }

    private float getRotation(float rotationPerYear)
    {
        float yearPercent = Time.deltaTime / YearInSeconds;
        float degreesPerYear = 365 / rotationPerYear;
        return yearPercent * degreesPerYear;
    }
}
