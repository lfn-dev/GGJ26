using UnityEngine;

[System.Serializable]
public class MovementController
{
    [SerializeField] private Rigidbody2D rigidbody;

    public void Move(Vector2 direction)
    {
        // Apply horizontal movement based on input
        rigidbody.linearVelocity = new Vector2(direction.x, direction.y);
    }
}