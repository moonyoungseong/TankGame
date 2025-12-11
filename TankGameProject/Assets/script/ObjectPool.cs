using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField]
    private GameObject poolingObjectPrefab;

    Stack<BombGenerator> poolingObjectStack = new Stack<BombGenerator>();

    private void Awake()
    {
        Instance = this;

        Initialize(150);
    }

    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            poolingObjectStack.Push(CreateNewObject());
        }
    }

    private BombGenerator CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab).GetComponent<BombGenerator>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public static BombGenerator GetObject()
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

    public static void ReturnObject(BombGenerator obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectStack.Push(obj);
    }
}
