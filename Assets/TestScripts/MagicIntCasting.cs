using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicIntCasting : MonoBehaviour
{
    [System.Flags] public enum MagicType { arcane = 1, fire = 2, water = 4, earth = 8, dark = 16, light = 32, blood = 64, cupcakes = 128 }
    [SerializeField] private MagicType _currentMagic;

    [SerializeField] private bool _getIntValue;

    private void Update()
    {
        if (_getIntValue)
        {
            // Will remove Arcane if any other magic type is selected
            if (_currentMagic != MagicType.arcane && (_currentMagic & MagicType.arcane) != 0)
            {
                _currentMagic &= ~MagicType.arcane;
            }

            // Will remove all other magic types if Blood or Cupcakes is selected
            if ((_currentMagic & (MagicType.blood | MagicType.cupcakes)) != 0)
            {
                _currentMagic = _currentMagic & (MagicType.blood | MagicType.cupcakes);
            }

            Debug.Log("Int value for current magic = " + (int)_currentMagic);

            _getIntValue = false;
        }
    }
}
