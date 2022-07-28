using Logger.Layouts.Interfaces;

namespace Logger.Layouts
{
    public class SimpleLayout : ILayout
    {
        public SimpleLayout()
        {
        }

        public string Format => "<{0}> - <{1}> - <{2}>";
    }
}

