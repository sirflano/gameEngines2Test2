using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class boid : MonoBehaviour {
    private List<SteeringBehaviour> behaviours = new List<SteeringBehaviour>();
    private Vector3 velocity;
    private Vector3 acceleration;

    public float maxSpeed = 5;
	// Use this for initialization
	void Start () {
        SteeringBehaviour[] _behaviours = GetComponents<SteeringBehaviour>();

        foreach (SteeringBehaviour b in _behaviours)
        {
            behaviours.Add(b);
        }
	}
	
	// Update is called once per frame
	void Update () {
        velocity = calculate();
        //velocity
        if(velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity *= maxSpeed;
        }

        transform.rotation = Quaternion.Euler(velocity);
        transform.position += velocity * Time.deltaTime;

        velocity *= 0.99f;

    }

    public Vector3 seek(Vector3 target)
    {
        Vector3 toTarget = transform.position - target;
        toTarget.Normalize();
        toTarget *= maxSpeed;

        return toTarget - velocity;
    }

    public Vector3 arrive(Vector3 target, float slowingDistance)
    {
        Vector3 toTarget = target - transform.position;
        float distance = toTarget.magnitude;
        toTarget.Normalize();

        float ramped = maxSpeed * (distance / slowingDistance);
        float clamped = Mathf.Min(maxSpeed, ramped);
        toTarget *= clamped;
        return toTarget - velocity;
    }

    private Vector3 calculate()
    {
        Vector3 force = Vector3.zero;
        foreach(SteeringBehaviour b in behaviours)
        {
            if (b.isActive())
            {
                force += b.calculate();
            }
        }

        return force;
    }
}
