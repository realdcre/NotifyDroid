using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace notifyd
{
    public class SettingsRepository
    {
        private static SettingsRepository _instance;
        private readonly SQLiteConnection _connection;

        public SettingsRepository(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<Settings>();
        }

        public static SettingsRepository Initialize(string dbPath)
        {
            if (_instance == null)
            {
                _instance = new SettingsRepository(dbPath);
            }
            return _instance;
        }

        public void StoreBooleanSetting(string key, bool value)
        {
            var setting = new Settings(key, value);
            _connection.InsertOrReplace(setting);
        }

        public void StoreStringSetting(string key, string value)
        {
            var setting = new Settings(key, value);
            _connection.InsertOrReplace(setting);
        }

        public bool GetBooleanSetting(string key)
        {
            var setting = _connection.Table<Settings>().FirstOrDefault(s => s.Key == key && s.IsBoolean);
            return setting != null ? bool.Parse(setting.Value) : false;
        }

        public string GetStringSetting(string key)
        {
            var setting = _connection.Table<Settings>().FirstOrDefault(s => s.Key == key && !s.IsBoolean);
            return setting != null ? setting.Value : null;
        }
    }
}