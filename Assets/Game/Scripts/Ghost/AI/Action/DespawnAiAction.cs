using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Despawn AI", story: "Despawn [AI]", category: "Action", id: "d6903791e61339154eade898e51f3046")]
public partial class DespawnAiAction : Action
{
    [SerializeReference] public BlackboardVariable<GhostAIController> AI;

    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        // Memastikan ada reference ke AI controller
        // Jika tidak ada, maka status gagal akan langsung
        // dikembalikan 
        if (AI.Value == null)
        {
            return Status.Failure;
        }
        // Melakukan despawn AI
        AI.Value.Despawn();
        // Mengembalikan status berhasil setelah despawn AI
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

