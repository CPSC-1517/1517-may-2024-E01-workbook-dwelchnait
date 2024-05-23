using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public static class Utilities
    {
        //static classes are NOT instantiated by the outside user (developer/coder)
        //static class items are referenced using: classname.xxxxx
        //methods within this class have the keyword static in their signature
        //static classes are shared between all outside users at the same time
        //DO NOT consider saving data within a static class BECAUSE you cannot
        //      be certain it (data) will be there when you use the class again
        //consider placing generic re-usable methods within a static class

        public static bool IsPositive(double value)
        {
            bool valid = true;
            if (value < 0.0)
            {
                valid = false;
            }
            return valid;

            //unstructured code
            //if (value < 0.0)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
        }

        public static bool IsPositive(int value) => value >= 0;

        public static bool IsPositive(decimal value) => value >= 0.0m;
    }
}
