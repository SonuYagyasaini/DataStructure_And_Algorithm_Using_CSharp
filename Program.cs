using System;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        int[] nums = { 1, 1, 2 };
        Console.Write(RemoveDuplicates(nums));
    }

    //https://leetcode.com/problems/merge-sorted-array/?envType=study-plan-v2&envId=top-interview-150
    static void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int k = m;
        int i = m;
        int j = n - 1;
        while (j >= 0)
        {
            nums1[i] = nums2[j];
            i++;
            j--;
        }
        Array.Sort(nums1);
        foreach (int item in nums1)
        {
            Console.Write(item);
        }
    }

    //https://leetcode.com/problems/remove-element/?envType=study-plan-v2&envId=top-interview-150
    static int RemoveElement(int[] nums, int val)
    {
        int ans = 0;
        foreach (int dt in nums)
        {
            if (dt != val)
            {
                nums[ans] = dt;
                ans++;
            }
        }
        return ans;
    }

    //https://leetcode.com/problems/remove-duplicates-from-sorted-array/description/?envType=study-plan-v2&envId=top-interview-150
    static int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0)
            return 0;

        int ans = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[i - 1])
            {
                nums[ans] = nums[i];
                ans++;
            }
        }

        return ans;
    }

    //https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/description/?envType=study-plan-v2&envId=top-interview-150
    static int RemoveDuplicates1(int[] nums)
    {
        int numCount = 0;
        bool isPrevValTwice = false;
        for (int i = 1; i < nums.Length; i++)
        {
            bool isCurrentValTwice = nums[numCount] == nums[i];
            if (!isCurrentValTwice || !isPrevValTwice)
            {
                nums[++numCount] = nums[i];
                isPrevValTwice = isCurrentValTwice;
            }
        }
        return numCount + 1;
    }

    //https://leetcode.com/problems/majority-element/?envType=study-plan-v2&envId=top-interview-150
    static int MajorityElement(int[] nums)
    {
        int majEle = 0;
        var dictionary = new Dictionary<int, int>();
        foreach (var dt in nums)
        {
            if (!dictionary.ContainsKey(dt))
            {
                dictionary.Add(dt, 1);
            }
            else
            {
                dictionary[dt] += 1;
            }
        }
        majEle = dictionary.Values.Max();
        return dictionary.First(k => k.Value == majEle).Key;
    }

    //https://leetcode.com/problems/rotate-array/description/?envType=study-plan-v2&envId=top-interview-150
    static void Rotate(int[] nums, int k)
    {
        int kTimes = k % nums.Length;
        Array.Reverse(nums);  // 7 6 5 4 3 2 1
        Array.Reverse(nums, 0, kTimes); // 5 6 7 4 3 2 1
        Array.Reverse(nums, kTimes, nums.Length - kTimes);  // 5 6 7 1 2 3 4
    }

    //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/?envType=study-plan-v2&envId=top-interview-150
    static int MaxProfit(int[] prices)
    {
        int maxProfit = prices[0];  //assumption
        int maxNum = prices[0];     //assumption
        int sum = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] > maxProfit)
            {
                maxProfit = prices[i];
                continue;
            }
            if (prices[i] < maxProfit)
            {
                sum += maxProfit - maxNum;
                maxNum = prices[i];
                maxProfit = prices[i];
            }
        }
        sum += maxProfit - maxNum;
        return sum;
    }

    //https://leetcode.com/problems/jump-game/description/?envType=study-plan-v2&envId=top-interview-150
    static bool CanJump(int[] nums)
    {
        int endPoint = nums.Length - 1;
        int curr = 0;
        for (int i = 0; i <= curr; i++)
        {
            if (nums[i] + i > curr)
            {
                curr = nums[i] + i;
            }
            if (curr >= endPoint)
            {
                return true;
            }
        }
        return false;
    }

    //https://leetcode.com/problems/jump-game-ii/description/?envType=study-plan-v2&envId=top-interview-150
    static int Jump(int[] nums)
    {
        int arrLength = nums.Length;
        int lJump = 0;
        int jump = 0;
        int currPosition = 0;

        if (arrLength == 1) //because array has single pos so no need to jump.
        {
            return 0;
        }
        if (nums[0] == 0) //no need to jump if start postion range exist
        {
            return -1;
        }
        for (int i = 0; i < arrLength; i++)
        {
            lJump = Math.Max(lJump, i + nums[i]);
            if (lJump >= arrLength - 1) //when long jump will be >= to arrlength it'll be re...
            {
                return jump + 1;
            }
            if (i == currPosition)
            {
                currPosition = lJump;
                jump++;
            }
        }
        return -1;
    }

    //https://leetcode.com/problems/h-index/description/?envType=study-plan-v2&envId=top-interview-150
    public int HIndex(int[] citations)
    {
        int arrLen = citations.Length;
        int[] dt = new int[arrLen + 1];
        foreach (int item in citations)
        {
            if (item > arrLen)
            {
                ++dt[arrLen];
            }
            else
            {
                ++dt[item];
            }
        }
        int total = 0;
        for (int i = arrLen; i != -1; --i)
        {
            total += dt[i];
            if (total >= i)
            {
                return i;
            }
        }
        return 0;
    }

    //https://leetcode.com/problems/insert-delete-getrandom-o1/description/?envType=study-plan-v2&envId=top-interview-150
    public class RandomizedSet
    {
        private Random randm = new();
        private Dictionary<int, int> dict = new();
        private List<int> list = new();
        public RandomizedSet()
        {
        }
        public bool Insert(int val)
        {
            if (dict.ContainsKey(val)) return false;
            list.Add(val);
            dict.Add(val, list.Count - 1);
            return true;
        }
        public bool Remove(int val)
        {
            if (!dict.ContainsKey(val)) return false;
            int lastVal = list[list.Count - 1]; //storing last value of the list
            list[list.Count - 1] = val; // replacing the last value in the list with entered one
            list[dict[val]] = lastVal;
            dict[lastVal] = dict[val];
            dict.Remove(val);
            list.RemoveAt(list.Count - 1);
            return true;
        }

        public int GetRandom()
        {
            int rndNum = randm.Next(0, list.Count);
            return list[rndNum];
        }
    }

    //https://leetcode.com/problems/product-of-array-except-self/description/?envType=study-plan-v2&envId=top-interview-150
    public int[] ProductExceptSelf(int[] arr)
    {
        int[] left = new int[arr.Length];
        left[0] = 1;
        int[] right = new int[arr.Length];
        right[0] = 1;
        for (int i = 1; i < left.Length; i++)
        {
            left[i] = left[i - 1] * arr[i - 1];
        }
        right[right.Length - 1] = 1;
        for (int i = right.Length - 2; i >= 0; i--)
        {
            right[i] = right[i + 1] * arr[i + 1];
        }
        for (int i = 0; i < right.Length; i++)
        {
            arr[i] = left[i] * right[i];
        }
        return arr;
    }

    //https://leetcode.com/problems/gas-station/description/?envType=study-plan-v2&envId=top-interview-150
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        int total = 0;
        int si = 0;
        int curr = 0;
        for (int i = 0; i < cost.Length; i++)
        {
            total = total + gas[i] - cost[i];

        }
        if (total < 0)
        {
            return -1;
        }
        for (int i = 0; i < cost.Length; i++)
        {
            curr = curr + gas[i] - cost[i];
            if (curr < 0)
            {
                si = i + 1;
                curr = 0;
            }

        }
        return si;
    }

    //https://leetcode.com/problems/trapping-rain-water/description/?envType=study-plan-v2&envId=top-interview-150
    public int Trap(int[] arr)
    {
        int n = arr.Length;
        int[] left = new int[n];
        int[] right = new int[n];

        left[0] = arr[0];
        right[n - 1] = arr[n - 1];
        for (int i = 1; i < right.Length; i++)
        {
            left[i] = Math.Max(left[i - 1], arr[i]);

        }

        for (int i = n - 2; i >= 0; i--)
        {
            right[i] = Math.Max(right[i + 1], arr[i]);

        }

        int sum = 0;

        for (int i = 0; i < right.Length; i++)
        {
            sum = sum + (Math.Min(left[i], right[i]) - arr[i]);

        }
        return sum;
    }

    //https://leetcode.com/problems/roman-to-integer/description/?envType=study-plan-v2&envId=top-interview-150
    public class RomanToInteger
    {
        private readonly Dictionary<char, int> dict = new Dictionary<char, int>
        {
            {'I' , 1},
            {'V' , 5},
            {'X' , 10},
            {'L' , 50},
            {'C' , 100},
            {'D' , 500},
            {'M' , 1000},
        };

        public int RomanToInt(string s)
        {
            char[] input = s.ToCharArray();
            int ans = 0, curVal, nextVal;
            for (int i = 0; i < input.Length; i++)
            {
                curVal = dict[input[i]];
                if (i != input.Length - 1)
                {
                    nextVal = dict[input[i + 1]];
                    if (nextVal > curVal)
                    {
                        curVal = nextVal - curVal;
                        i = i + 1;
                    }
                }
                ans = ans + curVal;
            }
            return ans;
        }
    }

    //https://leetcode.com/problems/integer-to-roman/description/?envType=study-plan-v2&envId=top-interview-150
    public class IntgerToRoman
    {
        public string IntToRoman(int input)
        {
            string[] ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
            string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] hrns = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] ths = { "", "M", "MM", "MMM" };
            return
                ths[input / 1000] +
                hrns[(input % 1000) / 100] +
                tens[(input % 100) / 10] +
                ones[input % 10];
        }
    }

    //https://leetcode.com/problems/length-of-last-word/description/?envType=study-plan-v2&envId=top-interview-150
    public class LengthOfTheLastWord
    {
        public int LengthOfLastWord(string s)
        {
            string[] words = s.Split(' ');
            string[] filteredWords = words.Where(word => !string.IsNullOrWhiteSpace(word)).ToArray();
            if (filteredWords.Length == 0)
            {
                return 0;
            }
            return filteredWords.Last().Length;
        }
    }

    //https://leetcode.com/problems/reverse-words-in-a-string/description/?envType=study-plan-v2&envId=top-interview-150
    public class ReverseWordsInSen
    {
        public string ReverseWords(string s)
        {
            string[] input = s.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            Array.Reverse(input);
            return string.Join(" ", input);
        }
    }
}
