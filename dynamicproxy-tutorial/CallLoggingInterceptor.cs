using Castle.DynamicProxy;

namespace dynamicproxy_tutorial;

public class CallLoggingInterceptor:  IInterceptor
{
    private int _indention;
    public CallLoggingInterceptor()
    {
    }


    public int Count { get; private set; }
    public void Intercept(IInvocation invocation)
    {
        //Console.WriteLine("\tBefore target call");
        try
        {
            Count++;
            _indention++;

            Console.WriteLine("{0}Intercepting: {1}", new string('\t', _indention), invocation.Method.Name);

            invocation.Proceed();
        }
        catch (Exception)
        {
            Console.WriteLine("\tTarget threw an exception!");
            throw;
        }
        finally
        {
            //Console.WriteLine("\tAfter target call");
            _indention--;
        }
    }
}