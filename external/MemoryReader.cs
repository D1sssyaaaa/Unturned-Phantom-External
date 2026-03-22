using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace UnturnedExternal
{
    public class MemoryReader
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, out int lpNumberOfBytesRead);

        private IntPtr _processHandle;
        private IntPtr _baseAddress;
        private System.Collections.Generic.Dictionary<IntPtr, byte[]> _cache = new System.Collections.Generic.Dictionary<IntPtr, byte[]>();

        public bool Connect(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            if (processes.Length > 0)
            {
                _processHandle = OpenProcess(0x0010 | 0x0020 | 0x0400, false, processes[0].Id);
                _baseAddress = processes[0].MainModule.BaseAddress;
                return true;
            }
            return false;
        }

        public void ClearCache() => _cache.Clear();

        public T Read<T>(IntPtr address, bool useCache = false) where T : struct
        {
            int size = Marshal.SizeOf(typeof(T));
            byte[] buffer;

            if (useCache && _cache.TryGetValue(address, out buffer))
            {
                // Return cached version
            }
            else
            {
                buffer = new byte[size];
                ReadProcessMemory(_processHandle, address, buffer, size, out _);
                if (useCache) _cache[address] = buffer;
            }

            GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            T data = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            handle.Free();
            return data;
        }
    }
}
