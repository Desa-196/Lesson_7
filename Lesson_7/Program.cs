using Lesson_7;

//Создаем объект нашего тестового класса
TestClass test = new TestClass(10, new char[] {'t', 'e', 's', 't'}, "Тестовая страка", 16.6m);

//Преобразуем его в строку
string resultString =  StringObject.ObjectToString(test) ;
Console.WriteLine(resultString); //При выводе видим, что поле S класса TestClass cстало называться String

//Преобразуем строку обратно в объект нашего тестового класса
var objFromString = StringObject.StringToObject(StringObject.ObjectToString(test));
//Смотрим, есть ли значение в поле с атрибутом
Console.WriteLine("S = " + (objFromString as TestClass).S); //После обратного преобразования, видим, что в поле S теперь наше поле из строки под именем String