using System;
namespace Zork
{
    public interface IOutputService
    {
        //event EventHandler<Room> LocationChanged;
        void Write(string value);
        void Write(object value);
        void WriteLine(string value);
        void WriteLine(object value);
        void Clear();
    }
}
