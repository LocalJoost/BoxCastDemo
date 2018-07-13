using UnityEngine;

namespace HoloToolkitExtensions.Utilities
{
public static class GameObjectExtensions
{
    /// <summary>
    /// Calculate the total bounds of an object and it's children
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static Bounds GetEncapsulatingBounds(this GameObject obj)
    {
        Bounds totalBounds = new Bounds();

        foreach (var renderer in obj.GetComponentsInChildren<Renderer>())
        {
            if (totalBounds.size.magnitude == 0f)
            {
                totalBounds = renderer.bounds;
            }
            else
            {
                totalBounds.Encapsulate(renderer.bounds);
            }
        }

        return totalBounds;
    }
}
}
