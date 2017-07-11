//-------------------------------------------------
// Author:  FreeKnigt
// Date:    20170710
// Desc:    
//-------------------------------------------------
using System.Globalization;
//-------------------------------------------------
namespace FKVoxelEditor
{
    public class UIFloatParam : UIBaseParam
    {
        public float MinRange { get; set; }
        public float MaxRange { get; set; }
        public float Value { get; set; }

        public UIFloatParam(float _min, float _max)
        {
            MinRange = _min;
            MaxRange = _max;
        }

        public static UIFloatParam FromString(string _inputs, string _value)
        {
            //ex. "Factor", 0.0, 10.0
            var inputs = _inputs.Split(',');
            if (inputs.Length != 3)
                return null;

            string name = inputs[0].Replace("\"", "");

            float min, max;
            if (!float.TryParse(inputs[1], NumberStyles.Float, CultureInfo.InvariantCulture, out min))
                return null;

            if (!float.TryParse(inputs[2], NumberStyles.Float, CultureInfo.InvariantCulture, out max))
                return null;

            //ex. 0.0
            float value;
            if (!float.TryParse(_value, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                return null;

            if (min < max)
            {
                var param = new UIFloatParam(min, max);
                param.Name = name;
                param.Value = value;
                return param;
            }

            return null;
        }
    }
}
