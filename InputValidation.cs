using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Tools {
    public class InputValidation {
        public static bool checkLetters(string input) {
            int count = Regex.Matches(input, @"[a-zA-Z\-\ ]").Count;

            if (input.Length != 0 && count == input.Length) {
                return true;
            } else {
                return false;
            }
        }

        public static bool checkNumbers(string input) {
            int count = Regex.Matches(input, @"[0-9]").Count;

            if (input.Length != 0 && count == input.Length) {
                return true;
            } else {
                return false;
            }
        }

        public static bool checkDecimals(string input){
            int count = Regex.Matches(input, @"[0-9\.]").Count;

            if (input.Length != 0 && count == input.Length) {
                return true;
            } else {
                return false;
            }
        }
    }
}
