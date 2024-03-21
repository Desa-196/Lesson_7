using Lesson_7;

TestClass test = new TestClass(10, new char[] {'t', 'e', 's', 't'}, "Тестовая страка", 16.6m);

string resultString =  StringObject.ObjectToString(test) ;
Console.WriteLine(resultString); //При выводе видим, что поле S класса TestClass cстало называться String

var objFromString = StringObject.StringToObject(StringObject.ObjectToString(test));
Console.WriteLine("S = " + (objFromString as TestClass).S); //После обратного преобразования, видим, что в поле S теперь наше поле из строки под именем String