using UnityEngine;

namespace Cysharp.Threading.Tasks
{
    public static class UniLoad
    {
        public static async UniTask<T> Load<T>(string path) where T : Object
        {
            Object loadedObject = await Resources.LoadAsync<T>(path);
            return loadedObject != null ? (T)loadedObject : null;
        }

        public static async UniTask<T> Instantiate<T>(T prefab) where T : Component
        {
            T component = Object.Instantiate(prefab);
            await UniTask.Yield();

            component.gameObject.SetActive(true);
            return component;
        }

        public static async UniTask<T> LoadAndInstantiate<T>(string path) where T : Component
        {
            T prefab = await Load<T>(path);
            return await Instantiate(prefab);
        }
    }
}
