using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSSEM
{
    public partial class dssem : Form
    {
        Dictionary<String, short> languageTable; // All of the opcode
        Dictionary<String, short> labelTable = new Dictionary<string, short>(); // Just for ORG command
        
        short nextLabelAddr = 0;
        String[] fields = new String[5];
        //0: label
        //1: opcode
        //2: address
        //3: I
        //4: comment

        String[] orgFields = new String[3]; // ORG command line
        //0: ORG
        //1: segment
        //2: start

        short codeStartAddr = 0;

        int currentCodeIndex = 0;
        int preprocessIndex = 0;

        void initLanguage() // Opcode stored(key, value).  
        {
            languageTable = new Dictionary<string, short>();

            // Memory Referance--------- I control -- opcode
            languageTable.Add("OR",  16);
            languageTable.Add("AND", 32);
            languageTable.Add("XOR", 48);
            languageTable.Add("ADD", 64);
            languageTable.Add("LDA", 80);
            languageTable.Add("STA", 96);
            languageTable.Add("BUN", 128);
            languageTable.Add("BSA", 144);
            languageTable.Add("ISZ", 240);


            // Register Referance  I = 0
            languageTable.Add("CLA",  1);
            languageTable.Add("SZA",  2);
            languageTable.Add("SNA",  3);
            languageTable.Add("CMA",  4);
            languageTable.Add("INC",  5);
            languageTable.Add("ASHR", 7);
            languageTable.Add("ASHL", 8);
            languageTable.Add("SZE",  0);
            languageTable.Add("HLT",  9);

            // I/O Referance

            languageTable.Add("INP", 15);


            // Stack Referance
            languageTable.Add("Push",     9);
            languageTable.Add("Pop",     10);
            languageTable.Add("SZEmpty", 11);
            languageTable.Add("SZFull",  12);

            

        }

        short compileInstruction() 
        {
            switch (fields[1])
            {
                case "OR":
                case "AND":
                case "XOR":
                case "ADD":
                case "LDA":
                case "STA":
                case "BUN":
                case "BSA":
                case "ISZ":
                    short I = 0;
                    if (fields[3].Equals("I"))
                        I = 256;
                    return (short)(I/*indirect*/ + languageTable[fields[1]]/*opcode*/ + labelTable[fields[2]]/*address / value*/);
                case "CLA":
                case "SZA":
                case "SNA":
                case "CMA":
                case "INC":
                case "ASHR":
                case "ASHL":
                case "SZE":
                case "HLT":
                    return languageTable[fields[1]];
                case "INP":
                case "Push":
                case "Pop":
                case "SZEmpty":
                case "SZFull":
                    return (short)(256 + languageTable[fields[1]]);

                case "DEC":
                    int decAddress = labelTable[fields[0]];

                    Register.memory[1][decAddress] = Int16.Parse(fields[2]);                   
                    break;

                case "HEX": 
                    int hexAddress = labelTable[fields[0]];

                    Register.memory[1][hexAddress] = Int16.Parse(fields[2], System.Globalization.NumberStyles.HexNumber);
                    break;
            }

            return -1;
        }
        bool I;
        void execute(bool micro = false)  // Microoperation and opcode operations.
        {
            if (Machine.S)
            {
                if (Machine.SC.get() == 0)
                {
                    microoperation.Items.Clear();

                    microoperation.Items.Add("T0:  AR ← PC");
                    microoperation.Items.Add("T1:  IR← M[AR] , PC ← PC +1");
                    microoperation.Items.Add("T2: D0...D15 ← Decode IR(4-7), AR ← IR (0-3) , I ←IR(8)");
                    microoperation.SelectedIndex = 0;

                    Register.bus = Machine.PC.get();
                    Machine.AR.load();
                    Machine.SC.increment();//SC++

                    if (micro) {updateTables(); return;}
                }

                if (Machine.SC.get() == 1)
                {
                    microoperation.SelectedIndex = 1;

                    Machine.IR.load();
                    Machine.PC.increment();
                    Machine.SC.increment();//SC++

                    if (micro) {updateTables(); return;}
                }

                string inst = Convert.ToString(Machine.IR.get(), 2).PadLeft(9, '0');//9 bits
                short op = Convert.ToInt16(inst.Substring(1, 4), 2);
                short addr = Convert.ToInt16(inst.Substring(5, 4), 2);

                bool indir = inst[0] == '1';
                I = inst[0] == '1';

                if (Machine.SC.get() == 2)
                {
                    microoperation.SelectedIndex = 2;

                    //AR <- decoded address
                    Register.bus = addr;
                    Machine.AR.load();
                    
                    Machine.SC.increment();//SC++  

                    if (micro) {updateTables(); return;}
                }



                if ( Machine.SC.get() >= 3 )//fetch decode finished
                {

                    if (op != 0)// MEMORY-REFERENCE
                    {
                        if (Machine.SC.get() == 3)
                        {
                            Machine.SC.increment();//SC++

                            if (indir)
                            {
                                microoperation.Items.Add("T3 : AR ← M[AR]");
                                microoperation.SelectedIndex++; ;

                                Register.bus = Register.memory[1][Machine.AR.get()];
                                Machine.AR.load();

                                if (micro) { updateTables(); return; }
                            }
                        }

                        switch (op)
                        {
                            case 1://OR

                               
                                if (Machine.SC.get() == 4)
                                {
                                    microoperation.Items.Add("T4: DR ← M[AR]");
                                    microoperation.Items.Add("T5: AC ← AC V DR, SC ← 0");
                                    microoperation.SelectedIndex++;;

                                    Register.bus = Register.memory[1][Machine.AR.get()];
                                    Machine.DR.load();
                                    Machine.SC.increment();//SC++

                                    if (micro) {updateTables(); return;}
                                }

                                if (Machine.SC.get() == 5)
                                {
                                    microoperation.SelectedIndex++;;

                                    Machine.AC.updateAC((short)(Machine.AC.get() | Machine.DR.get()));
                                    Machine.SC.clear();

                                    if (micro) {updateTables(); return;}
                                }

                                break;
                            case 2://AND
                                if (Machine.SC.get() == 4)
                                {
                                    microoperation.Items.Add("T4: DR ← M[AR]");
                                    microoperation.Items.Add("T5: AC ← AC Λ DR ,  SC ← 0");
                                    microoperation.SelectedIndex++;;

                                    Register.bus = Register.memory[1][Machine.AR.get()];
                                    Machine.DR.load();
                                    Machine.SC.increment();//SC++

                                    if (micro) {updateTables(); return;}
                                }
                                if (Machine.SC.get() == 5)
                                {
                                    microoperation.SelectedIndex++;;

                                    Machine.AC.updateAC((short)(Machine.AC.get() & Machine.DR.get()));
                                    Machine.SC.clear();

                                    if (micro) {updateTables(); return;}
                                }
                                break;
                            case 3://XOR
                                if (Machine.SC.get() == 4)
                                {
                                    microoperation.Items.Add("T4: DR ← M[AR]");
                                    microoperation.Items.Add("T5: AC ← AC ⊕ DR ,  SC ← 0");
                                    microoperation.SelectedIndex++;;

                                    Register.bus = Register.memory[1][Machine.AR.get()];
                                    Machine.DR.load();
                                    Machine.SC.increment();//SC++

                                    if (micro) {updateTables(); return;}
                                }
                                if (Machine.SC.get() == 5)
                                {
                                    microoperation.SelectedIndex++;;

                                    Machine.AC.updateAC((short)(Machine.AC.get() ^ Machine.DR.get()));
                                    Machine.SC.clear();

                                    if (micro) {updateTables(); return;}
                                }
                                break;
                            case 4://ADD
                                if (Machine.SC.get() == 4)
                                {
                                    microoperation.Items.Add("T4: DR ← M[AR]");
                                    microoperation.Items.Add("T5: AC ← AC + DR , E ← Cout, SC ← 0");
                                    microoperation.SelectedIndex++;;

                                    Register.bus = Register.memory[1][Machine.AR.get()];
                                    Machine.DR.load();
                                    Machine.SC.increment();//SC++

                                    if (micro) {updateTables(); return;}

                                }
                                if (Machine.SC.get() == 5)
                                {
                                    microoperation.SelectedIndex++;;

                                    Machine.E = Machine.AC.updateAC((short)(Machine.AC.get() + Machine.DR.get()));
                                    Machine.SC.clear();

                                    if (micro) {updateTables(); return;}

                                }
                                break;
                            case 5://LDA
                                if (Machine.SC.get() == 4)
                                {
                                    microoperation.Items.Add("T4: DR ← M[AR]");
                                    microoperation.Items.Add("T5: AC ←  DR ,  SC ← 0");
                                    microoperation.SelectedIndex++;

                                    Register.bus = Register.memory[1][Machine.AR.get()];
                                    Machine.DR.load();
                                    Machine.SC.increment();//SC++

                                    if (micro) {updateTables(); return;}
                                }
                                if (Machine.SC.get() == 5)
                                {
                                    microoperation.SelectedIndex++;

                                    Machine.AC.updateAC(Machine.DR.get());
                                    Machine.SC.clear();
                                    assemblyCode.SelectedIndex++;

                                    if (micro) {updateTables(); return;}
                                }
                                break;
                            case 6://STA
                                if (Machine.SC.get() == 4)
                                {
                                    microoperation.Items.Add("T4: M[AR] ← AC, SC←0");
                                    microoperation.SelectedIndex++;

                                    Register.memory[1][Machine.AR.get()] = Machine.AC.get();
                                    Machine.SC.clear();

                                    if (micro) {updateTables(); return;}
                                }
                                break;
                            case 8://BUN
                                if (Machine.SC.get() == 4)
                                {
                                    microoperation.Items.Add("T4: PC ← AR, SC ← 0");
                                    microoperation.SelectedIndex++;

                                    Register.bus = Machine.AR.get();
                                    Machine.PC.load();
                                    Machine.SC.clear();
                                    assemblyCode.SelectedIndex++;

                                    if (micro) {updateTables(); return;}
                                }
                                break;
                            case 9://BSA
                                if (Machine.SC.get() == 4)
                                {
                                    microoperation.Items.Add("T4: STACK ← PC");
                                    microoperation.Items.Add("T5: PC ← M[AR],  SC ← 0");
                                    microoperation.SelectedIndex++;

                                    Machine.SP.increment();//push inc
                                    Register.memory[2][Machine.SP.get()] = Machine.PC.get();//push
                                    Machine.SC.increment();//SC++

                                    if (micro) {updateTables(); return;}
                                }
                                if (Machine.SC.get() == 5)
                                {
                                    microoperation.SelectedIndex++;

                                    Register.bus = Register.memory[1][Machine.AR.get()];
                                    Machine.PC.load();
                                    Machine.SC.clear();

                                    if (micro) {updateTables(); return;}
                                }
                                break;
                            case 15://ISZ
                                if (Machine.SC.get() == 4)
                                {
                                    microoperation.Items.Add("T4: DR ← M[AR]");
                                    microoperation.Items.Add("T5: DR ←  DR +1");
                                    microoperation.Items.Add("T6: M[AR] ← DR if(DR=0)  then  (PC←PC+1)  SC ← 0");
                                    microoperation.SelectedIndex++;

                                    Register.bus = Register.memory[1][Machine.AR.get()];
                                    Machine.DR.load();
                                    Machine.SC.increment();//SC++

                                    if (micro) {updateTables(); return;}
                                }
                                if (Machine.SC.get() == 5)
                                {
                                    microoperation.SelectedIndex++;

                                    Machine.DR.increment();
                                    Machine.SC.increment();//SC++

                                    if (micro) {updateTables(); return;}
                                }
                                if (Machine.SC.get() == 6)
                                {
                                    microoperation.SelectedIndex++;

                                    Register.memory[1][Machine.AR.get()] = Machine.DR.get();

                                    if (Machine.DR.get() == 0)
                                        Machine.PC.increment(); // PC++

                                    Machine.SC.clear();

                                    if (micro) {updateTables(); return;}

                                }

                                break;
                        }
                    }
                    else
                    {
                        if (indir == false)
                        {
                            switch (addr)// REGISTER-REFERENCE
                            {
                                case 1://CLA
                                    if (Machine.SC.get() == 3)
                                    {
                                        microoperation.Items.Add("T3: AC ← 0");
                                        microoperation.SelectedIndex = 3;

                                        Machine.AC.clear();
                                        Machine.SC.clear();

                                        if (micro) {updateTables(); return;}
                                    }
                                    break;
                                case 2://SZA
                                    if (Machine.SC.get() == 3)
                                    {
                                        microoperation.Items.Add("T3: if(AC=0)  then  PC ←PC +1");
                                        microoperation.SelectedIndex = 3;

                                        if (Machine.AC.get() == 0)
                                            Machine.PC.increment(); // PC++
                                        Machine.SC.clear();

                                        if (micro) {updateTables(); return;}
                                    }
                                    break;
                                case 3://SNA
                                    if (Machine.SC.get() == 3)
                                    {
                                        microoperation.Items.Add("T3: if(AC(3)=1) then PC ←PC +1");
                                        microoperation.SelectedIndex = 3;

                                        if (Machine.AC.get() < 0)
                                            Machine.PC.increment(); // PC++
                                        Machine.SC.clear();

                                        if (micro) {updateTables(); return;}
                                    }

                                    break;
                                case 4://CMA
                                    if (Machine.SC.get() == 3)
                                    {
                                        microoperation.Items.Add("T3: AC ← AC’");
                                        microoperation.SelectedIndex = 3;

                                        Machine.AC.updateAC((short)~Machine.AC.get());//~: complement
                                        Machine.SC.clear();

                                        if (micro) {updateTables(); return;}
                                    }
                                    break;
                                case 5://INC
                                    if (Machine.SC.get() == 3)
                                    {
                                        microoperation.Items.Add("T3: AC ← AC +1");
                                        microoperation.SelectedIndex = 3;

                                        Machine.E = Machine.AC.increment(true);
                                        Machine.SC.clear();

                                        if (micro) {updateTables(); return;}
                                    }
                                    break;
                                case 7://ASHR
                                    if (Machine.SC.get() == 3)
                                    {
                                        microoperation.Items.Add("T3: E ← AC(3), AC ← shr AC,  AC(3) ← E");
                                        microoperation.SelectedIndex = 3;

                                        Machine.AC.updateAC((short)(Machine.AC.get() >> 1)); // Shift-Right
                                        Machine.SC.clear();

                                        if (micro) {updateTables(); return;}
                                    }
                                    break;
                                case 8://ASHL
                                    if (Machine.SC.get() == 3)
                                    {
                                        microoperation.Items.Add("T3: E ← 0, AC ← shl AC, AC(0) ← E");
                                        microoperation.SelectedIndex = 3;

                                        Machine.AC.updateAC((short)(Machine.AC.get() << 1)); // Shift-Left
                                        Machine.SC.clear();

                                        if (micro) {updateTables(); return;}
                                    }
                                    break;
                                case 0:
                                    if (Machine.SC.get() == 3)
                                    {
                                        microoperation.Items.Add("T3: if(E=0) then (PC ← PC + 1)");
                                        microoperation.SelectedIndex = 3;

                                        if (Machine.E == false)//E == 0
                                            Machine.PC.increment(); // PC++
                                        Machine.SC.clear();

                                        if (micro) {updateTables(); return;}
                                    }
                                    break;
                                case 9:
                                    if (Machine.SC.get() == 3)
                                    {
                                        microoperation.Items.Add("T3: S ← 0");
                                        microoperation.SelectedIndex = 3;

                                        Machine.S = false;
                                        Machine.SC.clear();

                                        if (micro) {updateTables(); return;}
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            switch (addr) // I/O-REFERENCE
                            {
                                case 15: // INP
                                    if (Machine.SC.get() == 3)
                                    {
                                        microoperation.Items.Add("T3: AC(0-3)←INPR, FGI←0");
                                        microoperation.SelectedIndex = 3;

                                        Register.bus = (short)Convert.ToInt16(inputRegister.Text);
                                        Machine.INPR.load();
                                        Machine.AC.updateAC(Machine.INPR.get());

                                        Machine.SC.clear();

                                        if (micro) {updateTables(); return;}
                                    }
                                    break;

                                // STACK-REFERENCE
                                case 9: // Push
                                    if (Machine.SC.get() == 3)
                                    {
                                        microoperation.Items.Add("T3: SP←SP + 1, SM[SP]←DR");
                                        microoperation.SelectedIndex = 3;

                                        Machine.SP.increment(); // SP++
                                        Register.memory[2][Machine.SP.get()] = Machine.DR.get();

                                        Machine.SC.clear();

                                        if (micro) {updateTables(); return;}
                                    }
                                    break;
                                case 10: // Pop
                                    if (Machine.SC.get() == 3)
                                    {
                                        microoperation.Items.Add("T3: PC←SM[SP] ,SP←SP -1");
                                        microoperation.SelectedIndex = 3;

                                        Register.bus = Register.memory[2][Machine.SP.get()];
                                        Machine.PC.load();
                                        Machine.SP.decrement(); // SP--

                                        Machine.SC.clear();

                                        if (micro) {updateTables(); return;}
                                    }
                                    break;
                                case 11: // SZEmpty
                                    if (Machine.SC.get() == 3)
                                    {
                                        microoperation.Items.Add("T3: if(SP=0) then (PC ← PC + 1)");
                                        microoperation.SelectedIndex = 3;

                                        if (Machine.SP.get() == 0)
                                            Machine.PC.increment(); // PC++

                                        Machine.SC.clear();

                                        if (micro) {updateTables(); return;}
                                    }
                                    break;
                                case 12: // SZFull
                                    if (Machine.SC.get() == 3)
                                    {
                                        microoperation.Items.Add("T3: if(SP=7) then (PC ← PC + 1)");
                                        microoperation.SelectedIndex = 3;

                                        if (Machine.SP.get() == 7)
                                            Machine.PC.increment(); // PC++

                                        Machine.SC.clear();

                                        if (micro) {updateTables(); return;}
                                    }
                                    break;
                            }
                        }
                    }
                }

                Machine.SC.clear();
            }

            updateTables();
        }

        private void genLabelTable() // To understand the DataSegment and CodeSegment 
        {
            labelTable.Clear();

            currentCodeIndex = 0;

            while (currentCodeIndex < assemblyCode.Items.Count)
            {
                readAssemblyLine(true);

                if (orgFields[1].Equals("C")) // Code Segment
                {
                    nextLabelAddr = Int16.Parse(orgFields[2]);
                    codeStartAddr = (short)Int32.Parse(orgFields[2]);  //* Which will start to save
                    preprocessIndex = codeStartAddr;
                    Register.bus = codeStartAddr;
                    Machine.PC.load();
                    Register.bus = 0;
                }

                else if (orgFields[1].Equals("D")) // Data Segment
                {
                    nextLabelAddr = Int16.Parse(orgFields[2]); //*
                }

                else nextLabelAddr++;
            }

            currentCodeIndex = 0;
        }

        private void compileAssembly()
        {

            readAssemblyLine(false);


            currentCodeIndex = 0;

            while (currentCodeIndex < assemblyCode.Items.Count)
            {
                readAssemblyLine(false);

                short instruction = compileInstruction();

                if (instruction != -1 && languageTable.ContainsKey(fields[1]))
                {
                    Register.memory[0][preprocessIndex - 1] = instruction;
                    updateTables();
                }
            }

            currentCodeIndex = 0;
        }

        private void updateTables()
        {     // All conversions and values of table were performed.
            
            if (binButton.Checked) // Binary-----
            {
                programCounter.Text = Convert.ToString(Machine.PC.get(), 2).PadLeft(4, '0');
                addressRegister.Text = Convert.ToString(Machine.AR.get(), 2).PadLeft(4, '0');
                dataRegister.Text = Convert.ToString(Machine.DR.get(), 2).PadLeft(4, '0');
                instructionRegister.Text = Convert.ToString(Machine.IR.get(), 2).PadLeft(9, '0');
                stackPointer.Text = Convert.ToString(Machine.SP.get(), 2).PadLeft(3, '0');
                accumulator.Text = Convert.ToString(Machine.AC.get(), 2).PadLeft(4, '0');
                sequenceCounter.Text = Convert.ToString(Machine.SC.get(), 2).PadLeft(4, '0');
                inputRegister.Text = Convert.ToString(Machine.INPR.get(), 2).PadLeft(4, '0');
                indirect.Text = I ? "1" : "0";
                E.Text = Machine.E ? "1" : "0";
                S.Text = Machine.S ? "1" : "0";


                for (int j = 0; j < Register.memory[0].Length; j++)
                {
                    codeSegmentGridView.Rows[j].SetValues(j, Convert.ToString(Register.memory[0][j] , 2).PadLeft(9, '0'));
                }

                for (int j = 0; j < Register.memory[1].Length; j++)
                {
                    dataSegmentGridView.Rows[j].SetValues(j, Convert.ToString(Register.memory[1][j] , 2).PadLeft(9, '0'));
                }

                for (int j = 0; j < Register.memory[2].Length; j++)
                {
                    stackSegmentGridView.Rows[j].SetValues(j, Convert.ToString(Register.memory[2][j] , 2).PadLeft(9, '0'));
                }




            }
            
            else if (decButton.Checked) // Decimal-----
            {
                programCounter.Text = Machine.PC.get().ToString();
                addressRegister.Text = Machine.AR.get().ToString();
                dataRegister.Text = Machine.DR.get().ToString();
                instructionRegister.Text = Machine.IR.get().ToString();
                stackPointer.Text = Machine.SP.get().ToString();
                accumulator.Text = Machine.AC.get().ToString();
                sequenceCounter.Text = Machine.SC.get().ToString();
                inputRegister.Text = Machine.INPR.get().ToString();
                indirect.Text = I ? "1" : "0";
                E.Text = Machine.E ? "1" : "0";
                S.Text = Machine.S ? "1" : "0";


                for (int j = 0; j < Register.memory[0].Length; j++)
                {
                    codeSegmentGridView.Rows[j].SetValues(j, Register.memory[0][j]);
                }

                for (int j = 0; j < Register.memory[1].Length; j++)
                {
                    dataSegmentGridView.Rows[j].SetValues(j, Register.memory[1][j]);
                }

                for (int j = 0; j < Register.memory[2].Length; j++)
                {
                    stackSegmentGridView.Rows[j].SetValues(j, Register.memory[2][j]);
                }
            }
            else if (hexButton.Checked) // Hexadecimal-----
            {

                programCounter.Text = Convert.ToString(Machine.PC.get(), 16);
                addressRegister.Text = Convert.ToString(Machine.AR.get(), 16);
                dataRegister.Text = Convert.ToString(Machine.DR.get(), 16);
                instructionRegister.Text = Convert.ToString(Machine.IR.get(), 16).PadLeft(3, '0');
                stackPointer.Text = Convert.ToString(Machine.SP.get(), 16);
                accumulator.Text = Convert.ToString(Machine.AC.get(), 16);
                sequenceCounter.Text = Convert.ToString(Machine.SC.get(), 16);
                inputRegister.Text = Convert.ToString(Machine.INPR.get(), 16);
                indirect.Text = I ? "1" : "0";
                E.Text = Machine.E ? "1" : "0";
                S.Text = Machine.S ? "1" : "0";


                for (int j = 0; j < Register.memory[0].Length; j++)
                {
                    codeSegmentGridView.Rows[j].SetValues(j, Convert.ToString(Register.memory[0][j], 16).PadLeft(3, '0'));
                }

                for (int j = 0; j < Register.memory[1].Length; j++)
                {
                    dataSegmentGridView.Rows[j].SetValues(j, Convert.ToString(Register.memory[1][j], 16).PadLeft(3, '0'));
                }

                for (int j = 0; j < Register.memory[2].Length; j++)
                {
                    stackSegmentGridView.Rows[j].SetValues(j, Convert.ToString(Register.memory[2][j], 16).PadLeft(3, '0'));
                }

                
            }
            else if (octButton.Checked) // Octal-----
            {

                programCounter.Text = Convert.ToString(Machine.PC.get(), 8).PadLeft(2, '0');
                addressRegister.Text = Convert.ToString(Machine.AR.get(), 8).PadLeft(2, '0');
                dataRegister.Text = Convert.ToString(Machine.DR.get(), 8).PadLeft(2, '0');
                instructionRegister.Text = Convert.ToString(Machine.IR.get(), 8).PadLeft(3, '0');
                stackPointer.Text = Convert.ToString(Machine.SP.get(), 8);
                accumulator.Text = Convert.ToString(Machine.AC.get(), 8).PadLeft(2, '0');
                sequenceCounter.Text = Convert.ToString(Machine.SC.get(), 8).PadLeft(2, '0');
                inputRegister.Text = Convert.ToString(Machine.INPR.get(), 8).PadLeft(2, '0');
                indirect.Text = I ? "1" : "0";
                E.Text = Machine.E ? "1" : "0";
                S.Text = Machine.S ? "1" : "0";


                for (int j = 0; j < Register.memory[0].Length; j++)
                {
                    codeSegmentGridView.Rows[j].SetValues(j, Convert.ToString(Register.memory[0][j], 8).PadLeft(3, '0'));
                }

                for (int j = 0; j < Register.memory[1].Length; j++)
                {
                    dataSegmentGridView.Rows[j].SetValues(j, Convert.ToString(Register.memory[1][j], 8).PadLeft(3, '0'));
                }

                for (int j = 0; j < Register.memory[2].Length; j++)
                {
                    stackSegmentGridView.Rows[j].SetValues(j, Convert.ToString(Register.memory[2][j], 8).PadLeft(3, '0'));
                }



            }

            assemblyCode.SelectedIndex = Machine.PC.get() - codeStartAddr + 1;

        }

        private void readAssemblyLine(bool preprocess) // Pre process is ORG = true
        {
            String label = "";
            String opCode = "";
            String value = "";
            String startPoint = "";//only for generating label tables, for example: "ORG C 2" -> startPoint is 2
            String indirect = "";
            String comment = "";

            if (currentCodeIndex < assemblyCode.Items.Count)
            {
                String line = assemblyCode.Items[currentCodeIndex].ToString();

                bool hasLabel = false;
                bool hasComment = false;
                bool isIndirect = false;
                int indirectIndex = 0;

                String[] lineSplit = line.Split('%');

                for (int i = 0; i < lineSplit[0].Length; i++)
                {
                    if (lineSplit[0][i] == ',')
                    {
                        hasLabel = true;

                        if (hasComment && isIndirect) break;
                    }

                    if (lineSplit[0][i] == '%')
                    {
                        hasComment = true;

                        if (hasLabel && isIndirect) break;
                    }
                }

                String[] words = lineSplit[0].Split(' ', ',');

                int nextWord = 0;
                int nextFullWord = 0;
                String[] fullWords = new String[words.Length];

                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Equals((string)"I"))

                    {
                        isIndirect = true;

                        indirectIndex = nextFullWord;
                    }

                    if (!words[i].Equals(""))//discard empty words
                    {
                        fullWords[nextFullWord++] = words[i];
                    }

                }

                words = fullWords;

                if (hasLabel)
                {
                    label = words[nextWord++];
                }

                if (nextWord < nextFullWord)//at this point, nextFullWord is the number of nonempty words.dd
                    opCode = words[nextWord++].Trim();
                
                if (nextWord < nextFullWord)
                    value = words[nextWord++];

                if (preprocess && opCode.Equals("ORG"))
                    startPoint = words[2];

                if (!preprocess && isIndirect)
                    indirect = words[indirectIndex];

                if (!preprocess && lineSplit.Length == 2)
                    comment = lineSplit[1];

                    orgFields[0] = opCode.Trim();
                    orgFields[1] = value.Trim();
                    orgFields[2] = startPoint.Trim();

                    fields[0] = label.Trim();
                    fields[1] = opCode.Trim();
                    fields[2] = value.Trim();
                    fields[3] = indirect.Trim();
                    fields[4] = comment;

                if (preprocess && !label.Equals("") && !labelTable.ContainsKey(label))//something that needs to be added to the label table
                {
                    labelTable.Add(label, nextLabelAddr);

                    labelGridView.Rows.Add(label, nextLabelAddr);
                }

            }

            if (!preprocess && !opCode.Equals("ORG")) preprocessIndex++;
            currentCodeIndex++;

            /*if (!preprocess && currentCodeIndex < assemblyCode.Items.Count)
                assemblyCode.SelectedIndex = currentCodeIndex;*/
            
        }

        private void assemblyButton_Click(object sender, EventArgs e)
        {
            execute(); // To execute line by line without microoperation

        }

        public dssem()
        {
            InitializeComponent();
        }

        private void DSSEM_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            timer1.Interval = 100;
            timer1.Start();

            initLanguage();

            for (int i = 0; i < 16; i++)
            {
                codeSegmentGridView.Rows.Add(i, "000000000");//TODO: display address in format
                dataSegmentGridView.Rows.Add(i, "000000000");

                if (i < 8)
                {
                    stackSegmentGridView.Rows.Add(i, "000000000");
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Machine.reset();

            labelGridView.Rows.Clear();

            Register.memory = new short[3][];
            Register.memory[0] = new short[16];
            Register.memory[1] = new short[16];
            Register.memory[2] = new short[8];
            Register.AR = Machine.AR;

            assemblyFile.Text = openFileDialog1.FileName;
            if (assemblyFile.Text == "") return;
            assemblyCode.Items.Clear();
            using (System.IO.StreamReader sr = new System.IO.StreamReader(assemblyFile.Text))
            {
                String line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    assemblyCode.Items.Add(line);
                }
            }

            genLabelTable();                           // To understand the DataSegment and CodeSegment
            Register.initialData = Register.memory[1]; // for output data segment store
            compileAssembly();                         // For file parse
            updateTables();
            microoperation.Items.Clear();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Please select the assembly file";
            openFileDialog1.Filter = "(*.asm)|*.asm|(*.basm)|*.basm";
            openFileDialog1.ShowDialog();
        }
        
        // Print in different formats (bin, hex, oct, hex)
        private void binButton_CheckedChanged(object sender, EventArgs e)
        {
            updateTables();
        }     

        private void hexButton_CheckedChanged(object sender, EventArgs e)
        {
            updateTables();
        }

        private void octButton_CheckedChanged(object sender, EventArgs e)
        {
            updateTables();
        }

        private void decButton_CheckedChanged(object sender, EventArgs e)
        {
            updateTables();
        }



        private void microButton_Click(object sender, EventArgs e)
        {
            execute(true);  // For microoperations procedure step by step.
        }

        private void export(string path, bool codeMemory)  // hex and mif file created.
        {
            short[] memory;

            if (codeMemory)
                memory = Register.memory[0];

            else memory = Register.initialData;

            StreamWriter writer = new StreamWriter(path);
            string line = "";

            switch (path.Substring(path.Length -3,3))
            {
                case "hex":
                    for (int i = 0; i < memory.Length; i++)
                    {
                        line = ":02" + Convert.ToString(i, 16).PadLeft(4, '0') + "00" + Convert.ToString(memory[i], 16).PadLeft(4, '0');
                        short dataCheckSum = 0;
                        for (int j = 0; j < 6; j++)
                        {
                            dataCheckSum += Convert.ToInt16(line.Substring(1+j*2,2),16);
                        }
                        dataCheckSum = (short)-dataCheckSum;
                        string temp = Convert.ToString(dataCheckSum, 16);
                        line += temp.Substring(temp.Length-2,2);
                        writer.WriteLine(line);
                    }
                    writer.WriteLine(":00000001FF");

                    writer.Close();
                    break;
                case "mif":

                    writer.WriteLine("DEPTH = 16;");
                    writer.WriteLine("WIDTH = 9;");
                    writer.WriteLine("ADDRESS_RADIX = HEX;");
                    writer.WriteLine("DATA_RADIX = BIN;");
                    writer.WriteLine("CONTENT");
                    writer.WriteLine("BEGIN");

                    for (int i = 0; i < memory.Length; i++)
                    {
                        writer.WriteLine(Convert.ToString(i, 16).PadLeft(2, '0') + " : " + Convert.ToString(memory[i], 2).PadLeft(9, '0') + ";");
                    }

                    writer.WriteLine("END;");

                    writer.Close();
                    break;
            }
            
        }


       
        private void saveButton_Click(object sender, EventArgs e)  // .mif and .hex file saved.
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Mif File|*.mif|Hex File|*.hex";
            save.OverwritePrompt = true;
            save.CreatePrompt = true;



            if (save.ShowDialog() == DialogResult.OK)
            {
                export(save.FileName, true);
            }

            save = new SaveFileDialog();
            save.Filter = "Mif File|*.mif|Hex File|*.hex";
            save.OverwritePrompt = true;
            save.CreatePrompt = true;



            if (save.ShowDialog() == DialogResult.OK)
            {
                export(save.FileName, false);
            }



        }

        // Extra timer opacity
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.1;
            if (this.Opacity == 1)
                timer1.Stop();
        }


    }
}
