using UnityEngine;

namespace RunnerGame
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T _instance;
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    _instance = obj.AddComponent<T>();
                    obj.name = typeof(T).ToString();
                }
                return _instance;
            }
        }
    }
}
