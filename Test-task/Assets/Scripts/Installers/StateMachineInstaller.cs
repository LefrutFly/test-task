using UnityEngine;
using Zenject;

public class StateMachineInstaller : MonoInstaller
{
    [SerializeField] private StateMachine stateMachinePrefab;

    public override void InstallBindings()
    {
        var stateMachine =
            Container.InstantiatePrefabForComponent<StateMachine>(
                stateMachinePrefab,
                Vector3.zero,
                Quaternion.identity,
                null
                );

        Container.Bind<StateMachine>().
            FromInstance(stateMachine).
            AsSingle().
            NonLazy();
    }
}
