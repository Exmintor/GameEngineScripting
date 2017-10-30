using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Tiled2Unity.CustomTiledImporter]
public class DisableSideFriction : Tiled2Unity.ICustomTiledImporter
{
    public void HandleCustomProperties(GameObject gameObject, IDictionary<string, string> keyValuePairs)
    {
        Debug.Log("Handle Custom properties from Tiled Map.");
    }

    public void CustomizePrefab(GameObject prefab)
    {
        PolygonCollider2D[] polygon2D = prefab.GetComponentsInChildren<PolygonCollider2D>();
        if(polygon2D == null)
        {
            return;
        }

        int oneWayMask = LayerMask.NameToLayer("OneWay");

        foreach (PolygonCollider2D polygon in polygon2D)
        {
            PlatformEffector2D effector = polygon.gameObject.GetComponent<PlatformEffector2D>();
            if(effector == null)
            {
                effector = polygon.gameObject.AddComponent<PlatformEffector2D>();
            }

            if(polygon.gameObject.layer == oneWayMask)
            {
                effector.useOneWay = true;
            }
            else
            {
                effector.useOneWay = false;
            }
            effector.useSideFriction = false;
            polygon.usedByEffector = true;
        }
    }
}
