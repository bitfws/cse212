/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1: Create queue with valid size
        // Scenario: Initialize a CustomerService queue with maxSize = 3
        // Expected Result: Queue is empty, max_size = 3
        Console.WriteLine("Test 1");
        var cs1 = new CustomerService();
        Console.WriteLine(cs1);

        // Defect(s) Found: None
        Console.WriteLine("=================");

        // Test 2: Create queue with invalid size (≤0)
        // Scenario: Initialize a CustomerService queue with maxSize = 0
        // Expected Result: Queue is empty, max_size defaults to 10
        Console.WriteLine("Test 2");
        var cs2 = new CustomerService();
        Console.WriteLine(cs2);

        // Defect(s) Found: None
        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below

        // Test 3: Add customers until queue is full
        // Scenario: Add 4 customers to a queue with maxSize = 3
        // Expected Result: First 3 customers are added successfully, 4th shows error
        Console.WriteLine("Test 3");
        cs1.AddNewCustomer();
        cs1.AddNewCustomer();
        cs1.AddNewCustomer();
        cs1.AddNewCustomer(); // Should show error
        Console.WriteLine(cs1);

        // Defect(s) Found: Original code allowed 4th customer due to using '>' instead of '>='
        Console.WriteLine("=================");

        // ===========================
        // Test 4: Serve customers from the queue
        // Scenario: Dequeue all customers from the queue and attempt one extra
        // Expected Result: Customers served in FIFO order, last attempt shows error
        Console.WriteLine("Test 4");
        cs1.ServeCustomer(); // Alice
        cs1.ServeCustomer(); // Bob
        cs1.ServeCustomer(); // Charlie
        cs1.ServeCustomer(); // Queue empty → should show error

        // Defect(s) Found: Original code crashed when queue was empty due to accessing _queue[0] after RemoveAt(0)
        Console.WriteLine("=================");
    }

        private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId}): {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        // if (_queue.Count > _maxSize) // Defect 3 - should use >=
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        // Need to check if there are customers in our queue
        if (_queue.Count <= 0) // Defect 2 - Need to check queue length
        {
            Console.WriteLine("No Customers in the queue");
        }
        else {
            // Need to read and save the customer before it is deleted from the queue
            var customer = _queue[0];
            _queue.RemoveAt(0); // Defect 1 - Delete should be done after
            Console.WriteLine(customer);
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}