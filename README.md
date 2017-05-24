# Test Automation using C# Selenium Web Driver

There are multiple technologies available to develop web applications, like,
php, java, ASP.Net, Angular JS, MVC, React. There are numerous tools available
to do UI automation testing like QTP, Soap UI, etc. Here I am going to talk
about Selenium Web Driver with C# which will ease your UI automation in any of
the above languages.

To start with web application automation using Selenium Web Driver, you need to
perform below steps:

Create a New Test Automation Project in Visual Studio and add Selenium nugget
packages. Below are some screenshots:

1.  Create a new test project:

![](https://cdn-images-1.medium.com/max/800/1*re8ZyKWVJ5LBUSsYCwntpQ.png)

2. Add nuget package : Right click on solution and click manage Nuget packages

3. Browse for Selenium nugets and install to the solution.

4. Verify nuget packages are installed and you can see the same in References
section.

5. If you go to location — MyFirstSeleniumWebApplication\packages, you will see
all the packages installed there.

You are not ready to write your first ever UI Automation test case in C#. Lets
take a scenario to do UI automation for google search. It will follow the below
steps:

a. Navigate to Google URL.

b. Identity Google Search text box and provide some inputs.

c. Click on Search button.

Below piece of code help you achieve this:

<span class="figcaption_hack">Code to launch IE and do google search using Selenium Web Driver.</span>

See how easy it is !!

* [Selenium](https://medium.com/tag/selenium?source=post)
* [Csharp](https://medium.com/tag/csharp?source=post)
* [Visual Studio](https://medium.com/tag/visual-studio?source=post)

### [Tarun Babbar](https://medium.com/@IamTarunBabbar)

