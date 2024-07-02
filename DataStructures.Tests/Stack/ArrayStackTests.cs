using DataStructures.Stack;
using FluentAssertions;
using NUnit.Framework;

namespace DataStructures.Tests.Stack;

public static class ArrayStackTests
{
    private const string StackEmptyErrorMessage = "The Stack is empty";

    [Test]
    public static void CountTest()
    {
        var stack = new ArrayStack<int>([0, 1, 2, 3, 4]);
        stack.Top.Should().Be(4);
    }

    [Test]
    public static void ClearTest()
    {
        var stack = new ArrayStack<int>([0, 1, 2, 3, 4]);

        stack.Clear();

        stack.Top.Should().Be(-1);
    }

    [Test]
    public static void ContainsTest()
    {
        var stack = new ArrayStack<int>([0, 1, 2, 3, 4]);
        
        Assert.Multiple(() =>
        {
            stack.Contains(0).Should().BeTrue();
            stack.Contains(1).Should().BeTrue();
            stack.Contains(2).Should().BeTrue();
            stack.Contains(3).Should().BeTrue();
            stack.Contains(4).Should().BeTrue();
        });
    }

    [Test]
    public static void PeekTest()
    {
        var stack = new ArrayStack<int>([0, 1, 2, 3, 4]);

        Assert.Multiple(() =>
        {
            stack.Peek().Should().Be(4);
            stack.Peek().Should().Be(4);
            stack.Peek().Should().Be(4);
        });
    }

    [Test]
    public static void PopTest()
    {
        var stack = new ArrayStack<int>([0, 1, 2, 3, 4]);

        Assert.Multiple(() =>
        {
            stack.Pop().Should().Be(4);
            stack.Pop().Should().Be(3);
            stack.Pop().Should().Be(2);
            stack.Pop().Should().Be(1);
            stack.Pop().Should().Be(0);
        });
    }

    [Test]
    public static void PushTest()
    {
        var stack = new ArrayStack<int>();

        Assert.Multiple(() =>
            Enumerable.Range(0, 5)
                .ToList()
                .ForEach(number =>
                {
                    stack.Push(number);
                    stack.Peek().Should().Be(number);
                }));
    }

    [Test]
    public static void AutomaticResizesTest()
    {
        const int initialCapacity = 2;
        var stack = new ArrayStack<int>
        {
            Capacity = initialCapacity,
        };

        stack.Push(0);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);

        stack.Capacity.Should().BeGreaterThan(initialCapacity);
    }

    [Test]
    public static void ShouldThrowStackEmptyExceptionOnEmptyPopTest()
    {
        var stack = new ArrayStack<int>();

        Action poppingAnEmptyStack = () => stack.Pop();

        poppingAnEmptyStack.Should()
            .Throw<InvalidOperationException>()
            .WithMessage(StackEmptyErrorMessage);

    }

    [Test]
    public static void ShouldThrowStackEmptyExceptionOnEmptyPeekTest()
    {
        var stack = new ArrayStack<int>();

        Action peekingAnEmptyStack = () => stack.Peek();

        peekingAnEmptyStack.Should()
            .Throw<InvalidOperationException>()
            .WithMessage(StackEmptyErrorMessage);
    }
}