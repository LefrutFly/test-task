using UnityEngine;
using Zenject;

public class ScreensInstaller : MonoInstaller
{
    [SerializeField] private Screens screens;

    public override void InstallBindings()
    {
        Container.Bind<Screens>().
            FromInstance(screens).
            AsSingle().
            NonLazy();
    }
}
