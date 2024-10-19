using SQLite;
using System;

namespace notifyd
{
    public class Settings
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public bool IsBoolean { get; set; }

        public Settings() { }

        public Settings(string key, bool value)
        {
            Key = key;
            Value = value.ToString();
            IsBoolean = true;
        }

        public Settings(string key, string value)
        {
            Key = key;
            Value = value;
            IsBoolean = false;
        }
    }
}