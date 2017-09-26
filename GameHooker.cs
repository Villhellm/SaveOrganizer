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
using Microsoft.VisualBasic;
using System.Globalization;

namespace SaveOrganizer
{
    class GameHooker
    {
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
        public static extern bool ReadProcessMemory(IntPtr hProcess,int lpBaseAddress, byte[] lpBuffer, int dwSize, int lpNumberOfBytesRead);

        private IntPtr _targetProcessHandle = IntPtr.Zero;

        Dictionary<string, int> LuaFunctions;
        private bool NoClip = false;

        private void AttachToProcess()
        {
            Process[] AllProcesses = Process.GetProcesses();
            foreach(Process Proc in AllProcesses)
            {
                if(Proc.MainWindowTitle.ToLower() == "dark souls")
                {
                    _targetProcessHandle = OpenProcess(0x1f0fff, false, Proc.Id);
                }
            }
        }

        public GameHooker()
        {
            FillDictionary();
        }

        private void FillDictionary()
        {
            string line;
            LuaFunctions = new Dictionary<string, int>();
            StreamReader file = new StreamReader("Resources\\FuncLocs.txt");
            while ((line = file.ReadLine()) != null)
            {
                LuaFunctions.Add(line.Substring(line.IndexOf("|")+1), Convert.ToInt32(line.Substring(0, 8)));
            }

            file.Close();
        }

        public void ExitToMainMenu()
        {
            AttachToProcess();
            WriteProcessMemory(_targetProcessHandle, ReturnAddressValue(0x13784A4), BitConverter.GetBytes(2), 4, 0);
            Thread.Sleep(15);
            WriteProcessMemory(_targetProcessHandle, ReturnAddressValue(0x13784A4), BitConverter.GetBytes(0), 4, 0);
            Thread.Sleep(10);

            while (ReturnAddressValue((int)ReturnAddressValue(0x01378680) + 0xF8) != 1)
            {
                if(ReturnAddressValueWithVerification(0x0019EEE4) != 0x00786D36)
                {
                    return;
                }
            }

            WriteProcessMemory(_targetProcessHandle, (ReturnAddressValue(0x01378680) + 0xF8), BitConverter.GetBytes(2), 4, 0);
        }

        public void WarpToStart()
        {
            AttachToProcess();
            WriteProcessMemory(_targetProcessHandle, ReturnAddressValue(0x13784A4), BitConverter.GetBytes(1), 4, 0);
        }

        public uint ReturnAddressValue(int Address)
        {
            AttachToProcess();
            byte[] Intermediate = new byte[4];
            ReadProcessMemory(_targetProcessHandle, Address, Intermediate, 4, 0);
            return BitConverter.ToUInt32(Intermediate, 0);
        }

        public uint ReturnAddressValueWithVerification(int Address)
        {
            List<uint> Reads = new List<uint>();
            for (int i = 0; i < 10; i++)
            {
                Reads.Add(ReturnAddressValue(Address));
            }

            int Count;

            foreach (uint Adrs in Reads)
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
            AttachToProcess();
            WriteProcessMemory(_targetProcessHandle, (ReturnAddressValue(0x0019EEE4)+ 0x108), BitConverter.GetBytes(3), 4, 0);
            WriteProcessMemory(_targetProcessHandle, (ReturnAddressValue(0x0019EEE4) + 0x114), BitConverter.GetBytes(2), 4, 0);
        }


        private delegate Int32 MyAdd(Int32 x, Int32 y);

        public void SetMapHit(bool YesNo)
        {
            AttachToProcess();
            if (YesNo)
            {
                RunLuaScript("disablemaphit", "10000", "0");

            }
            else
            {
                RunLuaScript("disablemaphit", "10000", "1");
            }
        }

        public void SetGravity(bool YesNo)
        {
            AttachToProcess();
            if (YesNo)
            {
                RunLuaScript("setdisablegravity", "10000", "0");

            }
            else
            {
                RunLuaScript("setdisablegravity", "10000", "1");
            }
        }

        public void ToggleNoClip()
        {
            if (NoClip)
            {
                SetGravity(true);
                SetMapHit(true);
                NoClip = false;
            }
            else
            {
                SetGravity(false);
                SetMapHit(false);
                NoClip = true;
            }
        }

        public void RunLuaScript(string LuaFunction, string Param1 = "", string Param2 = "", string Param3 = "", string Param4 = "", string Param5 = "")
        {
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


            WriteProcessMemory(_targetProcessHandle,Convert.ToUInt32(funcPtr), A.Bytes.ToArray(), 1024, 0);
            CreateRemoteThread(_targetProcessHandle, 0, 0, Convert.ToUInt32(funcPtr), 0, 0, 0);
            Thread.Sleep(5);
        }

        public void QuitToMenuDoThingsThenLoadSaveMenu(Action DoThings)
        {
            if (InGame())
            {
                ExitToMainMenu();
                Thread.Sleep(100);
                while (ReturnAddressValue((int)ReturnAddressValue(0x0019EEE4) + 0x10) != 27) ;
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
            uint Now = ReturnAddressValue((int)ReturnAddressValue(0x1378700) + 0x66);
            uint Then = ReturnAddressValue((int)ReturnAddressValue(0x1378700) + 0x66);
            if (Now !=0)
            {
                Thread.Sleep(20);
                Now = ReturnAddressValue((int)ReturnAddressValue(0x1378700) + 0x66);
                if(Now != Then && Now != 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
