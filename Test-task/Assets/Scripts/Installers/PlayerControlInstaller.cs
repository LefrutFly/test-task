using UnityEngine;
using Zenject;

public class PlayerControlInstaller : MonoInstaller
{
    [SerializeField] private PlayerControlSO playerControlSO;

    public override void InstallBindings()
    {
        Container.Bind<PlayerControlSO>().
            FromInstance(playerControlSO).
            AsSingle().
            NonLazy();
    }
}
