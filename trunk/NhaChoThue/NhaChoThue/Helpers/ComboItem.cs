using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NhaChoThue.Helpers
{
    public class ComboItem
    {
        private int m_itemValue = 0;
        private string m_displayValue = string.Empty;

        public int ItemValue
        {
            get { return m_itemValue; }
            set { m_itemValue = value; }
        }

        public string DisplayValue
        {
            get { return m_displayValue; }
            set { m_displayValue = value; }
        }

        public override string ToString()
        {
            return DisplayValue;
        }


    }
}
