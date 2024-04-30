namespace xyz_keygen;

public class XYZkeygen
{
    private const int  KEY_LENGTH  = 8;
    private const int  XYZ_BIN     = 0b11110000111100101111010;

    public void keygen(ref int outKey)
    {
        int sum = 0;
        int[] k = new int[KEY_LENGTH];
        
        for (int i = 0; i < KEY_LENGTH; i++)
        {
            Random r = new Random();
            k[i] = r.Next(9, 256) * 9 + r.Next(128,4196);
            sum += (k[i]*k[i]) ^ XYZ_BIN;
        }

        outKey = sum;
    }
}
