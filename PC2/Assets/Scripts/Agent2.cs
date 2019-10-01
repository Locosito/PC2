using UnityEngine;

public class Agent2 : SBAgent
{
	public Transform target;
	public Transform centro;


	void Start()
	{
		maxSpeed = 5f;
		maxSteer = 1f;

		//target2 = GameObject.Find("Target2").transform;

	}

	void Update()
	{
		velocity += SteeringBehaviours.Arrive(this, target, 3f);
		
		
		Vector3 offset = centro.position - transform.position;
        float sqrLen = offset.sqrMagnitude;

            if (transform.position.x > centro.position.x + 4 || transform.position.x < centro.position.x - 4
                || transform.position.y > centro.position.y + 2 || transform.position.y < centro.position.y - 2)
            {
				velocity += SteeringBehaviours.Arrive(this, centro, 3f);
				velocity += SteeringBehaviours.inside(this, target, 999f);
                print("fuera");
            }
			else{
				
				print("dentro");
			}

		//velocity += SteeringBehaviours.Inside(this, 3f, centro);
				

		transform.position += velocity * Time.deltaTime;
	}

	void OnDrawGizmos()
    {
        // Draw a yellow cube at the transform position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(centro.position, new Vector3(8, 4, 1));
    }
}
