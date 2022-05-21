using System.Collections.Generic;
using System.Text.Json;
using ShopServerLogic;

namespace ShopServerPresentation
{
    public abstract class Serializer
    {
        public static string FruitToJson(IFruitDTO fruit)
        {
            return JsonSerializer.Serialize(fruit);
        }

        public static IFruitDTO JsonToFruit(string json)
        {
            return JsonSerializer.Deserialize<FruitDTO>(json);
        }

        public static string AllFruitsToJson(List<IFruitDTO> fruits)
        {
            return JsonSerializer.Serialize(fruits);
        }

        public static List<IFruitDTO> JsonToManyFruits(string json)
        {
            List<FruitDTO> fruits = JsonSerializer.Deserialize<List<FruitDTO>>(json);
            return new List<IFruitDTO>(fruits!);
        }
    }
}