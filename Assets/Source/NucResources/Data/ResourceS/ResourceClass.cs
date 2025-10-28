using System;
using UnityEngine;

namespace ResourceSystem.Data
{
    [Serializable]
    public class NuclearResource
    {
        [field: SerializeField]
        internal ResourceType resourceType { get; private set; }
        [field:SerializeField]
        internal Sprite ActiveSprite { get; private set; }
        [field:SerializeField]
        internal Sprite DecomposingSprite { get; private set; }
        [field:SerializeField]
        internal float ActiveTime { get; private set; }
        [field:SerializeField]
        internal float DecomposingTime { get; private set; }
        [field:SerializeField]
        internal float ScoreAddition { get; private set; }
    }
}