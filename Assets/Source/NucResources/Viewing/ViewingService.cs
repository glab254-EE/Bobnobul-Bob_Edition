using ResourceSystem.Data;
using UnityEngine;

namespace ResourceSystem.Viewing
{
    public class ViewingService
    {
        private static ViewingService instance;
        public static ViewingService Instance
        {
            get
            {
                instance ??= new();
                return instance;
            }
        }
        public bool TryGetActiveSprite(ResourceType _ResourceType, out Sprite sprite)
        {
            sprite = null;
            if (ResourceDataProvider.TryGetResourceData(_ResourceType, out NuclearResource resource))
            {
                sprite = resource.ActiveSprite;
                return true;
            }
            return false;
        }
        public bool TryGetDecomposingSprite(ResourceType _ResourceType, out Sprite sprite)
        {
            sprite = null;
            if (ResourceDataProvider.TryGetResourceData(_ResourceType, out NuclearResource resource))
            {
                sprite = resource.DecomposingSprite;
                return true;
            }
            return false;
        }
    }
}
