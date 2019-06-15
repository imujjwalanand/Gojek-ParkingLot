using System;
using System.Collections.Generic;
using System.Text;

namespace parking_lot {
    public class HelperMethods {
        /// <summary>
        /// Helper method to beautify the status outpur so that every entry is aligned even for varying numbers of lenghts of values(Regn No., Colour etc.)
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static string BeautifyStatusOutput(string first, int second) {
            int n = second + 5 - first.Length;
            string s = string.Empty;
            for(int i = 0; i < n; i++) {
                s += " ";
            }
            return first + s;
        }
    }
}
