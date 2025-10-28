using ResourceSystem.Data;
using UnityEngine;

public class ResourceCycleClass
{
    internal bool completed = false;
    public async Awaitable Cycle(NuclearResource resource,bool isTargetingDecomposing)
    {
        if (resource == null || !GameStateManager.IsPlaying) return;
        completed = false;
        float duration = resource.ActiveTime;
        if (isTargetingDecomposing)
        {
            duration = resource.DecomposingTime;
        }
        await Awaitable.WaitForSecondsAsync(duration);
        completed = true;
        if (!isTargetingDecomposing)
        {
            GameStateManager.AddScore(resource.ScoreAddition);            
        }
    }
    public ResourceCycleClass(NuclearResource resource,bool isDecomposing)
    {
        _ = Cycle(resource,isDecomposing);
    }
}