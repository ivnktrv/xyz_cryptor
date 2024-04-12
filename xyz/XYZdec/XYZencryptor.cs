namespace XYZdec;

public class XYZencryptor
{
    private const byte B_255 = 0b11111111;
    private const int XYZ_BIN = 0b11110000111100101111010;

    private void __encryptText(List<char> chars, string saveFileName)
    {
        int[]? chars_bin = new int[chars.Count];

        for (int i = 0; i < chars.Count; i++)
        {
            int charASCII_code = (short)chars[i];
            chars_bin[i] = charASCII_code;
        }

        for (int i = 0; i < chars_bin.Length; i++)
        {
            int invertBits = B_255 - chars_bin[i];
            chars_bin[i] = invertBits;
        }

        for (int i = 0; i < chars_bin.Length; i++)
        {
            int addXYZ = chars_bin[i] + XYZ_BIN;
            chars_bin[i] = addXYZ;
        }

        Console.WriteLine("[+] Сделано");

        using (BinaryWriter binWriter = new BinaryWriter(File.Open($"{saveFileName}.xyz", FileMode.Create, FileAccess.Write)))
        {
            for (int i = 0; i < chars_bin.Length; i++)
            {
                binWriter.Write(chars_bin[i]);
            }
        }

        chars_bin = null;
        chars = null;
    }

    private void __encryptFile(List<byte> bytes, string saveFileName)
    {
        byte[]? chars_bin = new byte[bytes.Count];

        for (int i = 0; i < bytes.Count; i++)
        {
            int charASCII_code = bytes[i];
            chars_bin[i] = (byte)charASCII_code;
        }

        for (int i = 0; i < chars_bin.Length; i++)
        {
            int invertBits = B_255 - chars_bin[i];
            chars_bin[i] = (byte)invertBits;
        }

        for (int i = 0; i < chars_bin.Length; i++)
        {
            int addXYZ = chars_bin[i] + XYZ_BIN;
            chars_bin[i] = (byte)addXYZ;
        }

        Console.WriteLine("[+] Сделано");

        using (BinaryWriter binWriter = new BinaryWriter(File.Open($"{saveFileName}.xyz", FileMode.Create, FileAccess.Write)))
        {
            for (int i = 0; i < chars_bin.Length; i++)
            {
                binWriter.Write(chars_bin[i]);
            }
        }

        chars_bin = null;
        bytes = null;
    }
}
