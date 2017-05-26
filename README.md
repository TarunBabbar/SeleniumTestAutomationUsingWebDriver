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

See how easy it is !! Please have a look at the entire source code at my
[github](https://github.com/TarunBabbar/SeleniumTestAutomationUsingWebDriver)
link.

* [Selenium](https://medium.com/tag/selenium?source=post)
* [Csharp](https://medium.com/tag/csharp?source=post)
* [Visual Studio](https://medium.com/tag/visual-studio?source=post)

### [Tarun Babbar](https://medium.com/@IamTarunBabbar)


# Selenium Web Driver UI Automation on Multiple Browsers

I hope you have gone through my first story on Selenium Driver published
[here,](https://medium.com/@IamTarunBabbar/test-automation-using-c-selenium-web-driver-c195c3d4c273)
where I talked about how to create your first ui automation test case using
selenium driver and C#. Here, I am going little further to talk about how to do
testing across multiple browsers. If you haven’t yet visited, please do visit
[this](https://medium.com/@IamTarunBabbar/test-automation-using-c-selenium-web-driver-c195c3d4c273)
link to get initial idea on Selenium Web Driver.

An application is always opened on different browsers — Chrome, IE, Firefox,
Safari, etc. Selenium web driver is supported for all these browsers. To verify
behavior across browsers, Selenium has provided an easy mechanism to instantiate
any of Chrome/FF/IE browsers. You can use the below piece of code which would
help you achieve the same. Comparing with code I shown in my previous article,
here I created a separate class named WebDriver, where I am initializing
instance for webdriver, as per the instance required.

![](https://cdn-images-1.medium.com/max/800/1*6Lx4Z3eS7_8w5NCawqk28w.png)
<span class="figcaption_hack">Initiate one instance of webdriver pointing to corresponding Browser.</span>

I have an enum where I am storing all the browser types as below:

![](https://cdn-images-1.medium.com/max/800/1*KWU3KiD8EwbZeaxSNpvH_g.png)

![](https://cdn-images-1.medium.com/max/800/1*BiQsgHJ598F7ax6oqSxUWQ.png)
<span class="figcaption_hack">Launching browsers for each Browsers enum</span>

I’m really loving it guys, so easy with Selenium driver !!

Source code is placed
[here](https://github.com/TarunBabbar/SeleniumTestAutomationUsingWebDriver).

### [Tarun Babbar](https://medium.com/@IamTarunBabbar)
