using UnityEngine;
using UnityEngine.Tilemaps;

namespace BuildingSystem
{
    public class ConstructionLayer : TilemapLayer
    {
        private void Build(Vector3 worldCoords, BuildableItem item)
        {
            var coords = _tilemap.WorldToCell(worldCoords);
            if (item.Tile != null)
            {
                _tilemap.SetTile(coords, item.Tile);
            }
        }
    }
}