//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170706
// Desc:    简单的Input处理类
//-------------------------------------------------
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
//-------------------------------------------------
namespace FKVoxelEditor
{
    public class FKInputHandle : GameComponent
    {
        #region ======== 成员变量 ========

        private static KeyboardState _keyboardState;
        private static KeyboardState _lastKeyboardState;
        private static bool _bIsUseCustomKeyboardState;

        #endregion ======== 成员变量 ========

        #region ======== 构造函数 ========

        /// <summary>创建一个输入处理对象</summary>
        /// <remarks>
        /// 本对象应该仅被调用一次
        /// 使用方式如下 Components.Add(new Input(this));
        /// 之后便可以每帧通过该对象进行事件处理
        /// </remarks>
        public FKInputHandle(Game game, bool bIsUseCustomKeyboardState) : base(game)
        {
            _keyboardState = Keyboard.GetState();
            _bIsUseCustomKeyboardState = bIsUseCustomKeyboardState;
        }

        #endregion ======== 构造函数 ========

        #region ======== 核心函数 ========

        /// <summary>
        /// 每帧更新键盘按键状态
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            _lastKeyboardState = _keyboardState;
            if (_bIsUseCustomKeyboardState)
            {
                _keyboardState = FKKeyboardState.GetState();
            }
            else
            {
                _keyboardState = Keyboard.GetState();
            }

            // 输出Debug信息
            DebugOutput();

            base.Update(gameTime);
        }

        /// <summary>
        /// 检查本帧中，指定按键是否有释放
        /// </summary>
        public static bool IsReleased(Keys key)
        {
            return _keyboardState.IsKeyUp(key) && _lastKeyboardState.IsKeyDown(key);
        }

        /// <summary>
        /// 检查本帧中，指定按键是否有点击
        /// </summary>
        public static bool IsPressed(Keys key)
        {
            return _keyboardState.IsKeyDown(key) && _lastKeyboardState.IsKeyUp(key);
        }

        /// <summary>
        /// 检查本帧中，指定按键是否有按下
        /// </summary>
        public static bool IsDown(Keys key)
        {
            return _keyboardState.IsKeyDown(key);
        }

        /// <summary>
        /// Debug调试控制台输出
        /// </summary>
        private void DebugOutput()
        {
            string strRet = "";
            Keys[] pressedKeys;
            pressedKeys = _keyboardState.GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (_lastKeyboardState.IsKeyUp(key))
                {
                    string keyString = key.ToString();
                    bool isUpperCase = ((System.Windows.Forms.Control.IsKeyLocked(System.Windows.Forms.Keys.CapsLock) &&
                                         (!_keyboardState.IsKeyDown(Keys.RightShift) &&
                                          !_keyboardState.IsKeyDown(Keys.LeftShift))) ||
                                        (!System.Windows.Forms.Control.IsKeyLocked(System.Windows.Forms.Keys.CapsLock) &&
                                         (_keyboardState.IsKeyDown(Keys.RightShift) ||
                                          _keyboardState.IsKeyDown(Keys.LeftShift))));

                    if (keyString.Length == 1)
                    {
                        strRet += isUpperCase ? keyString.ToUpper() : keyString.ToLower();
                    }
                    else
                    {
                        strRet += keyString;
                    }
                }
            }

            if (!string.IsNullOrEmpty(strRet))
            {
                System.Diagnostics.Debug.WriteLine("按键输入:  " + strRet);
            }
        } 

        #endregion ======== 核心函数 ========

    }
}
