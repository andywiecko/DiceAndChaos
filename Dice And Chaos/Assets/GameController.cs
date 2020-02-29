using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{

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
    public bool trackCamera = false;
    public Camera mainCamera;
    private Vector3 initialCameraDistance;



    bool messageRecived = false;



    void Start()
    {
        Vector3 position = gameObject.transform.position;
        specimen = Instantiate(specimen, position, Quaternion.identity);
        initialCameraDistance = position - mainCamera.transform.position;
        initialPosition = specimen.transform.position;
        initialRotation = specimen.transform.rotation;
        rb = specimen.GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 100f;


        //*
        Time.maximumParticleDeltaTime = 0.03f;
        Time.timeScale = 30f;
        Time.maximumDeltaTime = 0.01f;
        //*/


        


        RollADice();




    }

    public void RollADice()
    {
        //specimen.transform.position = position;

        specimen.transform.position = initialPosition;
        specimen.transform.rotation = initialRotation;

        rb.velocity = new Vector3(initialVelocity, 0, 0);
        rb.angularVelocity = initialAngularVelocity;

        messageRecived = false;



    }



    // Update is called once per frame
    void Update()
    {
        if (trackCamera)
            mainCamera.transform.position = specimen.transform.position - initialCameraDistance;
        velocity = rb.velocity;

        if (velocity == Vector3.zero && !messageRecived)
        {
            Debug.Log("Body stopped!");
            messageRecived = !messageRecived;

            float maxheight = -1f;
            string maxname = "";
            foreach (Transform child in specimen.transform)
            {
                float childheigth = child.transform.position.y;

                if (maxheight < childheigth)
                {
                    maxheight = childheigth;
                    maxname = child.name;
                }


            }

            Debug.Log($"You roll { maxname }!");
            Vector3 angVel = initialAngularVelocity;
            string result = $"{angVel.x} {angVel.y} {angVel.z} { maxname }";
            Debug.Log(result);
            Logger.Save(result);
            if (angVel.y <= 5.0f) Simulate();

        }
    }

    public void Simulate()
    {

        Vector3 angVel = initialAngularVelocity;
        if (angVel.x <= 5.0f)
            angVel.x += 0.01f;
        else
        {
            angVel.y += 0.01f;
            angVel.x = -5.0f;
        }
        initialAngularVelocity = angVel;
        RollADice();
    }

}


