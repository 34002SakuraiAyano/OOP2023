using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Exercise01 {
    // List 17-8
    public abstract class TextProcessor {

        public static void Run<T>(string fileName) where T : TextProcessor, new() {
            var self = new T ();
            self.Process ( fileName );
        }

        private void Process(string fileName) {
            using (var sr = new StreamReader ( fileName )) {
                while (!sr.EndOfStream) {
                    string line = sr.ReadLine ();  //1行読み取る
                    Execute ( line );
                }
            }
        }

        protected virtual void Execute(string line) { }
    }
}
