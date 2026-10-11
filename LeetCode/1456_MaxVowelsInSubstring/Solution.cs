namespace SeasionOne;

public class Solution
{
     public int MaxVowels(string s, int k)
    {
        int counter = 0;
        int max = 0;
        for (int i = 0; i < k; i++)
            if (IsVowel(s[i]))
                counter++;
        
        max = counter;

        for (int i = k; i < s.Length; i++)
        {
            if (IsVowel(s[i - k]))
                counter--;

            if (IsVowel(s[i]))
                counter++;

            max = Math.Max(max, counter);
            
            if(max == k)
                break;
        }
            return max;
    }
     
     public bool IsVowel(char c)
     {
         return c switch
         {
             'a' => true,
             'e' => true,
             'i' => true,
             'o' => true,
             'u' => true,
             _ => false
         };
     }
    
    
}