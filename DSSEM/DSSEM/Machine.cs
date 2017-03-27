using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSSEM
{
    static class Machine
    {
        public static Register AR = new Register(4);
        public static Register DR = new Register(4);
        public static Register PC = new Register(4);
        public static Register IR = new Register(9, false); 
        public static Register SP = new Register(3);
        public static Register AC = new Register(4);
        public static Register INPR = new Register(4);

        public static Register SC = new Register(4);

        public static bool E = false; // caryOut

        public static bool S = true; // SC enable

        public static void reset()
        {
            AR = new Register(4);
            DR = new Register(4);
            PC = new Register(4);
            IR = new Register(9, false);
            SP = new Register(3);
            AC = new Register(4);
            INPR = new Register(4);

            SC = new Register(4);

            E = false;
            S = true;
        }
    }
}
