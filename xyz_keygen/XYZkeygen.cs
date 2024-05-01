namespace xyz_keygen;

public class XYZkeygen
{
    private const int  CYCLE  = 16;
    private const int  XYZ_BIN     = 0b11110000111100101111010;

    public void keygen(ref int outKey)
    {
        int sum = 0;
        int[] k = new int[CYCLE];
        
        for (int i = 0; i < CYCLE; i++)
        {
            Random r = new Random();
            k[i] = r.Next(r.Next(1,100), 256) * r.Next(1,10) ^ XYZ_BIN + r.Next(128,r.Next(1024, 4096)) ^ XYZ_BIN;
            sum += (k[i]*k[i]) ^ XYZ_BIN ^ r.Next(-1,1);
        }

        outKey = sum;
    }
}
