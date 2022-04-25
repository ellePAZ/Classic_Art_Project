using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveDirection{
    LEFT,
    RIGHT,
    NONE
}

public class VisitorMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] MoveDirection direction = MoveDirection.NONE;
    public MoveDirection MoveDirection{ get => direction; }

    public void Initiate(MoveDirection p_moveDirection){
        direction = p_moveDirection;
	}

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveDistance = 0f;

        if(direction == MoveDirection.LEFT){
            moveDistance = -1f;
		}
        else if(direction == MoveDirection.RIGHT){
            moveDistance = 1f;
		}

        transform.position += new Vector3(moveDistance * Time.deltaTime * movementSpeed, 0, 0);
	}

    public void DestroyMe()
    {
        Destroy(gameObject);
	}
}
