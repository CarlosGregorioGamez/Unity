using UnityEngine;

public class PersistentUI : MonoBehaviour
{
    private static bool exists = false;

    void Awake()
    {
        if (exists)
        {
            Destroy(gameObject);  
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            exists = true;
        }
    }
}
