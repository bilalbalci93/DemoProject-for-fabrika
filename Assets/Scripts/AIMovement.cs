using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fabrikademo.PlayerMovement;

public class AIMovement : MonoBehaviour
{
    private Transform player;

    private Rigidbody _rigidbody;
    [HideInInspector] public Transform pickedTransform;
    private float _motorForce;
    private float _startTime;
    private float _duration = 3f;
    private float _elapsedTime;
    private bool isStuck;


    private void Awake()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
        _motorForce = FindObjectOfType<PlayerMovementController>().MotorForce;

    }

    void Start()
    {
        player = AIController.instance.player.transform;
        PickTarget();
        _rigidbody.mass = Random.Range(0.75f, 1.4f);

    }

    private void Update()
    {
        transform.LookAt(pickedTransform);
        _elapsedTime = Time.time - _startTime;
        if(_elapsedTime >= _duration)
        {
            PickTarget();
        }
        TargetChanger();
    }

    void FixedUpdate()
    {
        FollowTarget();
    }

    public Transform PickTarget()
    {
        do
        {
            pickedTransform = AIController.instance.cars[Random.Range(0, AIController.instance.cars.Count)];
        }
        while (pickedTransform == this.transform);

        _startTime = Time.time;

        if (pickedTransform.gameObject != player.gameObject )
        {
            if (pickedTransform.gameObject.GetComponent<AIMovement>().pickedTransform == this.gameObject.transform && AIController.instance.cars.Count > 2)
            {
                pickedTransform.gameObject.GetComponent<AIMovement>().PickTarget();
            }
        }

        print(pickedTransform.name + " : " + this.name);
        return pickedTransform;
    }

    void FollowTarget()
    {
        _rigidbody.AddForce(_rigidbody.transform.forward * Random.Range(0.8f,1.2f) * _motorForce * Time.deltaTime, ForceMode.Force);
    }

    void TargetChanger()
    {
        if(pickedTransform.gameObject.GetComponent<AIMovement>() == null && pickedTransform.gameObject.GetComponent<PlayerMovementController>() == null)
        {
            PickTarget();
        }
        else if (pickedTransform.gameObject.CompareTag(TAGS.player) && pickedTransform.gameObject.GetComponent<PlayerMovementController>().isFall)
        {
            PickTarget();
        }

    }

    Vector3 PickRandomPlace(float minX, float maxX, float minZ, float maxZ)
    {
        Vector3 pickedPlace = new Vector3(Random.Range(minX,maxX), transform.position.y, Random.Range(minZ,maxZ));

        return pickedPlace;
    }
}
