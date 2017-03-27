# DeuSmallScaleExperimentalMachine

  In this project, you are expected to design a simulator for the basic computer called DEU Small Scale Experimental Machine (DSSEM) which is similar to Mano’s Computer. The main goal is converting assembly code to the corresponding machine code. You will write a windows application program to design the simulator by using C#. The simulator should have the following specifications:

   Reading and parsing the input files that include assembly code.
   It should run the program step by step showing the phases of instruction cycle (fetching, decoding, effective address calculation and execution).
   Generating label table and memory content table.
   Should show contents of the registers and memory segments.
   Should show computer operations and their micro operations.
   Should support instruction set shown in Table 1.
   Should switch between binary / hexadecimal /octal / decimal codes.
   Exporting hex or mif file of the machine code (hex code or binary code).
   User friendly, efficient Graphical User Interface(GUI).
  
  The basic computer DSSEM has 6 registers and 3 memory segments ( Figure 1). Registers are AR, DR, PC, IR, SP, AC. The memory has code segment, data segment and stack segment.
  In the input file (asm or basm file) there will be assembly(symbolic) codes. The assembly language of the basic computer is defined by a set of rules. An example for assembly code is given in the Code 1. Each line of the language has three columns called fields (Mano, 1993).
  
  1. The label field may be empty or it may specify a symbolic address. It is followed by a comma(,).
  2. The instruction field specifies a machine instruction (Table 1) or a pseudo-instruction ( ORG, END, DEC N, HEX N)
  3. The comment field may be empty or it may include a comment after a percent sign(%).
  The format of a line is as follow:
  [label,] opcode [address] [I] [%comment]
  
  
  example file: 
      ORG C 2   %Origin of code segment 
      LDA A     %Load operand from location A 
      ADD B     %Add operand from location B 
      STA S     %Store sum in location S 
      HLT       %Halt computer 
      ORG D 0   %Origin of data segment  
  A,  DEC 6     %Decimal operand  
  B,  HEX 4     %Hexadecimal operand  
  S,  DEC 0     %Sum stored in location S 
      END       %End of symbolic program
