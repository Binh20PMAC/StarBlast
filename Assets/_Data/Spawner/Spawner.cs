using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : KaisBehaviour
{

    [SerializeField] protected List<Transform> prefabs;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;

        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.prefabs.Add(prefab);
            prefab.gameObject.SetActive(false);
        }

        Debug.Log(transform.name + " LoadPrefabs", gameObject);
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogWarning("Prefab not found: " + prefabName);
            return null;
        }
        Transform newPrefab = Instantiate(prefab, spawnPos, rotation);
        return newPrefab;
    }

    public virtual Transform GetPrefabByName(string prefabName)
    {
        foreach (Transform prefab in this.prefabs)
        {
            if (prefab.name == prefabName) return prefab;
        }
        return null;
    }
}
