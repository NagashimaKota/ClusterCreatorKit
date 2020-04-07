using System;
using System.Security.Cryptography;
using UnityEngine;

namespace ClusterVR.CreatorKit.Item
{
    [Serializable]
    public struct ItemId : IEquatable<ItemId>
    {
        [SerializeField] ulong value;
        public ulong Value => value;

        static RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();

        public ItemId(ulong value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public bool Equals(ItemId other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is ItemId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        // TODO: 動的に Item 生成するときに速度評価する
        public static ItemId Create()
        {
            var bs = new byte[sizeof(ulong)];
            rngCryptoServiceProvider.GetBytes(bs);
            var value = BitConverter.ToUInt64(bs, 0);
            return new ItemId(value);
        }
    }
}