using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerToEntityCull : MonoBehaviour
{
    [SerializeField] private int _radius = 10;
    [SerializeField] private SphereCollider _collider;
    [SerializeField] private LayerMask _targetLayerMask;
    [SerializeField] private bool _drawGizmo = false;

    private void Start()
    {
        Assert.IsNotNull(_collider);
        _collider.radius = _radius;
        _collider.isTrigger = true;
    }

    private void OnDrawGizmos()
    {
        if (!_drawGizmo) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, _radius);
    }

    /*private void Cast()
    {
        var colliders = Physics.OverlapSphere(transform.position, _radius, _targetLayerMask);
        colliders.ToList().ForEach(collider => collider.gameObject.GetComponent<MeshRenderer>().enabled = true);
    }*/
}