using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Region : MonoBehaviour
{
    [SerializeField] private RegionCollider _regionCollider;
    [SerializeField] private List<Transform> _regionTransforms;

    void Start()
    {
        Assert.IsNotNull(_regionCollider);
        Assert.IsNotNull(_regionTransforms);
        _regionTransforms.ForEach(regionTransform => Assert.IsNotNull(regionTransform));
        ToggleDisableRegionTransforms();
    }

    private void OnEnable()
    {
        if(_regionCollider != null)
        {
            _regionCollider.PlayerEntersRegion += ToggleEnableRegionTransforms;
            _regionCollider.PlayerExitsRegion += ToggleDisableRegionTransforms;
        }
    }

    private void OnDisable()
    {
        if (_regionCollider != null)
        {
            _regionCollider.PlayerEntersRegion -= ToggleEnableRegionTransforms;
            _regionCollider.PlayerExitsRegion -= ToggleDisableRegionTransforms;
        }
    }

    private void ToggleEnableRegionTransforms() => ToggleRegionTransforms(true);
    private void ToggleDisableRegionTransforms() => ToggleRegionTransforms(false);
    private void ToggleRegionTransforms(bool value) => _regionTransforms.ForEach(regionTransform => regionTransform.gameObject.SetActive(value));
}
