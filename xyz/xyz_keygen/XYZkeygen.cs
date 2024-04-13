// Made by ivnktrv
// My github - https://github.com/ivnktrv


namespace xyz_keygen;

public class XYZkeygen
{
    private const int     KEY_LENGTH  = 8;
    private const string  DICT        = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+[]{};?/<>|.,~";

    public void keygen(ref int outKey)
    {
        string key = "";
        int sum = 0;
        int[] chars_bin = new int[KEY_LENGTH];
        
        for (int i = 0; i < KEY_LENGTH; i++)
        {
            Random r = new Random();
            key += DICT[r.Next(DICT.Length)];
            chars_bin[i] = key[i];
        }

        for (int i = 0;i < chars_bin.Length ;i++)
        {
            Random r = new Random();
            sum += (r.Next(1, 10000) * chars_bin[i]) + r.Next(0, 10000);
        }

        outKey = sum;
    }
}
