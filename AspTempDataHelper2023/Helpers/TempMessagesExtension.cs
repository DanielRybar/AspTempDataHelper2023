using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Json;

namespace AspTempDataHelper2023.Helpers
{
    public static class TempMessagesExtension
    {
        public static void Set<T>(this ITempDataDictionary tempData, string key, T value)
        {
            var serialized = JsonSerializer.Serialize(value);
            tempData[key] = serialized;
        }
        public static T? Get<T>(this ITempDataDictionary tempData, string key)
        {
            tempData.TryGetValue(key, out object? value);
            return value == null 
                ? default 
                : JsonSerializer.Deserialize<T>((string)value);
        }
        public static void AddMessage(this ITempDataDictionary tempData, string key, TempMessage msg)
        {
            var current = tempData.Get<List<TempMessage>>(key);
            if (current == default) current = new List<TempMessage>();
            current.Add(msg);
            tempData.Set(key, current);
        }

        public static void AddMessage(this ITempDataDictionary tempData, string key, MessageType type, String text)
        {
            var current = tempData.Get<List<TempMessage>>(key);
            if (current == default) current = new List<TempMessage>();
            current.Add(new TempMessage(type, text));
            tempData.Set(key, current);
        }

        public static List<TempMessage>? GetMessages(this ITempDataDictionary tempData, string key)
        {
            return tempData.Get<List<TempMessage>>(key);
        }
    }

    public enum MessageType
    {
        Success = 1,
        Danger,
        Warning,
        Info
    }

    public class TempMessage
    {
        public TempMessage(MessageType type, string text)
        {
            Type = type;
            Text = text;
        }

        public MessageType Type { get; set; }
        public string Text { get; set; }
    }
}