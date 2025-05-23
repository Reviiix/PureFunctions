using UnityEngine;

namespace pure_unity_methods
{
    /// <summary>
    /// Inheriting from this class will follow the singleton pattern.
    /// A singleton is for a case where there should be only one instance of the thing and it should be a global resource.
    /// Do not abuse singletons for their global scope.
    /// </summary>
    public abstract class Singleton<T> : MonoBehaviour where T : class
    {
        public static T Instance { get; private set; }

        protected virtual void OnEnable()
        {
            if (Instance != null)
            {
                Debug.LogError($"Duplicate singleton found: {Instance}");
                Destroy(this);
                return;
            }
            
            Instance = FindObjectOfType(typeof(T)) as T;
            if (Instance == null)
            {
                Debug.LogError($"Can not find singleton {typeof(T)}");
            }
        }

        protected virtual void OnDisable()
        {
            Instance = null;
        }
    }
    
    public abstract class PrivateSingleton<T> : MonoBehaviour where T : class
    {
        protected static T Instance;

        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError($"Duplicate singleton found: {Instance}");
                Destroy(this);
                return;
            }
            
            Instance = FindObjectOfType(typeof(T)) as T;
            if (Instance == null)
            {
                Debug.LogError($"Can not find singleton {typeof(T)}");
                
            }
        }

        protected virtual void OnDisable()
        {
            Instance = null;
        }
    }
}