using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

    public class DataReader
    {
        private byte[] data;
        private int Current = 0;
        public DataReader(byte[] data)
        {
            this.data = data;
        }

        #region Premitive
        public bool GetBool()
        {
            return BitConverter.ToBoolean(Next(sizeof(bool)), 0);
        }
        public byte GetByte()
        {
            return Next(1)[0];
        }
        public char GetChar()
        {
            return BitConverter.ToChar(Next(sizeof(char)), 0);
        }
        public double GetDouble()
        {
            return BitConverter.ToDouble(Next(sizeof(double)), 0);
        }
        public float GetFloat()
        {
            return BitConverter.ToSingle(Next(sizeof(float)), 0);
        }
        public int GetInt()
        {
            return BitConverter.ToInt32(Next(sizeof(int)), 0);
        }
        public uint GetUInt()
        {
            return BitConverter.ToUInt32(Next(sizeof(uint)), 0);
        }
        public long GetLong()
        {
            return BitConverter.ToInt64(Next(sizeof(long)), 0);
        }
        public ulong GetULong()
        {
            return BitConverter.ToUInt64(Next(sizeof(ulong)), 0);
        }
        public short GetShort()
        {
            return BitConverter.ToInt16(Next(sizeof(short)), 0);
        }
        public ushort GetUShort()
        {
            return BitConverter.ToUInt16(Next(sizeof(ushort)), 0);
        }
        public string GetString()
        {
            int length = GetInt();
            return Encoding.UTF8.GetString(Next(length));
        }
        #endregion

        #region Util
        public byte[] GetBytes()
        {
            int length = GetInt();
            return Next(length);
        }
        #endregion

        public byte[] Next(int size)
        {
            byte[] ret = data[Current..(Current + size)];
            Current += size;
            return ret;
        }
    }