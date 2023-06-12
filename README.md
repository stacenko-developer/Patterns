# Паттерны проектирования с примерами на C#
В данном репозитории содержатся реализации паттернов на языке программирования C#. Ниже вы можете ознакомиться с описанием паттернов, их назначением, а также преимуществами и недостатками. <br />
После изучения теории можете переходить в код - он хорошо задокументирован, поэтому разобраться в нем не составит труда. <br />
Помимо документации в данном файле будет пошагово описана реализация каждого паттерна, которыцй есть в репозитории.
### В папке каждого паттерна содержатся: <br />
* его реализация в библиотеке классов; <br />
* демонстрация работы в консольном приложении; <br />
* [тестирование](https://github.com/stacenko-developer/UnitTests "тестирование") методов классов и проверка корректности реализации паттерна <br />

## Оглавление


1. [Порождающие (Creational)](#Порождающие (Creational))
    1. [Абстрактная фабрика (Abstract Factory)](#Абстрактная-фабрика)
    2. [Одиночка (Singleton)](#Одиночка-(Singleton))
2. [Структурные (Structural)](#Структурные-(Structural))
    1. [Адаптер (Adapter)](#Адаптер-(Adapter))
    2. [Декоратор (Decorator)](#Декоратор-(Decorator))
3. [Поведенческие (Behavioral)](#Поведенческие-(Behavioral))
    1. [Итератор (Iterator)](#Итератор-(Iterator))
    2. [Наблюдатель (Observer)](#Наблюдатель-(Observer))
    3. [Посредник (Mediator)](#Посредник-(Mediator))
4. [Архитектурные (Architectural)](#Архитектурные-(Architectural))
    1. [Внедрение зависимостей (Dependency Injection)](#Итератор-(Iterator))

## Порождающие (Creational)

С помощью пораждающих паттернов у нас есть возможность удобно и безопасносно создавать объекты или группы объектов.
____
### Абстрактная фабрика
__Абстрактная фабрика__ (Abstract Factory) – это порождающий паттерн проектирования, который позволяет создавать семейства связанных объектов, не привязываясь к конкретным классам создаваемых объектов. <br />
Нам нужен такой способ создавать объекты, чтобы они сочетались с другими одного и того же семейства. Кроме того, мы не хотим вносить изменения в существующий код при добавлении новых объектов в программу. <br /><br>
> Данный паттерн необходимо использовать, когда система не должна зависеть от способа создания и компоновки новых объектов и когда создаваемые объекты должны использоваться вместе и являются взаимосвязанными.

<br>Предположим, что у нас есть какая-то компания, в которой работают сотрудники. Для простоты у нас есть два типа работников: __программист__ и __директор__. У каждого сотрудника есть девайс (компьютер и ноутбук) и служебный транспорт (пусть будет BMW и LADA). <br> <br>
:one: Для начала создадим два абстрактных класса: __WorkingCar__ (транспорт для нашего сотрудника) и __WorkingDevice__ (устройство, на котором наш сотрудник будет работать). Начнем с автомобиля: у него есть модель, цена и год выпуска. Помимо этого у нас будет абстрактный метод получения стоимости налога:
```C#
/// <summary>
/// Рабочий автомобиль.
/// </summary>
public abstract class WorkingCar
{
	/// <summary>
	/// Модель автомобиля.
	/// </summary>
	protected string _model;

	/// <summary>
	/// Цена.
	/// </summary>
	protected int _price;

	/// <summary>
	/// Год выпуска.
	/// </summary>
	protected int _releaseYear;
	
	/// <summary>
	/// Получить стоимость налога.
	/// </summary>
	/// <returns>Налог.</returns>
	public abstract int GetTax();
}
```
Аналогично реализовываем абстрактный класс рабочего устройства, у коготого есть цена и модель. В данном классе тоже будет абстрактный метод, который будет расчитывать стоимость дополнительных аксессуаров (например, зарядка, мышка и так далее).
```C#
/// <summary>
/// Рабочее устройство.
/// </summary>
public abstract class WorkingDevice
{
	/// <summary>
	/// Модель.
	/// </summary>
	protected string _model;

	/// <summary>
	/// Цена.
	/// </summary>
	protected int _price;
	
	/// <summary>
	/// Получить стоимость дополнительных аксессуаров.
	/// </summary>
	/// <returns>Стоимость дополнительных аксессуаров.</returns>
	public abstract int GetAccessoriesCost();
}
```
:two: После этого нам необходимо создать __классы наследники__: у WorkingCar классами-наследниками будут LADA и BMW, у WorkingDevice - Laptop и Computer. В данных классах наследникам мы реализуем методы, которые были в наших абстрактных классах.<br>
:three: Теперь нам необходимо реализовать __интерфейс__ фабрики по созданию сотрудника, в котором будет 2 метода: создание объекта __рабочего устройства__ и создание объекта __рабочего автомобиля__. 
```C#
/// <summary>
/// Фабрика сотрудника.
/// </summary>
public interface IWorkerFactory 
{
	/// <summary>
	/// Создание рабочего устройства для сотрудника. 
	/// </summary>
	/// <returns>Рабочее устройство.</returns>
	WorkingDevice CreateWorkingDevice();

	/// <summary>
	/// Создание рабочего автомобиля.
	/// </summary>
	/// <returns>Рабочий автомобиль.</returns>
	WorkingCar CreateWorkingCar();
}
```
Далее нам необходимо создать фабрику по созданию программиста и директора, реализующую интерфейс __IWorkerFactory__. Рассмотрим пример фабрики по созданию директора. У нас метод __CreateWorkingCar()__ возвращает объект автомобиля марки __BMW__ и метод __CreateWorkingDevice()__ объект __компьютера__ в качестве рабочего устройства.
```C#
/// <summary>
/// Фабрика директора.
/// </summary>
public class DirectorFactory : IWorkerFactory 
{
	/// <summary>
	/// Создание рабочего автомобиля.
	/// </summary>
	/// <returns>Рабочий автомобиль.</returns>
	public WorkingCar CreateWorkingCar() => new BMW();

	/// <summary>
	/// Создание рабочего устройства.
	/// </summary>
	/// <returns>Рабочее устройство.</returns>
	public WorkingDevice CreateWorkingDevice() => new Computer();
}
```
> Аналогично реализована фабрика по созданию объекта программиста: метод __CreateWorkingCar()__ возвращает объект Lada и метод __CreateWorkingDevice()__ возвращает ноутбук. 

<br>:four: Теперь у нас есть все условия для того, чтобы создать класс самого сотрудника. Как было сказано ранее, у сотрудника есть служебный автомобиль и рабочее устройство. Добавим их в поля сотрудника.<br>
В конструкторе в качестве параметра мы будем принимать интерфейс __IWorkerFactory__. Напомню, его у нас реализуют ProgrammerFactory и DirectorFactory.<br>
           __В итоге у нас получился следующий код:__
```C#
/// <summary>
/// Сотрудник.
/// </summary>
public class Worker
{
		
	/// <summary>
	/// Рабочий автомобиль.
	/// </summary>
	private WorkingCar _workingCar; 

	/// <summary>
	/// Рабочее устройство.
	/// </summary>
	private WorkingDevice _workingDevice;

	/// <summary>
	/// Создание сотрудника с помощью указанных параметров.
	/// </summary>
	/// <param name="workerFactory">Фабрика сотрудника.</param>
	/// <exception cref="ArgumentNullException">Фабрика сотрудника равна null!</exception>
	public Worker(IWorkerFactory workerFactory)
	{
		if (workerFactory == null)
		{
			throw new ArgumentNullException(nameof(workerFactory),
				"Фабрика для создания сотрудника равна null!");
		}

		_workingCar = workerFactory.CreateWorkingCar();
		_workingDevice = workerFactory.CreateWorkingDevice();
	}
	
	/// <summary>
	/// Получить стоимость налога за автомобиль.
	/// </summary>
	/// <returns>Стоимость налога.</returns>
	public int GetTax() => _workingCar.GetTax();

	/// <summary>
	/// Получить стоимость дополнительных аксессуаров для рабочего устройства.
	/// </summary>
	/// <returns>Стоимость дополнительных аксессуаров.</returns>
	public int GetAccessoriesCost() => _workingDevice.GetAccessoriesCost();
}
```
:white_check_mark: Из преимуществ данного паттерна стоит отметить упрощение добавления новых продуктов, их сочетаемость, а также избавление кода от привязки к конкретным классам продуктов. <br>
:x: К недостаткам стоит отнести возможное усложнение кода из-за создания огромного количества вспомогательных классов.
