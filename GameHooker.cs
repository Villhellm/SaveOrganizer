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
        public static extern bool ReadProcessMemory(IntPtr hProcess,int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        uint funcPtr;
        uint dropPtr;
        private IntPtr _targetProcessHandle = IntPtr.Zero;

        private void AttachToProcess()
        {
            Process[] AllProcesses = Process.GetProcesses();
            foreach(Process Proc in AllProcesses)
            {
                if(Proc.MainWindowTitle.ToLower() == "dark souls")
                {
                    _targetProcessHandle = OpenProcess(0x1f0fff, false, Proc.Id);
                    dropPtr = (uint)VirtualAllocEx(_targetProcessHandle, 0, 1024, 4096, 4);
                    funcPtr = (uint)VirtualAllocEx(_targetProcessHandle, 0, 1024, 4096, 4);

                }
            }
        }

        private void funcCall()
        {
            byte[] bytes = new byte[] {0x55, 0x8b, 0xec, 0x50, 0xb8, 0, 0, 0, 0, 0x50, 0xb8, 0, 0, 0, 0, 0x50, 0xb8, 0, 0, 0, 0, 0x50, 0xb8, 0, 0, 0, 0, 0x50, 0xb8, 0, 0, 0, 0, 0x50, 0xe8, 0, 0, 0, 0, 0x58, 0x58, 0x58, 0x58, 0x58, 0x58, 0x8b, 0xe5, 0x5d, 0xc3 };
            byte[] bytes2 = null;

            dynamic bytParams = new int[] { 0x1d, 0x17, 0x11, 0xb, 0x5 };
            int bytJmp = 35;

            bytes2 = BitConverter.GetBytes(Convert.ToInt32(0 - ((funcPtr + bytJmp + 4) - 14016960)));

            Array.Copy(bytes2, 0, bytes, bytJmp, bytes2.Length);
            WriteProcessMemory(_targetProcessHandle, funcPtr, bytes, 1024, 0);
            CreateRemoteThread(_targetProcessHandle, 0, 0, funcPtr, 0, 0, 0);
            Thread.Sleep(2);
        }

        public void ExitToMainMenu()
        {
            AttachToProcess();
            funcCall();
            Thread.Sleep(2000);
        }
    }
}
