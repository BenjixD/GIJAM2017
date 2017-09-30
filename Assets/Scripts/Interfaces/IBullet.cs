using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    void SetSpawnedBy(GameObject spawner);
    GameObject GetSpawnedBy();
    void SetTravelProperties(float angle, float speed);
    float GetDamage();
}
