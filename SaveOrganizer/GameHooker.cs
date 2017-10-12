using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;

namespace SaveOrganizer
{
    class GameHooker
    {
        [DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, uint lpBaseAddress, byte[] lpBuffer, int dwSize, int lpNumberOfBytesWritten);

        [DllImport("kernel32")]
        public static extern IntPtr CreateRemoteThread(IntPtr hProcess, int lpThreadAttributes, int dwStackSize, uint lpStartAddress, int lpParameter, uint dwCreationFlags, uint lpThreadId);

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, int lpAddress, int dwSize, int flAllocationType, int flProtect);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, uint lpBaseAddress, byte[] lpBuffer, int dwSize, int lpNumberOfBytesRead);

        private IntPtr _targetProcessHandle = IntPtr.Zero;
        public uint _targetProcessBaseAddress = 0x400000;
        Dictionary<string, int> LuaFunctions;
        private bool NoClip = false;
        private uint Damage = 0;
        private bool AIEnabled = true;

        private void AttachToProcess()
        {
            Process[] AllProcesses = Process.GetProcesses();
            foreach(Process Proc in AllProcesses)
            {
                if(Proc.MainWindowTitle.ToLower() == "dark souls")
                {
                    if(_targetProcessHandle != IntPtr.Zero)
                    {
                        CloseHandle(_targetProcessHandle);
                    }
                    _targetProcessHandle = OpenProcess(0x1f0fff, false, Proc.Id);
                }
            }
        }

        public GameHooker()
        {
            LuaFunctions = FuncLocs.LuaFunctions();
        }

        public void ExitToMainMenu()
        {
            Write(ReturnPointer(0x13784A4), BitConverter.GetBytes(2));
            Thread.Sleep(15);
            Write(ReturnPointer(0x13784A4), BitConverter.GetBytes(0));
            Thread.Sleep(10);

            while (ReturnInt32(ReturnPointer(0x01378680) + 0xF8) != 1)
            {
                if(ReturnAddressValueWithVerification(0x0019EEE4) != 0x00786D36)
                {
                    return;
                }
            }

            Write((ReturnPointer(0x01378680) + 0xF8), BitConverter.GetBytes(2));
        }

        public void WarpToStart()
        {
            Write(ReturnPointer(0x13784A4), BitConverter.GetBytes(1));
        }

        public int ReturnInt32(uint Address)
        {
            AttachToProcess();
            byte[] Intermediate = new byte[4];
            ReadProcessMemory(_targetProcessHandle, Address, Intermediate, 4, 0);
            return BitConverter.ToInt32(Intermediate, 0);
        }

        public uint ReturnPointer(uint Address)
        {
            AttachToProcess();
            byte[] Intermediate = new byte[4];
            ReadProcessMemory(_targetProcessHandle, Address, Intermediate, 4, 0);
            return BitConverter.ToUInt32(Intermediate, 0);
        }

        public int ReturnAddressValueWithVerification(uint Address)
        {
            List<int> Reads = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                Reads.Add(ReturnInt32(Address));
            }

            int Count;

            foreach (int Adrs in Reads)
            {
                Count = (from temp in Reads where temp.Equals(Adrs) select temp).Count();
                if (Count >= 5)
                {
                    return Adrs;
                }
            }

            return 69696969;
        }

        public void LoadSaveMenu()
        {
            Write((ReturnPointer(0x0019EEE4)+ 0x108), BitConverter.GetBytes(3));
            Write((ReturnPointer(0x0019EEE4) + 0x114), BitConverter.GetBytes(2));
        }

        private delegate Int32 MyAdd(Int32 x, Int32 y);

        public void SetMapHit(bool YesNo)
        {
            if (YesNo)
            {
                RunLuaScript("disablemaphit", "10000", "0");

            }
            else
            {
                RunLuaScript("disablemaphit", "10000", "1");
            }
        }

        public void SetGravity(bool Toggle)
        {
            if (Toggle)
            {
                RunLuaScript("setdisablegravity", "10000", "0");

            }
            else
            {
                RunLuaScript("setdisablegravity", "10000", "1");
            }
        }

        public void SetDamage(bool Toggle)
        {
            if (Toggle)
            {
                RunLuaScript("disabledamage", "10000", "1");
            }
            else
            {
                RunLuaScript("disabledamage", "10000", "0");
            }
        }

        public void ToggleNoClip()
        {
            uint CharacterPointer = ReturnPointer(0x137DC70);
            CharacterPointer = ReturnPointer(CharacterPointer + 0x4);
            CharacterPointer = ReturnPointer(CharacterPointer);
            uint CharacterMapDataPointer = ReturnPointer(CharacterPointer + 0x28);
            bool NoClipToggle = ((ReturnPointer(CharacterMapDataPointer+ 0xC4) & 0x10) == 0x10);

            SetGravity(NoClipToggle);
            SetMapHit(NoClipToggle);
        }

        public void ToggleDamage()
        {
            uint CharacterPointer = ReturnPointer(0x137DC70);
            CharacterPointer = ReturnPointer(CharacterPointer + 0x4);
            CharacterPointer = ReturnPointer(CharacterPointer);
            uint DamageValue = ReturnPointer(CharacterPointer + 0x1FF);
            bool DamageToggle = DamageValue == Damage;
            SetDamage(!DamageToggle);
            Damage = DamageValue;
        }

        public void ToggleAI()
        {
            bool Enabled = Convert.ToBoolean(ReturnInt32(0x13784EE));
            Write(0x13784EE, BitConverter.GetBytes(!Enabled));
        }

        private void WaitMilliseconds(int Millis)
        {
            DateTime Then = DateTime.Now;
            DateTime Now = DateTime.Now;

            while (Then.AddMilliseconds(Millis) > Now)
            {
                Now = DateTime.Now;
            }
        }

        public void RunLuaScript(string LuaFunction, string Param1 = "", string Param2 = "", string Param3 = "", string Param4 = "", string Param5 = "")
        {
            AttachToProcess();
            List<string> Params = new List<string>() { Param1, Param2, Param3, Param4, Param5 };
            IntPtr Param = Marshal.AllocHGlobal(4);
            int funcPtr = (int)VirtualAllocEx(_targetProcessHandle, 0, 1024, 4096, 0x40);
            int ParamInt;
            Single ParamFloat;

            ASM A = new ASM();
            LuaFunction = LuaFunction.ToLower();
            A.Position = funcPtr;
            A.AddVar("funcloc", LuaFunctions[LuaFunction]);
            A.AddVar("returnedloc", funcPtr + 0x200);
            A.AddASM("push ebp");
            A.AddASM("mov ebp,esp");
            A.AddASM("push eax");

            for (int i = 4; i >= 0; i += -1)
            {
                if (Params[i].ToLower() == "false")
                    Params[i] = "0";
                if (Params[i].ToLower() == "true")
                    Params[i] = "1";
                if (Params[i].Length < 1)
                    Params[i] = "0";

                if (Params[i].Contains("."))
                {
                    ParamFloat = Convert.ToSingle(Params[i], new CultureInfo("en-us"));
                    Marshal.StructureToPtr(ParamFloat, Param, false);
                    A.AddVar("param" + i, Marshal.ReadInt32(Param));
                }
                else
                {
                    ParamInt = Convert.ToInt32(Params[i], new CultureInfo("en-us"));
                    A.AddVar("param" + i, ParamInt);
                }

                A.AddASM("mov eax,param" + i);
                A.AddASM("push eax");

            }
            A.AddASM("call funcloc");
            A.AddASM("mov ebx,returnedloc");
            A.AddASM("mov [ebx],eax");
            A.AddASM("pop eax");
            A.AddASM("pop eax");
            A.AddASM("pop eax");
            A.AddASM("pop eax");
            A.AddASM("pop eax");
            A.AddASM("pop eax");
            A.AddASM("mov esp,ebp");
            A.AddASM("pop ebp");
            A.AddASM("ret");

            Marshal.FreeHGlobal(Param);


            Write(Convert.ToUInt32(funcPtr), A.Bytes.ToArray(), 1024);
            CreateRemoteThread(_targetProcessHandle, 0, 0, Convert.ToUInt32(funcPtr), 0, 0, 0);
            Thread.Sleep(5);
        }

        public void Write(uint Address, byte[] ToBeWritten)
        {
            AttachToProcess();
            WriteProcessMemory(_targetProcessHandle, Address, ToBeWritten, 4, 0);
        }
        public void Write(uint Address, byte[] ToBeWritten, int Buffer)
        {
            AttachToProcess();
            WriteProcessMemory(_targetProcessHandle, Address, ToBeWritten, Buffer, 0);
        }

        public void QuitToMenuDoThingsThenLoadSaveMenu(Action DoThings)
        {
            if (InGame())
            {
                ExitToMainMenu();
                Thread.Sleep(100);
                while (ReturnInt32(ReturnPointer(0x0019EEE4) + 0x10) != 27) ;
                DoThings();
                LoadSaveMenu();
            }
            else
            {
                DoThings();
            }
        }

        private bool InGame()
        {
            int Now = ReturnInt32(ReturnPointer(0x1378700) + 0x66);
            int Then = ReturnInt32(ReturnPointer(0x1378700) + 0x66);
            if (Now !=0)
            {
                Thread.Sleep(20);
                Now = ReturnInt32(ReturnPointer(0x1378700) + 0x66);
                if(Now != Then && Now != 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
