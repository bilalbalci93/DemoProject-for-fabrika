using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public GameObject player;

    public float minX, maxX, minZ, maxZ;


    public static AIController instance
    {
        private set;
        get;
    }

    public List<Transform> cars = new List<Transform>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

public static class TAGS
{
    public static readonly string car = "Car";
    public static readonly string player = "Player";
}
