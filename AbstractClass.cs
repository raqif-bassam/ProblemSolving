using System;

namespace ProblemSolving
{
    public abstract class AbstractClass
    {
        public abstract void Hello();
        public virtual void Hello1() {
            Console.WriteLine("Hello 1 Base class implementation");
        }

        public void Hello2()
        {
            Console.WriteLine("Hello 2 Base class implementation");
        }
    }

    public class ClassA : AbstractClass
    {
        public override void Hello()
        {
            Console.WriteLine("Hello Derived class implementation");
        }
        public override void Hello1()
        {
            Console.WriteLine("Hello 1 Derived class implementation");
        }
    }
}
