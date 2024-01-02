using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : KaisMonoBehaviour
{
    [SerializeField] protected JunkCtrl junkCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = GetComponent<JunkCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected override void Start()
    {
        this.JunkSpawning();
    }

    protected virtual void JunkSpawning()
    {
        this.junkCtrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, transform.position, transform.rotation);
        Invoke(nameof(this.JunkSpawning), 1f);
    }
}
