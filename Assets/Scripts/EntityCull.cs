using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EntityCull : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private LayerMask _rendererLayerMask;
    [SerializeField] private BoxCollider _collider;

    private void Start()
    {
        Assert.IsNotNull(_meshRenderer);
        Assert.IsNotNull(_collider);
        _collider.isTrigger = true;
        _meshRenderer.enabled = false;
    }

    private void OnTriggerEnter(Collider other) => Render(other.gameObject, true);

    private void OnTriggerExit(Collider other) => Render(other.gameObject, false);

    private void Render(GameObject gameObject, bool value)
    {
        if (!IsValidLayer(gameObject) ||
            _meshRenderer.enabled == value) return;
        _meshRenderer.enabled = value;
    }

    private bool IsValidLayer(GameObject gameObject)
    {
        if (gameObject is null) return false;
        return (_rendererLayerMask.value & (1 << gameObject.layer)) > 0; 
    }
}

