//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170707
// Desc:    自定义键盘状态对象
//-------------------------------------------------
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
//-------------------------------------------------
namespace FKVoxelEditor
{
    public static class FKKeyboardState
    {
        static Keys[] _currentKeys = new Keys[0];
        static Dictionary<int, Keys[]> _arrayCache = new Dictionary<int, Keys[]>();

        public static KeyboardState GetState()
        {
            return new KeyboardState(_currentKeys);
        }

        internal static void SetKeys(List<Keys> keys)
        {
            if (!_arrayCache.TryGetValue(keys.Count, out _currentKeys))
            {
                _currentKeys = new Keys[keys.Count];
                _arrayCache.Add(keys.Count, _currentKeys);
            }

            keys.CopyTo(_currentKeys);
        }
    }
}
