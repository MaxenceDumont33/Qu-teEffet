using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScriptableObjectSpawnManager : MonoBehaviour
{
    public GameObject entityToSpawn;

    // An instance of the ScriptableObject defined above.
    public EffectSo effectSo;

    public List<EffectSo> listOfEffects = new();

    // This will be appended to the name of the created entities and increment when each is created.
    int instanceNumber = 1;

    void Start()
    {
        
    }

    [ContextMenu("ef")]
    void SpawnEntities()
    {           
        GameObject currentEntity = Instantiate(entityToSpawn, new Vector3(0,0,0), Quaternion.identity);         
        currentEntity.name = effectSo.EffectName;
    }
}
