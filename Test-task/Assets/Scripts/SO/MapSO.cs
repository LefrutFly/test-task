using UnityEngine;

[CreateAssetMenu(fileName = "Map", menuName = "Map/Map")]
public class MapSO : ScriptableObject
{
    [SerializeField] private float rangeBetweenWalls;

    public float RangeBetweenWalls => rangeBetweenWalls;
}