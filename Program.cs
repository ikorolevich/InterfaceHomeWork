namespace InterfaceHomeWork
{
    public interface ISummarize
    {
        public double Summ(double a, double b);
    }
    public interface ILogger
    {
        public void Result(double message);
        public void Error(string message);

    }
    public class Logger : ILogger
    {
        void ILogger.Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }

        void ILogger.Result(double val)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Summ is: {0}", val);
        }
    }
    public class Calculator : ISummarize
    {
        ILogger logger { get; }
        public Calculator(ILogger logger)
        {
            this.logger = logger;
        }
        double ISummarize.Summ(double a, double b)
        {
            double c = a + b;
            logger.Result(c);
            return c;
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Logger logger = new Logger();
            double a = 0, b = 0;

            Console.WriteLine("Enter a");
            try
            {
                a = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception e)
            {
                ((ILogger)logger).Error(e.Message);
                Environment.Exit(0);
            }

            Console.WriteLine("Enter b");
            try
            {
                b = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception e)
            {
                ((ILogger)logger).Error(e.Message);
                Environment.Exit(0);
            }

            Calculator calculator = new Calculator(logger);
            ((ISummarize)calculator).Summ(a, b);

            Console.WriteLine("Hello, World!");
        }
    }
}
