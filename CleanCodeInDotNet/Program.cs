
#region Naming

#region Avoid using bad names نام های بد را استفاده نکنید
//bad
using System;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using System.Threading;

int a;

//good
int daySinceModification;
#endregion 

#region Avoid Misleading Names عدم استفاده از نام های گمراه کننده

//bad
//var dataFromDb = db.GetFromService().ToList();

//good
//var listOfEmployes = _employeeService.GetEmployees().ToList();


#endregion

#region Avoid Hungarian notation از روش نام گذاری مجارستانی استفاده نکنید
//عدم اعلام نوع در نام گذازی ها

//bad
int iCounter;
string strName;

//good
int counter;
string name;

//نباید در پارامتر های دریافتی متد نیز استفاده شود

//bad
bool IsShoopOpen(string pDay, int pAmount)
{
    return default;
}

//good
bool IsShoopOpenn(string day, int amount)
{
    return default;
}

#endregion

#region Use consistent capitalization از حروف بزرگ استفاده کنید
//قانونی را برای خود در نظر بگیرید و در آن ثابت قدم باشید 
//استفاده از حروف بزرگ حرف های بسیاری برای گفتن دارد

//bad 
const int Days_In_Week = 7;
const int DaysInMonth = 30;

var songs = new List<string> { "", "", "" };
var Artists = new List<string> { "", "", "" };

bool EraseDataBase() { return default; }
bool Restore_Data_Base() { return default; }

class animal { };
class Apha { };

//good

const int DaysInWeek = 7;
const int DaysInMonth = 30;

var songs = new List<string> { "", "", "" };
var artists = new List<string> { "", "", "" };

bool EraseDataBase() { return default; }
bool RestoreDataBase() { return default; }

class Animal { };
class Apha { };


#endregion

#region Use pronounceable names از نام های قابل تلفظ استفاده کنید

//bad
class Employee
{
    public DateTime sWorkDate { get; set; }
    public DateTime ModTime { get; set; }
}


//good
class Student
{
    public DateTime StartWorkinDate { get; set; }

    public DateTime ModificationDate { get; set; }
}


#endregion

#region Use Camelcase notation از camelCase برای نام متغییر و پارامتر استفاده کنید

//bad
var employeephone = "9999";

int Calculatesalary(int workindays, int workinghour) { return 0; }

//good
var employeePhone = "232323";

int CalculateSalary(int workingDays, int workingHour) { return 0; }

#endregion

#region Use Domain Name 
//People who read your code are also programmers.
//Naming things right will help everyone be on the same page.
//We don't want to take time to explain to everyone what a variable or function is for.

//good
public class SingleObject
{
    // create an object of SingleObject
    private static SingleObject _instance = new SingleObject();

    // make the constructor private so that this class cannot be instantiated
    private SingleObject() { }

    // get the only object available
    public static SingleObject GetInstance()
    {
        return _instance;
    }

    public string ShowMessage()
    {
        return "Hello World!";
    }
}

public static void main(String[] args)
{
    // illegal construct
    // var object = new SingleObject();

    // Get the only object available
    var singletonObject = SingleObject.GetInstance();

    // show the message
    singletonObject.ShowMessage();
}



#endregion

#endregion


#region Variables


#region Avoid nesting too deeply and return early پرهیز از تکرار بیش از حد if, پرهیز از عمیق کردن شرط
//Too many if else statements can make the code hard to follow.
//Explicit is better than implicit.

//bad
bool IsShopOpen(string day)
{
    if (!string.IsNullOrEmpty(day))
    {
        day = day.ToLower();
        if (day == "friday")
        {
            return true;
        }
        else if (day == "saturday")
        {
            return true;
        }
        else if (day == "sunday")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    else
    {
        return false;
    }

}


//good
bool IsShopOpen(string day)
{
    if (string.IsNullOrEmpty(day))
        return false;

    var openingDays = new string[] { "friday", "saturday", "sunday" };

    return openingDays.Any(openDay => openDay == day.ToLower());
}
//-------------------------------

//bad
//شرط if فلت باشد
long Fibonacci(int n)
{
    if (n < 50)
    {
        if (n != 0)
        {
            if (n != 1)
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
            else
            {
                return 1;
            }
        }
        else
        {
            return 0;
        }
    }
    else
    {
        throw new System.Exception("Not supported");
    }
}

//good
public long Fibonacci(int n)
{
    if (n == 0)    
        return 0;

    if (n == 1)
        return 1;

    if (n > 50)
        throw new System.Exception("Not supported");


    return Fibonacci(n - 1) + Fibonacci(n - 2);
}

#endregion


#region Avoid mental mapping نام گذاری صریح باشد بهتر از ضمنی است
//نقشه برداری ذهنی خود را حذف کنید

//bad
var l = new[] { "Austin", "New York", "San Francisco" };

for (var i = 0; i < l.Count(); i++)
{
    var li = l[i];
    DoStuff();
    DoSomeOtherStuff();

    // ...
    // ...
    // ...
    // Wait, what is `li` for again?
    Dispatch(li);
}


//good
var locations = new[] { "Austin", "New York", "San Francisco" };

foreach (var location in locations)
{
    DoStuff();
    DoSomeOtherStuff();

    // ...
    // ...
    // ...
    Dispatch(location);
}

#endregion



#region Avoid magic string
//رشته های جادویی رشته های هستند که در برنامه منطقی را با آن ها 
//بررسی کردیم و از رشته به صورت مستقیم در کد خود استفاده کردیم استفاده از این روش سبب این 
//می شود که در طول برنامه زمانی که نیاز به تغییر آن ها داریم باید تعداد بیشماری از موارد استفاده را
//تغییر دهیم ولی اگز در یک متغییر نوع ثابت ذخیره کرده باشید و از آن استفاده کنید
//فقط با یک تغییر تمامی موارد استفاده شده را اصلاح کرده اید.

//bad
if (userRole == "Admin")
{
    // logic in here
}


//good
const string ADMIN_ROLE = "Admin";
if (userRole == ADMIN_ROLE)
{
    // logic in here
}



#endregion


#region Don't add unneeded context زمینه که نیاز ندارید را اضافه نکنید
//If your class/object name tells you something,
//don't repeat that in your variable name.

//bad
class Car
{
    public string CarColor { get; set; }
    public int CarModel { get; set; }
}


//good
class Car
{
    public string Color { get; set; }
    public int Model { get; set; }
}

#endregion

#region Use meaningful and pronounceable variable names متغییر بامعنی و قابل تلفظ

//bad
var ymdstr = DateTime.Now.ToString("MMM dd,yyyy");

//good
var currentDate = DateTime.Now.ToString("MMM dd,yyyy");

#endregion

#region Use the same vocabulary for the same type of variable

//bad
GetUserInfo();
GetUserData();
GetUserRecord();
GetUserProfile();

//good
GetUser();


#endregion


#region Use searchable names از نام های قابل جستجو استفاده کنید
//We will read more code than we will ever write.
//It's important that the code we do write is readable and
//searchable. By not naming variables that end up being
//meaningful for understanding our program, we hurt our readers.
//Make your names searchable.


//bad
var data = new { Name = "John", Age = 42 };

var stream1 = new MemoryStream();
var ser1 = new DataContractJsonSerializer(typeof(object));
ser1.WriteObject(stream1, data);

stream1.Position = 0;
var sr1 = new StreamReader(stream1);
Console.Write("JSON form of Data object: ");
Console.WriteLine(sr1.ReadToEnd());

//good
var person = new Person
{
    Name = "John",
    Age = 42
};

var stream2 = new MemoryStream();
var ser2 = new DataContractJsonSerializer(typeof(Person));
ser2.WriteObject(stream2, data);

stream2.Position = 0;
var sr2 = new StreamReader(stream2);
Console.Write("JSON form of Data object: ");
Console.WriteLine(sr2.ReadToEnd());


#endregion


#region Use searchable names (part 2)

//bad
var data = new { Name = "John", Age = 42, PersonAccess = 4 };

// What the heck is 4 for?
if (data.PersonAccess == 4)
{
    // do edit ...
}

//good
public enum PersonAccess : int
{
    ACCESS_READ = 1,
    ACCESS_CREATE = 2,
    ACCESS_UPDATE = 4,
    ACCESS_DELETE = 8
}

var person = new Person
{
    Name = "John",
    Age = 42,
    PersonAccess = PersonAccess.ACCESS_CREATE
};

if (person.PersonAccess == PersonAccess.ACCESS_UPDATE)
{
    // do edit ...
}

#endregion


#region Use explanatory variables از متغییر های توضیحی استفاده کنید

//bad
const string Address = "One Infinite Loop, Cupertino 95014";
var cityZipCodeRegex = @"/^[^,\]+[,\\s]+(.+?)\s*(\d{5})?$/";
var matches = Regex.Matches(Address, cityZipCodeRegex);
if (matches[0].Success == true && matches[1].Success == true)
{
    SaveCityZipCode(matches[0].Value, matches[1].Value);
}


//good
const string Address = "One Infinite Loop, Cupertino 95014";
var cityZipCodeWithGroupRegex = @"/^[^,\]+[,\\s]+(?<city>.+?)\s*(?<zipCode>\d{5})?$/";
var matchesWithGroup = Regex.Match(Address, cityZipCodeWithGroupRegex);
var cityGroup = matchesWithGroup.Groups["city"];
var zipCodeGroup = matchesWithGroup.Groups["zipCode"];
if (cityGroup.Success == true && zipCodeGroup.Success == true)
{
    SaveCityZipCode(cityGroup.Value, zipCodeGroup.Value);
}
#endregion



#region Use default arguments instead of short circuiting or conditionals 
//از آرگومان های پیشفرض استفاده کنید به جای شرطی کردن انتخاب یا استفاده از نال

//bad
 void CreateMicrobrewery(string name = null)
{
    var breweryName = !string.IsNullOrEmpty(name) ? name : "Hipster Brew Co.";
    var breweryName3 =  name ?? "Hipster Brew Co.";
    // ...
}


//good
public void CreateMicrobrewery(string breweryName = "Hipster Brew Co.")
{
    // ...
}

#endregion






#endregion


#region Functions

#region Avoid Side Effects
//A function produces a side effect if it does anything other than take a value
// in and return another value or values. A side effect could be writing to
//a file, modifying some global variable, or accidentally wiring all your
// money to a stranger.
//متد ورودی بگیرد و خروجی تحویل دهد 
//روی متغییری که دسترسی گلوبال دارد کاری انجام ندهد

//Now, you do need to have side effects
//in a program on occasion. Like the previous example,
//you might need to write to a file. What you want to do is
//to centralize where you are doing this. Don't have several
//functions and classes that write to a particular file.
//Have one service that does it. One and only one.
//کار ها را متمکرز در یک متد یا سرویس انجام دهید

//The main point is to avoid common pitfalls like 
//sharing state between objects without any structure,
//using mutable data types that can be written to by anything,
//and not centralizing where your side effects occur. 
//If you can do this, you will be happier than the vast majority of other programmers.

//Bad
// Global variable referenced by following function.
// If we had another function that used this name, now it'd be an array and it could break it.
var name = "Ryan McDermott";

public void SplitAndEnrichFullName()
{
    var temp = name.Split(" ");
    name = $"His first name is {temp[0]}, and his last name is {temp[1]}"; // side effect
}

SplitAndEnrichFullName();

Console.WriteLine(name); // His first name is Ryan, and his last name is McDermott

//Good--------------------------------------------------------------
public string SplitAndEnrichFullName(string name)
{
    var temp = name.Split(" ");
    return $"His first name is {temp[0]}, and his last name is {temp[1]}";
}

var name = "Ryan McDermott";
var fullName = SplitAndEnrichFullName(name);

Console.WriteLine(name); // Ryan McDermott
Console.WriteLine(fullName); // His first name is Ryan, and his last name is McDermott



#endregion


#region Avoid negative conditionals از شرط منفی استفاده نکیند

//bad
public bool IsDOMNodeNotPresent(string node)
{
    // ...
}

if (!IsDOMNodeNotPresent(node))
{
    // ...
}


//good
public bool IsDOMNodePresent(string node)
{
    // ...
}

if (IsDOMNodePresent(node))
{
    // ...
}

#endregion

#region Avoid conditionals از شرط ها دوری کنید
//This seems like an impossible task. Upon first hearing this,
//most people say, "how am I supposed to do anything without an 
//if statement?" The answer is that you can use polymorphism to
//achieve the same task in many cases. The second question is usually,
//"well that's great but why would I want to do that?" The answer is a
//previous clean code concept we learned: a function should only do one
//thing. When you have classes and functions that have if statements,
//you are telling your user that your function does more than one thing.
//Remember, just do one thing.


//bad
class Airplane
{
    // ...

    public double GetCruisingAltitude()
    {
        switch (_type)
        {
            case '777':
                return GetMaxAltitude() - GetPassengerCount();
            case 'Air Force One':
                return GetMaxAltitude();
            case 'Cessna':
                return GetMaxAltitude() - GetFuelExpenditure();
        }
    }
}

//good
interface IAirplane
{
    // ...

    double GetCruisingAltitude();
}

class Boeing777 : IAirplane
{
    // ...

    public double GetCruisingAltitude()
    {
        return GetMaxAltitude() - GetPassengerCount();
    }
}

class AirForceOne : IAirplane
{
    // ...

    public double GetCruisingAltitude()
    {
        return GetMaxAltitude();
    }
}

class Cessna : IAirplane
{
    // ...

    public double GetCruisingAltitude()
    {
        return GetMaxAltitude() - GetFuelExpenditure();
    }
}

#endregion


#region Avoid type-checking (part 1) از بررسی نوع typeCheking پرهیز کنید

//bad
public Path TravelToTexas(object vehicle)
{
    if (vehicle.GetType() == typeof(Bicycle))
    {
        (vehicle as Bicycle).PeddleTo(new Location("texas"));
    }
    else if (vehicle.GetType() == typeof(Car))
    {
        (vehicle as Car).DriveTo(new Location("texas"));
    }
}

//good
public Path TravelToTexas(Traveler vehicle)
{
    vehicle.TravelTo(new Location("texas"));
}
//or
// pattern matching
public Path TravelToTexas(object vehicle)
{
    if (vehicle is Bicycle bicycle)
    {
        bicycle.PeddleTo(new Location("texas"));
    }
    else if (vehicle is Car car)
    {
        car.DriveTo(new Location("texas"));
    }
}

#endregion

#region Avoid type-checking (part 2) 

//bad
public int Combine(dynamic val1, dynamic val2)
{
    int value;
    if (!int.TryParse(val1, out value) || !int.TryParse(val2, out value))
    {
        throw new Exception('Must be of type Number');
    }

    return val1 + val2;
}


//good
public int Combine(int val1, int val2)
{
    return val1 + val2;
}

#region Avoid flags in method parameters از بولین در پارامتر متد استفاده نکیند
//چون معنی انجام بیش از یک کار را می دهد

//bad
public void CreateFile(string name, bool temp = false)
{
    if (temp)
    {
        Touch("./temp/" + name);
    }
    else
    {
        Touch(name);
    }
}
//good
public void CreateFile(string name)
{
    Touch(name);
}

public void CreateTempFile(string name)
{
    Touch("./temp/" + name);
}

#endregion 

#region Don't write to global functions
//Polluting globals is a bad practice in many languages
//because you could clash with another library and
//the user of your API would be none-the-wiser until
//they get an exception in production.
//Let's think about an example: what if you wanted to
//have configuration array. You could write global function 
//like Config(), but it could clash with another library that
//tried to do the same thing.


//bad
public Dictionary<string, string> Config()
{
    return new Dictionary<string, string>()
    {
        ["foo"] = "bar"
    };
}


//good
class Configuration
{
    private Dictionary<string, string> _configuration;

    public Configuration(Dictionary<string, string> configuration)
    {
        _configuration = configuration;
    }

    public string[] Get(string key)
    {
        return _configuration.ContainsKey(key) ? _configuration[key] : null;
    }
}

var configuration = new Configuration(new Dictionary<string, string>()
{
    ["foo"] = "bar"
});
#endregion




#region Don't use a Singleton pattern
//Singleton is an anti - pattern.Paraphrased from Brian Button:
//They are generally used as a global instance, why is that so bad?
//Because you hide the dependencies of your application in your code, 
//instead of exposing them through the interfaces. Making something global 
//to avoid passing it around is a code smell.
//They violate the single responsibility principle: by virtue of the fact that
//they control their own creation and lifecycle.
//They inherently cause code to be tightly coupled. This makes faking them out
//under test rather difficult in many cases.
//They carry state around for the lifetime of the application. Another hit to 
//testing since you can end up with a situation where tests need to be ordered 
//which is a big no for unit tests. Why? Because each unit test should be independent from the other.
//There is also very good thoughts by Misko Hevery about the root of problem.


//bad
class DBConnection
{
    private static DBConnection _instance;

    private DBConnection()
    {
        // ...
    }

    public static GetInstance()
    {
        if (_instance == null)
        {
            _instance = new DBConnection();
        }

        return _instance;
    }

    // ...
}

var singleton = DBConnection.GetInstance();

//good
class DBConnection
{
    public DBConnection(IOptions<DbConnectionOption> options)
    {
        // ...
    }

    // ...
}
var options = < resolve from IOC>;
var connection = new DBConnection(options);
#endregion


#region Function arguments (2 or fewer ideally) پارامتر های  تابع هرچی کمتر بهتر
//Limiting the amount of function parameters is 
//incredibly important because it makes testing
//your function easier. Having more than three leads
//to a combinatorial explosion where you have to test
//tons of different cases with each separate argument.
//Zero arguments is the ideal case. One or two arguments is
//ok, and three should be avoided. Anything more than that
//should be consolidated. Usually, if you have more than
//two arguments then your function is trying to do too much. 
//In cases where it's not, most of the time a higher-level
//object will suffice as an argument.

//bad
public void CreateMenu(string title, string body, string buttonText, bool cancellable)
{
    // ...
}


//goog
public class MenuConfig
{
    public string Title { get; set; }
    public string Body { get; set; }
    public string ButtonText { get; set; }
    public bool Cancellable { get; set; }
}

var config = new MenuConfig
{
    Title = "Foo",
    Body = "Bar",
    ButtonText = "Baz",
    Cancellable = true
};

public void CreateMenu(MenuConfig config)
{
    // ...
}


#endregion


#region Functions should do one thing توابع تک مسئولیتی باشند
//This is by far the most important rule in software engineering. 
//When functions do more than one thing, they are harder to compose,
//test, and reason about. When you can isolate a function to just one
//action, they can be refactored easily and your code will read much cleaner.
//If you take nothing else away from this guide other than this, 
//you'll be ahead of many developers.

//bad
public void SendEmailToListOfClients(string[] clients)
{
    foreach (var client in clients)
    {
        var clientRecord = db.Find(client);
        if (clientRecord.IsActive())
        {
            Email(client);
        }
    }
}

//good
public void SendEmailToListOfClients(string[] clients)
{
    var activeClients = GetActiveClients(clients);
    // Do some logic
}

public List<Client> GetActiveClients(string[] clients)
{
    return db.Find(clients).Where(s => s.Status == "Active");
}

#endregion

#region Function names should say what they do نام تابع توصیف کننده کارش باشد

//bad
public class Email
{
    //...

    public void Handle()
    {
        SendMail(this._to, this._subject, this._body);
    }
}

var message = new Email(...);
// What is this? A handle for the message? Are we writing to a file now?
message.Handle();

//good
public class Email
{
    //...

    public void Send()
    {
        SendMail(this._to, this._subject, this._body);
    }
}

var message = new Email(...);
// Clear and obvious
message.Send();
#endregion


#region Functions should only be one level of abstraction
//توابع باشد در سطح انتزاع یکسانی باشند در غیر این صورت آن ها 
//را در سطوح انتزاع مختلفی نوشته و با استفاده از تزریق وابستگی 
//از آن ها استفاده کنید

//When you have more than one level of abstraction your function 
//is usually doing too much. Splitting up functions leads
//to reusability and easier testing.

//Bad
public string ParseBetterJSAlternative(string code)
{
var regexes = [
// ...
];

var statements = explode(" ", code);
var tokens = new string[] { };
foreach (var regex in regexes)
{
foreach (var statement in statements)
{
// ...
}
}

var ast = new string[] { };
foreach (var token in tokens)
{
// lex...
}

foreach (var node in ast)
{
// parse...
}
}


//Bad too
//We have carried out some of the functionality,
//but the ParseBetterJSAlternative() function 
//is still very complex and not testable.

public string Tokenize(string code)
{
var regexes = new string[]
{
        // ...
    };

var statements = explode(" ", code);
var tokens = new string[] { };
foreach (var regex in regexes)
{
foreach (var statement in statements)
{
tokens[] = /* ... */;
}
}

return tokens;
}

public string Lexer(string[] tokens)
{
var ast = new string[] { };
foreach (var token in tokens)
{
ast[] = /* ... */;
}

return ast;
}

public string ParseBetterJSAlternative(string code)
{
var tokens = Tokenize(code);
var ast = Lexer(tokens);
foreach (var node in ast)
{
// parse...
}
}

//Good:
//The best solution is move out 
//the dependencies of 
//ParseBetterJSAlternative() function.

class Tokenizer
{
    public string Tokenize(string code)
    {
        var regexes = new string[] {
            // ...
        };

        var statements = explode(" ", code);
        var tokens = new string[] { };
        foreach (var regex in regexes)
        {
            foreach (var statement in statements)
            {
                tokens[] = /* ... */;
            }
        }

        return tokens;
    }
}

class Lexer
{
    public string Lexify(string[] tokens)
    {
        var ast = new[] { };
        foreach (var token in tokens)
        {
            ast[] = /* ... */;
        }

        return ast;
    }
}

class BetterJSAlternative
{
    private string _tokenizer;
    private string _lexer;

    public BetterJSAlternative(Tokenizer tokenizer, Lexer lexer)
    {
        _tokenizer = tokenizer;
        _lexer = lexer;
    }

    public string Parse(string code)
    {
        var tokens = _tokenizer.Tokenize(code);
        var ast = _lexer.Lexify(tokens);
        foreach (var node in ast)
        {
            // parse...
        }
    }
}

#endregion


#region Function callers and callees should be close
//If a function calls another, keep those
//functions vertically close in the source 
//file. Ideally, keep the caller right above
//the callee. We tend to read code from top-to-bottom,
//like a newspaper. Because of this, make your code read that way.

//bad
class PerformanceReview
{
    private readonly Employee _employee;

    public PerformanceReview(Employee employee)
    {
        _employee = employee;
    }

    private IEnumerable<PeersData> LookupPeers()
    {
        return db.lookup(_employee, 'peers');
    }

    private ManagerData LookupManager()
    {
        return db.lookup(_employee, 'manager');
    }

    private IEnumerable<PeerReviews> GetPeerReviews()
    {
        var peers = LookupPeers();
        // ...
    }

    public PerfReviewData PerfReview()
    {
        GetPeerReviews();
        GetManagerReview();
        GetSelfReview();
    }

    public ManagerData GetManagerReview()
    {
        var manager = LookupManager();
    }

    public EmployeeData GetSelfReview()
    {
        // ...
    }
}

var review = new PerformanceReview(employee);
review.PerfReview();

//good
class PerformanceReview
{
    private readonly Employee _employee;

    public PerformanceReview(Employee employee)
    {
        _employee = employee;
    }

    public PerfReviewData PerfReview()
    {
        GetPeerReviews();
        GetManagerReview();
        GetSelfReview();
    }

    private IEnumerable<PeerReviews> GetPeerReviews()
    {
        var peers = LookupPeers();
        // ...
    }

    private IEnumerable<PeersData> LookupPeers()
    {
        return db.lookup(_employee, 'peers');
    }

    private ManagerData GetManagerReview()
    {
        var manager = LookupManager();
        return manager;
    }

    private ManagerData LookupManager()
    {
        return db.lookup(_employee, 'manager');
    }

    private EmployeeData GetSelfReview()
    {
        // ...
    }
}

var review = new PerformanceReview(employee);
review.PerfReview();



#endregion


#region Encapsulate conditionals شرط ها را کپسوله کنید
//سعی کنید جزئیات را در شرط های منطقی مخفی کنید

//bad
if (article.state == "published")
{
    // ...
}

//good
if (article.IsPublished())
{
    // ...
}

#endregion


#region Remove dead code کد تکراری را به متد تبدیل کرده
//Dead code is just as bad as duplicate code. 
//There's no reason to keep it in your codebase.
//If it's not being called, get rid of it! It will 
//still be safe in your version history if you still need it.

//bad
public void OldRequestModule(string url)
{
    // ...
}

public void NewRequestModule(string url)
{
    // ...
}

var request = NewRequestModule(requestUrl);
InventoryTracker("apples", request, "www.inventory-awesome.io");


//good
public void RequestModule(string url)
{
    // ...
}

var request = RequestModule(requestUrl);
InventoryTracker("apples", request, "www.inventory-awesome.io");

#endregion




#endregion



























#endregion


#region Objects and Data Structures

#region Use getters and setters
//In C# / VB.NET you can set public, 
//protected and private keywords for
//methods. Using it, you can control
//properties modification on an object.
//When you want to do more beyond getting an 
//object property, you don't have to look up and change every accessor in your codebase.
//Makes adding validation simple when doing a set.
//Encapsulates the internal representation.
//Easy to add logging and error handling when getting and setting.
//Inheriting this class, you can override default functionality.
//You can lazy load your object's properties, let's say getting it from a server.
//Additionally, this is part of Open/Closed principle, from object-oriented design principles.


//bad
class BankAccount
{
    public double Balance = 1000;
}

var bankAccount = new BankAccount();

// Fake buy shoes...
bankAccount.Balance -= 100;

//good
class BankAccount
{
    private double _balance = 0.0D;

    pubic double Balance
    {
        get
        {
            return _balance;
        }
    }

    public BankAccount(balance = 1000)
    {
        _balance = balance;
    }

    public void WithdrawBalance(int amount)
    {
        if (amount > _balance)
        {
            throw new Exception('Amount greater than available balance.');
        }

        _balance -= amount;
    }

    public void DepositBalance(int amount)
    {
        _balance += amount;
    }
}

var bankAccount = new BankAccount();

// Buy shoes...
bankAccount.WithdrawBalance(price);

// Get balance
balance = bankAccount.Balance;
#endregion


#region Make objects have private/protected members
//bad
class Employee
{
    public string Name { get; set; }

    public Employee(string name)
    {
        Name = name;
    }
}

var employee = new Employee("John Doe");
Console.WriteLine(employee.Name); // Employee name: John Doe


//good
class Employee
{
    public string Name { get; }

    public Employee(string name)
    {
        Name = name;
    }
}

var employee = new Employee("John Doe");
Console.WriteLine(employee.Name); // Employee name: John Doe
#endregion
#endregion


#region Classes

#region Use method chaining از متد های زنجیره ی استفاده کنید
//good
public static class ListExtensions
{
    public static List<T> FluentAdd<T>(this List<T> list, T item)
    {
        list.Add(item);
        return list;
    }

    public static List<T> FluentClear<T>(this List<T> list)
    {
        list.Clear();
        return list;
    }

    public static List<T> FluentForEach<T>(this List<T> list, Action<T> action)
    {
        list.ForEach(action);
        return list;
    }

    public static List<T> FluentInsert<T>(this List<T> list, int index, T item)
    {
        list.Insert(index, item);
        return list;
    }

    public static List<T> FluentRemoveAt<T>(this List<T> list, int index)
    {
        list.RemoveAt(index);
        return list;
    }

    public static List<T> FluentReverse<T>(this List<T> list)
    {
        list.Reverse();
        return list;
    }
}

internal static void ListFluentExtensions()
{
    var list = new List<int>() { 1, 2, 3, 4, 5 }
        .FluentAdd(1)
        .FluentInsert(0, 0)
        .FluentRemoveAt(1)
        .FluentReverse()
        .FluentForEach(value => value.WriteLine())
        .FluentClear();
}
#endregion

#region Prefer Composition over inhritance در بعضی از مواقع ترکیب را به ارث بری ترجیح دهید
//As stated famously in Design Patterns by the Gang of Four, 
//you should prefer composition over inheritance where you can.
//There are lots of good reasons to use inheritance and lots of good reasons to use composition.

//The main point for this maxim is that if your mind instinctively
//goes for inheritance, try to think if composition could model 
//your problem better. In some cases it can.

//You might be wondering then, "when should I use inheritance?" 
//It depends on your problem at hand, but this is a decent list of when
//inheritance makes more sense than composition:

//Your inheritance represents an "is-a" relationship and not a "has-a" relationship
//(Human->Animal vs. User->UserDetails).
//You can reuse code from the base classes (Humans can move like all animals).
//You want to make global changes to derived classes by changing a base class
//(Change the caloric expenditure of all animals when they move).

//bad
class Employee
{
    private string Name { get; set; }
    private string Email { get; set; }

    public Employee(string name, string email)
    {
        Name = name;
        Email = email;
    }

    // ...
}

// Bad because Employees "have" tax data.
// EmployeeTaxData is not a type of Employee

class EmployeeTaxData : Employee
{
    private string Name { get; }
    private string Email { get; }

    public EmployeeTaxData(string name, string email, string ssn, string salary)
    {
        // ...
    }

    // ...
}


//good
class EmployeeTaxData
{
    public string Ssn { get; }
    public string Salary { get; }

    public EmployeeTaxData(string ssn, string salary)
    {
        Ssn = ssn;
        Salary = salary;
    }

    // ...
}

class Employee
{
    public string Name { get; }
    public string Email { get; }
    public EmployeeTaxData TaxData { get; }

    public Employee(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public void SetTax(string ssn, double salary)
    {
        TaxData = new EmployeeTaxData(ssn, salary);
    }

    // ...
}
#endregion


#endregion


#region Solid

#region Single Responsibility Priciple
//As stated in Clean Code, "There should never be
//more than one reason for a class to change".
//It's tempting to jam-pack a class with a lot
//of functionality, like when you can only take
//one suitcase on your flight. The issue with 
//this is that your class won't be conceptually 
//cohesive and it will give it many reasons to change.
//Minimizing the amount of times you need to change a
//class is important.

//It's important because if too much functionality is in 
//one class and you modify a piece of it, it can be 
//difficult to understand how that will affect other
//dependent modules in your codebase.
#endregion

#region Open/Closed Principle (OCP)
//As stated by Bertrand Meyer, 
//"software entities (classes, modules, functions, etc.)
//should be open for extension, but closed for modification.
//" What does that mean though? This principle basically states 
//that you should allow users to add new functionalities
//without changing existing code.
#endregion

#region Liskov Substitution Principle (LSP)
//This is a scary term for a very simple concept.
//It's formally defined as "If S is a subtype 
//of T, then objects of type T may be replaced
//with objects of type S (i.e., objects of type S may 
//substitute objects of type T) without altering any
//of the desirable properties of that program 
//(correctness, task performed, etc.)." That's an even scarier definition.

//The best explanation for this is if you have a parent
//class and a child class, then the base class and 
//child class can be used interchangeably without 
//getting incorrect results. This might still be
//confusing, so let's take a look at the classic 
//Square-Rectangle example. Mathematically, a square 
//is a rectangle, but if you model it using the "is-a"
//relationship via inheritance, you quickly get into trouble.
#endregion

#region Interface Segregation Principle (ISP) جداسازی رابط
//کلاس های که واسط را پیاده سازی می کنند
//باید به تمامی متد های واسط مرتبط باشند و اگر متدی غیر مرتبط داشته باشیم
//باید از رابط خارج کرده و به رابط دیگری اضافه شود
//ISP states that "Clients should not be
//forced to depend upon interfaces that they do not use."
//A good example to look at that demonstrates
//this principle is for classes that require
//large settings objects. Not requiring clients to 
//setup huge amounts of options is beneficial, 
//because most of the time they won't need all
//of the settings. Making them optional helps prevent having a "fat interface".

#endregion


#region Dependency Inversion Principle (DIP)
//This principle states two essential things:

//High - level modules should not depend on 
//    low-level modules. Both should depend on abstractions.
//Abstractions should not depend upon details.
//    Details should depend on abstractions.
//This can be hard to understand at first, but
//if you've worked with .NET/.NET Core framework,
//you've seen an implementation of this principle 
//in the form of Dependency Injection (DI). While 
//they are not identical concepts, DIP keeps high-level
//modules from knowing the details of its low-level 
//modules and setting them up. It can accomplish this
//through DI. A huge benefit of this is that it reduces
//the coupling between modules. Coupling is a very bad 
//development pattern because it makes your code hard to refactor.
#endregion

#region Dont Repeat Yourself (DRY)
//Do your absolute best to avoid duplicate code. 
//Duplicate code is bad because it means
//that there's more than one place to alter 
//something if you need to change some logic.
#endregion

#endregion


#region Testing

#region Basic Consept Of Testing
//Basic concept of testing
//Testing is more important than shipping. If you have 
//no tests or an inadequate amount, then every time
//you ship code you won't be sure that you didn't break 
//anything. Deciding on what constitutes an adequate amount 
//is up to your team, but having 100% coverage
//(all statements and branches) is how you achieve very 
//high confidence and developer peace of mind. This means
//that in addition to having a great testing framework,
//you also need to use a good coverage tool.

//There's no excuse to not write tests. There's plenty of good .
//NET test frameworks, so find one that your team prefers.
//When you find one that works for your team, then aim to
//always write tests for every new feature/ module you introduce.
//If your preferred method is Test Driven Development (TDD),
//that is great, but the main point is to just make sure you are
//reaching your coverage goals before launching any feature,
//or refactoring an existing one.

#endregion


#region Single Consept Per Test تست ها متمرکز باشند و چیز های غیر مرتبط را تست نکنند.
//Ensures that your tests are laser focused and 
//not testing miscellaenous (non-related) things,
//forces AAA patern used to make your codes more
//clean and readable.
#endregion


#endregion


#region Concurrency 

#region Async/Await Best Practice
//The async/await is the best for IO bound tasks 
//(networking communication, database communication,
//http request, etc.) but it is not good to apply on
//computational bound tasks (traverse on the huge list,
//render a hugge image, etc.). Because it will release
//the holding thread to the thread pool and CPU/cores 
//available will not involve to process those tasks.
//Therefore, we should avoid using Async/ Await for 
//computional bound tasks.

//For dealing with computational bound tasks, prefer to 
//use Task.Factory.CreateNew with TaskCreationOptions is 
//LongRunning.It will start a new background thread to process
//a heavy computational bound task without release it back to
//the thread pool until the task being completed.

//کد نویسی اسینک مناسب کار های ای او باند مانند ارتباط با شبکه یا پایگاه داده 
//و غیره است از استفاده آن ها در کارهای محاسباتی پرهیز کنید مانند پیمایش لیست بزرگ رندر کردن تصویری بزرگ و غیره
//برای انجام کار های محاسباتی بهتر است از 
//task.Factory.CreateNew , TaskCreationOption LongRunning
//استفاده کنید که یک نخ از نوع 
//backGround
//ایجاد می کند که یک ترد از نوع بک گراند ساخته و آن را در ترد پول رها نمی کند تا زمانی که کار اتمام برسد
//


//best practice

//Avoid async void	  Prefer async Task methods over async void methods	     Event handlers
//Async all the way	  Don't mix blocking and async code	                     Console main method (C# <= 7.0)
//Configure context	  Use ConfigureAwait(false) when you can	             Methods that require con­text


//Retrieve the result of a background task	Task.Wait or Task.Result	await
//Wait for any task to complete	            Task.WaitAny	            await Task.WhenAny
//Retrieve the results of multiple tasks	Task.WaitAll    	        await Task.WhenAll
//Wait a period of time	                    Thread.Sleep	            await Task.Delay

//Create a task to execute code	                        Task.Run or TaskFactory.StartNew (not the Task constructor or Task.Start)
//Create a task wrapper for an operation or event	    TaskFactory.FromAsync or TaskCompletionSource<T>
//Support cancellation	                                CancellationTokenSource and CancellationToken
//Report progress	                                    IProgress<T> and Progress<T>
//Handle streams of data	                            TPL Dataflow or Reactive Extensions
//Synchronize access to a shared resource	            SemaphoreSlim
//Asynchronously initialize a resource	                AsyncLazy<T>
//Async-ready producer/consumer structures	            TPL Dataflow or AsyncCollection<T>

//task.Wait         await task	                        Wait/await for a task to complete
//task.Result	    await task	                        Get the result of a completed task
//Task.WaitAny	    await Task.WhenAny	                Wait/await for one of a collection of tasks to complete
//Task.WaitAll	    await Task.WhenAll	                Wait/await for every one of a collection of tasks to complete
//Thread.Sleep	    await Task.Delay	                Wait/await for a period of time
//Task constructor	Task.Run or TaskFactory.StartNew	Create a code-based task


#endregion



#endregion


#region Error Handling

#region Don't use 'throw ex' in catch block

//bad
try
{
    // Do something..
}
catch (Exception ex)
{
    // Any action something like roll-back or logging etc.
    throw ex;
}

//good
try
{
    // Do something..
}
catch (Exception ex)
{
    // Any action something like roll-back or logging etc.
    throw;
}


#endregion

#region Don't ignore caught errors خطا ها را نادیده نگیرید

//bad
try
{
    FunctionThatMightThrow();
}
catch (Exception ex)
{
    // silent exception
}

//good
try
{
    FunctionThatMightThrow();
}
catch (Exception error)
{
    NotifyUserOfError(error);

    // Another option
    ReportErrorToService(error);
}

#endregion

#region Use multiple catch block instead of if conditions.
//bad
try
{
    // Do something..
}
catch (Exception ex)
{

    if (ex is TaskCanceledException)
    {
        // Take action for TaskCanceledException
    }
    else if (ex is TaskSchedulerException)
    {
        // Take action for TaskSchedulerException
    }
}

//good
try
{
    // Do something..
}
catch (TaskCanceledException ex)
{
    // Take action for TaskCanceledException
}
catch (TaskSchedulerException ex)
{
    // Take action for TaskSchedulerException
}
#endregion


#region Keep exception stack trace when rethrowing exceptions
//bad
try
{
    FunctionThatMightThrow();
}
catch (Exception ex)
{
    logger.LogInfo(ex);
    throw ex;
}


//good
try
{
    FunctionThatMightThrow();
}
catch (Exception error)
{
    logger.LogInfo(error);
    throw;

    //-----------
    logger.LogInfo(error);
    throw new CustomException(error);
}
#endregion

#endregion


#region Comments
//Comment Only For Complex Logic Not All
//Part Of Code
#endregion






















