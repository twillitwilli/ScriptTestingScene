using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Linq;

public class PWInventory : MonoBehaviour
{
    private int[] _guids = new int[64];

    public bool AddItem(int id)
    {
        if (HasOpenInventorySlot(id).GetAwaiter().GetResult())
        {
            return true;
        }

        return false;
    }

    public bool RemoveItem(int id)
    {
        if (HasItem(id))
        {
            return true;
        }

        return false;
    }

    public bool HasItem(int id)
    {
        var itemFound = _guids.Contains(id);

        if (itemFound)
        {
            return true;
        }

        return false;
    }

    private async Task<bool> HasOpenInventorySlot(int id)
    {
        for (int i = 0; i < _guids.Length; i++)
        {
            if (_guids[i] == 0)
            {
                _guids[i] = id;
                return true;
            }
        }
        return false;
    }
}
