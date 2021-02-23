using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestingExample
{
    public class FileStore : IStore
    {
        private readonly string _filePath;
        public int Result { get; set; }

        public FileStore(string filePath)
        {
            _filePath = filePath;
        }

        public void Save(int value)
        {
            using(var writer = File.CreateText(_filePath))
            {
                writer.Write(value);
            }
        }
    }
}
