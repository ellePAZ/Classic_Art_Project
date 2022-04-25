using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    private MoveDirection moveDirection = MoveDirection.NONE;
    // Start is called before the first frame update
    void Start()
    {
        Spawner spawner = GetComponent<Spawner>();
        
        if(spawner.SpawnedUnitsMoveDirection == MoveDirection.LEFT)
        {
            moveDirection = MoveDirection.RIGHT;
		}
        else if(spawner.SpawnedUnitsMoveDirection == MoveDirection.RIGHT)
        {
            moveDirection = MoveDirection.LEFT;
		}
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
        Debug.Log("Object entered");
        VisitorMovement visitorMovement = collision.gameObject.GetComponent<VisitorMovement>();

		if(visitorMovement != null)
        {
            if(visitorMovement.MoveDirection == moveDirection)
            {
                visitorMovement.DestroyMe();
		    }
		}
	}
}
