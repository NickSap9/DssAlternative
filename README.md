# DSS "Альтернатива"
Система поддержки принятия решений на основе метода анализа иерархий (сокращенно МАИ). Одностраничное веб-приложение на Blazor WebAssembly, а ещё некогда дипломный проект (ВКР).

**Что делает?**

Приложение позволяет быстро применить МАИ для поиска наилучшей альтернативы без знаний теории принятия решений и предварительной подготовки (регистрации, установки и так далее).
Воплощению концепции способствует и веб-формат, и большая часть дизайнерских решений.

**Ссылка**

https://alleaxxrmca.github.io/DssAlternativeV3/

![Создание задачи](https://i.ibb.co/qB4ddc8/image.png)

## Технологии
C# / .NET 5 / Blazor WebAssembly

Для визуализации метода анализа иерархий необходим интерактивный интерфейс, а для реализации программной логики работы метода - солидный язык, не взрывающий мозг. Мозг пусть взрывают многоуровневые иерархии… 
С учетом веб-формата, желания опробовать новые технологии и не разделять сложную логику на два языка - выбор был очевиден.

Впрочем, существует и прототип этого же приложения в качестве – [десктопной WPF-программы](https://github.com/Alleaxx/DSS/tree/master/DSSView). Именно на её основе был сделан этот проект.

- ``` DSSAlternative``` - Blazor WASM приложение для метода анализа иерархии.
- ``` DSSAlternative.AHP``` - библиотека с реализацией алгоритма МАИ.
- ``` DSSAlternative.Tests``` - набор тестов MSTest для библиотеки МАИ.

## Использование

Сперва, разумеется, стоит перейти в [само приложение](https://alleaxxrmca.github.io/DssAlternativeV3/). При этом регистрация или установка чего-либо не требуется от слова совсем.

Секреты работы системы можно познать несколькими способами:
1. Прочитать раздел о принципах работы системы в приложении.
2. Прочитать ещё один раздел о методе анализа иерархий там же.
3. Загрузить любой пример в приложении и изучить всё методом научного тыка.

## Возможности
С помощью приложения можно выявить предпочтения пользователя в вариантах решения возникшей проблемы выбора, определить наиболее подходящее решение и математически обосновать. Полученные результаты могут служить увесистым аргументом для окончательного выбора той или иной альтернативы.

![Иерархия проблемы](https://i.ibb.co/wLJ0Vf4/image.png)

**Для этого приложение:**
- Реализует алгоритм МАИ с поддержкой многоуровневой иерархии;
- Визуализирует этапы решений задач согласно МАИ:
    - Интерактивная схема иерархии;
    - Заполнение отношений с помощью словесных оценок;
    - Помощь в согласовании отношений;
    - Анализ результата.
- Предоставляет шаблоны для решения распространенных задач;
- Позволяет решать сразу несколько задач параллельно;
- Сохраняет прогресс решения и пользовательские задачи по необходимости.

### Какие задачи можно решать?
Метод анализа иерархий можно применять в самых разных ситуациях - от житейских выборов и вопросов до полноценных исследований.
- Выбор между несколькими местами учебы / работы;
- Определение оптимального выбора при покупке чего-либо;
-  ...


Теоретические возможности приложения простираются и до таких пределов как:
- Обоснование стека технологий проекта;
- Выбор кандидата в команду проекта;
-  …

Но, правда, только теоретические. Серьезным намерениям - серьезный инструмент.

## Подробности
Разумеется, подробнее всего приложение описано в выпускной квалификационной работе. Ну, той самой, где еще 130 страниц! Однако вместо них можно кратко написать основную суть, и так будет даже лучше.

### Принцип работы
Если кратко, то система делится на две части:
- *Подготовка к решению* - выглядит как обычный сайт с парой статических страниц, где расположена информация про систему и навигационные ссылки.
- *Решение задач выбора* - редактор созданных задач . Позволяет переключаться между открытыми задачами и между этапами их решения. 

У любой задачи есть этапы решения, которые последовательно открывают доступ друг к другу. Так, заключительная стадия результатов доступна только когда все отношения в иерархии заполнены и согласованы. В свою очередь, редактирование отношений доступно лишь при утвержденной корректной иерархии. Получается следующая цепочка:
*создание задачи -> иерархия -> проверка -> отношения -> проверка -> результат*.

Пользователю необходимо последовательно пройти все этапы решения и не застрять в процессе. Для предотвращения косяков ему в помощь отпущено множество всяческих инструментов и подсказок. Если всё пройдет хорошо, то пользователь доберется до последнего этапа и останется доволен.

![Формирование связей](https://i.ibb.co/589nyXc/image.png)


### Технические решения
Одной из ключевых особенностей работы является формирование иерархий за счет группировки списка узлов, работа со связями этих узлов друг с другом, а также формирование матриц на основе этих отношений.

*Чуть более подробно про расчет коэффициентов расказано на одной из страниц системы*

Сохранение задач и прогресса происходит в JSON-формате. Сохраненный прогресс хранится в локальном хранилище браузера.

## Планы на будущее
- Полноценная интерактивная SVG-схема иерархии, поддержка редактирования многоуровневых иерархий;
    - История действий в редакторе;
- Система автоисправления рассогласованности пользовательских оценок;
- Рефакторинг кода и стилей;
- Поддержка аккаунтов пользователей;
- Возможности оформить обоснования решения задачи в отчет (файл);
- Добавление возможности сохранения файлов.
