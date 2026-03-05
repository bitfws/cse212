public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
                // Plan:
                // 1. Create an array of type double with size equal to length.
                // 2. Use a for loop that runs from 0 to length - 1. 
                // 3. For each index i, calculate the multiple of the number.
                // 4. The formula for each multiple will be number * (i + 1).
                // 5. Store that value in the array at position i.
                // 6. After the loop finishes, return the array.

        double[] result = new double[length];

        for(int i = 0; i < length; i++)
        {
            result[i] = number * (i +1);
        }

        return result; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Plan:
        // 1. Determine the index where the last 'amount' elements start.
        //    This can be calculated as data.Count - amount.
        // 2. Use GetRange to copy the last 'amount' elements into a temporary list.
        // 3. Remove those elements from the original list using RemoveRange.
        // 4. Insert the temporary list at the beginning of the original list using InsertRange.
        // 5. This will rotate the list to the right by the specified amount. 

        int startIndex = data.Count - amount;
        List<int> endPart = data.GetRange(startIndex, amount);
        data.RemoveRange(startIndex, amount);
        data.InsertRange(0, endPart);
    }
}
