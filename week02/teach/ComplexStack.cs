public static class ComplexStack {

        public static void Main() {
        // Test 1: All parentheses are balanced
        // Expected result: True (stack is empty at the end)
        Console.WriteLine(DoSomethingComplicated("(a == 3 or (b == 5 and c == 6))"));

        // Test 2: Error due to wrong square bracket
        // Expected result: False
        // Explanation: The stack had a '(' and when it encounters ']', it fails because it expected '['
        Console.WriteLine(DoSomethingComplicated("(students]i].Grade > 80 and students[i].Grade < 90)"));

        // Test 3: Error due to missing closing parenthesis
        // Expected result: False
        // Explanation: The final ')' is missing, so the stack still has an extra '(' at the end
        Console.WriteLine(DoSomethingComplicated("(robot[id + 1].Execute(.Pass() || (!robot[id * (2 + i)].Alive && stormy) || (robot[id - 1].Alive && lavaFlowing))"));
    }
    public static bool DoSomethingComplicated(string line) {
        var stack = new Stack<char>();
        foreach (var item in line) {
            if (item is '(' or '[' or '{') {
                stack.Push(item);
            }
            else if (item is ')') {
                if (stack.Count == 0 || stack.Pop() != '(')
                    return false;
            }
            else if (item is ']') {
                if (stack.Count == 0 || stack.Pop() != '[')
                    return false;
            }
            else if (item is '}') {
                if (stack.Count == 0 || stack.Pop() != '{')
                    return false;
            }
        }

        return stack.Count == 0;
    }
}