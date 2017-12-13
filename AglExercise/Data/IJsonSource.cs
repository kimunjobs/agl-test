using System.Runtime.CompilerServices;

namespace Data
{
    public interface IJsonSource<out T> where T: class 
    {
        T Load();
    }
}