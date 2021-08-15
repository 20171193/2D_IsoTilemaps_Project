using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianSpawner : MonoBehaviour
{
    public void SpawnGuardian(Transform tileTransform, GameObject guardianPrefab)
    {
        Instantiate(guardianPrefab, tileTransform.position, Quaternion.identity);
    }

}
