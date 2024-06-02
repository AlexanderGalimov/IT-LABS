# IT-LABS
**1) Задание 1:**
Класс «Линейный_список».
Свойства: текущий элемент, количество элементов, признак пуст ли список (IsEmpty).
Методы: добавления и удаления элементов, перехода к следующему элементу (если переход к следующему элементу не возможен, возвращает false, иначе - true), переход в начало.

**2) Задание 2:**
Базовый класс: живое существо (свойство: скорость перемещения, абстрактные методы: двигаться, стоять)
Производные классы: пантера, собака, черепаха. реализовать методы двигаться и стоять. При этом неоднократный вызов, например, метода двигаться увеличивает скорость до максимально возможного и наоборот - вызов метода стоять, уменьшает вплоть до остановки. У пантеры и собаки должен быть метод - подать голос (определяется вызовом соответствующих событий), и пантера может залезть на дерево.

**3) Задание 3:**
Используя решение задачи 2. Необходимо с помощью рефлексии реализовать возможность создания  и вызова методов данных классов на форме. В программе необходимо предусмотреть ввод пути к библиотеке классов, программа должна загрузить её, найти все классы, которые реализуют нужный интерфейс.  Получить всю информацию о данных классах, вывести список названий классов. При выборе класса на форму должны динамически подгружаться все методы класса с возможностью ввода параметров пользователем. При нажатии кнопки «Выполнить» должен создаваться объект и выполняться выбранный метод.

**3) Задание 4:**
Гонки – смоделировать гонки. Реализовать классы – Болид, Механик, интерфейс – погрузчик. События – Стерлись покрышки – заезд в боксы смена колес, Столкновение (с некоторой долей вероятности) – приезжает погрузчик.
