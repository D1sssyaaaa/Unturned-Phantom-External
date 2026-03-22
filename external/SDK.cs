using System;
using System.Numerics;

namespace UnturnedExternal
{
    // Эти структуры должны точно соответствовать расположению данных в памяти (Memory Layout)
    // Мы основываемся на анализе Assembly-CSharp.dll
    
    public struct UnityVector3
    {
        public float X, Y, Z;
    }

    public class PlayerSDK
    {
        public IntPtr Instance;
        
        // Примерные смещения внутри объекта Player
        public static int HealthOffset = 0x120; // Нужно будет уточнить
        public static int PositionOffset = 0x30; // Обычно в Unity это Transform -> Position
        
        public float GetHealth(MemoryReader reader)
        {
            return reader.Read<float>(Instance + HealthOffset);
        }
    }

    public class ItemSDK
    {
        public IntPtr Instance;
        public string Name;
        public Vector3 Position;
    }
}
