using System.IO;
using Lessons.Chemistry.Scripts.Data;
using UnityEditor;
using UnityEngine;

namespace Lessons.Chemistry.Editor
{
    public class CreateElements
    {
        [MenuItem("Assets/Create/Element")]
        public static void CreateElementAssets()
        {
            // Путь к вашему файлу
            var filePath = "Assets/Elements.txt";

            // Проверка наличия файла
            if (File.Exists(filePath))
            {
                // Чтение всех строк из файла
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                    // Разделение строки на части по запятой
                    var parts = line.Split(',');

                    if (parts.Length == 2)
                    {
                        // Получение символа и числа из файла
                        var symbol = parts[0].Trim();
                        int atomicNumber;

                        if (int.TryParse(parts[1].Trim(), out atomicNumber))
                        {
                            // Создание элемента и установка значения Id
                            var element = ScriptableObject.CreateInstance<AtomSO>();
                            element.Id = atomicNumber;

                            // Создание уникального пути для каждого элемента
                            var path = AssetDatabase.GenerateUniqueAssetPath(
                                "Assets/Lessons/Chemistry/ScriptableObjects/AtomicElements/" + symbol + ".asset");

                            // Создание актива и сохранение
                            AssetDatabase.CreateAsset(element, path);
                            AssetDatabase.SaveAssets();

                            Debug.Log($"Created Element: {symbol}, Atomic Number: {atomicNumber}");
                        }
                        else
                        {
                            Debug.LogError($"Invalid atomic number in line: {line}");
                        }
                    }
                    else
                    {
                        Debug.LogError($"Invalid format in line: {line}");
                    }
                }
            }
            else
            {
                Debug.LogError("File not found: " + filePath);
            }
        }
    }
}