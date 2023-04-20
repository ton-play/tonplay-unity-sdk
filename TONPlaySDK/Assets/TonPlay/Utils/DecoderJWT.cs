using System.Collections;
using System.Collections.Generic;

namespace TONPlay {
    public static class DecoderJWT {
        public static string Decode(string token) {
            string userInfo = "";

            var parts = token.Split('.');
            if (parts.Length > 2) {
                var decode = parts[1];
                var padLength = 4 - decode.Length % 4;
                if (padLength < 4) {
                    decode += new string('=', padLength);
                }
                var bytes = System.Convert.FromBase64String(decode);
                userInfo = System.Text.ASCIIEncoding.ASCII.GetString(bytes);
            }
            return userInfo;
        }
    }
}
