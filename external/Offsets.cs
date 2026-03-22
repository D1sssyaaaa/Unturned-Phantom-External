using System;

namespace UnturnedExternal
{
    public static class Offsets
    {
        // Эти значения нужно будет найти через Cheat Engine или дампер
        public static IntPtr BaseModule = IntPtr.Zero;
        
        // Примерные смещения для Unity/Mono
        public static int Provider = 0x123456; 
        public static int ClientList = 0x78;
        public static int PlayerCount = 0x80;
    }
}
