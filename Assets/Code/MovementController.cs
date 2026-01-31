using UnityEngine;

[System.Serializable]
public class MovementController
{
    [SerializeField] private Rigidbody2D rigidbody;

    public void Move(Vector2 direction)
    {
        rigidbody.MovePosition(rigidbody.transform.position + new Vector3(direction.x, direction.y, 0f) * Time.fixedDeltaTime);
    }
}