# WebApi
Postman Collection - https://www.getpostman.com/collections/a6768bec083bb076e17f

Щодо запуску з консолі, я не впевнений, але я завжди користувався dotnet test / dotnet test <path to project>

Для того щоб створити репорт за допомогою LivingDoc потрібно зробити (я зробив) наступне :

1) Встановити LivingDoc, я це зробив наступним чином: dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI

2) Після того, як заранили тест, наприклад, за допомогою dotnet test, можна згенерувати файл-репорт виконавши наступну команди:

livingdoc test-assembly <Шлях до compiled SpecFlow test assembly.dll> -t <Шлях до файлу з результатми тесту.json>

У мому випадку це було так6

livingdoc test-assembly /home/eingird/Study/csharp/WebAPI_2/WebAPI_2/bin/Debug/net6.0/WebAPI_2.dll -t /home/eingird/Study/csharp/WebAPI_2/WebAPI_2/bin/Debug/net6.0/TestExecution.json

Після чого отримаємо LivingDoc.html - репорт.



