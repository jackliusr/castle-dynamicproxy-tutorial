using Castle.DynamicProxy;

namespace dynamicproxy_tutorial;

public class CallLoggingInterceptor:  IInterceptor
{
    public CallLoggingInterceptor()
    {
    }
    public void Intercept(IInvocation invocation)
    {
        //Console.WriteLine("\tBefore target call");
        Console.WriteLine($"\tIntercepting: {invocation.Method.Name}");
        try
        {
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
        }
    }
}