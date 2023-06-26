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
    3. [Строитель (Builder)](#Строитель)
    4. [Прототип (Prototype)](#Прототип)
    5. [Фабричный метод (Factory Method)](#Фабричный-метод)
2. [Структурные паттерны](#Структурные-паттерны)
    1. [Адаптер (Adapter)](#Адаптер)
    2. [Декоратор (Decorator)](#Декоратор)
3. [Поведенческие (Behavioral)](#Поведенческие-паттерны)
    1. [Итератор (Iterator)](#Итератор)
    2. [Наблюдатель (Observer)](#Наблюдатель)
    3. [Посредник (Mediator)](#Посредник)
    4. [Шаблонный метод (Template Method)](#Шаблонный-метод)
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
:white_check_mark: __Преимущества паттерна Abstract Factory__: упрощение добавления новых продуктов, их сочетаемость, а также избавление кода от привязки к конкретным классам продуктов.<br>
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
:five: Добавляем публичный метод __Initialize__. Его назначение - инициализировать объект базы данных, а также проверять: если объект базы данных уже был создан, то необходимо возврать уже ранее созданный экземпляр. Также не забываем про использование синхронизации для критической секции.<br><br>
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
:white_check_mark: __Преимущества паттерна Singleton__: класс гарантированно имеет только один экземпляр и не более, у нас есть точка доступа к единственному экземпляру (в нашем случае это метод Initialize).<br>
:x: __Недостатки__: нарушение принципа единой ответственности (Single Responsibility Principle), требуется особая обработка в многопоточной среде.
___
### Строитель
__Строитель (Builder)__ - это порождающий паттерн проектирования, который позволяет разделить создание экземпляра класса на несколько шагов. Данный паттерн может быть полезен, когда созданние какого-либо экземпляра класса требует много разных этапов и когда также важно, в каком порядке эти этапы будут выполняться.<br>
> :x: Проблема заключается в том, что у нас может быть какой-то сложный объект и его создание может привести к огромному количеству кода в конструкторе
Паттерн Builder (Строитель) состоить из двух участников:
* __Строитель (Builder)__ – предоставляет методы для сборки частей экземпляра класса;
* __Распорядитель (Director)__ – определяет саму стратегию того, как будет происходить сборка: определяет, в каком порядке будут вызываться методы Строителя.

Реализуем данный паттерн на основе примера: у нас есть завод по производству компьютеров. У нас есть разработчики компьютеров и директор.<br>
:one: Создадим класс компьютера, для простоты он будет содержать всего 4 характеристики:
```C#
/// <summary>
/// Содержит методы для разработчика компьютеров.
/// </summary>
public interface IComputerDeveloper
{   
	/// <summary>
	/// Установка процессора.
	/// </summary>
	void SetProcessor();
	
	/// <summary>
	/// Установка оперативной памяти.
	/// </summary>
	void SetRandomAccessMemory();
	
	/// <summary>
	/// Установка операционной системы.
	/// </summary>
	void SetOperationSystem();
	
	/// <summary>
	/// Получение компьютера.
	/// </summary>
	/// <returns>Компьютер.</returns>
	Computer GetComputer();
}
```
:two: Теперь создадим интерфейс __IComputerDeveloper__, которые будет содержать методы разработчика компьютеров: 
```C#
/// <summary>
/// Содержит методы для разработчика компьютеров.
/// </summary>
public interface IComputerDeveloper
{   
        /// <summary>
        /// Установка процессора.
        /// </summary>
        void SetProcessor();

        /// <summary>
        /// Установка оперативной памяти.
        /// </summary>
        void SetRandomAccessMemory();

        /// <summary>
        /// Установка операционной системы.
        /// </summary>
        void SetOperationSystem();

        /// <summary>
        /// Получение компьютера.
        /// </summary>
        /// <returns>Компьютер.</returns>
        Computer GetComputer();
}
```
:three: Затем создадим классы HPComputerDeveloper (разработчик компьютеров HP) и DELLComputerDeveloper (Разработчик компьютеров DELL), в которых будет реализован интерфейс IComputerDeveloper. Рассмотрим реализация класса HPComputerDeveloper, класс DELLComputerDeveloper реализован аналогично.
```C#
/// <summary>
/// Разработчик компьютеров HP.
/// </summary>
public class HPComputerDeveloper : IComputerDeveloper
{
        /// <summary>
        /// Компьютер.
        /// </summary>
        private Computer _computer;

        /// <summary>
        /// Модель.
        /// </summary>
        private string _model = "HP";

        /// <summary>
        /// Процессор.
        /// </summary>
        private string _processor = "Intel Core i5-7400";

        /// <summary>
        /// Количество оперативной памяти.
        /// </summary>
        private int _randomAccessMemoryCount = 8;

        /// <summary>
        /// Операционная система.
        /// </summary>
        private string _operationSystem = "Windows 10 Pro";

        /// <summary>
        /// Создание разработчика компьютеров HP.
        /// </summary>
        public HPComputerDeveloper() 
        {
            _computer = new Computer();
            _computer.Model = _model;
        }

        /// <summary>
        /// Установка процессора.
        /// </summary>
        public void SetProcessor()
        {
            _computer.Processor = _processor;
        }

        /// <summary>
        /// Установка оперативной памяти.
        /// </summary>
        public void SetRandomAccessMemory()
        {
            _computer.RandomAccessMemory = _randomAccessMemoryCount;
        }

        /// <summary>
        /// Установка операционной системы.
        /// </summary>
        public void SetOperationSystem()
        {
            _computer.OperationSystem = _operationSystem;
        }

        /// <summary>
        /// Получение компьютера.
        /// </summary>
        /// <returns>Компьютер.</returns>
        public Computer GetComputer() => _computer;
}
```
:four: Теперь создадим класс Director, который будет иметь поле IComputerDeveloper, то есть, он будет принимать в конструкторе одного из разработчиков компьютеров и в зависимости от разработчика создавать определенный компьютер.
```C#
/// <summary>
/// Директор.
/// </summary>
public class Director
{
        /// <summary>
        /// Разработчик компьютеров.
        /// </summary>
        private IComputerDeveloper _computerDeveloper;

        /// <summary>
        /// Создание директора с помощью указанных параметров.
        /// </summary>
        /// <param name="computerDeveloper">Разработчик компьютеров.</param>
        /// <exception cref="ArgumentNullException">Разработчик компьютеров равен null!</exception>
        public Director(IComputerDeveloper computerDeveloper) 
        {
            if (computerDeveloper == null)
            {
                throw new ArgumentNullException(nameof(computerDeveloper), "Разработчик компьютеров равен null!");
            }

            _computerDeveloper = computerDeveloper;
        }

        /// <summary>
        /// Создание полноценного компьютера.
        /// </summary>
        /// <returns>Созданный компьютер.</returns>
        public Computer CreateFullComputer()
        {
            _computerDeveloper.SetProcessor();
            _computerDeveloper.SetRandomAccessMemory();
            _computerDeveloper.SetOperationSystem();

            return _computerDeveloper.GetComputer();
        }

        /// <summary>
        /// Создание компьютера без операционной системы.
        /// </summary>
        /// <returns>Созданный компьютер.</returns>
        public Computer CreateComputerWithoutOperationSystem()
        {
            _computerDeveloper.SetProcessor();
            _computerDeveloper.SetRandomAccessMemory();

            return _computerDeveloper.GetComputer();
        }
}
```
> За счет того, что мы разбили процесс создания компьютера на отдельный шаги, мы можем создавать разные объекты, например, полноценный компьютер или компьютер без операционной системы.

:white_check_mark: __Преимущества паттерна Builder__: контроль за этапами создания экземпляра класса, в зависимости от этапов можно получить различные объекты.<br>
:x: __Недостатки__: жесткая связка конкретного Builder и продукта, который он создает. 
___
### Прототип
__Прототип (Prototype)__ - это такой паттерн, который используется ​для создания новых объектов с помощью клонирования существующих. Для того, чтобы определение паттерна было более понятно, приведу конкретный пример.<br>
Предположим, что у нас есть биржа фриланса, где есть заказчики и исполнители.<br>
:one: Для начала создадим абстрактный класс User - пользователь биржи фриланса. У пользователя будут идентификатор, ФИО и абстрактный метод Clone. Это означает, что мы обязательно должны реализовать его в классе-наследнике.
```C#
/// <summary>
/// Пользователь
/// </summary>
public abstract class User
{
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; set; }
        
        /// <summary>
        /// Отчество.
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Клонирование пользователя.
        /// </summary>
        /// <returns>Нового пользователя.</returns>
        public abstract User Clone();

        /// <summary>
        /// Строковое представления объекта пользователя.
        /// </summary>
        /// <returns>Данные пользователя в виде строки.</returns>
        public override string ToString() => $"Идентификатор - {Id} Имя - {FirstName} Фамилия - {LastName} Отчество - {Patronymic}";
}
```
:two: Теперь реализуем класс-наследник исполнителя: в него не будем добавлять дополнительные свойства. Реализация метода Clone будет выглядеть так: 
```C#
/// <summary>
/// Исполнитель.
/// </summary>
public class Executor : User
{
        /// <summary>
        /// Клонирование пользователя.
        /// </summary>
        /// <returns>Нового пользователя.</returns>
        public override User Clone() => (Executor)MemberwiseClone();

        /// <summary>
        /// Строковое представления объекта исполнителя.
        /// </summary>
        /// <returns>Данные исполнителя в виде строки.</returns>
        public override string ToString() => $"Данные исполнителя: {base.ToString()}";
}
```
> В данном случае мы можем выполнить неполное (поверхностное) копирование. Это подходит тогда, когда у нас все поля Executor являются значимыми типами (исключение: string).

Теперь рассмотрим второй класс-наследник: Customer. 
```C#
/// <summary>
/// Заказчик
/// </summary>
public class Customer : User
{
        /// <summary>
        /// Паспорт.
        /// </summary>
        public Passport Passport { get; set; }

        /// <summary>
        /// Создание пользователя.
        /// </summary>
        public Customer()
        {
            Passport = new Passport();
        }

        /// <summary>
        /// Клонирование пользователя.
        /// </summary>
        /// <returns>Нового пользователя.</returns>
        public override User Clone()
        {
            var customer = (Customer)MemberwiseClone();
            customer.Passport = new Passport();
            customer.Passport.Series = Passport.Series;
            customer.Passport.Number = Passport.Number;
            customer.Passport.ReceiptPlace = Passport.ReceiptPlace;

            return customer;
        }

        /// <summary>
        /// Строковое представления объекта заказчика.
        /// </summary>
        /// <returns>Данные заказчика в виде строки.</returns>
        public override string ToString() => $"Данные заказчика: {base.ToString()} {Passport}";
}
```
> Здесь у нас уже присутствует класс Passport - это ссылочный тип, соответсвенно, мы не можем использовать неполное копирование. Если мы будем использовать неполное копирование, то у нас будет два заказчика ссылаться на один и тот же объект паспортных данных. Поэтому нам придется создать новый объект паспорта и вручную его проинициализировать.

Также, чтобы убедиться в том, что у нас создаются два абсолютно разных объекта, которые не ссылаются на одни и те же поля, рекомендую запустить тесты в проекте PrototypeTests, где происходит данная проверка.<br><br>
:white_check_mark: __Преимущества паттерна Prototype__: клонирование объектов без привязки к конкретным классам, сокращение кода инициализации экземплятор классов.<br>
:x: __Недостатки__: Проблемы с клонированием составных объектов, то есть, тех объектов, которые внутри содержат другие объекты.
___
### Фабричный метод
__Фабричный метод (Factory Method)__ - это порождающий паттерн проектирования, который определяет интерфейс для создания объектов определенного класса, но именно в подклассах принимается решение о типе объекта, который будет создан.<br>
> :white_check_mark: Фабричный метод будет полезен, если мы заранее не знаем, объекты каких типов мы хотим создать.

У нас есть следующие участники: 
* базовый класс какого-либо продукта;
* наследники базового класса продукта;
* базовый класс создателя этого продукта;
* создатели-наследники базового класса создателя, которые созданию продукты-наследники базового класса продукта<br>

:one: Реализуем паттерн на примере создания телефонов. Пусть у нас будет базовый класс __Phone__, содержащий следующие свойства: 
```C#
/// <summary>
/// Телефон.
/// </summary>
public abstract class Phone
{
        /// <summary>
        /// Цена.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Модель.
        /// </summary>
        public string Model { get; set; } = string.Empty;

        /// <summary>
        /// Процессор.
        /// </summary>
        public string Processor { get; set; } = string.Empty;

        /// <summary>
        /// Оперативная память.
        /// </summary>
        public int RandomAccessMemory { get; set; }

        /// <summary>
        /// Строковое представления объекта телефона.
        /// </summary>
        /// <returns>Данные телефона в виде строки.</returns>
        public override string ToString() => $"Цена = {Price} Модель = {Model} Процессор = {Processor} Оперативная память = {RandomAccessMemory}";
}
```
:two: Создадим два класса наследника: Nokia и Samsung, в них добавим по одному дополнительному свойству.
```C#
/// <summary>
/// Нокиа.
/// </summary>
public class Nokia : Phone
{
        /// <summary>
        /// Работает ли батарея.
        /// </summary>
        public bool IsBatteryWork { get; set; }

        /// <summary>
        /// Строковое представления объекта Нокиа.
        /// </summary>
        /// <returns>Данные Нокиа в виде строки.</returns>
        public override string ToString() => $"Нокиа: {base.ToString()} Работает ли батарея = {IsBatteryWork}";
}

/// <summary>
/// Самсунг.
/// </summary>
public class Samsung : Phone
{
        /// <summary>
        /// Влючена ли сейчас фронтальная камера.
        /// </summary>
        public bool IsFrontCamera { get; set; }

        /// <summary>
        /// Строковое представления объекта Самсунга.
        /// </summary>
        /// <returns>Данные Самсунга в виде строки.</returns>
        public override string ToString() => $"Самсунг: {base.ToString()} Включена ли фронтальная камера = {IsFrontCamera}";
}
```
:three: Создадим интерфейс создателя телефонов IPhoneDeveloper:
```C#
/// <summary>
/// Содержит методы для рабработчика телефонов.
/// </summary>
public interface IPhoneDeveloper
{   
        /// <summary>
        /// Создание телефона.
        /// </summary>
        /// <returns>Телефон.</returns>
        Phone CreatePhone();
}
```
:four: Создадим разработчиков телефонов Нокиа и Самсунга, реализующих интерфейсы __IPhoneDeveloper__:
```C#
/// <summary>
/// Разработчик телефонов фирмы Нокиа.
/// </summary>
public class NokiaDeveloper : IPhoneDeveloper
{
        /// <summary>
        /// Создание телефона.
        /// </summary>
        /// <returns>Телефон.</returns>
        public Phone CreatePhone() => new Nokia();
}

/// <summary>
/// Разработчик телефонов фирмы Самсунг.
/// </summary>
public class SamsungDeveloper
{
        /// <summary>
        /// Создание телефона.
        /// </summary>
        /// <returns>Телефон.</returns>
        public Phone CreatePhone() => new Samsung();
}
```
:white_check_mark: __Преимущества паттерна Factory Method__: упрощение поддержки кода, так как продукт создается в отдельном классе.<br>
:x: __Недостатки__: Значительное увеличение кода, так как для каждого класса продукта необходимо будет добавлять класс-создатель, который будет создавать данный продукт.
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
Идея паттерна в том, чтобы вынести поведение обхода коллекции из самой коллекции в __отдельный класс__.<br>
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
:white_check_mark: __Преимущества паттерна Iterator__: достигается упрощение классов хранения данных.<br>
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

:four: Теперь давайте реализуем данный класс.<br><br>
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
### Посредник 
__Посредник (Mediator)__ - это поведенческий паттерн проектирования, бгагодаря которому уменьшается связанность множества классов между собой. Это достигается за счет перемещения этих связей в один класс-посредник.<br>
Самое популярное применение посредника в C# коде – это связь нескольких компонентов __GUI__ одной программы. __Аналогия из жизни__: пилоты не общаются напрямую друг с другом, а через диспетчера.<br><br>
Давайте попробуем реализовать данный паттерн на __следующем примере__: пусть у нас есть какая-то IT-компания, в которой есть программист и тимлид. Тимлид не скидывает лично (напрямую) программисту задачу, например, в социальных сетях. Он публикует ее в __TFS__ (Team Foundation Server). <br> 

Программист заходит на TFS, чтобы проверить, не появилось ли для него задач. Если задачи есть - берет их в работу. После выполнения задачи, программист переводит ее в "ожидающие проверки". Тимлид также заходит на TFS, чтобы проверить, выполнил ли программист задачи, которые он выдал. Если сделал - проверяет их. Если есть недочеты - отправляет на доработку, если недочетов нет - закрывает задачу. Также тимлид может дать программисту новые задачи для выполнения, если таковые имеются. <br>

> В нашем примере посредником (Mediator) будет является TFS между программистом и тимлидом.

Теперь реализуем это в коде.<br>
:one: Создадим интерфейс __IMediator__ - он будет содержать методы, которыми будет обладать класс-посредник. С помощью метода __Notify__ посредник будет уведомлять обе стороны о каком-либо событии.
```C#
/// <summary>
/// Содержит методы для посредника.
/// </summary>
public interface IMediator
{
	/// <summary>
	/// Обрабатывает уведомления.
	/// </summary>
	/// <param name="worker">Работник.</param>
	/// <param name="message">Сообщение.</param>
	void Notify(Worker worker, string message);
}
```
:two: Теперь реализуем абстрактный класс Worker - это будет наш сотрудник. Он будет хранить посредника - его можно будет установить в методе __SetMediator__:
```C#
/// <summary>
/// Работник.
/// </summary>
public abstract class Worker
{
	/// <summary>
	/// Посредник.
	/// </summary>
	protected IMediator _mediator;

	/// <summary>
	///Устанавливает посредника для работника.
	/// </summary>
	/// <param name="mediator">Посредник.</param>
	/// <exception cref="ArgumentNullException">Посредник равен null!</exception>
	public void SetMediator(IMediator mediator)
	{
		if (mediator == null)
		{
			throw new ArgumentNullException(nameof(mediator), "Посредник равен null!");
		}

		_mediator = mediator;
	}
}
```
:three: Теперь создадим первый класс-наследник нашего Worker: это будет класс Programmer. У него будет два метода: начать работу и закончить работу. Причем программисту нельзя давать новую задачу, пока он не завершил предыдущую. 
```C#
/// <summary>
/// Программист.
/// </summary>
public class Programmer : Worker
{
	/// <summary>
	/// Текст задачи,над которой работает программист.
	/// </summary>
	private string _taskText = string.Empty;

	/// <summary>
	/// Получение текста задания.
	/// </summary>
	public string TaskText => _taskText;

	/// <summary>
	/// Начинает работу над задачей.
	/// </summary>
	/// <param name="taskText">Текст задачи.</param>
	public void StartWork(string taskText)
	{
		Validator.ValidateStringText(taskText);

		if (_taskText.Length != 0)
		{
			if (_mediator != null)
			{
				_mediator.Notify(this, "Программист уже работает над задачей!");
			}

			return;
		}

		_taskText = taskText;

		if (_mediator != null)
		{
			_mediator.Notify(this, $"Программист начал работу над задачей: {taskText}");
		}
	}

	/// <summary>
	/// Завершает работу над задачей.
	/// </summary>
	public void FinishWork()
	{
		if (_mediator != null)
		{
			_mediator.Notify(this, $"Программист завершил работу над задачей: {_taskText}");
		}
		_taskText = string.Empty;
	}
}
```
:four: Вторым классом-наследником будет наш Тимлид. У него будет метод __GiveTask__ - выдать задачу. 
```C#
/// <summary>
/// Тимлид.
/// </summary>
public class TeamLead : Worker
{
	/// <summary>
	/// Дать задание.
	/// </summary>
	/// <param name="taskText">Текст задания.</param>
	public void GiveTask(string taskText)
	{
		Validator.ValidateStringText(taskText);

		if (_mediator != null)
		{
			_mediator.Notify(this, "Выдаю задачу программисту: " + taskText);
		}
	}
}
```
:five: Теперь мы можем написать класс TFS, который будет реализовывать интерфейс посредника IMediator. Класс внутри будет содержать объекты тимлида и программиста, посредниками которых он является. Также у нас будет список задач. С помощью метода AddTask мы можем добавить задачу в список. В конструкторе мы не только инициализируем тимлида и программиста, но и устанавливаем им текущего посредника.<br><br>
Логика работы метода Notify следующая: если уведомление посреднику отправляет тимлид, то это означает, что он дает задачу сотруднику, значит сотрудник должен приступить к работе. Если уведомление приходит от сотрудника, то это означает, что он выполнил задачу и тимлид дает ему новую задачу: он будет давать новые задачи до тех пор, пока список задач не станет пустым.
```C#
/// <summary>
/// TFS.
/// </summary>
public class TFS : IMediator
{
	/// <summary>
	/// Программист.
	/// </summary>
	private Programmer _programmer;

	/// <summary>
	/// Тимлид.
	/// </summary>
	private TeamLead _teamLead;

	/// <summary>
	/// Задачи.
	/// </summary>
	private List<string> _tasks;

	/// <summary>
	/// Создает TFS с помощью указанных данных.
	/// </summary>
	/// <param name="programmer">Программист.</param>
	/// <param name="teamLead">Тимлид.</param>
	/// <exception cref="ArgumentNullException">Программист или тимлид равен null!</exception>
	public TFS(Programmer programmer, TeamLead teamLead)
	{
		if (programmer == null)
		{
			throw new ArgumentNullException(nameof(programmer), "Программист равен null!");
		}

		if (teamLead == null)
		{
			throw new ArgumentNullException(nameof(teamLead), "Тимлид равен null!");
		}

		_programmer = programmer;
		_teamLead = teamLead;
		programmer.SetMediator(this);
		teamLead.SetMediator(this);
		_tasks = new List<string>();
	}

	/// <summary>
	/// Обрабатывает уведомления.
	/// </summary>
	/// <param name="worker">Работник.</param>
	/// <param name="message">Сообщение.</param>
	public void Notify(Worker worker, string message)
	{
		if (worker == null)
		{
			throw new ArgumentNullException(nameof(worker), "Работник равен null!");
		}

		Validator.ValidateStringText(message);

		Console.WriteLine(message);

		if (worker is Programmer)
		{
			if (message.StartsWith("Программист завершил работу над задачей"))
			{
				if (_tasks.Count != 0)
				{
					_teamLead.GiveTask(_tasks[0]);
					_tasks.RemoveAt(0);
				}
			}

			return;
		}

		if (worker is TeamLead)
		{
			_programmer.StartWork(message);
		}
	}

	/// <summary>
	/// Добавить задачу.
	/// </summary>
	/// <param name="taskText">Текст задачи.</param>
	public void AddTask(string taskText)
	{
		Validator.ValidateStringText(taskText);
  
		_tasks.Add(taskText);
	}
}
```
:white_check_mark: __Преимущества паттерна Mediator__: Достигается устранение зависимости между компонентами, благодаря чему их можно повторно использовать, более удобным становится взаимодействие между компонентами, также управление компонентами централизовано.<br>
:x: __Недостатки__: Код посредника может быть очень большим.
___
### Шаблонный метод
__Шаблонный метод__ (Template Method) - это поведенческий паттерн проектирования, который определяет общий алгоритм поведения подклассов. При этом подклассы имеют возможность переопределять части этого алгоритма, не меняя при этом его общей структуры.
> :white_check_mark: Если бы мы не использовали данный паттерн, то нам приходилось бы явно прописывать реализацию алгоритма в каждой подклассе, несмотря на то, что алгоритмы в этих подклассах имеют небольшие различия.

Рассмотрим реализацию шаблонного метода на конкретном примере: пусть у нас будет бухгалтерия, в котором выдают зарплату для сотрудников.<br>
:one: Реализуем класс Worker, содержащий необходимые свойства, которыми будет обладать каждый сотрудник. 
```C#
/// <summary>
/// Сотрудник.
/// </summary>
public class Worker
{
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string LastName { get; set; }    

        /// <summary>
        /// Отчество.
        /// </summary>
        public string Patronymic { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        public string Post { get; set; }

        /// <summary>
        /// Выплачена ли зарплата.
        /// </summary>
        public bool IsSalaryPaid { get; set; }
}
```
:two: Реализуем абстрактный класс бухгалтерии, в которой из полей будет список сотрудников типа Worker, которые работают в конкретной компании и словарь, в котором в зависимости от должности указана зарплата, которую должен получать сотрудник, занимая определенную должность.<br><br> 
Нам необходимо выдать зарплату сотруднику - за это отвечает метод __GetSalary__. Алгоритм выдачи зарплаты следующий: <br>
1. Сначала вызывается метод __ValidateWorkerId__, проверяющий корректности идентификатора сотрудника, которому необходимо выдать зарплату - он не должен быть null.<br>
2. Далее вызывается метод __ValidateWorkerExistence__, проверяющий существование сотрудника с указанным идентификатором.<br>
3. Затем вызывается метод __ValidatePaidSalary__, проверяющий, получал ли работник зарплату ранее, если он ее уже получил, то повторно она выплачиваться не должна.<br>
4. Последний этап - вызывается метод __GetCalculationSalary__, который расчитывает зарплату в зависимости от должности - он будет виртуальным. Это означает, что классы-наследники могут его переопределить, а могут и не переопределять, поскольку в базовом классе прописана его реализация по умолчанию. Результат метода GetCalculationSalary и будет возвращаться методом GetSalary.<br>
> __Обратите внимание__, что нам нет смысла переопределять методы из первых трех пунктов - неважно, какой компании является бухгалтерия. То есть в абсолютно любой бухгалтерии прежде чем выдать сотруднику зарплату, необходимо выполнить первые три пункта (возможно больше, в примере представлена упрощенная версия, чтобы было более понятно назначение паттерна.

:white_check_mark: Благодаря шаблонному методу нам не нужно в бухгалтерии каждой компании прописывать выполнение первых трех пунктов, потому что они уже реализованы в базовом классе __Accounting__.
```C#
/// <summary>
/// Бухгалтегия.
/// </summary>
public abstract class Accounting
{
        /// <summary>
        /// Список сотрудников для выплаты зарплаты.
        /// </summary>
        protected List<Worker> _workers = new List<Worker>();

        /// <summary>
        /// Зарплаты сотрудников.
        /// </summary>
        protected Dictionary<string, decimal> _workersSalary = new Dictionary<string, decimal>();

        /// <summary>
        /// Создание бухгалтерии.
        /// </summary>
        public Accounting()
        {   
            _workers = new List<Worker>();
            _workersSalary = new Dictionary<string, decimal>();
        }

        /// <summary>
        /// Проверка корректности идентификатора сотрудника.
        /// </summary>
        /// <exception cref="ArgumentNullException">Идентификатор сотрудника равен null!</exception>
        protected void ValidateWorkerId(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "Идентификатор сотрудника равен null!");
            }
        }

        /// <summary>
        /// Проверка наличия сотрудника в базе.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника, которого необходимо проверить.</param>
        protected void ValidateWorkerExistence(Guid id)
        {
            if (_workers.FirstOrDefault(worker => worker.Id == id) == null) 
            {
                throw new ArgumentNullException(nameof(id), "Сотрудник с указанным идентификатором не найден!");
            }
        }

        /// <summary>
        /// Проверка того, была ли выплачена зарплата работнику ранее.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <exception cref="ArgumentOutOfRangeException">Данному сотруднику уже выплачена зарплата!</exception>
        protected void ValidatePaidSalary(Guid id)
        {
            if (_workers.FirstOrDefault(worker => worker.Id == id).IsSalaryPaid)
            {
                throw new ArgumentOutOfRangeException("Данному сотруднику уже выплачена зарплата!");
            }
        }

        /// <summary>
        /// Получение расчитанной зарплаты сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>Расчитанная зарплата.</returns>
        protected virtual decimal GetCalculationSalary(Guid id)
            => _workersSalary[_workers.FirstOrDefault(worker => worker.Id == id).Post];

        /// <summary>
        /// Выплата зарплаты сотруднику.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника, которого необходимо проверить.</param>
        public decimal GetSalary(Guid id)
        {
            ValidateWorkerId(id);
            ValidateWorkerExistence(id);
            ValidatePaidSalary(id);

            _workers.FirstOrDefault(worker => worker.Id == id).IsSalaryPaid = true;

            return GetCalculationSalary(id);
        }

        /// <summary>
        /// Добавление сотрудника в базу бухгалтерии.
        /// </summary>
        /// <param name="firstName">Имя.</param>
        /// <param name="lastName">Фамилия.</param>
        /// <param name="patronymic">Отчество.</param>
        /// <param name="post">Должность.</param>
        /// <exception cref="ArgumentOutOfRangeException">Сотрудник с указанными данными уже есть в базе!</exception>
        /// <exception cref="ArgumentNullException">Указанная должность в бухгалтерии не найдена!</exception>
        public Guid AddWorker(string firstName, string lastName, string patronymic, string post)
        {
            Validator.ValidateStringText(firstName);
            Validator.ValidateStringText(lastName);
            Validator.ValidateStringText(patronymic);
            Validator.ValidateStringText(post);

            if (!_workersSalary.ContainsKey(post))
            {
                throw new ArgumentNullException("Указанная должность в бухгалтерии не найдена!");
            }

            var id = Guid.NewGuid();

            _workers.Add(new Worker
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                Patronymic = patronymic,
                Post = post,
                IsSalaryPaid = false
            });

            return id;
        }

        /// <summary>
        /// Получение сотрудника по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>Сотрудника.</returns>
        public Worker GetWorker(Guid id)
        {
            ValidateWorkerId(id);
            ValidateWorkerExistence(id);

            return _workers.First(worker => worker.Id == id);
        }

        /// <summary>
        /// Удаляет сотрудника из базы.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника, которого необходимо удалить.</param>
        /// <exception cref="ArgumentNullException">Сотрудник с указанным идентификатором не найден в базе!</exception>
        public void DeleteWorker(Guid id)
        {
            ValidateWorkerExistence(id);

            _workers.Remove(_workers.FirstOrDefault(worker => worker.Id == id));
        }
}
```
:three: Теперь реализуем первый класс-наследник базового класса Accounting - пусть это будет бухгалтерия __Сбера__ (SberAccounting). В Сбере сотрудникам помимо заработной платы выдается еще и фиксированная премия. Это значит, что нам необходимо изменить логику расчета зарплаты для сотрудников Сбера:
```C#
/// <summary>
/// Бухгалтерия Сбера.
/// </summary>
public class SberAccounting : Accounting
{
        /// <summary>
        /// Премия.
        /// </summary>
        private decimal _prize = 5000;

        /// <summary>
        /// Создание бухгалтерии Сбера.
        /// </summary>
        public SberAccounting() 
        {
            _workers = new List<Worker>();

            _workersSalary = new Dictionary<string, decimal>
            {
                {"Менеджер", 30000 },
                {"Программист", 100000 }
            };
        }

        /// <summary>
        /// Получение расчитанной зарплаты сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>Расчитанная зарплата.</returns>
        protected override decimal GetCalculationSalary(Guid id) => base.GetCalculationSalary(id) + _prize;
}
```
:four: Реализуем второй класс-наследник: бухгалтерия Озона (OzonAccounting). У Озона у сотрудников нет премии. Все сотрудники добираются на работу на корпоративном такси, соответственно, ежемесячная плата за корпоративное такси вычитается из их заработной платы. Это означает, что нам также придется переопределить расчет зарплаты и здесь:
```C#
/// <summary>
/// Бухгалтерия Ozon.
/// </summary>
public class OzonAccounting : Accounting
{
        /// <summary>
        /// Плата за корпоративное такси в месяц для поезди от дома до работы и обратно.
        /// </summary>
        private decimal _taxiCostByMonth = 15000;
	
        /// <summary>
        /// Создание бухгалтерии Озона.
        /// </summary>
        public OzonAccounting()
        {
            _workers = new List<Worker>();

            _workersSalary = new Dictionary<string, decimal>
            {
                { "Менеджер", 40000 },
                { "Программист", 90000 }
            };
        }
	
        /// <summary>
        /// Получение расчитанной зарплаты сотрудника.
        /// </summary>
        /// <param name="id">Идентификатор сотрудника.</param>
        /// <returns>Расчитанная зарплата.</returns>
        protected override decimal GetCalculationSalary(Guid id) => base.GetCalculationSalary(id) - _taxiCostByMonth;
}
```
:white_check_mark: __Преимущества паттерна Template Method__: Сокращение дублирования кода <br>
:x: __Недостатки__: По мере роста шагов в шаблонном методе возникают проблемы с его дальнейшей поддержкой.<br>
___
