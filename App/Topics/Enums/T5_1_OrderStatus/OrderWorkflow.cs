// Тема 5, Задача T5.1_OrderStatus
// Проектирование enum и функций переходов состояний заказа.

namespace App.Topics.Enums.T5_1_OrderStatus;

public enum OrderStatus
{
    New,
    Paid,
    Shipped,
    Delivered,
    Cancelled
}

public static class OrderWorkflow
{
    private static readonly Dictionary<OrderStatus, HashSet<OrderStatus>> _allowedTransitions = new()
    {
        [OrderStatus.New] = new HashSet<OrderStatus> { OrderStatus.Paid, OrderStatus.Cancelled },
        [OrderStatus.Paid] = new HashSet<OrderStatus> { OrderStatus.Shipped, OrderStatus.Cancelled },
        [OrderStatus.Shipped] = new HashSet<OrderStatus> { OrderStatus.Delivered, OrderStatus.Cancelled },
        [OrderStatus.Delivered] = new HashSet<OrderStatus>(),
        [OrderStatus.Cancelled] = new HashSet<OrderStatus>()
    };

    public static bool CanTransition(OrderStatus from, OrderStatus to)
    {
        return _allowedTransitions[from].Contains(to);
    }

    public static OrderStatus Next(OrderStatus current)
    {
        if (current == OrderStatus.Delivered || current == OrderStatus.Cancelled)
        {
            throw new InvalidOperationException(
                $"Cannot get next status for '{current}' - order workflow is complete.");
        }

        return current switch
        {
            OrderStatus.New => OrderStatus.Paid,
            OrderStatus.Paid => OrderStatus.Shipped,
            OrderStatus.Shipped => OrderStatus.Delivered,
            _ => throw new InvalidOperationException($"Unexpected status: {current}")
        };
    }

    public static OrderStatus Parse(string text)
    {
        if (text == null)
        {
            throw new ArgumentNullException(nameof(text));
        }

        if (string.IsNullOrWhiteSpace(text))
        {
            throw new ArgumentException("Input string cannot be null or empty.", nameof(text));
        }

        if (Enum.TryParse<OrderStatus>(text, true, out var result))
        {
            return result;
        }

        throw new ArgumentException($"Cannot parse '{text}' to OrderStatus.", nameof(text));
    }
}
