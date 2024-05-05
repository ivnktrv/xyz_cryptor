using xyz_keygen;

namespace xyz_cryptor;

public class XYZcryptor
{
    private const byte B_255 = 0b11111111;
    private const int XYZ_BIN = 0b11110000111100101111010;

    public void encrypt(string openFilePath, string saveFileName)
    {
        List<byte>? bytes = new List<byte>();

        using (FileStream stream = new FileStream(openFilePath, FileMode.Open, FileAccess.Read))
        {
            byte[] getBytes = File.ReadAllBytes(openFilePath);
            bytes = new List<byte>(getBytes);
        }

        XYZkeygen kg = new XYZkeygen();

        int key = 0;
        kg.keygen(ref key);

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

        for (int i = 0; i < chars_bin.Length; i++)
        {
            int h = chars_bin[i] ^ key;
            chars_bin[i] = (byte)h;

        }

        Console.WriteLine($"[+] Сделано. Ключ для {saveFileName}: {key}");

        using (BinaryWriter binWriter = new BinaryWriter(File.Open($"{saveFileName}", FileMode.Create, FileAccess.Write)))
        {
            for (int i = 0; i < chars_bin.Length; i++)
            {
                binWriter.Write(chars_bin[i]);
            }
        }
    }

    public void decrypt(string openFile, int key, string? outFile = null, bool print = false)
    {
        List<int>? chars_bin = new List<int>();

        try
        {
            using (BinaryReader binRead = new BinaryReader(File.Open($"{openFile}", FileMode.Open, FileAccess.Read)))
            {
                while (binRead.BaseStream.Position != binRead.BaseStream.Length)
                {
                    int n = binRead.ReadByte();
                    chars_bin.Add(n);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("[-] Файл не найден");
        }

        byte[]? chars = new byte[chars_bin.Count];

        for (int i = 0; i < chars_bin.Count; i++)
        {
            int h = chars_bin[i] ^ key;
            chars_bin[i] = (byte)h;
        }

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
            string s = System.Text.Encoding.UTF8.GetString(chars);
            Console.Write(s);
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
    }
}
