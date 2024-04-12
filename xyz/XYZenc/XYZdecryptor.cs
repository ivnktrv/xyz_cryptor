

namespace XYZenc;

public class XYZdecryptor
{
    private const byte B_255 = 0b11111111;
    private const int XYZ_BIN = 0b11110000111100101111010;

    private void __decryptText(List<int> chars_bin, string? outFile = null, bool print = false)
    {
        char[]? chars;

        for (int i = 0; i < chars_bin.Count; i++)
        {
            int divXYZ = chars_bin[i] - XYZ_BIN;
            chars_bin[i] = divXYZ;
        }

        for (int i = 0; i < chars_bin.Count; i++)
        {
            int invertBytes = B_255 - chars_bin[i];
            chars_bin[i] = invertBytes;
        }

        chars = new char[chars_bin.Count];

        for (int i = 0; i < chars_bin.Count; i++)
        {
            char toCharASCII = (char)chars_bin[i];
            chars[i] = toCharASCII;
        }

        if (print == true)
        {
            for (int i = 0; i < chars.Length; i++)
            {
                Console.Write(chars[i]);
            }
        }

        if (outFile != null)
        {
            using (FileStream stream = new FileStream(outFile, FileMode.Create, FileAccess.Write))
            {
                for (int i = 0; i < chars.Length; i++)
                {
                    byte[] writeBuffer = System.Text.Encoding.UTF8.GetBytes($"{chars[i]}");
                    stream.Write(writeBuffer, 0, writeBuffer.Length);
                }
            }
        }

        chars = null;
        chars_bin = null;
    }

    private void __decryptFile(List<int> chars_bin, string? outFile = null, bool print = false)
    {
        byte[] chars = new byte[chars_bin.Count];

        for (int i = 0; i < chars_bin.Count; i++)
        {
            int divXYZ = chars_bin[i] - XYZ_BIN;
            chars_bin[i] = divXYZ;
        }

        for (int i = 0; i < chars_bin.Count; i++)
        {
            int invertBytes = B_255 - chars_bin[i];
            chars_bin[i] = invertBytes;
        }

        for (int i = 0; i < chars_bin.Count; i++)
        {
            byte toCharASCII = (byte)chars_bin[i];
            chars[i] = toCharASCII;
        }

        if (print == true)
        {
            for (int i = 0; i < chars.Length; i++)
            {
                Console.Write(chars[i]);
            }
        }

        if (outFile != null)
        {
            using (BinaryWriter binWriter = new BinaryWriter(File.Open($"{outFile}", FileMode.Create, FileAccess.Write)))
            {
                for (int i = 0; i < chars.Length; i++)
                {
                    binWriter.Write(chars[i]);
                }
            }
        }

        chars = null;
        chars_bin = null;
    }
}
