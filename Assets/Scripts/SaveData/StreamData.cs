using System.IO;

namespace AlexSpace
{
    public sealed class StreamData : IData<SavedData>
    {
        public void Save(SavedData data, string path = null)
        {
            if (path == null) return;
            using (var sw = new StreamWriter(path))
            {
                //sw.WriteLine(data._name);
                //sw.WriteLine(data._position.X);
                //sw.WriteLine(data._position.Y);
                //sw.WriteLine(data._position.Z);
                //sw.WriteLine(data._isEnabled);
            }
        }

        public SavedData Load(string path = null)
        {
            //    var result = new SavedData();
            //    using (var sr = new StreamReader(path))
            //    {
            //        while (!sr.EndOfStream)
            //        {
            //            result._name = sr.ReadLine();
            //            result._position.X = float.Parse(sr.ReadLine());
            //            result._position.Y = float.Parse(sr.ReadLine());
            //            result._position.Z = float.Parse(sr.ReadLine());
            //            result._isEnabled = bool.Parse(sr.ReadLine());
            //        }
            //    }
            return new SavedData();
        }
} 
}