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

:white_check_mark: __Преимущества паттерна Decorator__: возможность добавлять или удалять функционал из экземпляра класса во время выполнения, благодаря оберткам объединить несколько возможных вариантов поведения объекта.<br>
:x: __Недостатки__: в результате получается большое число мелких объектов, которые друг на друга похожи и отличаются способом взаимосвязи.
___
## Поведенческие паттерны
__Поведенческие паттерны__ (Behavioral) описывают способы реализации взаимодействия между объектами с отличающимися типами. При таком взаимодействии объекты могут решать более трудные задачи, чем если бы они решали их по-отдельности.
___
### Итератор
__Итератор (Iterator)__ - это поведенческий паттерн проектирования, благодаря которому у нас есть возможность последовательно обходить элементы составных объектов, при этом не раскрывая их внутреннего представления.<br>
Идея паттерна в том, чтобы вынести поведение обхода коллекции из самой коллекции в __отдельный класс__. <br>
> :white_check_mark: Зная эту информацию, давайте теперь его реализуем.

Пусть у нас будет файловая система, которая будет хранить файлы. У каждого файла есть следующие свойства:
```C#
/// <summary>
/// Файл.
/// </summary>
public class File
{
	/// <summary>
	/// Идентификатор.
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// Название.
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	/// Тип.
	/// </summary>
	public string Type { get; set; }

	/// <summary>
	/// Строковое преставление объекта файла.
	/// </summary>
	/// <returns>Данные объекта файла в виде строки.</returns>
	public override string ToString() => $"Идентификатор: {Id} Название: {Name} Тип: {Type}";
}
```
:one: Создадим интерфейс IFileIterator итератора для файловой системы:
```C#
/// <summary>
/// Содержит методы для итератора файловой системы.
/// </summary>
public interface IFileIterator
{
	/// <summary>
	/// Проверяет, есть ли в коллекции следующий элемент.
	/// </summary>
	/// <returns>Результат проверки.</returns>
	bool HasNext();

	/// <summary>
	/// Получает следующий элемент.
	/// </summary>
	/// <returns>Следующий элемент.</returns>
	File Next();
}
```
:two: Создадим интерфейс IFileNumerator, содержащий методы получения итератора из коллекции: 
```C#
/// <summary>
/// Содержит методы получения итератора из коллекции.
/// </summary>
public interface IFileNumerable
{
	/// <summary>
	/// Создание итератора.
	/// </summary>
	/// <returns>Созданный итератор.</returns>
	IFileIterator CreateNumerator(); 

	/// <summary>
	/// Количество элементов в коллекции.
	/// </summary>
	int Count { get; }

	/// <summary>
	/// Получение элемента из коллекции по индексу.
	/// </summary>
	/// <param name="index">Индекс элемента, который необходимо получить.</param>
	/// <returns>Элемент по индексу.</returns>
	File this[int index] { get; }
}
```
:three: Теперь мы можем создать конкретную файловую систему, реализующую интерфейс IFileNumerable:
```C#
/// <summary>
/// Файловая система.
/// </summary>
public class FileSystem : IFileNumerable
{
	/// <summary>
	/// Файлы, хранящиеся в файловой системе.
	/// </summary>
	private List<File> _files;

	/// <summary>
	/// Количество файлов в файловой системе.
	/// </summary>
	public int Count => _files.Count;

	/// <summary>
	/// Создание файловой системы.
	/// </summary>
	public FileSystem()
	{
		_files = new List<File>();
	}
 
	/// <summary>
	/// Проверяет выход индекса за границы списка файлов файловой системы.
	/// </summary>
	/// <param name="index">Порядковый номер элемента.</param>
	/// <exception cref="ArgumentOutOfRangeException">Индекс вышел за границы!
	/// </exception>
	private void ValidateIndex(int index)
	{
		if (index < 0 || index >= _files.Count)
		{
			throw new ArgumentOutOfRangeException("Индекс вышел за границы массива!");
		}
	}

	/// <summary>
	/// Создание итератора.
	/// </summary>
	/// <returns>Итератор.</returns>
	public IFileIterator CreateNumerator() => new FileSystemNumerator(this); // Данный класс мы создадим далее.

	/// <summary>
	/// Доступ к элементам файловой системы.
	/// </summary>
	/// <param name="index">Позиция элемента, к которому необходим доступ.</param>
	/// <exception cref="ArgumentOutOfRangeException">Индекс вышел за границы!</exception>
	public File this[int index]
	{
		get
		{
			ValidateIndex(index);
			return _files[index];
		}
	}
}
```
:four: Теперь последний шаг - реализуем класс-алгоритм обхода файловой системы, реализующий интерфейс IFileIterator.
```C#
/// <summary>
/// Реализует алгоритм обхода файловой системы.
/// </summary>
public class FileSystemNumerator : IFileIterator
{
	/// <summary>
	/// Содержит методы для создания объекта-итератора.
	/// </summary>
	private IFileNumerable _aggregate;

	/// <summary>
	/// Индекс текущего элемента.
	/// </summary>
	private int _index = 0;

	/// <summary>
	/// Создание итератора файловой системы с помощью указанных параметров.
	/// </summary>
	/// <param name="aggregate">Содержит методы для создания объекта-итератора.</param>
	/// <exception cref="ArgumentNullException">Интерфейс для создания объекта-итератора равен null!</exception>
	public FileSystemNumerator(IFileNumerable aggregate)
	{
		if (aggregate == null)
		{
			throw new ArgumentNullException(nameof(aggregate), 
				"Интерфейс для создания объекта-итератора равен null!");
		}

		_aggregate = aggregate;
	}

	/// <summary>
	/// Проверяет наличие следующего элемента.
	/// </summary>
	/// <returns>Результат проверки.</returns>
	public bool HasNext() => _index < _aggregate.Count;

	/// <summary>
	/// Получение следующего элемента из файловой системы.
	/// </summary>
	/// <returns>Следующий файл.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Индекс вышел за границы!</exception>
	public File Next()
	{
		if (!HasNext())
		{
			throw new ArgumentOutOfRangeException("Индекс вышел за границы!");
		}

		return _aggregate[_index++];
	}
}
```
:white_check_mark: __Преимущества паттерна Iterator__: достигается упрощение классов хранения данных<br>
:x: __Недостатки__: Если вы работаете только с простыми коллекциями, то вам нет необходимости использовать данный паттерн.
___
### Наблюдатель
__Наблюдатель (Observer)__ - поведенческий шаблон проектирования. Определяет зависимость типа «один ко многим» таким образом, что при изменении объекта все, зависящие от него, получают сообщение об этом событии. <br>
В dotnet есть три способа реализации данного паттерна:<br><br>
:one: __Через делегаты.__ Данный способ гарантирует наличие наблюдателя и подходит, когда нужно реализовать отношение: 1 поставщик – 1 наблюдатель. Также при данном подходе можно получить результат – ответ от подписчика.<br>
:two: __Через события.__ Любое число подписчиков. Нет гарантии наличия подписчиков. Не предусмотрено получение ответа от подписчика.<br>
:three: __Через набор интерфейсов IObserver__ (механизм для получения push-уведомлений)/IObservable (определяет поставщика push-уведомлений).<br>
> :x: Почему стоит использовать эти интерфейсы вместо событий: события плохо поддаются тестированию, данный паттерн универсален, он может использоваться и в других языках программирования. В C# есть события, а в других языках программирования их может и не быть.

:grey_exclamation: Таким образом, у нас есть __IObservable__ – определяет наблюдаемый объект и __IObserver__ – определяет наблюдателей.<br><br>
Реализуем паттерн __наблюдатель__ на примере __корпоративного портала для сотрудников__. У нас будут пользователи корпоративного портала - сотрудники компании. <br>
Сотрудники могут подписываться на уведомления о каких-либо новостях, событиях, которые будут публиковаться на корпоративном портале.<br>
Соответственно, все пользователи, которые подписаны на уведомления корпоративного портала (подписчики) будут уведомлены о каком-либо событии. В данном случае корпоративный портал будет __поставщиком данных__ для наших подписчиков. <br><br>
:one: Создаем класс Message, который будет являться объектом сообщения (уведомления), которое будут получать подписчики от поставщика данных - в нашем случае корпоративного портала.
```C#
/// <summary>
/// Сообщение.
/// </summary>
public class Message
{
	/// <summary>
	/// Текст сообщения.
	/// </summary> 
	private string _text;

	/// <summary>
	/// Автор сообщения.
	/// </summary>
	private string _author;

	/// <summary>
	/// Создание сообщения с помощью указанных данных.
	/// </summary>
	/// <param name="text">Текст сообщения.</param>
	/// <param name="author">Автор сообщения.</param>
	public Message(string text, string author)
	{
		Validator.ValidateStringText(text);
		Validator.ValidateStringText(author);

		_text = text;
		_author = author;
	}
 
	/// <summary>
	/// Строковое представление объекта сообщения.
	/// </summary>
	/// <returns>Данные сообщения в виде строки.</returns>
	public override string ToString() => $"Текст сообщения: {Environment.NewLine}{_text}" +
		$"{Environment.NewLine}Автор: {_author}";
}
```
:two: Далее мы создаем объект пользователя, реализующего интерфейс IObserver, поскольку он является наблюдателем. Параметром интерфейса выступает __Message__ - тип данных уведопления, которое будут получать подписчики.<br>
Реализуя данный интерфейс, нам необходимо реализовать логику работы методов __OnCompleted, OnError, OnNext__.
```C#
/// <summary>
/// Пользователь.
/// </summary>
public class User : IObserver<Message>
{
	/// <summary>
	/// Логин пользователя.
	/// </summary>
	private string _login; 

	/// <summary>
	/// Создает пользователя с помощью указанных параметров.
	/// </summary>
	/// <param name="login">Логин пользователя.</param>
	/// <exception cref="ArgumentNullException">Логин равен null!</exception>
	public User(string login)
	{
		Validator.ValidateStringText(login);

		_login = login;
	}
 
	/// <summary>
	/// Обработчик события, когда от поставщика данных больше не будет поступать никаких уведомлений.
	/// </summary>
	public void OnCompleted()
	{

	}

	/// <summary>
	/// Обработчик события возникновения исключения у поставщика данных при отправке уведомлений.
	/// </summary>
	/// <param name="error">Исключение, которое возникло у поставщика данных.</param>
	/// <exception cref="ArgumentNullException">Исключение равно null!</exception>
	public void OnError(Exception error)
	{
		if (error == null)
		{
			throw new ArgumentNullException(nameof(error), "Исключение равно null!");
		}

		Console.WriteLine($"Отправка уведомлений пользователю завершилась с ошибкой: {error.Message}" +
			$"{Environment.NewLine}Логин получателя: {_login}");
	}

	/// <summary>
	/// Обработчик события поступления уведомлений от поставщика данных.
	/// </summary>
	/// <param name="value">Сообщение, поступившее от поставщика данных.</param>
	/// <exception cref="ArgumentNullException">Сообщение равно null!</exception>
	public void OnNext(Message value)
	{
		if (value == null)
		{
			throw new ArgumentNullException(nameof(value), "Сообщение равно null!");
		}

		Console.WriteLine($"Полученное уведомление: {Environment.NewLine}{value}{Environment.NewLine}" +
			$"Логин получателя: {_login}");
	}
```
:three: Теперь создадим класс нашего корпоративного портала, реализующий интерфейс IObservable (наблюдаемый объект). В качестве параметра также выступает тип данных Message - тип сообщения для подписчиков.
```C#
/// <summary>
/// Корпоративный портал.
/// </summary>
public class CorporatePortal : IObservable<Message>
{
	/// <summary>
	/// Список подписчиков.
	/// </summary>
	private readonly List<IObserver<Message>> _observers; 

	/// <summary>
	/// Создание корпоративного портала.
	/// </summary>
	public CorporatePortal()
	{
		_observers = new List<IObserver<Message>>();
	}

	/// <summary>
	/// Подписка на уведомления.
	/// </summary>
	/// <param name="observer">Подписчик.</param>
	/// <returns>Объект с механизмом освобождения неуправляемых ресурсов.</returns>
	/// <exception cref="ArgumentNullException">Подписчик равен null!</exception>
	public IDisposable Subscribe(IObserver<Message> observer)
	{
		if (observer == null)
		{
			throw new ArgumentNullException(nameof(observer), "Подписчик равен null!");
		}

		_observers.Add(observer);

		return new Unsubscriber<Message>(_observers, observer); // Данные класс будет реализован далее.
	}

	/// <summary>
	/// Отправляет уведомление всем подписчикам.
	/// </summary>
	/// <param name="message">Сообщение, которое будет отправлено всем подписчикам.</param>
	/// <exception cref="ArgumentNullException">Сообщение равно null!</exception>
	public void Notify(Message message)
	{
		if (message == null)
		{
			throw new ArgumentNullException(nameof(message), "Сообщение равно null!");
		}

		foreach (var observer in _observers)
		{
			observer.OnNext(message);
		}
	}
}
```
> Несколько комментариев касательно Unsubscriber: нам необходимо, чтобы помимо подписки на событие, у пользователя была возможность и отписаться от события. В Unsubscriber должен храниться список всех подписчиков и конкретный подписчик, с которым будет происходить взаимодействие.

:four: Теперь давайте реализуем данный класс. <br><br>
:pushpin: __Обратите внимание__, что он должен реализовывать интерфейс __IDisposable__, в котором содержится метод Dispose - именно так будет происходить отписка пользователя от уведомлений корпоративного портала.
```C#
/// <summary>
/// Работает с отписками от уведомлений.
/// </summary>
/// <typeparam name="T">Тип подписчика.</typeparam>
public class Unsubscriber<T> : IDisposable
{
	/// <summary>
	/// Список подписчиков.
	/// </summary>
	private readonly List<IObserver<T>> _observers; 

	/// <summary>
	/// Подписчик.
	/// </summary>
	private readonly IObserver<T> _observer;

	/// <summary>
	/// Создание экземпляра для отписок от уведомлений с помощью указанных данных.
	/// </summary>
	/// <param name="observers">Подписчики.</param>
	/// <param name="observer">Подписчик.</param>
	/// <exception cref="ArgumentNullException">Подписчики равны null!</exception>
	public Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
	{
		if (observers == null || observers.FindIndex(subscriber => subscriber == null) != -1)
		{
			throw new ArgumentNullException(nameof(observers),
				"Список подписчиков или его элементы равны null!");
		}

		if (observer == null)
		{
			throw new ArgumentNullException(nameof(observer), "Подписчик равен null!");
		}

		if (!observers.Contains(observer))
		{
			throw new ArgumentNullException(nameof(observer),
				"Подписчик не найден в списке подписчиков!");
		}

		_observer = observer;
		_observers = observers;
	}
 
	/// <summary>
	/// Отписка подписчика от уведомлений.
	/// </summary>
	public void Dispose()
	{
		if (_observers.Contains(_observer))
		{
			_observers.Remove(_observer);
		}
	}
}
```
Отписка у нас происходит следующим образом: мы удаляем подписчика из нашей коллекции подписчиков, соответственно, ему больше не будут приходить уведомления корпоративного портала.<br><br>
:white_check_mark: __Преимущества паттерна Observer__: Можно создавать новые классы подписчиков. При этот класс наблюдаемого объекта как-то изменять не нужно.<br>
:x: __Недостатки__: Подписчики уведомляются в произвольном порядке.
___
