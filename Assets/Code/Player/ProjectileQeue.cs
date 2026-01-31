using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileQeue
{
    List<GameObject> gameObjects = new List<GameObject>();
    List<bool> isActive = new List<bool>();
    List<float> timer = new List<float>();
    int index = 0;
    int maxIndex = 0;

    public float space = 1.0f;

    public void addObj(GameObject obj)
    {
        gameObjects.Add(obj);
        isActive.Add(false);
        timer.Add(0.0f);
        maxIndex++;
    }

    public void UpdatePosition(Vector3 position)
    {
        float subset=1/maxIndex;
        float halfIndex = maxIndex/2;
        for (int i = 0; i < maxIndex; i++)
        {
            if (!isActive[i])
            {
                float dx = position.x + (subset*(i-halfIndex));
                gameObjects[i].transform.position = new Vector3(dx,position.y,position.z);
            }
        }
    }

    public void Shoot(Vector3 targetPosition)
    {
        return;
    }
}