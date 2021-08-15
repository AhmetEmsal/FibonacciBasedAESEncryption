using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace FibonacciBasedAESEncryption
{
    public class Faes
    {
        //do not change datas because some changes were made for performance reasons. Search: //for performance
        public static readonly byte round = 14;
        public static readonly int blockSize = 128; //bit size
        public static readonly int keySize = 128; //bit size
        private static readonly Polynomial irreduciblePoly = Polynomial.WithBitArr(new char[2] { '1', '1' }, 2); //1 + x =  x^4
        private static readonly byte irreduciblePolyDegree = 4;

        //Dimension of matrix
        private static readonly byte rowSize = 4;
        private static readonly byte columnSize = 4;

        //Sbox Tables
        private static readonly byte[,] sBoxTables = new byte[16, 16]{
              //00    01    02    03    04    05    06    07    08    09    0A    0B    0C    0D    0E    0F
            { 0x5A, 0x45, 0x4E, 0x42, 0xCB, 0x52, 0x56, 0xFC, 0x09, 0x38, 0x5E, 0x12, 0xC7, 0xEE, 0x92, 0x4F }, //00
            { 0xF3, 0xBB, 0xF0, 0x44, 0xC3, 0x60, 0x7E, 0xC9, 0x94, 0xED, 0x9B, 0x96, 0xA5, 0x9D, 0x4B, 0xF9 }, //01
            { 0x8E, 0xC4, 0xAA, 0x1F, 0x0F, 0x06, 0xCE, 0xF5, 0x0D, 0x9C, 0xDC, 0xC8, 0x48, 0xE1, 0x08, 0x2C }, //02
            { 0x3D, 0xFE, 0x1A, 0xFA, 0x21, 0xAF, 0x3C, 0xA3, 0x3E, 0x2B, 0xB9, 0xDB, 0xD2, 0x1E, 0x8B, 0x4C }, //03
            { 0x30, 0xBA, 0x15, 0x23, 0x22, 0x57, 0x63, 0x99, 0x6B, 0x02, 0xEF, 0x8A, 0x10, 0xDA, 0x16, 0xBD }, //04
            { 0x6A, 0xE8, 0x39, 0xD4, 0x19, 0xC5, 0x88, 0x62, 0x53, 0xF2, 0x87, 0x00, 0x73, 0x75, 0x61, 0xF6 }, //05
            { 0xE9, 0xD6, 0x93, 0xC2, 0x7A, 0x74, 0x0A, 0xBC, 0x7C, 0xC0, 0x3B, 0x46, 0x69, 0x05, 0xA6, 0x91 }, //06
            { 0x68, 0x9A, 0x79, 0xB6, 0xAB, 0xA4, 0x01, 0xCC, 0x85, 0x8F, 0xE3, 0x18, 0x29, 0xC6, 0xCA, 0xEB }, //07
            { 0xF4, 0x35, 0x2A, 0xD5, 0x66, 0xAE, 0x7D, 0x2E, 0xFD, 0x9E, 0x47, 0x04, 0x5D, 0x64, 0x20, 0x4A }, //08
            { 0x59, 0xB8, 0x76, 0xE5, 0x1B, 0x13, 0xA9, 0xB1, 0x7F, 0xD7, 0x81, 0x2D, 0xE7, 0x67, 0x32, 0xE2 }, //09
            { 0xD9, 0x0B, 0x03, 0x33, 0x70, 0x3F, 0x1D, 0x65, 0xFB, 0xEA, 0x95, 0x5B, 0xA8, 0xAC, 0xDD, 0x40 }, //0A
            { 0xDE, 0xF1, 0x0E, 0x54, 0xB4, 0xEC, 0x77, 0x90, 0x55, 0x6F, 0xCD, 0xD3, 0x5C, 0x43, 0x97, 0x31 }, //0B
            { 0x83, 0x41, 0x1C, 0x17, 0x25, 0x9F, 0x8D, 0xFF, 0xD1, 0xE4, 0x4D, 0x26, 0x72, 0x84, 0xB2, 0xB3 }, //0C
            { 0x49, 0x07, 0x8C, 0x5F, 0x71, 0x3A, 0xCF, 0x37, 0x58, 0x0C, 0x6E, 0x80, 0xBF, 0xF8, 0x24, 0xA7 }, //0D
            { 0xD8, 0xC1, 0xA1, 0x28, 0x50, 0xE0, 0xB7, 0xAD, 0xA2, 0x27, 0xBE, 0xD0, 0xF7, 0x6C, 0x11, 0xE6 }, //0E
            { 0xB5, 0x98, 0xB0, 0x34, 0x86, 0xDF, 0x7B, 0x51, 0x78, 0xA0, 0x14, 0x36, 0x89, 0x6D, 0x82, 0x2F }  //0F
        };
        private static readonly byte[,] inverseSBoxTables = new byte[16, 16]{
             //00    01    02    03    04    05    06    07    08    09    0A    0B    0C    0D    0E    0F
            { 0x5B, 0x76, 0x49, 0xA2, 0x8B, 0x6D, 0x25, 0xD1, 0x2E, 0x08, 0x66, 0xA1, 0xD9, 0x28, 0xB2, 0x24 }, //00
            { 0x4C, 0xEE, 0x0B, 0x95, 0xFA, 0x42, 0x4E, 0xC3, 0x7B, 0x54, 0x32, 0x94, 0xC2, 0xA6, 0x3D, 0x23 }, //01
            { 0x8E, 0x34, 0x44, 0x43, 0xDE, 0xC4, 0xCB, 0xE9, 0xE3, 0x7C, 0x82, 0x39, 0x2F, 0x9B, 0x87, 0xFF }, //02
            { 0x40, 0xBF, 0x9E, 0xA3, 0xF3, 0x81, 0xFB, 0xD7, 0x09, 0x52, 0xD5, 0x6A, 0x36, 0x30, 0x38, 0xA5 }, //03
            { 0xAF, 0xC1, 0x03, 0xBD, 0x13, 0x01, 0x6B, 0x8A, 0x2C, 0xD0, 0x8F, 0x1E, 0x3F, 0xCA, 0x02, 0x0F }, //04
            { 0xE4, 0xF7, 0x05, 0x58, 0xB3, 0xB8, 0x06, 0x45, 0xD8, 0x90, 0x00, 0xAB, 0xBC, 0x8C, 0x0A, 0xD3 }, //05
            { 0x15, 0x5E, 0x57, 0x46, 0x8D, 0xA7, 0x84, 0x9D, 0x70, 0x6C, 0x50, 0x48, 0xED, 0xFD, 0xDA, 0xB9 }, //06
            { 0xA4, 0xD4, 0xCC, 0x5C, 0x65, 0x5D, 0x92, 0xB6, 0xF8, 0x72, 0x64, 0xF6, 0x68, 0x86, 0x16, 0x98 }, //07
            { 0xDB, 0x9A, 0xFE, 0xC0, 0xCD, 0x78, 0xF4, 0x5A, 0x56, 0xFC, 0x4B, 0x3E, 0xD2, 0xC6, 0x20, 0x79 }, //08
            { 0xB7, 0x6F, 0x0E, 0x62, 0x18, 0xAA, 0x1B, 0xBE, 0xF1, 0x47, 0x71, 0x1A, 0x29, 0x1D, 0x89, 0xC5 }, //09
            { 0xF9, 0xE2, 0xE8, 0x37, 0x75, 0x1C, 0x6E, 0xDF, 0xAC, 0x96, 0x22, 0x74, 0xAD, 0xE7, 0x85, 0x35 }, //0A
            { 0xF2, 0x97, 0xCE, 0xCF, 0xB4, 0xF0, 0x73, 0xE6, 0x91, 0x3A, 0x41, 0x11, 0x67, 0x4F, 0xEA, 0xDC }, //0B
            { 0x69, 0xE1, 0x63, 0x14, 0x21, 0x55, 0x7D, 0x0C, 0x2B, 0x17, 0x7E, 0x04, 0x77, 0xBA, 0x26, 0xD6 }, //0C
            { 0xEB, 0xC8, 0x3C, 0xBB, 0x53, 0x83, 0x61, 0x99, 0xE0, 0xA0, 0x4D, 0x3B, 0x2A, 0xAE, 0xB0, 0xF5 }, //0D
            { 0xE5, 0x2D, 0x9F, 0x7A, 0xC9, 0x93, 0xEF, 0x9C, 0x51, 0x60, 0xA9, 0x7F, 0xB5, 0x19, 0x0D, 0x4A }, //0E
            { 0x12, 0xB1, 0x59, 0x10, 0x80, 0x27, 0x5F, 0xEC, 0xDD, 0x1F, 0x33, 0xA8, 0x07, 0x88, 0x31, 0xC7 }, //0F
        };

        //Shifting
        private static readonly byte[] horizontalShift = { 1, 1, 2, 3 };
        private static readonly byte[] verticalShift = { 1, 1, 2, 3 };

        //Fibonacci Polynomials
        private Polynomial[] fibonacciPolynomials;
        private Polynomial[] inverseFibonacciPolynomials;

        //Rcons Matrix
        private static readonly byte[,] rcons =
        {
            {1, 0, 0, 0 },
            {2, 0, 0, 0 },
            {3, 0, 0, 0 },
            {8, 0, 0, 0 },
            {21, 0, 0, 0 },
            {34, 0, 0, 0 },
            {81, 0, 0, 0 },
            {128, 0, 0, 0 },
            {74, 0, 0, 0 },
            {20, 0, 0, 0 },
            {98, 0, 0, 0 },
            {194, 0, 0, 0 },
            {189, 0, 0, 0 },
            {97, 0, 0, 0 },
        };

        private byte bytesPerBlock;

        public byte bytesForKey;
        public uint blockCount;
        public uint processedBlock;
        public bool working;
        public bool stopped = false;

        private enum SourceType
        {
            image,
            text
        };

        private enum Method
        {
            encrypt,
            decrypt
        }

        public Faes()
        {

            //keySize control
            if (Faes.keySize % 8 != 0) throw new Exception("Faes.keySize Error");
            this.bytesForKey = Convert.ToByte(Faes.keySize >> 3);

            //blockSize control
            if (Faes.blockSize % 8 != 0) throw new Exception("Faes.blockSize Error");
            this.bytesPerBlock = Convert.ToByte(Faes.blockSize >> 3);

            //rowSize and columnSize control
            if (Faes.rowSize * Faes.columnSize != this.bytesPerBlock) throw new Exception("Faes.rowSize*Faes.columnSize must be equal this.bytesPerBlock!");

            //sbox tables control
            {
                int row = sBoxTables.GetLength(0),
                    col = sBoxTables.GetLength(1);
                if (row != col || row != 16) throw new Exception("sBoxTables must be a 16x16 square matrix!");
                if (inverseSBoxTables.GetLength(0) != row || inverseSBoxTables.GetLength(1) != col) throw new Exception("sBoxInverseTables must be a 16x16 square matrix!");

                ushort correct = 0;
                for (byte i = 0, dec, j; i < this.bytesPerBlock; i++)
                {
                    for (j = 0; j < this.bytesPerBlock; j++)
                    {
                        dec = sBoxTables[i, j];
                        if (
                            (i.ToString("x") + j.ToString("x")).ToUpper() ==
                            inverseSBoxTables[dec >> 4, dec & 15].ToString().ToUpper()) //dec % 16 -> dec & 15 | https://stackoverflow.com/questions/11040646/faster-modulus-in-c-c#answer-11040718
                            ++correct;
                    }
                }
                Console.WriteLine("Sbox-Inverse Sbox Control: " + (correct == 256 ? "Correct" : "Incorrect (" + (256 - correct) + " fail)"));
            }

            //Generate Fibonacci Polynomials
            {
                string[] fibonacci = {
                    /* 1*/"1", //f(x)= 1
                    /* 2*/"10", //f(x)= x
                    /* 3*/"101", //f(x)= x^2 + 1
                    /* 4*/"1000", //f(x)= x^3
                    /* 5*/"110", //f(x)= x^2 + x
                    /* 6*/"100", //f(x)= x^2
                    /* 7*/"1110", //f(x)= x^3 + x^2 + x
                    /* 8*/"1011", //f(x)= x^3 + x + 1
                    /* 9*/"1011", //f(x)= x^3 + x + 1
                    /*10*/"1110", //f(x)= x^3 + x^2 + x
                    /*11*/"100", //f(x)= x^2
                    /*12*/"110", //f(x)= x^2 + x
                    /*13*/"1000", //f(x)= x^3
                    /*14*/"101", //f(x)= x^2 + 1
                    /*15*/"10", //f(x)= x
                    /*16*/"1", //f(x)= 1
                };
                if (fibonacci.Length != this.bytesPerBlock) throw new Exception("Length of fibonacci must be equal this.bytesPerBlock!");
                fibonacciPolynomials = new Polynomial[this.bytesPerBlock];
                char[] chars;
                for (byte i = 0; i < this.bytesPerBlock; i++)
                {
                    chars = fibonacci[i].ToCharArray();
                    Array.Reverse(chars);
                    //fibonacciPolynomials[i] = new Polynomial(string.Join(" ", chars));
                    fibonacciPolynomials[i] = Polynomial.WithBitArr(chars, (byte)chars.Length);
                }
            }

            //Generate Inverse Fibonacci Polynomials
            {
                string[] inverseFibonacci = {
                    /* 1*/"1", //f(x)= 1
                    /* 2*/"1001", //f(x)= x^3 + 1
                    /* 3*/"1011", //f(x)= x^3 + x + 1
                    /* 4*/"1111", //f(x)= x^3 + x^2 + x + 1
                    /* 5*/"111", //f(x)= x^2 + x + 1
                    /* 6*/"1101", //f(x)= x^3 + x^2 + 1
                    /* 7*/"11", //f(x)= x + 1
                    /* 8*/"101", //f(x)= x^2 + 1
                    /* 9*/"101", //f(x)= x^2 + 1
                    /*10*/"11", //f(x)= x + 1
                    /*11*/"1101", //f(x)= x^3 + x^2 + 1
                    /*12*/"111", //f(x)= x^2 + x + 1
                    /*13*/"1111", //f(x)= x^3 + x^2 + x + 1
                    /*14*/"1011", //f(x)= x^3 + x + 1
                    /*15*/"1001", //f(x)= x^3 + 1
                    /*16*/"1", //f(x)= 1
                };
                if (inverseFibonacci.Length != this.bytesPerBlock) throw new Exception("Length of inverse fibonacci must be equal this.bytesPerBlock!");
                inverseFibonacciPolynomials = new Polynomial[this.bytesPerBlock];
                char[] chars;
                for (byte i = 0; i < this.bytesPerBlock; i++)
                {
                    chars = inverseFibonacci[i].ToCharArray();
                    Array.Reverse(chars);
                    //inverseFibonacciPolynomials[i] = new Polynomial(string.Join(" ", chars));
                    inverseFibonacciPolynomials[i] = Polynomial.WithBitArr(chars, (byte)chars.Length);
                }
            }

            // Generate Polynomial Rcons
            {
                //byte[,] rcons = {
                //    { 1, 2, 15, 16 },
                //    {3, 4, 13, 14 },
                //    {5, 6, 11, 12 },
                //    {7, 8, 9, 10 },
                //    {9, 10, 7, 8 },
                //    {11, 12, 5, 6 },
                //    {13, 14, 3, 4 },
                //    {15, 16, 1, 2 },
                //    {16, 15, 2, 1 },
                //    {2, 1, 16, 15 }
                //};
                //byte[,] rcons = {
                //    { 1, 0, 0, 0},
                //    { 2, 0, 0, 0},
                //    { 3, 0, 0, 0},
                //    { 4, 0, 0, 0},
                //    { 5, 0, 0, 0},
                //    { 6, 0, 0, 0},
                //    { 7, 0, 0, 0},
                //    { 8, 0, 0, 0},
                //    { 9, 0, 0, 0},
                //    { 10, 0, 0, 0},
                //    { 11, 0, 0, 0},
                //    { 12, 0, 0, 0},
                //    { 13, 0, 0, 0},
                //    { 14, 0, 0, 0},
                //};
                if (Faes.rcons.GetLength(0) < Faes.round) throw new Exception("Row size of rcons matrix must be equal Faes.round!");
                if (Faes.rcons.GetLength(1) != Faes.rowSize) throw new Exception("Column size of rcons matrix must be equal Faes.rowSize!");

                //Polynomial p;
                //string hex;
                //this.rcons = new byte[Faes.round, Faes.rowSize];
                //for (byte i = 0, j, dec; i < Faes.round; i++)
                //{
                //    for (j = 0; j < Faes.rowSize; j++)
                //    {
                //        p = this.fibonacciPolynomials[rcons[i, j] - 1];
                //        dec = Convert.ToByte(p.evaluate());
                //        hex = dec.ToString("x");
                //        this.rcons[i, j] = Convert.ToByte(hex, 16);
                //        //Console.Write(this.rcons[i, j] + "[" + hex + "]  ");
                //    }
                //    //Console.WriteLine();
                //}
                //Console.WriteLine("yey");
            }
        }

        public String encryptText(String unicodePlainString, String utf8KeyString)
        {
            byte[] key = Encoding.Default.GetBytes(utf8KeyString);
            if (key.Length != this.bytesForKey) throw new Exception("Bytes of utf8KeyString must be " + this.bytesForKey + ". But it was " + key.Length.ToString() + "!");

            byte[] bytes = Encoding.Default.GetBytes(unicodePlainString);

            this.encrypt(ref bytes, key, SourceType.text);

            Console.WriteLine("[{0}]", string.Join(", ", bytes));
            return Encoding.Default.GetString(bytes);
            //string res = "";
            //string hex;
            //foreach(byte b in bytes){
            //    hex = b.ToString("X");
            //    res += (hex.Length == 1 ? "0" : "") + hex;
            //}
            //return res;
        }
        public String decryptText(string encryptedString, String utf8KeyString)
        {
            byte[] key = Encoding.Default.GetBytes(utf8KeyString);
            if (key.Length != this.bytesForKey) throw new Exception("Bytes of utf8KeyString must be " + this.bytesForKey + ". But it was " + key.Length.ToString() + "!");

            byte[] bytes = Encoding.Default.GetBytes(encryptedString);
            Console.WriteLine("[{0}]", string.Join(", ", bytes));
            if (bytes.Length % this.bytesPerBlock != 0) throw new Exception("Bytes of base64String must be a multiple of " + bytesPerBlock + ". But it's length was  " + (bytes.Length % bytesPerBlock).ToString() + "!");

            this.decrypt(ref bytes, key, SourceType.text);

            return Encoding.Default.GetString(bytes);
        }

        public Bitmap encryptImage(Bitmap bm_image, String utf8KeyString)
        {
            return this.encryptOrDecryptImage(bm_image, utf8KeyString, Method.encrypt);
        }
        public Bitmap decryptImage(Bitmap bm_encryptedImage, String utf8KeyString)
        {
            return this.encryptOrDecryptImage(bm_encryptedImage, utf8KeyString, Method.decrypt);
        }
        private Bitmap encryptOrDecryptImage(Bitmap bm_image, String utf8KeyString, Method method)
        {
            byte[] key = Encoding.Default.GetBytes(utf8KeyString);
            if (key.Length != this.bytesForKey) throw new Exception("Bytes of utf8KeyString must be " + this.bytesForKey + ". But it was " + key.Length.ToString() + "!");

            BitmapData bmd_image;
            try
            {
                bmd_image = bm_image.LockBits(
                    new Rectangle(0, 0, bm_image.Width, bm_image.Height),
                    ImageLockMode.ReadWrite,
                    bm_image.PixelFormat
                );
                Console.WriteLine(bm_image.PixelFormat + " - " + method.ToString());
            }
            catch (ArgumentException ae) { throw new Exception("The incorrect PixelFormat is passed in for a bitmap.", ae); }
            catch (Exception e) { throw new Exception("Image#LockBits operation is failed.", e); }

            //if (bmd_image.Stride != (Convert.ToInt32(Image.GetPixelFormatSize(image.PixelFormat)/8) * image.Width)) throw new Exception("aboww");

            IntPtr ptr_fistPixel = bmd_image.Scan0;
            byte pixelByte = Convert.ToByte(Image.GetPixelFormatSize(bm_image.PixelFormat) / 8);
            int length = bm_image.Width * bm_image.Height * pixelByte;
            byte[] bytes = new byte[length];

            try
            {
                IntPtr ptr_temp = ptr_fistPixel;
                for (int i = 0, lineWidth = bmd_image.Width * pixelByte; i < bmd_image.Height; ++i)
                {
                    Marshal.Copy(ptr_temp, bytes, i * lineWidth, lineWidth);
                    ptr_temp += bmd_image.Stride;
                }


                //Marshal.Copy(
                //    ptr_fistPixel, //source
                //    bytes, //destination
                //    0, //start index
                //    length //length
                //);
            }
            catch (ArgumentNullException ane) { throw new Exception("source, destination, startIndex, or length is null.", ane); }

            if (method == Method.encrypt) this.encrypt(ref bytes, key, SourceType.image);
            else this.decrypt(ref bytes, key, SourceType.image); 

            try
            {

                IntPtr ptr_temp = ptr_fistPixel;
                for (int i = 0, lineWidth = bmd_image.Width * pixelByte; i < bmd_image.Height; ++i)
                {
                    Marshal.Copy(bytes, i * lineWidth, ptr_temp, lineWidth);
                    ptr_temp += bmd_image.Stride;
                }

                //Marshal.Copy(
                //    bytes, //Source
                //    0, //Start index
                //    ptr_fistPixel, //Destination
                //    length //Length
                //);
            }
            catch (ArgumentOutOfRangeException ae) { throw new Exception("startIndex and length are not valid.", ae); }
            catch (ArgumentNullException ane) { throw new Exception("source, startIndex, destination, or length is null.", ane); }

            try
            {
                bm_image.UnlockBits(bmd_image);
            }
            catch (Exception e) { throw new Exception("Image#UnlockBits operation is failed.", e); }

            return bm_image;
        }

        private void encrypt(ref byte[] bytes, byte[] key, SourceType sourceType = SourceType.text)
        {
            this.stopped = false;
            this.working = true;

            if (sourceType == SourceType.text)
            {
                int strLength = bytes.Length;
                if (strLength % this.bytesPerBlock != 0)
                {
                    byte missing = Convert.ToByte(this.bytesPerBlock - strLength % this.bytesPerBlock);
                    Array.Resize(ref bytes, strLength + missing);
                    //for (byte t = 0; t < missing; t++) bytes[strLength + t] = 0; //by default values are zero
                }
            }

            byte[,,] roundKeys = this.generateRoundKeys(key, Faes.sBoxTables);
            uint blockCount = Convert.ToUInt32(bytes.Length / this.bytesPerBlock);
            this.blockCount = blockCount;
            byte[,] blockMtx = new byte[Faes.rowSize, Faes.columnSize];
            byte i, j;
            this.processedBlock = 0;

            for (
                uint blockIndex = 0; //Initialize
                blockIndex < blockCount && !this.stopped;  //Condition
                                                           //Steps:
                blockIndex++,
                this.processedBlock++,
                roundKeys = (
                    sourceType == SourceType.image ?
                    this.generateRoundKeys(roundKeys, Convert.ToByte(Faes.round - 1), ref key, Faes.sBoxTables) :
                    roundKeys
                )
            )
            {

                //Set block bytes from bytes array to blockMtx
                for (i = 0; i < Faes.rowSize; i++)
                    for (j = 0; j < Faes.columnSize; j++)
                        //blockMtx[i, j] = bytes[blockIndex * this.bytesPerBlock + i * Faes.columnSize + j];
                        blockMtx[i, j] = bytes[(blockIndex << 4) + (i << 2) + j]; //for performance

                this.encryptBlock(ref blockMtx, ref key, ref roundKeys);

                //Set encrypted bytes from blockMtx to bytes array
                for (i = 0; i < Faes.rowSize; i++)
                    for (j = 0; j < Faes.columnSize; j++)
                        //bytes[blockIndex * bytesPerBlock + i * Faes.columnSize + j] = blockMtx[i, j];
                        bytes[(blockIndex << 4) + (i << 2) + j] = blockMtx[i, j]; //for performance
            }

            this.working = false;
        }
        private void decrypt(ref byte[] bytes, byte[] key, SourceType sourceType = SourceType.text)
        {
            this.stopped = false;
            this.working = true;

            byte[,,] roundKeys = this.generateRoundKeys(key, Faes.sBoxTables);
            uint blockCount = Convert.ToUInt32(bytes.Length / this.bytesPerBlock);
            this.blockCount = blockCount;
            byte[,] blockMtx = new byte[Faes.rowSize, Faes.columnSize];

            byte i, j;
            this.processedBlock = 0;
            for (
                uint blockIndex = 0; //Initialize
                blockIndex < blockCount && !this.stopped; //Conditions
                                                          //Steps:
                blockIndex++,
                this.processedBlock++,
                roundKeys = (
                    sourceType == SourceType.image ?
                        this.generateRoundKeys(roundKeys, Convert.ToByte(Faes.round - 1), ref key, Faes.sBoxTables) :
                        roundKeys
                    )
            )
            {

                //Get bytes of block from str
                for (i = 0; i < Faes.rowSize; i++)
                    for (j = 0; j < Faes.columnSize; j++)
                        //blockMtx[i, j] = bytes[blockIndex * this.bytesPerBlock + i * Faes.columnSize + j];
                        blockMtx[i, j] = bytes[(blockIndex << 4) + (i << 2) + j]; //for performance

                this.decryptBlock(ref blockMtx, ref key, ref roundKeys);

                //Set encrypted bytes to str
                for (i = 0; i < Faes.rowSize; i++)
                    for (j = 0; j < Faes.columnSize; j++)
                        //bytes[blockIndex * bytesPerBlock + i * Faes.columnSize + j] = blockMtx[i, j];
                        bytes[(blockIndex << 4) + (i << 2) + j] = blockMtx[i, j]; //for performance
            }

            if (sourceType == SourceType.text)
            { //Remove byte(0) from right
                byte t = 0;
                ulong ll = Convert.ToUInt64(bytes.Length - 1);
                for (i = 0; i < this.bytesPerBlock; i++)
                {
                    if (bytes[ll - i] == 0) t++;
                    else break;
                }
                if (t != 0)
                {
                    Array.Resize(ref bytes, bytes.Length - t);
                }
            }

            this.working = false;

        }

        private void encryptBlock(ref byte[,] blockMtx, ref byte[] key, ref byte[,,] roundKeys)
        {
            this.sumOfMatrices(ref blockMtx, ref key);

            for (byte roundIndex = 0; roundIndex < Faes.round - 1; roundIndex++)
            {
                this.crossTransformation(ref blockMtx, ref this.fibonacciPolynomials);
                this.sbox(ref blockMtx, Faes.sBoxTables);

                this.mixColumnsAndRows(ref blockMtx, Method.encrypt);

                this.productOfMatrices(ref blockMtx, roundIndex, Method.encrypt);

                this.sumOfMatrices(ref blockMtx, ref roundKeys, roundIndex);
            }

            this.productOfMatrices(ref blockMtx, Convert.ToByte(Faes.round - 1), Method.encrypt);

            this.sumOfMatrices(ref blockMtx, ref roundKeys, Convert.ToByte(Faes.round - 1));
        }
        private void decryptBlock(ref byte[,] blockMtx, ref byte[] key, ref byte[,,] roundKeys)
        {
            this.sumOfMatrices(ref blockMtx, ref roundKeys, Convert.ToByte(Faes.round - 1));

            this.productOfMatrices(ref blockMtx, Convert.ToByte(Faes.round - 1), Method.decrypt);

            for (byte roundIndex = 0; roundIndex < Faes.round - 1; roundIndex++)
            {
                this.sumOfMatrices(ref blockMtx, ref roundKeys, Convert.ToByte(Faes.round - 1 - (roundIndex + 1)));

                this.productOfMatrices(ref blockMtx, Convert.ToByte(Faes.round - (2 + roundIndex)), Method.decrypt);

                this.mixColumnsAndRows(ref blockMtx, Method.decrypt);

                this.sbox(ref blockMtx, Faes.inverseSBoxTables);
                this.crossTransformation(ref blockMtx, ref this.inverseFibonacciPolynomials);
            }

            this.sumOfMatrices(ref blockMtx, ref key);
        }

        private byte[,,] generateRoundKeys(byte[] key, byte[,] sBoxTables)
        {
            byte[,,] roundKeys = new byte[Faes.round, Faes.rowSize, Faes.columnSize];

            byte[] column1 = new byte[Faes.rowSize];
            byte[] column2 = new byte[Faes.rowSize];
            byte[] resColumn = new byte[Faes.rowSize];
            for (byte r = 0, i, j, temp; r < Faes.round; r++)
            {
                for (j = 0; j < Faes.columnSize; j++)
                {
                    if (j == 0)
                    { //First Column of Round Key

                        for (i = 0; i < Faes.rowSize; i++)
                        {
                            //Bir önceki matrisin ilk sütunu
                            column1[i] = r == 0 ?
                                key[i * Faes.columnSize] : //Eğer ilk round anahtarı ise, orjinal anahtarın ilk sütunu
                                roundKeys[r - 1, i, 0]; //Değilse, bir önceki round anahtarın ilk sütunu

                            //Bir önceki matrisin son sütunu
                            column2[i] = r == 0 ?
                                    key[i * Faes.columnSize + (Faes.columnSize - 1)] : //Eğer ilk round anahtarı ise, orjinal anahtarın son sütunu
                                    roundKeys[r - 1, i, Faes.columnSize - 1]; //Değilse, bir önceki round anahtarın son sütunu
                        }

                        //column1'i 1 bayt aşağı kaydır
                        temp = column1[Faes.rowSize - 1];
                        for (i = Convert.ToByte(Faes.rowSize - 2); i != 255; i--) column1[i + 1] = column1[i];
                        column1[0] = temp;

                        //column2'yi 1 bayt yukarı kaydır
                        temp = column2[0];
                        for (i = 1; i < Faes.rowSize; i++) column2[i - 1] = column2[i];
                        column2[Faes.rowSize - 1] = temp;

                        //column2'yi sbox'a sok
                        for (i = 0; i < Faes.rowSize; i++) {
                            temp = column2[i];
                            column2[i] = sBoxTables[temp >> 4, temp & 15];
                        }

                        //resColumn[i] = column1[i] XOR column2[i] XOR rcons[r,i]
                        for (i = 0; i < Faes.rowSize; i++)
                            resColumn[i] = Convert.ToByte(column1[i] ^ column2[i] ^ Faes.rcons[r, i]);
                    }
                    else
                    {
                        for (i = 0; i < Faes.rowSize; i++)
                        {
                            resColumn[i] = Convert.ToByte(
                                (  //Bir önceki matrisin aynı sütununu al
                                    r == 0 ?
                                        key[i * Faes.columnSize + j] :
                                        roundKeys[r - 1, i, j]
                                ) ^
                                roundKeys[r, i, j - 1] //Bir önceki sütun
                            );
                        }
                    }

                    for (i = 0; i < Faes.rowSize; i++)
                        roundKeys[r, i, j] = resColumn[i];
                }
            }


            if (false)
            { //For logging
                //Console.WriteLine("ROUND KEYS:");
                //string dec;
                //for (byte r = 0, row, col; r < Faes.round; r++)
                //{
                //    Console.WriteLine("=================ROUND KEY" + (r).ToString() + "=================");
                //    for (row = 0; row < Faes.rowSize; row++)
                //    {
                //        for (col = 0; col < Faes.columnSize; col++)
                //        {
                //            dec = roundKeys[r, row, col].ToString();
                //            Console.Write(new string(' ', 3 - dec.Length) + dec + " ");
                //        }
                //        Console.WriteLine();
                //    }
                //}

                Console.WriteLine($"{this.processedBlock+1}. BLOCK KEYS:");
                string line = "";
                string hex;

                //First Row
                for (byte i = 0, j, k, t = (byte)(Faes.round / 2); i < Faes.rowSize; i++)
                {
                    line += "\t|";
                    for(j=0; j<Faes.columnSize; j++)
                    {
                        //Key-Orjinal Anahtar Byte
                        hex = key[i * Faes.columnSize + j].ToString("X");
                        if (hex.Length == 1) hex = "0" + hex;
                        line += " " + new string(' ', 2 - hex.Length) + hex;
                    }
                    line += " | ";

                    //Round 0-[round/2]
                    for (k = 0; k < t; k++)
                    {
                        line += " |";
                        for(j=0; j<Faes.columnSize; j++)
                        {
                            //Tur Anahtar Byte
                            hex = roundKeys[k, i, j].ToString("X");
                            if (hex.Length == 1) hex = "0" + hex;
                            line += " " + new string(' ', 2 - hex.Length) + hex;
                        }
                        line += " | ";
                    }
                    line += "\n";
                }
                Console.WriteLine(line);

                //Second Row
                line = "";
                bool addBlank = (Convert.ToByte(Faes.round / 2)) * 2 == Faes.round;
                for (byte i = 0, j, k, t = (byte)((Faes.round / 2)); i < Faes.rowSize; i++)
                {
                    line += "\t";
                    if (addBlank)
                        line += new string(' ', 6 + Faes.columnSize*2 + (Faes.columnSize-1)*1);
                    line += "|";

                    for(k=t; k<Faes.round; k++)
                    {
                        if(k!=t)
                            line += " |";
                        for (j=0; j<Faes.columnSize; j++)
                        {
                            //Tur Anahtar Byte
                            hex = roundKeys[k, i, j].ToString("X");
                            if (hex.Length == 1) hex = "0" + hex;
                            line += " " + new string(' ', 2 - hex.Length) + hex;
                        }
                        line += " | ";
                    }
                    line += "\n";
                }
                Console.WriteLine(line);

                if(this.processedBlock==3000)
                    System.Environment.Exit(0);
            }

            return roundKeys;
        }
        private byte[,,] generateRoundKeys(byte[,,] prevRoundKeys, byte keyIndex, ref byte[] key, byte[,] sBoxTables)
        {
            //byte[] firstKey = new byte[this.bytesPerBlock];
            for (byte i = 0, j; i < Faes.rowSize; i++)
            {
                for (j = 0; j < Faes.columnSize; j++)
                {
                    //key[i * Faes.columnSize + j] = prevRoundKeys[keyIndex, i, j];
                    key[(i << 2) + j] = prevRoundKeys[keyIndex, i, j]; //for performance
                    //firstKey[(i << 2) + j] = prevRoundKeys[0, i, j];
                }
            }

            return this.generateRoundKeys(key, sBoxTables);
        }

        private void crossTransformation(ref byte[,] blockMtx, ref Polynomial[] fibonacciPolynomials)
        {
            byte dec, a, b, c;
            Polynomial poly, polyF, polyRes;
            bool direction; // true:left, false:right
            for (byte i = 0, j; i < Faes.rowSize; i++)
            {
                for (j = 0; j < Faes.columnSize; j++)
                {
                    dec = blockMtx[i, j];
                    a = (byte)(dec >> 4);
                    b = (byte)(dec & 15); // dec % 16 = dec & 15

                    direction = ((i + j) & 1) == 0; //  %2 = &1
                    if (direction) //Left
                    {
                        //poly
                        poly = Polynomial.WithDec(a);
                        //chars = Convert.ToString(a, 2).ToCharArray();
                        //Array.Reverse(chars);
                        ////poly = new Polynomial(string.Join(" ", chars));
                        //poly = Polynomial.WithBitArr(chars, (byte)chars.Length);

                        //polyF
                        polyF = fibonacciPolynomials[
                            Convert.ToByte(((i + 1) * (j + 1)) & 15) // % 16 -> & 15
                        ];
                    }
                    else //Right
                    {
                        //poly
                        poly = Polynomial.WithDec(b);
                        //chars = Convert.ToString(b, 2).ToCharArray();
                        //Array.Reverse(chars);
                        ////poly = new Polynomial(string.Join(" ", chars));
                        //poly = Polynomial.WithBitArr(chars, (byte)chars.Length);

                        //polyF
                        polyF = fibonacciPolynomials[
                            Convert.ToByte(((i + 1) * (j + 1)) & 15)
                        ];
                    }
                    //continue; //0.49ms 31.8KB

                    //polyRes
                    polyRes = (poly * polyF).reduction().mod2();
                    //continue; //0.54ms 29.2KB

                    c = Convert.ToByte(polyRes.evaluate());
                    //continue; //0.60ms 26.1KB -> 0.48ms 32.8KB -> 0.44ms 35.3KB

                    blockMtx[i, j] = direction ?
                        Convert.ToByte((c << 4) + b) :
                        Convert.ToByte((a << 4) + c);
                }
            }
        }

        private void sbox(ref byte[,] blockMtx, byte[,] sBoxTables)
        {
            for (byte i = 0, j, dec; i < Faes.rowSize; i++)
            {
                for (j = 0; j < Faes.columnSize; j++)
                {
                    dec = blockMtx[i, j];
                    blockMtx[i, j] = sBoxTables[dec >> 4, dec & 15];
                }
            }
        }

        private void mixColumnsAndRows(ref byte[,] blockMtx, Method method)
        {
            List<byte> row = new List<byte>(new byte[Faes.columnSize]);
            List<byte> column = new List<byte>(new byte[Faes.rowSize]);
            byte r, i, b, l;
            if (method == Method.decrypt)
            {
                for (r = 0, l = Convert.ToByte(Faes.horizontalShift.Length); r < l; r++)
                {
                    for (i = 0; i < Faes.columnSize; i++) row[i] = blockMtx[r, i];
                    for (i = 0; i < Faes.horizontalShift[r]; i++)
                    {
                        //Left shift
                        b = row[0];
                        row.RemoveAt(0);
                        row.Add(b);
                    }
                    for (i = 0; i < Faes.columnSize; i++) blockMtx[r, i] = row[i];
                }

                for (r = 0, l = Convert.ToByte(Faes.verticalShift.Length); r < l; r++)
                {
                    for (i = 0; i < Faes.rowSize; i++) column[i] = blockMtx[i, r];
                    for (i = 0; i < Faes.verticalShift[r]; i++)
                    {
                        //Up shift
                        b = column[0];
                        column.RemoveAt(0);
                        column.Add(b);
                    }
                    for (i = 0; i < Faes.rowSize; i++) blockMtx[i, r] = column[i];
                }
            }
            else
            {
                for (r = 0, l = Convert.ToByte(Faes.verticalShift.Length); r < l; r++)
                {
                    for (i = 0; i < Faes.rowSize; i++) column[i] = blockMtx[i, r];
                    for (i = 0; i < Faes.verticalShift[r]; i++)
                    {
                        //Down shift
                        b = column[Faes.rowSize - 1];
                        column.RemoveAt(Faes.rowSize - 1);
                        column.Insert(0, b);
                    }
                    for (i = 0; i < Faes.rowSize; i++) blockMtx[i, r] = column[i];
                }

                for (r = 0, l = Convert.ToByte(Faes.horizontalShift.Length); r < l; r++)
                {
                    for (i = 0; i < Faes.columnSize; i++) row[i] = blockMtx[r, i];
                    for (i = 0; i < Faes.horizontalShift[r]; i++)
                    {
                        //Right shift
                        b = row[Faes.columnSize - 1];
                        row.RemoveAt(Faes.columnSize - 1);
                        row.Insert(0, b);
                    }
                    for (i = 0; i < Faes.columnSize; i++) blockMtx[r, i] = row[i];
                }
            }
        }

        private void productOfMatrices(ref byte[,] blockMtx, byte roundIndex, Method method)
        {
            Polynomial[,] group = new Polynomial[2, 2];
            Polynomial[,] fibonacciMatrix;
            {
                int round = roundIndex + 1,
                    multipier = method == Method.decrypt ? 1 : -1;
                fibonacciMatrix = new Polynomial[2, 2]{
                        {this.fibonacciPolynomials[round + 1 * multipier] , this.fibonacciPolynomials[round] },
                        {this.fibonacciPolynomials[round] , this.fibonacciPolynomials[round - 1 * multipier] },
                };
            }
            Polynomial res;

            uint d;
            for (
                byte k = 0, l, i, j, m, dec; //Counters
                k < 2;
                k++
            )
            {
                for (l = 0; l < 4; l++)
                {
                    //grupları oluşturmak: 2x2 Polynomial matrix
                    for (i = 0; i < 2; i++)
                    {
                        group[i, 0] = Polynomial.WithDec(
                            Convert.ToByte(blockMtx[(k << 1) + i, l] >> 4)
                        );
                        group[i, 1] = Polynomial.WithDec(
                            Convert.ToByte(blockMtx[(k << 1) + i, l] & 15)
                        );
                    }

                    //Matrix Çarpımı = group*fibonacciMatrix
                    for (i = 0; i < 2; i++)
                    {
                        dec = 0;
                        for (j = 0; j < 2; j++)
                        {

                            res = new Polynomial();

                            for (m = 0; m < 2; m++)
                                res.summation(group[i, m] * fibonacciMatrix[m, j]);

                            d = res.reduction()
                                .mod2()
                                .evaluate();

                            dec += (byte)(j == 0 ? d << 4 : d);
                        }

                        blockMtx[(k << 1) + i, l] = dec;
                    }
                }
            }
            //0.91ms 17.3KB -> 0.62ms 25.4KB
        }

        private void sumOfMatrices(ref byte[,] blockMtx, ref byte[] key)
        {
            for (byte i = 0, j; i < Faes.rowSize; i++)
                for (j = 0; j < Faes.columnSize; j++)
                    blockMtx[i, j] ^= key[i * Faes.columnSize + j]; //xor
        }
        private void sumOfMatrices(ref byte[,] blockMtx, ref byte[,,] roundKeys, byte roundIndex)
        {
            for (byte i = 0, j; i < Faes.rowSize; i++)
                for (j = 0; j < Faes.columnSize; j++)
                    blockMtx[i, j] ^= roundKeys[roundIndex, i, j]; //xor
        }

        public void printBytes(byte[] bytes, string start = "Bytes: ")
        {
            String bytesString = "";
            for (int i = 0, len = bytes.Length; i < len; i++)
                bytesString += bytes[i].ToString() + (i + 1 != len ? ", " : "");
            Console.WriteLine(start + bytesString);
        }


        class Polynomial
        {
            private static readonly byte len = 7;
            private byte[] datas;
            private byte degree = 0;

            public Polynomial()
            {
                this.datas = new byte[Polynomial.len];
            }
            public Polynomial(byte[] datas, byte degree)
            {
                this.datas = datas;
                this.degree = degree;
            }
            public static Polynomial WithBitArr(char[] zerosOrOnes, byte len)
            {
                byte[] datas = new byte[Polynomial.len];
                for (byte i = 0; i < len; i++)
                    datas[i] = (byte)(zerosOrOnes[i] == '0' ? 0 : 1);
                return new Polynomial(datas, (byte)(len - 1));
            }
            public static Polynomial WithDec(int dec)
            {
                if (dec < 1) return new Polynomial();
                byte[] datas = new byte[Polynomial.len];
                byte degree = 0;
                while (dec != 0)
                {
                    datas[degree++] = (byte)(dec & 1); // % 2
                    dec = dec >> 1;
                }

                return new Polynomial(datas, (byte)(degree - 1));
            }

            private byte findDegree()
            {
                for (byte i = Convert.ToByte(Polynomial.len - 1); i != 255; i--)
                    if (this.datas[i] != 0)
                        return i;
                return 0;
            }
            private byte findDegree(byte i)
            {
                for (; i != 255; i--)
                    if (this.datas[i] != 0)
                        return i;
                return 0;
            }

            public uint evaluate()
            {
                uint res = 0;
                ushort coeff;
                for (byte i = 0, l = (byte)(this.degree + 1); i < l; i++)
                {
                    coeff = this.datas[i];
                    res += Convert.ToUInt32(coeff * (2 << i >> 1)); // equals = coeff*Math.Pow(2, i)
                }
                return res;
            }

            public Polynomial reduction()
            {
                ushort coeff1, coeff2;
                sbyte degreeDiff;
                //Console.WriteLine("Before| " + this);
                byte l = (byte)(Faes.irreduciblePoly.degree + 1);
                while ((degreeDiff = Convert.ToSByte(this.degree - Faes.irreduciblePolyDegree)) >= 0)
                {
                    coeff1 = this.datas[this.degree];
                    this.datas[this.degree] = 0;
                    for (byte i = 0; i < l; i++)
                    {
                        coeff2 = Faes.irreduciblePoly.datas[i];
                        //if (coeff2==0) continue; // irreduciblePoly = 1 + x -> no necessary
                        this.datas[i + degreeDiff] += (byte)(coeff1 * coeff2);
                    }
                    this.degree = this.findDegree((byte)(this.degree - 1));
                }
                //Console.WriteLine("After| " + this);

                return this;
            }

            public static Polynomial operator *(Polynomial a, Polynomial b)
            {
                Polynomial res = new Polynomial();
                byte l1 = (byte)(a.degree + 1),
                    l2 = (byte)(b.degree + 1);
                for (byte i = 0, j; i < l1; i++)
                    for (j = 0; j < l2; j++)
                        res.datas[i + j] += (byte)(a.datas[i] * b.datas[j]);
                res.degree = (byte)(l1 + l2 - 2);
                //Console.WriteLine("(" + a + ")*(" + b + ") = " + res);
                return res;
            }
            public Polynomial multiplication(Polynomial a)
            {
                return this * a;
            }

            public static Polynomial operator +(Polynomial a, Polynomial b)
            {
                Polynomial res = new Polynomial();
                byte l = (byte)(Math.Max(a.degree, b.degree) + 1);
                for (byte i = 0; i < l; i++)
                    res.datas[i] = Convert.ToByte(a.datas[i] + b.datas[i]);
                res.degree = (byte)(l - 1);
                return res;
            }
            public Polynomial summation(Polynomial add)
            {
                byte l = (byte)(Math.Max(this.degree, add.degree) + 1);
                for (byte i = 0; i < l; i++)
                    this.datas[i] += add.datas[i];
                this.degree = (byte)(l - 1);
                return this;
            }

            public static Polynomial operator %(Polynomial a, byte mod)
            {
                for (byte i = 0, l = (byte)(a.degree + 1); i < l; i++)
                    a.datas[i] = Convert.ToByte(a.datas[i] % mod);
                a.degree = a.findDegree();
                return a;
            }
            public Polynomial mod2()
            {
                for (byte i = 0, l = (byte)(this.degree + 1); i < l; i++)
                    this.datas[i] &= 1;
                this.degree = this.findDegree();
                return this;
            }

            public override string ToString()
            {
                string text = "";
                ushort coeff;
                for (byte degree = 0; degree <= this.degree; degree++)
                {
                    coeff = this.datas[degree];
                    if (coeff == 0) continue;
                    text += ( //Katsayı
                        (coeff != 1 || degree == 0) ?
                            coeff.ToString() :
                            ""
                    ) +
                    (
                        degree > 0 ?
                            "x" + (degree != 1 ? "^" + degree : "") :
                            ""
                    ) + " + ";
                }
                if (text == "") return "empty poly";
                return "[" + this.degree.ToString() + "] " + text.Substring(0, text.Length - 3);
            }
        }

    }
}
