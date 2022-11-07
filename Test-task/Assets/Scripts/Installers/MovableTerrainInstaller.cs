using UnityEngine;
using Zenject;

public class MovableTerrainInstaller : MonoInstaller
{
    [SerializeField] private MovableTerrain movableTerrain;

    public override void InstallBindings()
    {
        Container.Bind<MovableTerrain>().
            FromInstance(movableTerrain).
            AsSingle().
            NonLazy();
    }
}