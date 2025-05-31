using BlogEF.Data;

namespace BlogEF;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new BlogDataContext())
        {
        }
    }
}