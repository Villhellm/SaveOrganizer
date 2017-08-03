using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveOrganizer
{
    class GameHooker
    {
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
