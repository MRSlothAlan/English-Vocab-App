# Read me for the English vocabulary learning system
This is another fun side-project fyr. I am going to take the IELTS exam soon and I need a tool to learn new vocabularies quickly. I decided to build it myself.

![Alt text](demoUpdated.png?raw=true "Current layout")

The list of removed directories / files:

* App.config

The format of the App.config is:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <configSections>
    </configSections>
  <appSettings>
    <add key ="dbConnStr" value="{DATABASE CONNECTION STRING HERE}"/>
    <add key ="defaulDictionaryPath" value="{PATH TO THE RAW TEXT FILE OF ENGLISH WORDS HERE}"/>
    <add key="undo_steps" value="10"/>
  </appSettings>
    <connectionStrings>
        ...
    </connectionStrings>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.1" />
    </startup>
</configuration>
```
# Implemented functions:
### Instant Spelling check & recommendation
A customized tree data structure is implemented to search for words in O(N^2(log(N))) time complexity.

### Basic operations for the word database
Insert, update, delete vocabularies, along with their meanings.

#To-do:
* Implement a quiz function.

