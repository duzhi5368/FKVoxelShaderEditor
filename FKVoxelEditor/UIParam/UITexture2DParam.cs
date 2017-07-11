//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170710
// Desc:    
//-------------------------------------------------

namespace FKVoxelEditor
{
    public class UITexture2DParam : UIBaseParam
    {
        public string Value { get; set; }

        public UITexture2DParam(string _slotID)
        {

        }

        public static UITexture2DParam FromString(string _inputs, string _value)
        {
            //ex. "xAmbiantTex"
            string name = _inputs.Replace("\"", "");

            //ex. "0" -> slotIdx
            string value = _value;

            var param = new UITexture2DParam(value);
            param.Name = name;
            param.Value = value;
            return param;
        }
    }
}
