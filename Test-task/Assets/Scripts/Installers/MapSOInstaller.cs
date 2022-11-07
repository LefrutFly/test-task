using UnityEngine;
using Zenject;

public class MapSOInstaller : MonoInstaller
{
    [SerializeField] private MapSO mapSO;

    public override void InstallBindings()
    {
        Container.Bind<MapSO>().
            FromInstance(mapSO).
            AsSingle().
            NonLazy();
    }
}