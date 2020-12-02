using System;
using System.Collections.Generic;
using System.Data.HashFunction;
using System.Data.HashFunction.CRC;
using System.Linq;
using UnityEngine;

namespace Networking
{
    public class Message
    {
        public byte Version { get; }
        public byte[] Payload { get; }
        
        private readonly byte[] beginSequence = BitConverter.GetBytes((ushort)0xABDA);
        private byte[] header;
        
        private readonly bool includedPayloadChecksum;
        
        private int HeaderLength => includedPayloadChecksum ? 16 : 12;
        
        // Interpreting received byte[]
        public Message(byte[] receivedData)
        {
            // BEGIN SEQUENCE
            
            if (beginSequence.Equals(SubArray(receivedData, 0, 2)))
                throw new Exception("Wrong begin sequence");
            
            // VER
            Version = receivedData[2];

            // RES
            
            // C
            includedPayloadChecksum = (receivedData[3] % 2) == 1;

            // PAYLOAD LENGHT
            int payloadLenght = BitConverter.ToInt32(receivedData, 4);
            if (receivedData.Length - HeaderLength != payloadLenght)
                throw new Exception($"Wrong payload length: got {receivedData.Length - HeaderLength} expected {payloadLenght}");
            
            Payload = SubArray(receivedData, HeaderLength, receivedData.Length - HeaderLength);
            header = SubArray(receivedData, 0, HeaderLength);
            
            // PAYLOAD CHECKSUM
            if (includedPayloadChecksum)
            {
                if (CalculateCRC(Payload, CRCConfig.CRC32).Equals(SubArray(header,8, 4)))
                    throw new Exception("Wrong payload checksum");
            }
            
            // RES

            
            // HEADER CHECKSUM
            byte[] calculatedHeaderChecksum = CalculateCRC(SubArray(header, 0, HeaderLength - 2), CRCConfig.ARC);
            if (!calculatedHeaderChecksum.SequenceEqual(SubArray(header, HeaderLength - 2, 2)))
                throw new Exception($"Wrong header checksum\nExpected:\t{BitConverter.ToString(calculatedHeaderChecksum)}\nReceived:\t{BitConverter.ToString(SubArray(header, HeaderLength - 2, 2))}");
        }

        // Sending serialized data
        public Message(byte[] payload, byte version, bool includePayloadChecksum = true)
        {
            Payload = payload;
            includedPayloadChecksum = includePayloadChecksum;
            Version = version;

            List<byte> newHeader = new List<byte>(HeaderLength);
            
            newHeader.AddRange(beginSequence);
            
            newHeader.Add(version);
            
            newHeader.Add(includePayloadChecksum ? (byte)1u : (byte)0);
            
            newHeader.AddRange(BitConverter.GetBytes(payload.Length)); // PAYLOAD LENGTH
            
            if (includePayloadChecksum)
                newHeader.AddRange(CalculateCRC(payload, CRCConfig.CRC32)); //PAYLOAD CHECKSUM
            
            newHeader.AddRange(new byte[2]); // RES
            
            newHeader.AddRange(CalculateCRC(newHeader.ToArray(), CRCConfig.ARC)); // HEADER CHECKSUM
            
            header = newHeader.ToArray();
            if (header.Length != HeaderLength)
                throw new Exception($"Header should be {HeaderLength}, but is {header.Length}");
        }
        

        public byte[] ToBytes()
        {
            List<byte> ret = new List<byte>(Payload.Length + header.Length);
            ret.AddRange(header);
            ret.AddRange(Payload);
            return ret.ToArray();
        }

        private static T[] SubArray<T>(T[] array, int offset, int length)
        {
            return new ArraySegment<T>(array, offset, length).ToArray();
        }

        public static byte[] CalculateCRC(byte[] data, ICRCConfig checksumType)
        {
            var function =  CRCFactory.Instance.Create(checksumType);
            IHashValue value = function.ComputeHash(data);
            return value.Hash;
        }
    }
}
