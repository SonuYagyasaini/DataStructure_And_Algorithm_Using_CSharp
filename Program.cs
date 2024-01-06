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
}
