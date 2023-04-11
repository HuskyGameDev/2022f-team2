using System;
using UnityEngine;

namespace BlackstarCarnival
{
    public enum FaceDirection: byte
    {
        North, 
        NorthWest, 
        West, 
        SouthWest, 
        South, 
        SouthEast, 
        East, 
        NorthEast
    }
    
    internal sealed class FaceDirectionUtility
    {
        private static readonly Quaternion[] _faceDirectionRotations =
        {
            Quaternion.Euler(0, 0, 0),      // North
            Quaternion.Euler(0, 0, 45),     // NorthWest
            Quaternion.Euler(0, 0, 90),     // West
            Quaternion.Euler(0, 0, 135),    // SouthWest
            Quaternion.Euler(0, 0, 180),    // South
            Quaternion.Euler(0, 0, 225),    // SouthEast
            Quaternion.Euler(0, 0, 270),    // East
            Quaternion.Euler(0, 0, 315)     // NorthEast
        };
        
        internal static Quaternion GetRotation(FaceDirection faceDirection)
        {
            return _faceDirectionRotations[(byte) faceDirection];
        }

        internal static FaceDirection GetFaceDirection(Vector2 movement)
        {
            var angle = Vector2.SignedAngle(Vector2.up, movement);
            if (angle < -157.5 || angle > 157.5) return FaceDirection.South;
            if (angle < -112.5) return FaceDirection.SouthEast;
            if (angle < -67.5) return FaceDirection.East;
            if (angle < -22.5) return FaceDirection.NorthEast;
            if (angle < 22.5) return FaceDirection.NorthWest;
            if (angle < 67.5) return FaceDirection.West;
            if (angle < 112.5) return FaceDirection.SouthWest;
            return FaceDirection.North;
        }
    }
}