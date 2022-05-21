using System.Collections.Generic;
using System.Text.Json;

namespace ShopData
{
    public abstract class Serializer
    {
        public static string FruitToJson(IFruit fruit)
        {
            return JsonSerializer.Serialize(fruit);
        }

        public static IFruit JsonToFruit(string json)
        {
            return JsonSerializer.Deserialize<Fruit>(json);
        }

        public static string AllFruitsToJson(List<IFruit> fruits)
        {
            return JsonSerializer.Serialize(fruits);
        }

        public static List<IFruit> JsonToManyFruits(string json)
        {
            return new List<IFruit>(JsonSerializer.Deserialize<List<Fruit>>(json)!);
        }
    }
}