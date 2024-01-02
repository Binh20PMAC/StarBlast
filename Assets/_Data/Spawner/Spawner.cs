using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : KaisMonoBehaviour
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObj;

    protected override void LoadComponents()
    {
        this.LoadPrefabs();
        this.LoadHolder();
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

    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + " LoadHolder", gameObject);
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion rotation)
    {
        Transform prefab = this.GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogWarning("Prefab not found: " + prefabName);
            return null;
        }
        Transform newPrefab = this.GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, rotation);
        newPrefab.parent = this.holder;
        return newPrefab;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach(Transform obj in this.poolObj)
        {
            if(obj.name == prefab.name)
            {
                this.poolObj.Remove(obj);
                return obj; 
            }
        }
        Transform newPrefab = Instantiate(prefab);
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

    public virtual void Despawn(Transform obj)
    {
        this.poolObj.Add(obj);  
        obj.gameObject.SetActive(false);
    }
}
