using System.Collections;

namespace Bwire
{
    public class ReadGrudDto
    {
        public int count { get; set; }
        public IEnumerable result { get; set; }
        public IEnumerable groupDs { get; set; }
    }
}
