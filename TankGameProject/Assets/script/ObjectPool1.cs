using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool1 : MonoBehaviour
{
    public static ObjectPool1 Instance;

    [SerializeField]
    private GameObject poolingObjectPrefab;

    Stack<Gun> poolingObjectStack = new Stack<Gun>();

    private void Awake()
    {
        Instance = this;

        Initialize(30);
    }

    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            poolingObjectStack.Push(CreateNewObject());
        }
    }

    private Gun CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab).GetComponent<Gun>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public static Gun GetObject()
    {
        if (Instance.poolingObjectStack.Count > 0)
        {
            var obj = Instance.poolingObjectStack.Pop();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewObject();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static void ReturnObject(Gun obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectStack.Push(obj);
    }
}
