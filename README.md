# Паттерны проектирования с примерами на C#
В данном репозитории содержатся реализации паттернов на языке программирования C#. Ниже вы можете ознакомиться с описанием паттернов, их назначением, а также преимуществами и недостатками. <br />
После изучения теории можете переходить в код - он хорошо задокументирован, поэтому разобраться в нем не составит труда. <br />
Помимо документации в данном файле будет пошагово описана реализация каждого паттерна, которыцй есть в репозитории.
### В папке каждого паттерна содержатся: <br />
* его реализация в библиотеке классов; <br />
* демонстрация работы в консольном приложении; <br />
* [тестирование](https://github.com/stacenko-developer/UnitTests "тестирование") методов классов и проверка корректности реализации паттерна <br />

## Оглавление


1. [Порождающие паттерны (Creational)](#Порождающие-паттерны)
    1. [Абстрактная фабрика (Abstract Factory)](#Абстрактная-фабрика)
    2. [Одиночка (Singleton)](#Одиночка)
2. [Структурные паттерны](#Структурные-паттерны)
    1. [Адаптер (Adapter)](#Адаптер)
    2. [Декоратор (Decorator)](#Декоратор)
3. [Поведенческие (Behavioral)](#Поведенческие-паттерны)
    1. [Итератор (Iterator)](#Итератор)
    2. [Наблюдатель (Observer)](#Наблюдатель)
    3. [Посредник (Mediator)](#Посредник)
4. [Архитектурные (Architectural)](#Архитектурные-паттерны)
    1. [Внедрение зависимостей (Dependency Injection)](#Внедрение-зависимостей)

## Порождающие паттерны

С помощью пораждающих паттернов (Creational) у нас есть возможность удобно и безопасносно создавать объекты или группы объектов.
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
:white_check_mark: __Преимущества паттерна Abstract Factory__: упрощение добавления новых продуктов, их сочетаемость, а также избавление кода от привязки к конкретным классам продуктов. <br>
:x: __Недостатки__: возможное усложнение кода из-за создания огромного количества вспомогательных классов.
____
### Одиночка
__Одиночка (Singleton)__ - это __паттерн__, который позволяет гарантировать, что класс имеет только один экземпляр, обеспечивая при этом глобальную точку доступа к этому экземпляру. <br>
Модель Singleton решает две проблемы одновременно, __нарушая принцип единой ответственности__: <br><br>
:one: Гарантия того, что класс имеет только один экземпляр. Это может пригодиться, когда необходимо контролировать доступ к какому-либо общему ресурсу, например, к базе данных или файлу. <br>
:two: Предоставление глобальной точки доступа к этому экземпляру.
> Шаблон требует специальной обработки в __многопоточной среде__, чтобы несколько потоков не создавали экземпляр класса несколько раз.

Теперь перейдем к реализации данного __паттерна__. Пусть у нас есть какой-то сайт, в котором есть разделы. Раздел будет иметь следующие свойства: название и код (идентификатор). <br>
```C#
/// <summary>
/// Раздел.
/// </summary>
public class Section
{
	/// <summary>
	/// Название раздела.
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// Код раздела.
	/// </summary>
	public string Code { get; set; } 
}
```
Теперь мы хотим создать экземпляр класса базы данных __SectionDatabase__, в которой будут храниться наши разделы. <br><br>
:one: В данном классе создаем статическое поле, имеющее тот же тип, что и сам класс: SectionDatabase. По умолчанию он будет равен null, так как еще ни разу не был создан экземпляр данного класса.<br>
:two: Создаем заблокированный объект, который мы будем использовать для синхронизации. Это означает, что в критическую область кода потоки будут заходить по очереди.<br>
:three: Создаем список разделов, в который мы будем добавлять созданные разделы.<br>
:four: Создаем защищенный конструктор. Это необходимо для того, чтобы у нас не было возможности вызвать публичный конструктор, так как в этом случае мы не сможем контролировать количество созданных экземпляров класса SectionDatabase.<br>
:five: Добавляем публичный метод __Initialize__. Его назначение - инициализировать объект базы данных, а также проверять: если объект базы данных уже был создан, то необходимо возврать уже ранее созданный экземпляр. Также не забываем про использование синхронизации для критической секции. <br><br>
Теперь посмотрим на получившийся результат (код представлен в упрощенном виде, полная реализация доступна в репозитории):
```C#
/// <summary>
/// База данных разделов. Реализация паттерна Singleton.
/// </summary>
public class SectionDatabase
{
        /// <summary>
        /// База данных разделов.
        /// </summary>
        private static SectionDatabase Database = null;

        /// <summary>
        /// Заблокированный объект.
        /// Служит для синхронизации потоков.
        /// </summary>
        private static object LockObject = new object(); 

        /// <summary>
        /// Список разделов.
        /// </summary>
        private List<Section> _sectionsList;

        /// <summary>
        /// Создает хранилище данных разделов.
        /// </summary>
        protected SectionDatabase()
        {
        }
	
        /// <summary>
        /// Инициализация хранилища данных разделов.
        /// </summary>
        /// <returns>Хранилище данных разделов.</returns>
        public static SectionDatabase Initialize()
        {
            if (Database == null)
            {
                lock (LockObject)
                {
                    if (Database == null)
                    {
                        Database = new SectionDatabase();
                    }
                }
            }

            return Database;
        }
    }
```
:white_check_mark: __Преимущества паттерна Singleton__: класс гарантированно имеет только один экземпляр и не более, у нас есть точка доступа к единственному экземпляру (в нашем случае это метод Initialize) <br>
:x: __Недостатки__: нарушение принципа единой ответственности (Single Responsibility Principle), требуется особая обработка в многопоточной среде.
___
## Структурные паттерны
__Структурные паттерны__ (Structural) - цель их применения заключается в том, что благодаря им вы можете совмещать и сочетать сущности вместе.
___
### Адаптер
Адаптер (Adapter) - это структурный шаблон проектирования, который используется для организации использования методов объекта, недоступного для модификации, через специально созданный интерфейс.<br>
> __Проблема__: у нас уже есть конкретный класс и нужно, чтобы этот класс реализовывал определенный интерфейс, при этом сам класс менять нельзя.

:white_check_mark: Решение: мы пишем класс, который будет реализовывать необходимый интерфейс, затем мы наследуем наш класс от того класса, который нам нужно изменить без прямого вмешательства в тот класс.
Предположим, что у нас есть офис, в котором работают сотрудники. У офиса есть название, адрес:
```C#
/// <summary>
/// Офис.
/// </summary>
public class Office
{
        /// <summary>
        /// Название.
        /// </summary>
        protected string _name; 

        /// <summary>
        /// Адрес.
        /// </summary>
        protected string _address;

        /// <summary>
        /// Создает офис с помощью указанных параметров.
        /// </summary>
        /// <param name="name">Название офиса.</param>
        /// <param name="address">Адрес офиса.</param>
        public Office(string name, string address)
        {
            Validator.ValidateStringText(name);
            Validator.ValidateStringText(address);

            _name = name;
            _address = address;
        }
}
```
Теперь нам необходимо добавить метод "переезда офиса". То есть метод, который устанавливает новое значение для адреса. Не будем забывать, что существующий класс нельзя модифицировать. Решим проблему с помощью паттерна Адаптер:<br>
:one: Создадим интерфейс IMovable, в котором будет один метод Move, принимающий новый адрес офиса.
```C#
/// <summary>
/// Содержит методы, связанные с переездом офиса.
/// </summary>
public interface IMovable
{
	/// <summary>
	/// Изменение адреса офиса.
	/// </summary>
	/// <param name="newAddress">Новый адрес.</param>  
	void Move(string newAddress);
}
```
:two: Создадим класс-наследник нашего базового класса Office, пусть это будет офис какой-то конкретной компании (например, Норбит). В данном классе мы реализуем интерфейс __IMovable__.
```C#
/// <summary>
/// Офис Норбит. Реализация паттерна Адаптер.
/// </summary>
public class NrbOffice : Office, IMovable
{
	/// <summary>
	/// Создает офис Норбит с помощью указанных параметров. 
	/// </summary>
	/// <param name="name">Название офиса.</param>
	/// <param name="address">Адрес офиса.</param>
	public NrbOffice(string name, string address)
		: base(name, address)
	{
	}

	/// <summary>
	/// Изменение адреса офиса.
	/// </summary>
	/// <param name="newAddress">Новый адрес.</param>
	public void Move(string newAddress)
	{
		Validator.ValidateStringText(newAddress);

		_address = newAddress;
	}
}
```
:white_check_mark: __Преимущества паттерна Adapter__: возможность отделения интерфейса или кода преобразования данных от основной бизнес-логики программы.<br>
:x: __Недостатки__: общая сложность кода увеличивается. 
___
### Декоратор
__Декоратор (Decorator)__ - это паттерн, который позволяет динамически подключать к объекту дополнительную функциональность, оборачивая объект в обертки. <br>
Для того, чтобы определить какой-либо новый функционал, как правило, мы прибегаем к наследованию. Декораторы в отличие от наследования позволяют динамически в процессе выполнения определять новые возможности у объектов.<br>
> Можно использовать несколько разных обёрток одновременно и вы получите бъединённое поведение сразу всех обёрток.

Давайте теперь реализуем данный паттерн. Пусть у нас также будут сотрудники какой-то компании. У нас есть __задача__: отфильтровать сотрудника по определенному признаку.<br>
:one: Для начала создадим абстрактный класс __WorkersFilter__, в котором будет метод __GetFiltratedList()__, который будет возвращать нам отфильтрованный список сотрудников.
```C#
/// <summary>
/// Фильтр.
/// </summary>
public abstract class WorkersFilter
{
        /// <summary>
        /// Получение отфильтрованного списка.
        /// </summary>
        /// <returns>Отфильтрованный список.</returns>  
        public abstract List<Worker> GetFiltratedList(); 
}
```
:two: Создаем класс-наследник NorbitWorkersFilter, базовый класс у которого WorkersFilter. В наследнике мы реализуем логику метода GetFiltratedList(). То есть текущий фильтр будет возвращать коллекцию, у всех сотрудников которой значение свойства __Organization__ равно __Norbit__.
```C#
/// <summary>
/// Фильтр сотрудников.
/// </summary>
public class NorbitWorkersFilter : WorkersFilter
{
	/// <summary>
	/// Сотрудники.
	/// </summary>
	protected static List<Worker> Workers; 

	/// <summary>
	/// Название организации по умолчанию.
	/// </summary>
	private string _defaultOrganization = "Норбит";

	/// <summary>
	/// Создание фильтра сотрудников с помощью указанных параметров.
	/// </summary>
	/// <param name="workers">Список сотрудников.</param>
	/// <exception cref="ArgumentNullException">Список сотрудников или его элементы равны null!</exception>
	public NorbitWorkersFilter(List<Worker> workers)
	{
		if (workers == null || workers.FindIndex(worker => worker == null) != -1)
		{
			throw new ArgumentNullException(nameof(workers), "Список сотрудников или его элементы равны null!");
		}

		Workers = workers;
	}

	/// <summary>
	/// Получение отфильтрованного списка сотрудников.
	/// </summary>
	/// <returns>Отфильтрованный список сотрудников.</returns>
	public override List<Worker> GetFiltratedList() => Workers
		.Where(worker => worker.Organization == _defaultOrganization)
		.ToList();
}
```
:three: Создаем класс дополнительного условия фильтрации, который будет классом-наследником класс NorbitWorkersFilter. Он будет создаваться с помощью конструктора, который будет приниматт объект типа NorbitWorkersFilter. 
```C#
/// <summary>
/// Дополнительное условие фильтрации.
/// </summary>
public class AdditionalFilteringCondition : NorbitWorkersFilter
{
	/// <summary>
	/// Фильтр сотрудников Норбит.
	/// </summary>
	protected NorbitWorkersFilter _filter; 

	/// <summary>
	/// Создает дополнительное условие фильтрации с помощью указанных параметров.
	/// </summary>
	/// <param name="filter">Фильтр сотрудников Норбит.</param>
	public AdditionalFilteringCondition(NorbitWorkersFilter filter)
		: base(Workers)
	{
		if (filter == null)
		{
			throw new ArgumentNullException(nameof(filter), "Фильтр равен null!");
		}

		_filter = filter;
		Workers = base.GetFiltratedList();
	}
}
```
> Перед тем, как список будет отфильтрован дополнительным условием, он сначала будет отфильтрован фильтров базового метода с помощью __base.GetFiltratedList()__

:four: Добавим классы, которые будут фильтровать сотрудников по возрасту и должности. 
```C#
/// <summary>
/// Фильтр сотрудников по возрасту.
/// </summary>
public class AgeWorkersFilter : AdditionalFilteringCondition
{
	/// <summary>
	/// Минимальное допустимое значение возраста.  
	/// </summary>
	private int _defaultMinCorrectAge = 25; 

	/// <summary>
	/// Создание фильтра сотрудников по возрасту с помощью указанных параметров.
	/// </summary>
	/// <param name="filter">Базовый фильтр сотрудников Норбит.</param>
	public AgeWorkersFilter(NorbitWorkersFilter filter)
		: base(filter)
	{
		Workers = filter.GetFiltratedList();
	}

	/// <summary>
	/// Получение отфильтрованного списка сотрудников.
	/// </summary>
	/// <returns>Отфильтрованный список сотрудников.</returns>
	public override List<Worker> GetFiltratedList() => Workers
		.Where(worker => worker.Age >= _defaultMinCorrectAge)
		.ToList();
}
```
> По такому же принципу реализован класс PostWorkersFilter. Для подробного ознакомления рекомендую перейти в репозиторий. Также с помощью консольного приложения вы можете наблюдать снижения количества сотрудников в коллекции по мере добавления к базовому фильтру сотрудников дополнительный оберток.
