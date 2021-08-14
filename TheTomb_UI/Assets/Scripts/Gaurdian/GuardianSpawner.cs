using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject guardianPrefab;

    public void SpawnGuardian(Transform tileTransform)
    {
        Instantiate(guardianPrefab, tileTransform.position, Quaternion.identity);
    }

}
