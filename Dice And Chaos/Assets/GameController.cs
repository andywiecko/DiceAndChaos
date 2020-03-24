using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class GameController : MonoBehaviour
{
    /// <summary>
    /// specimen object to test
    /// </summary>
    public GameObject specimen = null;

    [SerializeField]
    public float initialVelocity = 50;

    private Rigidbody rb = null;

    [SerializeField]
    private Vector3 velocity;

    [SerializeField]
    private Vector3 initialAngularVelocity;

    private Vector3 position;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    [SerializeField]
    public InitialConditions initialConditions;

    [SerializeField]
    public bool trackCamera = false;
    public Camera mainCamera;
    private Vector3 initialCameraDistance;

    /// <summary>
    /// flag to display message only once
    /// </summary>
    bool messageRecived = true;

    void Start()
    {
        Initialization();
    }

    void Initialization()
    {
        Vector3 position = gameObject.transform.position;
        specimen = Instantiate(specimen, position, Quaternion.identity);
        initialCameraDistance = position - mainCamera.transform.position;
        initialPosition = specimen.transform.position;
        initialRotation = specimen.transform.rotation;
        rb = specimen.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.maxAngularVelocity = 100f;
    }


    public void RestoreInitialConditions()
    {
        specimen.transform.position = transform.position;
        specimen.transform.rotation = transform.rotation;
        rb.velocity = new Vector3(initialVelocity, 0, 0);
        rb.angularVelocity = initialAngularVelocity;
    }

    public void RollADice()
    {
        RestoreInitialConditions();
        rb.useGravity = true;
        messageRecived = false;
    }

    /// <summary>
    /// Transforming camera position to follow the specimen object
    /// </summary>
    void CameraTracker()
    {
        if (trackCamera)
            mainCamera.transform.position = specimen.transform.position - initialCameraDistance;
    }

    string FindHighestFace(Transform transfrom)
    {
        float maxheight = -1f;
        string maxname = "";
        // iterate over all specimen "faces"
        foreach (Transform child in transform)
        {
            float childheigth = child.transform.position.y;

            if (maxheight < childheigth)
            {
                maxheight = childheigth;
                maxname = child.name;
            }


        }
        return maxname;
    }

    void Propagate()
    {
        if (velocity == Vector3.zero && !messageRecived)
        {
            Debug.Log("Body stopped!");
            messageRecived = true;

            string maxname = FindHighestFace(specimen.transform);
            Debug.Log($"You roll { maxname }!");

        }
    }

    // Update is called once per frame
    void Update()
    {
        CameraTracker();
        velocity = rb.velocity;
        Propagate();
    }

}


