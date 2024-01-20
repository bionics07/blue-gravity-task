using System;
using System.Collections;
using System.Collections.Generic;
public class ObserverService
{
    private Action<ItemKeys, int> _storageUpdateListener;

    public void SubscribeOnStorageUpdateListener(Action<ItemKeys, int> action)
    {
        _storageUpdateListener += action;
    }

    public void UnsubscribeOnStorageUpdateListener(Action<ItemKeys, int> action)
    {
        _storageUpdateListener -= action;
    }

    public void FireOnStorageUpdate(ItemKeys p1, int p2)
    {
        _storageUpdateListener?.Invoke(p1,p2);
    }
}
