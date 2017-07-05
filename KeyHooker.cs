using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveOrganizer
{
    class KeyHooker : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_HOTKEY = 0x0312;
        private LowLevelKeyboardProc _proc;
        private static IntPtr _hookID = IntPtr.Zero;

        public int Modifier
        {
            get
            {
                return _Modifier;
            }
            set
            {
                _Modifier = value;
            }
        }
        public int CurrentKey
        {
            get
            {
                return _CurrentKey;
            }
            set
            {
                _CurrentKey = value;
                OnPropertyChanged("KeyChangedCombo");
            }
        }
        private int _Modifier = 0;
        private int _CurrentKey = 0;

        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        public void Initialize()
        {
            _proc = new LowLevelKeyboardProc(HookCallback);
            _hookID = SetHook(_proc);
        }

        public void CloseHooker()
        {
            UnhookWindowsHookEx(_hookID);
        }

        int KeyPrevious = 0;

        static List<int> ModifierList = new List<int>() { 160, 161, 162, 163 };

        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            int vkCode = Marshal.ReadInt32(lParam);
            foreach (int Mod in ModifierList)
            {
                if (vkCode == Mod && wParam == (IntPtr)WM_KEYDOWN && KeyPrevious != vkCode)
                {
                    Modifier = Mod;
                    KeyPrevious = vkCode;
                    CurrentKey = 0;
                    return CallNextHookEx(_hookID, nCode, wParam, lParam);
                }
                if (vkCode == Mod && wParam == (IntPtr)WM_KEYUP)
                {
                    KeyPrevious = 0;
                    Modifier = 0;
                    if (CurrentKey == 0)
                    {
                        CurrentKey = vkCode;
                    }
                    return CallNextHookEx(_hookID, nCode, wParam, lParam);
                }
            }

            if (wParam == (IntPtr)WM_KEYDOWN && KeyPrevious != vkCode)
            {
                if (Modifier == 164)
                {
                    Modifier = 0;
                }
                KeyPrevious = vkCode;
                CurrentKey = vkCode;
            }

            if (wParam == (IntPtr)WM_SYSKEYDOWN && KeyPrevious != vkCode)
            {
                KeyPrevious = vkCode;
                Modifier = 164;
                CurrentKey = 0;
            }

            if (wParam == (IntPtr)WM_SYSKEYUP)
            {
                KeyPrevious = 0;
                CurrentKey = vkCode;
            }

            if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP)
            {
                KeyPrevious = 0;
                if (vkCode == 164)
                {
                    Modifier = 0;
                    if (CurrentKey == 0)
                    {
                        CurrentKey = vkCode;
                    }
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

    }
}
