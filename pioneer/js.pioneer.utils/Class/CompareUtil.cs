using KellermanSoftware.CompareNetObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace js.pioneer.utils
{
    public class CompareUtil : ICompareUtil
    {
        public string Compare(object o1, object o2)
        {
            try
            {
                CompareLogic compareLogic = new CompareLogic();

                ComparisonResult result = compareLogic.Compare(o1, o2);

                //These will be different, write out the differences
                if (!result.AreEqual)
                    return result.DifferencesString;

                return "No Changes found";
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
