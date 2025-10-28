using System.Collections.Generic;
using ResourceSystem.Data;
using ResourceSystem.Viewing;
using UnityEngine;
using UnityEngine.UI;

public class ResourceSelectionHandler : MonoBehaviour
{
    [field: SerializeField]
    private Transform ResourcesParent;
    [field: SerializeField]
    private GameObject ResourceTemplate;
    private List<NuclearResource> activeResources = new();
    private bool Started = false;
    void Start()
    {
        Initialize();
        GameStateManager.ChangePlayingState(true);
    }
    async void OnResourceClicked(GameObject source, NuclearResource resource)
    {
        if (source == null || resource == null || activeResources.Contains(resource)) return;
        if (!Started)
        {
            GameStateManager.ChangePlayingState(true);
            Started = true;
        }
        if (ViewingService.Instance.TryGetActiveSprite(resource.resourceType, out Sprite sprite))
        {
            ChangeImage(source, sprite);
        }
        ResourceCycleClass _activeCycleClass = new(resource,false);
        activeResources.Add(resource);
        do
        {
            await Awaitable.NextFrameAsync();
        } while (!_activeCycleClass.completed); 
        // i could not figuire it out how to await two conditionsm, so have to use ts
        if (ViewingService.Instance.TryGetDecomposingSprite(resource.resourceType, out Sprite sprite1))
        {
            ChangeImage(source, sprite1);
        }
        activeResources.Remove(resource);
        ResourceCycleClass _decomposingCycleClass = new(resource,true);
        do
        {
            await Awaitable.NextFrameAsync();
        } while (!_decomposingCycleClass.completed && !activeResources.Contains(resource));
        if (!activeResources.Contains(resource) 
        && _decomposingCycleClass.completed)
        {
            Debug.Log(_decomposingCycleClass.completed);
            Debug.Log(activeResources.Contains(resource));
            GameStateManager.ChangePlayingState(false);     
        }
    }
    void ChangeImage(GameObject gameObject,Sprite image)
    {
        if (gameObject.TryGetComponent(out Image imageLabel))
        {
            imageLabel.sprite = image;
        }        
    }
    void Initialize()
    {
        bool LoadedData = ResourceDataProvider.TryGetResourceDatabase(
            out ResourceDatabaseSO database);
        if (ResourceTemplate == null 
        || ResourcesParent == null 
        ||!LoadedData)
        {
            Debug.LogWarning("Failed to initialize.");
            Debug.Log(ResourceTemplate == null);
            Debug.Log(ResourcesParent == null);
            return;
        }
        foreach(NuclearResource resource in database.ResourceList)
        {
            GameObject newobject = Instantiate(ResourceTemplate,
             ResourcesParent);
            if (newobject.TryGetComponent(out Button button))
            {
                button.onClick.AddListener(
                    () => OnResourceClicked(newobject, resource));
            }    
            if (ViewingService.Instance.TryGetDecomposingSprite(resource.resourceType, out Sprite sprite1))
            {
                ChangeImage(newobject, sprite1);
            }
        }
    }
}  