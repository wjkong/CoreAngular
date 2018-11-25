using System;

namespace Konger.CoreAngular.Model
{
    public class StringValueAttribute : Attribute
    {
        // Fields
        private string mValue;

        // Methods
        public StringValueAttribute(string value)
        {
            mValue = value;
        }

        // Properties
        public string Value
        {
            get
            {
                return mValue;
            }
        }
    }
}
