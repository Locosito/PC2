using UnityEngine;

public class Agent : SBAgent
{
	public Transform target;
	public Transform centro;
	

	void Start()
	{
		maxSpeed = 5f;
		maxSteer = 1f;

	}

	void Update()
	{

		velocity += SteeringBehaviours.Arrive(this, target, 3f);
		
		
		Vector3 offset = centro.position - transform.position;
        float sqrLen = offset.sqrMagnitude;

            if (sqrLen < 9f)
            {
				
                //print("dentro");
            }
			else{
				velocity += SteeringBehaviours.Arrive(this, centro, 3f);
				velocity += SteeringBehaviours.inside(this, target, 999f);
				//print("fuera");
			}

		//velocity += SteeringBehaviours.Inside(this, 3f, centro);
				

		transform.position += velocity * Time.deltaTime;
	}

	void OnDrawGizmos()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(centro.position,3f);
    }
}
