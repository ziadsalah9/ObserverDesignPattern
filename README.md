✅ Example: Observer Design Pattern
This is a simple example demonstrating the Observer Design Pattern, where a notification is sent every time a new loaf of bread is produced.

✅ Step 1: Define the Observer Interface
csharp
Copy
Edit
public interface IObserver
{
    void Update(string message);
}
This interface defines the contract that allows the Subject to notify any registered Observer by sending a message.

✅ Step 2: Create a Concrete Observer
csharp
Copy
Edit
public class ShowMessage : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Observer is notified with message: {message}");
    }
}
This is a concrete implementation of IObserver which simply prints the received message to the console.

✅ Step 3: Create the Subject and Observer Management Logic
After creating the interface and its implementation, we define a Subject class that:

Maintains a list of IObserver instances.

Notifies them whenever the bread count changes.

csharp
Copy
Edit
public class Bakery
{
    private List<IObserver> observers = new List<IObserver>();
    private int _breadCount;

    public int BreadCount
    {
        get { return _breadCount; }
        set
        {
            _breadCount = value;
            NotifyObservers($"Bread count increased: {value}");
        }
    }

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    private void NotifyObservers(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }
}
✅ Summary of Key Functions
The Subject (in this case Bakery) should implement the following methods:

Attach(IObserver observer): Adds an observer to the list.

Detach(IObserver observer): Removes an observer from the list.

NotifyObservers(string message): Notifies all observers with the given message.

✅ Usage Example
csharp
Copy
Edit
class Program
{
    static void Main()
    {
        var bakery = new Bakery();
        var observer = new ShowMessage();

        bakery.Attach(observer);

        bakery.BreadCount = 1;
        bakery.BreadCount = 2;

        bakery.Detach(observer);

        bakery.BreadCount = 3; // No message will be shown
    }
}
