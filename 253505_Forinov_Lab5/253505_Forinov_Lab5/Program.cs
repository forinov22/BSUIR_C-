// See https://aka.ms/new-console-template for more information

// Создаем объекты актеров
using _253505_Forinov_Lab5.Domain.Entities;
using SerializerLib;

Serializer s = new();

Actor actor1 = new Actor("Иван Иванов", 30, "Мужской");
Actor actor2 = new Actor("Мария Петрова", 25, "Женский");
Actor actor3 = new Actor("Алексей Сидоров", 35, "Мужской");
Actor actor4 = new Actor("Елена Козлова", 28, "Женский");

// Создаем объекты персонажей фильма и заполняем коллекцию MovieCharacter
List<MovieCharacter> characters = new List<MovieCharacter>
{
    new MovieCharacter("Герой 1", "Главный герой", actor1),
    new MovieCharacter("Герой 2", "Поддерживающая роль", actor2),
    new MovieCharacter("Антагонист 1", "Антагонист", actor3),
    new MovieCharacter("Герой 3", "Поддерживающая роль", actor4),
};

s.SerializeByLINQ(characters, "charactersLinq.xml");
s.SerializeXML(characters, "charactersXml.xml");
s.SerializeJSON(characters, "charactersJson.json");

var col1 = s.DeSerializeByLINQ("charactersLinq.xml").ToList();
var col2 = s.DeSerializeXML("charactersXml.xml").ToList();
var col3 = s.DeSerializeJSON("charactersJson.json").ToList();

bool equal = true;

for (var i = 0; i < characters.Count; i++) {
    if (!col1[i].Equals(characters[i])) {
        equal = false;
        break;
    }
}

Console.WriteLine(equal ? "Коллекции одинаковы" : "Коллекции не совпадают");

equal = true;

for (var i = 0; i < characters.Count; i++) {
    if (!col2[i].Equals(characters[i])) {
        equal = false;
        break;
    }
}

Console.WriteLine(equal ? "Коллекции одинаковы" : "Коллекции не совпадают");

equal = true;

for (var i = 0; i < characters.Count; i++) {
    if (!col3[i].Equals(characters[i])) {
        equal = false;
        break;
    }
}

Console.WriteLine(equal ? "Коллекции одинаковы" : "Коллекции не совпадают");