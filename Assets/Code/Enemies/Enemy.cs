using UnityEngine;

[System.Serializable]
public class Enemy
{
    [SerializeField] private Transform transform;
    public Transform Transform { get { return transform; } }
    [SerializeField] private MovementController movementController;
    public MovementController MovementController { get { return movementController; } }
    [SerializeField] private Shooter shooter;
    public Shooter Shooter { get { return shooter; } }
}