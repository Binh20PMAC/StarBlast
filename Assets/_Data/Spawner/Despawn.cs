using UnityEngine;

public abstract class Despawn : KaisMonoBehaviour
{
    protected virtual void FixedUpdate()
    {
        Despawning();
    }

    protected virtual void Despawning()
    {
        if (!this.CanDespawn()) return;
        this.DespawnObject();
    }

    protected virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }

    protected abstract bool CanDespawn();
}
