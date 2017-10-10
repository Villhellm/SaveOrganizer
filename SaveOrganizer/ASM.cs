using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace SaveOrganizer
{
    class ASM
    {
        public List<byte> Bytes;
        public int Position;

        public Dictionary<string, int> Reg8;
        public Dictionary<string, int> Reg16;
        public Dictionary<string, int> Reg32;
        public Dictionary<string, int> CodeBlock;
        public Dictionary<string, int> Variables;
        public SortedDictionary<int, string> VariableRefs;

        public ASM()
        {
            Initialize();
        }

        private void Initialize()
        {
            Bytes = new List<byte>();
            Reg8 = new Dictionary<string, int>();
            Reg16 = new Dictionary<string, int>();
            Reg32 = new Dictionary<string, int>();
            CodeBlock = new Dictionary<string, int>();
            Variables = new Dictionary<string, int>();
            VariableRefs = new SortedDictionary<int, string>();

            Position = 0;

            Reg8.Clear();
            Reg8.Add("al", 0);
            Reg8.Add("cl", 1);
            Reg8.Add("dl", 2);
            Reg8.Add("bl", 3);
            Reg8.Add("ah", 4);
            Reg8.Add("ch", 5);
            Reg8.Add("dh", 6);
            Reg8.Add("bh", 7);

            Reg16.Clear();
            Reg16.Add("ax", 0);
            Reg16.Add("cx", 1);
            Reg16.Add("dx", 2);
            Reg16.Add("bx", 3);

            Reg32.Clear();
            Reg32.Add("eax", 0);
            Reg32.Add("ecx", 1);
            Reg32.Add("edx", 2);
            Reg32.Add("ebx", 3);
            Reg32.Add("esp", 4);
            Reg32.Add("ebp", 5);
            Reg32.Add("esi", 6);
            Reg32.Add("edi", 7);

            CodeBlock.Clear();
            CodeBlock.Add("inc", 0x40);
            CodeBlock.Add("dec", 0x48);
            //CodeBlock.Add("push", 0x50)
            CodeBlock.Add("pop", 0x58);
            CodeBlock.Add("pushad", 0x60);
            CodeBlock.Add("popad", 0x61);
        }

        public void AddVar(string Name, IntPtr Value)
        {
            AddVar(Name, (int)Value);
        }

        public void AddVar(string Name, int Value)
        {
            Name = Name.Replace(":", "");

            if (!Variables.ContainsKey(Name))
            {
                Variables.Add(Name, Value);
            }
            else
            {
                Variables[Name] = Value;
                foreach (var Entry in VariableRefs)
                {
                    if (Entry.Value == Name)
                    {
                        byte[] TempByte;
                        switch (Bytes[Entry.Key])
                        {
                            case 0xe8:
                            case 0xe9:
                                TempByte = BitConverter.GetBytes(Value - (Position - (Bytes.Count() - Entry.Key)) - 5);
                                Array.Copy(TempByte, 0, Bytes.ToArray(), Entry.Key + 1, TempByte.Length);

                                break;
                            case 0xf:
                                TempByte = BitConverter.GetBytes(Value - (Position - (Bytes.Count() - Entry.Key)) - 6);
                                Array.Copy(TempByte, 0, Bytes.ToArray(), Entry.Key + 2, TempByte.Length);
                                break;
                        }
                    }

                }

            }
        }

        private void Add(Byte ByteToAdd)
        {
            Bytes.Add(ByteToAdd);
        }

        private void Add(Byte[] BytesToAdd)
        {
            foreach(byte ToAdd in BytesToAdd)
            {
                Bytes.Add(ToAdd);
            }
        }

        private void ParseInput(string AString, ref string CMD, ref string Reg1, ref string Reg2, ref bool Ptr1, ref bool Ptr2, ref int Plus1, ref int Plus2, ref int Value1, ref int Value2)
        {
            string Params = "";
            string Param1 = "";
            string Param2 = "";

            //Separate Command from params
            if (AString.Contains(" "))
            {
                CMD = AString.Split(' ')[0];
                Params = AString.Substring(CMD.Length+1);
                Params = Params.Replace(" ", "");
            }
            else
            {
                CMD = AString;
            }
            //Check for section name
            if (AString.Contains(":"))
            {
                Variables.Add(CMD, Position);
            }

            //Split params
            if (Params.Contains(","))
            {
                Param2 = Params.Split(',')[1];
            }
            Param1 = Params.Split(',')[0];

            //Check if immediate or pointers
            if (Param1.Contains("["))
            {
                Ptr1 = true;
                Param1 = Param1.Replace("[", "");
                Param1 = Param1.Replace("]", "");
            }
            if (Param2.Contains("["))
            {
                Ptr2 = true;
                Param2 = Param2.Replace("[", "");
                Param2 = Param2.Replace("]", "");
            }

            //Check if there are offsets in params
            if (Param1.Contains("+") | Param1.Contains("-"))
            {
                if (Param1.Contains("0x"))
                {
                    Plus1 = Convert.ToInt32(Param1[3] + Param1.Substring(Param1.Length - 6), 16);
                }
                else
                {
                    Plus1 = Convert.ToInt32(Param1[3] + Param1.Substring(Param1.Length - 4));
                }
                Param1 = Param1.Split('+')[0];
                Param1 = Param1.Split('-')[0];
            }
            if (Param2.Contains("+") | Param2.Contains("-"))
            {
                if (Param2.Contains("0x"))
                {
                    //Plus2 = Convert.ToInt32(param2(3) & Microsoft.VisualBasic.Right(param2, param2.Length - 6), 16)
                    Plus2 = Convert.ToInt32(Param2.Substring(Param2.Length - 4), 16);
                    if (Param2[3] == '-')
                        Plus2 *= -1;
                }
                else
                {
                    Plus2 = Convert.ToInt32(Param2[3] + Param2.Substring(Param2.Length - 4));
                }
                Param2 = Param2.Split('+')[0];
                Param2 = Param2.Split('-')[0];
            }

            //If not registers, convert params from hex to dec
            if (Param1.Contains("0x"))
            {
                Value1 = Convert.ToInt32(Param1, 16);
            }
            if (Param2.Contains("0x"))
            {
                Value2 = Convert.ToInt32(Param2, 16);
            }

            //If numeric, set values
            if (Information.IsNumeric(Param1))
            {
                Value1 = Convert.ToInt32(Param1);
            }
            if (Information.IsNumeric(Param2))
            {
                Value2 = Convert.ToInt32(Param2);
            }

            //Define registers, if not values
            if (Reg32.ContainsKey(Param1))
                Reg1 = Param1;
            if (Reg32.ContainsKey(Param2))
                Reg2 = Param2;
            if (Reg16.ContainsKey(Param1))
                Reg1 = Param1;
            if (Reg16.ContainsKey(Param2))
                Reg2 = Param2;
            if (Reg8.ContainsKey(Param1))
                Reg1 = Param1;
            if (Reg8.ContainsKey(Param2))
                Reg2 = Param2;

            //If param is previously defined section
            if (Variables.ContainsKey(Param1))
            {
                Value1 = Variables[Param1];
                VariableRefs.Add(Bytes.Count(), Param1);
            }
            if (Variables.ContainsKey(Param2))
            {
                Value2 = Variables[Param2];
                VariableRefs.Add(Bytes.Count(), Param2);
            }
        }

        public void AddASM(string AssemblyString)
        {
            string CMD = "";
            string Reg1 = "";
            string Reg2 = "";
            bool Ptr1 = false;
            bool Ptr2 = false;
            int Plus1 = 0;
            int Plus2 = 0;
            int Value1 = 0;
            int Value2 = 0;

            ParseInput(AssemblyString, ref CMD, ref Reg1, ref Reg2, ref Ptr1, ref Ptr2, ref Plus1, ref Plus2, ref Value1, ref Value2);

            byte[] newbytes = null;
            //Check if command is simple 1-byte command
            if (CodeBlock.ContainsKey(CMD))
            {
                newbytes = new byte[] { 0};
                newbytes[0] =Convert.ToByte(CodeBlock[CMD]);

                if (Reg32.ContainsKey(Reg1))
                {
                    newbytes[0] = Convert.ToByte(newbytes[0] | Reg32[Reg1]);
                }
                Add(newbytes);
                Position += newbytes.Count();
                return;
            }

            switch (CMD)
            {
                case "add":
                    if (Reg32.ContainsKey(Reg1) && string.IsNullOrEmpty(Reg2))
                    {
                        newbytes = new byte[]{0x81,0xc0};
                        if (Math.Abs(Value2) < 0x80)
                        {
                            newbytes[0] =Convert.ToByte(newbytes[0] | 2);
                            newbytes = newbytes.Concat(new byte[]{Convert.ToByte(Value2 & 0xFF)}).ToArray();
                        }
                        else
                        {
                            if (Reg1 == "eax")
                            {
                                newbytes = new byte[] { 5 };
                            }
                            newbytes = newbytes.Concat(BitConverter.GetBytes(Value2)).ToArray();
                        }
                        newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                    }

                    if (Reg32.ContainsKey(Reg1) & Reg32.ContainsKey(Reg2))
                    {
                        newbytes = new byte[]{1,0};
                        if (Ptr1)
                        {
                            newbytes[1] = Convert.ToByte(newbytes[1] | (Reg32[Reg2] * 8));
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                        }
                        if (Ptr2)
                        {
                            newbytes[0] = Convert.ToByte(newbytes[0] | 0x2);
                            newbytes[1] = Convert.ToByte(newbytes[1] | (Reg32[Reg1] * 8));
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg2]);
                        }

                        if (!(Ptr1 | Ptr2))
                        {
                            newbytes[1] = Convert.ToByte(newbytes[1] | (Reg32[Reg2] * 8));
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                            newbytes[1] = Convert.ToByte(newbytes[1] | 0xc0);
                        }

                        dynamic offset = null;
                        offset = Plus1 + Plus2;

                        if (Math.Abs(offset) < 0x80)
                        {
                            if (offset > 0)
                            {
                                newbytes[1] = Convert.ToByte(newbytes[1] | 0x40);
                                newbytes = newbytes.Concat(new byte[] { Convert.ToByte(offset & 0xff )}).ToArray();
                            }
                        }
                        if (Math.Abs(offset) > 0x7f)
                        {
                            newbytes[1] = Convert.ToByte(newbytes[1] | 0x80);
                            newbytes = newbytes.Concat(new byte[] { Convert.ToByte(offset) }).ToArray();
                        }

                        if (!Ptr1 & !Ptr2)
                        {
                            newbytes = new byte[] { 1,0xc0};
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg2] * 8);
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                        }
                    }
                    Add(newbytes);
                    Position += newbytes.Count();

                    return;
                case "and":
                    if (Reg32.ContainsKey(Reg1) & string.IsNullOrEmpty(Reg2))
                    {
                        newbytes = new byte[] { 0x83,0xe0};
                        if (Math.Abs(Value2) < 0x80)
                        {
                            newbytes[0] = Convert.ToByte(newbytes[0] | 2);
                            newbytes = newbytes.Concat(new byte[] { Convert.ToByte(Value2 & 0xff )}).ToArray();
                        }
                        else
                        {
                            if (Reg1 == "eax")
                            {
                                newbytes = new byte[] { 0x25 };
                            }
                            newbytes = newbytes.Concat(BitConverter.GetBytes(Value2)).ToArray();
                        }
                        newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                    }

                    if (Reg32.ContainsKey(Reg1) & Reg32.ContainsKey(Reg2))
                    {
                        newbytes = new byte[] { 0x21,0};
                        if (Ptr1)
                        {
                            newbytes[1] = Convert.ToByte(newbytes[1] | (Reg32[Reg2] * 8));
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                        }
                        if (Ptr2)
                        {
                            newbytes[0] = Convert.ToByte(newbytes[0] | 0x2);
                            newbytes[1] = Convert.ToByte(newbytes[1] | (Reg32[Reg1] * 8));
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg2]);
                        }

                        if (!(Ptr1 | Ptr2))
                        {
                            newbytes[1] = Convert.ToByte(newbytes[1] | (Reg32[Reg2] * 8));
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                            newbytes[1] = Convert.ToByte(newbytes[1] | 0xc0);
                        }

                        int offset;
                        offset = Plus1 + Plus2;

                        if (Math.Abs(offset) < 0x80)
                        {
                            if (offset > 0)
                            {
                                newbytes[1] = Convert.ToByte(newbytes[1] | 0x40);
                                newbytes = newbytes.Concat(new byte[] { Convert.ToByte(offset & 0xff )}).ToArray();
                            }
                        }
                        if (Math.Abs(offset) > 0x7f)
                        {
                            newbytes[1] = Convert.ToByte(newbytes[1] | 0x80);
                            newbytes = newbytes.Concat(BitConverter.GetBytes(offset)).ToArray();
                        }

                        if (!Ptr1 & !Ptr2)
                        {
                            newbytes = new byte[] { 0x21,0xc0};
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg2] * 8);
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                        }
                    }
                    Add(newbytes);
                    Position += newbytes.Count();

                    return;
                case "call":
                    if (!Ptr1)
                    {
                        if (Reg32.ContainsKey(Reg1))
                        {
                            //Is only a register
                            newbytes = new byte[] { 0xff,0xd0};
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                        }
                        else
                        {
                            newbytes = new byte[] { 0xe8 };
                            int addrs = Convert.ToInt32(Value1) - Position - 5;
                            newbytes = newbytes.Concat(BitConverter.GetBytes(addrs)).ToArray();

                        }
                    }
                    else
                    {
                        //Is an offset from a register
                        if (Math.Abs(Plus1) < 0x80)
                        {
                            if (Plus1 == 0)
                            {
                                newbytes = new byte[] { 0xff,0x10};
                                newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                            }
                            else
                            {
                                newbytes = new byte[] { 0xff,0x50,0};
                                newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                                newbytes[2] = Convert.ToByte(Plus1);
                            }
                        }
                        else
                        {
                            newbytes = new byte[] { 0xff,0x90};
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                            newbytes = newbytes.Concat(BitConverter.GetBytes(Plus1)).ToArray();
                        }
                    }
                    Add(newbytes);
                    Position += newbytes.Count();
                    return;
                case "cmp":
                    if (Reg32.ContainsKey(Reg1) & string.IsNullOrEmpty(Reg2))
                    {
                        newbytes = new byte[] { 0x81,0xf8};
                        if (Math.Abs(Value2) < 0x80)
                        {
                            newbytes[0] = Convert.ToByte(newbytes[0] | 2);
                            newbytes = newbytes.Concat(new byte[] {Convert.ToByte(Value2 & 0xff )}).ToArray();
                        }
                        else
                        {
                            if (Reg1 == "eax")
                            {
                                newbytes = new byte[] { 0x3d };
                            }
                            newbytes = newbytes.Concat(BitConverter.GetBytes(Value2)).ToArray();
                        }
                        newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                    }

                    if (Reg32.ContainsKey(Reg1) & Reg32.ContainsKey(Reg2))
                    {
                        newbytes = new byte[] { 0x39,0};
                        if (Ptr1)
                        {
                            newbytes[1] = Convert.ToByte(newbytes[1] | (Reg32[Reg2] * 8));
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                        }
                        if (Ptr2)
                        {
                            newbytes[0] = Convert.ToByte(newbytes[0] | 0x2);
                            newbytes[1] = Convert.ToByte(newbytes[1] | (Reg32[Reg1] * 8));
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg2]);
                        }

                        if (!(Ptr1 | Ptr2))
                        {
                            newbytes[1] = Convert.ToByte(newbytes[1] | (Reg32[Reg2] * 8));
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                            newbytes[1] = Convert.ToByte(newbytes[1] | 0xc0);
                        }

                        int offset;
                        offset = Plus1 + Plus2;

                        if (Math.Abs(offset) < 0x80)
                        {
                            if (offset > 0)
                            {
                                newbytes[1] = Convert.ToByte(newbytes[1] | 0x40);
                                newbytes = newbytes.Concat(new byte[] { Convert.ToByte(offset & 0xff )}).ToArray();
                            }
                        }
                        if (Math.Abs(offset) > 0x7f)
                        {
                            newbytes[1] = Convert.ToByte(newbytes[1] | 0x80);
                            newbytes = newbytes.Concat(BitConverter.GetBytes(offset)).ToArray();
                        }

                        if (!Ptr1 & !Ptr2)
                        {
                            newbytes = new byte[] { 0x39,0xc0};
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg2] * 8);
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                        }
                    }
                    Add(newbytes);
                    Position += newbytes.Count();
                    return;
                case "je":
                    newbytes = new byte[] { 0xf,0x84};
                    int addr = Convert.ToInt32(Value1) - Position - 6;
                    newbytes = newbytes.Concat(BitConverter.GetBytes(addr)).ToArray();
                    Add(newbytes);
                    Position += newbytes.Count();
                    return;
                case "jmp":
                    if (!Ptr1)
                    {
                        if (Reg32.ContainsKey(Reg1))
                        {
                            //Is only a register
                            newbytes = new byte[] { 0xff,0xe0};
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                        }
                        else
                        {
                            newbytes = new byte[] { 0xe9 };
                            int addrs = Convert.ToInt32(Value1) - Position - 5;
                            newbytes = newbytes.Concat(BitConverter.GetBytes(addrs)).ToArray();
                        }
                    }
                    else
                    {
                        //Is an offset from a register
                        if (Math.Abs(Plus1) < 0x80)
                        {
                            if (Plus1 == 0)
                            {
                                newbytes = new byte[] { 0xff,0x20};
                                newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                            }
                            else
                            {
                                newbytes = new byte[] { 0xff,0x60,0};
                                newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                                newbytes[2] = Convert.ToByte(Plus1 & 0xff);
                            }
                        }
                        else
                        {
                            newbytes = new byte[] { 0xff,0xa0};
                            newbytes[1] =Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                            newbytes = newbytes.Concat(BitConverter.GetBytes(Plus1)).ToArray();
                        }
                    }
                    Add(newbytes);
                    Position += newbytes.Count();
                    return;
                case "jne":
                    newbytes = new byte[] { 0xf,0x85};
                    addr = Convert.ToInt32(Value1) - Position - 6;
                    newbytes = newbytes.Concat(BitConverter.GetBytes(addr)).ToArray();
                    Add(newbytes);
                    Position += newbytes.Count();
                    return;
                case "mov":
                    //TODO:  Complete
                    if (Reg8.ContainsKey(Reg1) & Reg8.ContainsKey(Reg2))
                    {
                        newbytes = new byte[] { 0x88,0xc0};
                        newbytes[1] = Convert.ToByte(newbytes[1] | Reg8[Reg1]);
                        newbytes[1] = Convert.ToByte(newbytes[1] | Reg8[Reg2] * 8);
                        //TODO:  Complete
                    }


                    if (Reg32.ContainsKey(Reg1) & string.IsNullOrEmpty(Reg2))
                    {
                        newbytes = new byte[] { 0xb8 };
                        newbytes[0] = Convert.ToByte(newbytes[0] | Reg32[Reg1]);
                        newbytes = newbytes.Concat(BitConverter.GetBytes(Value2)).ToArray();
                    }

                    if (Reg32.ContainsKey(Reg1) & Reg32.ContainsKey(Reg2))
                    {
                        newbytes = new byte[] { 0x89,0};

                        if (Ptr1)
                        {
                            newbytes[1] = Convert.ToByte(newbytes[1] | (Reg32[Reg2] * 8));
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                        }
                        if (Ptr2)
                        {
                            newbytes[0] = Convert.ToByte(newbytes[0] | 0x2);
                            newbytes[1] = Convert.ToByte(newbytes[1] | (Reg32[Reg1] * 8));
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg2]);
                        }

                        if (!(Ptr1 | Ptr2))
                        {
                            newbytes[1] = Convert.ToByte(newbytes[1] | (Reg32[Reg2] * 8));
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                            newbytes[1] = Convert.ToByte(newbytes[1] | 0xc0);
                        }

                        int offset;
                        offset = Plus1 + Plus2;

                        if ((Ptr1 & Reg1 == "esp") | (Ptr2 & Reg2 == "esp"))
                        {
                            newbytes = newbytes.Concat(new byte[] { 0x24 }).ToArray();
                        }

                        if (Math.Abs(offset) < 0x80)
                        {
                            if (Math.Abs(offset) > 0 | (Ptr2 & Reg2 == "ebp") | (Ptr1 & Reg1 == "ebp"))
                            {
                                newbytes[1] = Convert.ToByte(newbytes[1] | 0x40);
                                newbytes = newbytes.Concat(new byte[] {Convert.ToByte(offset & 0xff )}).ToArray();
                            }
                        }
                        if (Math.Abs(offset) > 0x7f)
                        {
                            newbytes[1] = Convert.ToByte(newbytes[1] | 0x80);
                            newbytes = newbytes.Concat(BitConverter.GetBytes(offset)).ToArray();
                        }
                    }
                    Add(newbytes);
                    Position += newbytes.Count();
                    return;
                case "push":
                    if (!Ptr1)
                    {
                        if (Reg32.ContainsKey(Reg1))
                        {
                            //Is only a register
                            newbytes = new byte[] { 0x50 };
                            newbytes[0] = Convert.ToByte(newbytes[0] | Reg32[Reg1]);
                        }
                        else
                        {
                            if (Math.Abs(Value1) < 0x100)
                            {
                                newbytes = new byte[] { 0x6a,0};
                                newbytes[1] = Convert.ToByte(Value1 & 0xff);
                            }
                            else
                            {
                                newbytes = new byte[] { 0x68 };
                                newbytes = newbytes.Concat(BitConverter.GetBytes(Value1)).ToArray();
                            }
                        }
                    }
                    else
                    {
                        //Is an offset from a register
                        if (Math.Abs(Plus1) < 0x80)
                        {
                            if (Plus1 == 0)
                            {
                                //No Offset
                                newbytes = new byte[] { 0xff,0x30};
                            }
                            else
                            {
                                //Offset between 0 and 0xFF
                                newbytes = new byte[] { 0xff,0x70,0};
                                newbytes[2] = Convert.ToByte(Plus1 & 0xff);
                            }
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                        }
                        else
                        {
                            //Offset is > 0xFF
                            newbytes = new byte[] { 0xff,0xb0};
                            newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                            newbytes = newbytes.Concat(BitConverter.GetBytes(Plus1)).ToArray();
                        }
                    }
                    Add(newbytes);
                    Position += newbytes.Count();
                    return;
                case "ret":
                    newbytes = new byte[] { 0xc2 };
                    if (Math.Abs(Value1) > 0)
                    {
                        newbytes = newbytes.Concat(BitConverter.GetBytes(Convert.ToInt16(Value1))).ToArray();
                    }
                    else
                    {
                        newbytes[0] = Convert.ToByte(newbytes[0] | 1);
                    }
                    Add(newbytes);
                    Position += newbytes.Count();
                    return;
                case "shl":
                case "shr":
                    //TODO:  Handle Reg1 = ax, al
                    if (Reg32.ContainsKey(Reg1))
                    {
                        if (Reg2 == "cl")
                        {
                            newbytes = new byte[] { 0xd3,0xe0};
                        }
                        if (string.IsNullOrEmpty(Reg2))
                        {
                            newbytes = new byte[] { 0xc1,0xe0};
                            newbytes = newbytes.Concat(new byte[] {Convert.ToByte(Value2 & 0xff )}).ToArray();
                        }
                        newbytes[1] = Convert.ToByte(newbytes[1] | Reg32[Reg1]);
                        if (CMD == "shr")
                            newbytes[1] = Convert.ToByte(newbytes[1] | 0x8);
                    }
                    Add(newbytes);
                    Position += newbytes.Count();
                    return;
            }
        }
    }
}
