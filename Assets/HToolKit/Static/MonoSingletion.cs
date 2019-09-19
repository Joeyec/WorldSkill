using System.Collections;
using UnityEngine;

public class MonoSingletion<T> : MonoBehaviour where T : MonoBehaviour {

   // private MonoSingletion() { }
    private static T instance = null;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
                //GameObject go = new GameObject("MonoSingletion");
                //instance = go.AddComponent<T>();
            }
            return instance;
        }
        set { instance = value; }
    }

    protected virtual void Awake() {
        instance = this as T;
    }
}
