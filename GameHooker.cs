﻿using System;
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
            Thread.Sleep(100);
            WriteProcessMemory(_targetProcessHandle, ReturnAddressValue(0x13784A4), BitConverter.GetBytes(0), 4, 0);

        }

        public void WarpToStart()
        {
            AttachToProcess();
            WriteProcessMemory(_targetProcessHandle, ReturnAddressValue(0x13784A4), BitConverter.GetBytes(1), 4, 0);
        }

        private uint ReturnAddressValue(int Address)
        {
            byte[] Intermediate = new byte[4];
            ReadProcessMemory(_targetProcessHandle, Address, Intermediate, 4, 0);
            return BitConverter.ToUInt32(Intermediate, 0);
        }
    }
}