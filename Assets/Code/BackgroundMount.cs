using System.Collections;
using UnityEngine;

public class BackgroundMount : MonoBehaviour
{
    [SerializeField] private Grid grid;
    public Vector2 TargetSize;

    public void Update()
    {
        grid.cellSize = TargetSize;
    }
}
