namespace Pong.Menus
{
    using System;

    public interface IMenu<T> where T : struct, IConvertible
    {
        string Title { get; }

        string[] Options { get; }

        void Print();

        T Display();
    }
}
