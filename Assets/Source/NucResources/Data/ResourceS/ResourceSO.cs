using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem.Data
{
    [CreateAssetMenu(fileName = "New Resource Base",menuName = "Scriptable Objects/Resource Database")]
    public class ResourceDatabaseSO : ScriptableObject
    {
        [field:SerializeField]
        public List<NuclearResource> ResourceList { get; private set; }
    }
}