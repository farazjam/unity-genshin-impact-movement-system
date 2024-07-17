using SickscoreGames.HUDNavigationSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EntityCull : MonoBehaviour
{
    [SerializeField] private List<MeshRenderer> _meshRenderers;
    [SerializeField] private LayerMask _rendererLayerMask;
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private HUDNavigationElement _HNSIndicator;

    private void Start()
    {
        Assert.IsNotNull(_meshRenderers);
        _meshRenderers.ForEach(mesh => Assert.IsNotNull(mesh));
        Assert.IsNotNull(_collider);
        _collider.isTrigger = true;
        _HNSIndicator.enabled = false;
        _meshRenderers.ForEach(mesh => mesh.enabled = false);
    }

    private void OnTriggerEnter(Collider other) => Render(other.gameObject, true);

    private void OnTriggerExit(Collider other) => Render(other.gameObject, false);

    private void Render(GameObject gameObject, bool value)
    {
        if (!IsValidLayer(gameObject)) return;
        _meshRenderers.ForEach(mesh => mesh.enabled = value);

        if (_HNSIndicator != null)
            _HNSIndicator.enabled = value;
    }

    private bool IsValidLayer(GameObject gameObject)
    {
        if (gameObject is null) return false;
        return (_rendererLayerMask.value & (1 << gameObject.layer)) > 0; 
    }
}

