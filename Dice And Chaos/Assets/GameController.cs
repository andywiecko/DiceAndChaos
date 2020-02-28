using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    bool messageRecived = false;

    

    void Start()
    {
        Vector3 position = gameObject.transform.position;
        specimen = Instantiate(specimen, position, Quaternion.identity);
        rb = specimen.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(initialVelocity, 0, 0);
        rb.angularVelocity = initialAngularVelocity;
        //Time.maximumParticleDeltaTime = 0.03f;
        //Time.timeScale = 30f;
        //Time.maximumDeltaTime = 0.01f;
        
        
    }

    // Update is called once per frame
    void Update()
    {
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


        }
    }
}
