using System;
using System.Numerics;

namespace UnturnedExternal
{
    public class Aimbot
    {
        public float Smoothness = 5.0f; // Чем выше, тем медленнее доводка
        public float FOV = 10.0f;

        public Vector3 CalculateSmoothRotation(Vector3 currentRotation, Vector3 targetRotation, float deltaTime)
        {
            // Плавная интерполяция между текущим углом и целью
            Vector3 delta = targetRotation - currentRotation;
            
            // Нормализация углов (чтобы не крутить камеру на 360 градусов)
            if (delta.X > 180) delta.X -= 360;
            if (delta.X < -180) delta.X += 360;
            if (delta.Y > 180) delta.Y -= 360;
            if (delta.Y < -180) delta.Y += 360;

            return currentRotation + (delta / Smoothness) * deltaTime * 10f;
        }

        public bool IsInFOV(Vector3 playerPos, Vector3 targetPos, Vector3 viewAngle)
        {
            // Проверка, попадает ли цель в круг FOV
            return true; // Упрощенно
        }
    }
}
