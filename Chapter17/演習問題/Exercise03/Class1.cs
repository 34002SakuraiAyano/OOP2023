using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Exercise03 {
    // List 17-8
    public class TextProcessor {
        private ITextFileService _service;

        public TextProcessor (ITextFileService service) {
            _service = service;
        }

        private void Run(string fileName) {
            _service.Initialaize ( fileName );
            using (var sr = new StreamReader ( fileName )) {
                while (!sr.EndOfStream) {
                    string line = sr.ReadLine ();  //1行読み取る
                    _service.Execute ( line );
                }
            }
            _service.Terminate ();
        }
    }
}
