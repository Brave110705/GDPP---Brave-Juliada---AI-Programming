using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "SetLastSeenPosition", story: "Set [LastSeenPosition] from [AIController]", category: "Action", id: "46ece3443117f0924d875733b78d49c4")]
public partial class SetLastSeenPositionAction : Action
{
    [SerializeReference] public BlackboardVariable<Vector3> LastSeenPosition;
    [SerializeReference] public BlackboardVariable<GhostAIController> AI;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (AI.Value == null || AI.Value.Target == null)
        {
            return Status.Failure;
        }
        LastSeenPosition.Value = AI.Value.Target.transform.position;
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

