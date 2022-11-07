using UnityEngine;
using Zenject;

public class TimerInstaller : MonoInstaller
{
    [SerializeField] private Timer timer;

    public override void InstallBindings()
    {
        Container.Bind<Timer>().
            FromInstance(timer).
            AsSingle().
            NonLazy();
    }
}