﻿namespace PSITS_Web.WebAssembly.Classes
{
    public interface ICookie
    {
        public Task SetValue(string key, string value, int? days = null);
        public Task<string> GetValue(string key, string def = "");
    }
}
