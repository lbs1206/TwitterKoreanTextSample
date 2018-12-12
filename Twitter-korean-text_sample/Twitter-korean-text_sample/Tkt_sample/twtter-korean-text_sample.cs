using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Moda.Korean.TwitterKoreanProcessorCS;

namespace Twitter_korean_text_sample.Tkt_sample
{
    public class twtter_korean_text_sample
    {
        string text = "한국어를 처리하는 예시입니닼ㅋㅋㅋㅋㅋㅋㅋㅋ #한국어";

        //Normalize
        public string NormalizeSample()
        {
            var result = TwitterKoreanProcessorCS.Normalize(text);

            return result;
        }

        //토큰화
        public string TokenizeSample()
        {
            StringBuilder result = new StringBuilder();

            var tokens = TwitterKoreanProcessorCS.Tokenize(text);
            var results = TwitterKoreanProcessorCS.TokensToStrings(tokens);

            return string.Join("/", results);
        }

        //어근화
        public string StemSample()
        {
            StringBuilder result = new StringBuilder();

            var tokens = TwitterKoreanProcessorCS.Tokenize(text);
            var stemmedTokens = TwitterKoreanProcessorCS.Stem(tokens);

            foreach (var stemmedToken in stemmedTokens)
            {
                result.AppendFormat(format: "{0}({1}) [{2},{3}] / ",
                    args: new object[] { stemmedToken.Text, stemmedToken.Pos.ToString(), stemmedToken.Offset, stemmedToken.Length });
            }

            return result.ToString();
        }

        public string ExtractPhraseSample1()
        {
            StringBuilder result = new StringBuilder();

            var tokens = TwitterKoreanProcessorCS.Tokenize(text);
            var phrases = TwitterKoreanProcessorCS.ExtractPhrases(tokens);

            foreach (var phrase in phrases)
            {
                result.AppendLine("---------");
                result.AppendFormat("{0} | ", phrase.Pos.ToString());
                foreach (var token in phrase.Tokens)
                {
                    result.AppendFormat(format: "{0}({1}) [{2},{3}] / ",
                        args: new object[] { token.Text, token.Pos.ToString(), token.Offset, token.Length });
                }
                result.AppendLine();
            }

            return result.ToString();
        }
    }
}