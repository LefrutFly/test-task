using UnityEngine;
using Zenject;

public class WaitSecondsInstaller : MonoInstaller
{
    [SerializeField] private WaitSecondsSO waitSecondslSO;

    public override void InstallBindings()
    {
        Container.Bind<WaitSecondsSO>().
            FromInstance(waitSecondslSO).
            AsSingle().
            NonLazy();
    }
}
