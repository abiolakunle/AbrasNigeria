using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbrasNigeria.Data.Extensions
{
    public static class SessionExtensions
    {
        public static void SetJson<T>(this ISession session, string key, IEnumerable<T> value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static IEnumerable<T> GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null
            ? default(IEnumerable<T>) : JsonConvert.DeserializeObject<IEnumerable<T>>(sessionData);
        }
    }

}
