using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player playerPrefab;
    [SerializeField] private Transform playerSpawnPosition;

    public override void InstallBindings()
    {
        var player =
            Container.InstantiatePrefabForComponent<Player>(
                playerPrefab,
                playerSpawnPosition.position,
                Quaternion.identity,
                null
                );

        Container.Bind<Player>().
            FromInstance(player).
            AsSingle().
            NonLazy();
    }
}
