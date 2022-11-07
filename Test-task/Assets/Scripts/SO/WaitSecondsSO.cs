using UnityEngine;

[CreateAssetMenu(fileName = "WaitSeconds", menuName = "Player/WaitSeconds")]
public class WaitSecondsSO : ScriptableObject
{
    [SerializeField] private float seconds;

    public float Seconds => seconds;
}
