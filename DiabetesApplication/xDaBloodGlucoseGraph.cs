using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabetesApplication
{
    class xDaBloodGlucoseGraph
    {
        public static void BloodGlucoseGraph()
        {
            Program.ClearAndDisplayTitleOfApplication();

            ClearAndDisplayBloodGlucoseGraph();
        }

        public static void ClearAndDisplayBloodGlucoseGraph()
        {
            Console.Clear();

            Console.Write("-- Blood Glucose Graph Display -- \n\n");
        }
    }
}
