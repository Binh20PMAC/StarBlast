using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : KaisMonoBehaviour
{
    [SerializeField] protected JunkSpawnerCtrl junkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = GetComponent<JunkSpawnerCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected override void Start()
    {
        base.Start();
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        Transform ran = this.junkCtrl.JunkSpawnPoints.GetRandom();
        this.junkCtrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, ran.position, transform.rotation);
        Invoke(nameof(this.JunkSpawning), 1f);
    }
}
