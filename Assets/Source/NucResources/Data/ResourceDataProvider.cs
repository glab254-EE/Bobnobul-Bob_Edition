using UnityEngine;

namespace ResourceSystem.Data
{
    public static class ResourceDataProvider
    { // no singleton, as this only need static functions,accessable everywhere.
        public static bool TryGetResourceData(ResourceType _type, out NuclearResource resource)
        {
            resource = null;
            try
            {
                Object databaseObject = Resources.Load("ResourceDatabase");
                if (databaseObject == null) return false;
                ResourceDatabaseSO databaseSO = databaseObject as ResourceDatabaseSO;
                foreach (NuclearResource _resource in databaseSO.ResourceList)
                {
                    if (_resource.resourceType == _type)
                    {
                        resource = _resource;
                        return true;
                    }
                }
                throw new System.Exception();
            }
            catch (System.Exception e)
            {
                Debug.LogWarning("Failed to get resource.\n" + e .Message);
            }
            return false;
        }
        public static bool TryGetResourceDatabase(out ResourceDatabaseSO resourceDatabaseSO)
        {
            resourceDatabaseSO = null;
            try
            {
                Object databaseObject = Resources.Load("ResourceDatabase");
                if (databaseObject == null) return false;
                ResourceDatabaseSO databaseSO = databaseObject as ResourceDatabaseSO;
                if (databaseSO == null) return false;
                resourceDatabaseSO = databaseSO;
                return true;
            }
            catch (System.Exception)
            {
                Debug.LogWarning("Failed to find resource database.");
            }
            return false;            
        }
    }
}