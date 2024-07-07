using System;
using static System.Console;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace DesignPattern.Creational.Prototype
{
    public static class ExtensionMethods
    {
        public static T DeepCopyXml<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T)s.Deserialize(ms);
            }
        }
    }

    //[Serializable] // this is, unfortunately, required
    public class Foo
    {
        public uint Stuff;
        public string Whatever;

        public override string ToString()
        {
            return $"{nameof(Stuff)}: {Stuff}, {nameof(Whatever)}: {Whatever}";
        }
    }

    public static class CopyThroughSerialization
    {
        static void test()
        {
            Foo foo = new Foo { Stuff = 42, Whatever = "abc" };

            //Foo foo2 = foo.DeepCopy(); // crashes without [Serializable]
            Foo foo2 = foo.DeepCopyXml();

            foo2.Whatever = "xyz";
            WriteLine(foo);
            WriteLine(foo2);
        }
    }
}
