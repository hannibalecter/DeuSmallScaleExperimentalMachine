using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSSEM
{
    class Register
    {
        //common for all registers
        public static short bus;
        public static short[][] memory = new short[3][];
        public static short[] initialData = new short[16];

        public static Register AR;

        private int bits;
        private short state = 0;
        private bool fromBus;

        public Register(int bits, bool fromBus = true)
        {
            this.bits = bits;
            this.fromBus = fromBus;
        }

        public bool increment(bool AC = false)
        {
            state++;

            if (AC && state == 8)
            {
                state = -8;//underflow
                return true;
            }

            return false;
        }

        public void clear()
        {
            state = 0;
        }

        public void decrement()
        {
            state--;
        }

        public void load()
        {
            if (fromBus)
                state = bus;

            else
            {
                state = (short)memory[0][AR.get()]; 
            }
        }

        public bool updateAC(short value)
        {
            bool overflow = false;

            if ((int)value > 7 || (int)value < -8)
            {
                overflow = true;

                //simulate 4 bit over-underflow
                if (value > 7)
                    value -= 16;

                else if (value < -8)
                    value += 16;
            }

            state = value;

            return overflow;
        }

        public short get()
        {
            return state;
        }
    }
}
