using JWT.Algorithms;
using JWT;
using JWT.Serializers;
using System;
using System.Collections.Generic;

namespace Yara.Helper
{
    public static class General
    {
        public static string GenerateToken(string FileName)
        {
            string RequestType = "general";
            int MemberTypeID = 1;
            int MemberID = GetRegMember(FileName);
            var now = DateTimeOffset.UtcNow;
            long iat = now.ToUnixTimeSeconds();
            long exp = now.AddMonths(1).ToUnixTimeSeconds();
            var payload = new Dictionary<string, object>
            {
                { "MemberID", MemberID },
                { "MemberTypeID", MemberTypeID },
                { "RequestType", RequestType },
                { "FileName", FileName },
                { "iat", iat },
                { "exp", exp }
            };
            const string secret = "#YARA LMS Mazust @1400@";

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm(); // symmetric
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

            return encoder.Encode(payload, secret);
        }


        public static int GetRegMember(string filename)
        {
            const string nums = "0123456789";
            int index = 0;

            for (int i = 0; i < filename.Length; i++)
                if (nums.IndexOf(filename[i]) > -1)
                {
                    index = i;
                    break;
                }

            string output = "";


            while (true)
            {
                output += filename[index].ToString();
                index++;
                if (nums.IndexOf(filename[index]) == -1)
                    return int.Parse(output);
            }

        }

    }
}