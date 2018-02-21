
using UnityEngine;

public class Persist : MonoBehaviour {


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
