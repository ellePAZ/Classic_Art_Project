using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject visitorPrefab;
    [SerializeField] float spawnTime = 3f;
    [SerializeField] MoveDirection spawnedUnitsMoveDirection = MoveDirection.NONE;
    public MoveDirection SpawnedUnitsMoveDirection { get => spawnedUnitsMoveDirection; }


    Vector2 maxBounds;
    Vector2 minBounds;


    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        minBounds = new Vector2(transform.position.x - boxCollider.bounds.size.x / 2, transform.position.y - boxCollider.bounds.size.y / 2);
        maxBounds = new Vector2(transform.position.x + boxCollider.bounds.size.x / 2, transform.position.y + boxCollider.bounds.size.y / 2);

        StartCoroutine(SpawnObjectWithTimer());
    }

    IEnumerator SpawnObjectWithTimer()
    {
        yield return new WaitForSeconds(spawnTime);

        Vector2 spawnPosition = new Vector2(Random.Range(minBounds.x, maxBounds.x), Random.Range(minBounds.y, maxBounds.y));
        VisitorMovement visitor = Instantiate(visitorPrefab, spawnPosition, Quaternion.identity).GetComponent<VisitorMovement>();
        visitor.Initiate(spawnedUnitsMoveDirection);

        spawnTime = Random.Range(3, 8);

        StartCoroutine(SpawnObjectWithTimer());
	}
}
